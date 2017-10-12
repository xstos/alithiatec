using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataTable = System.Data.DataTable;

namespace ListMerge
{
    public class JsonArgs
    {
        public string Destination;
        public string Master;
        public string PrimaryKey;
        public List<string> Inputs;

        public static JsonArgs Default()
        {
            return new JsonArgs()
            {
                Destination = "finalMerged.xlsx",
                Master = "URLMasterList.xlsx",
                Inputs = new List<string>() {"inputs\\alexa.xlsx", "inputs\\social.xlsx", "inputs\\whois.xlsx"},
                PrimaryKey = "Url"
            };
        }

    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application excel = new Application();
            try
            {
                var args = LoadArgs();
                var primaryKey = args.PrimaryKey;
                var inputs = args.Inputs;


                excel.DisplayAlerts = false;
                Workbook masterUrlList = excel.Workbooks.Open(args.Master);
                var masterUrlTable = masterUrlList.ToTable(primaryKey);
                var set = masterUrlTable.GetColumn<string>(primaryKey).ToSet();

                var tables = inputs.ReadInputFilesToTables(excel, primaryKey);
                var merged = tables.MergeInputs();

                // delete rows containing whois email from blacklist
                var WhoisEmailBlacklist = new List<string>() { "@web.com", "@uniregistry.com" };
                var registrantEmailKey = "Registrant email";

                merged.DeleteRows(row =>
                {
                    var url = row[primaryKey];
                    var registrantEmail = (row[registrantEmailKey] ?? "").ToString();
                    return set.Contains(url) || WhoisEmailBlacklist.Any(registrantEmail.Contains);
                });
                
                merged.AcceptChanges();
                var newUrls = merged.GetColumn<string>(primaryKey).ToSet();

                merged.Save(excel, args.Destination).Close();

                foreach (var newUrl in newUrls)
                {
                    var dr = masterUrlTable.NewRow();
                    dr[primaryKey] = newUrl;
                    masterUrlTable.Rows.Add(dr);
                }
                masterUrlTable.AcceptChanges();

                masterUrlTable.WriteTo(masterUrlList.Sheets().First());

                masterUrlList.Save();
                masterUrlList.Close();
            }
            finally
            {
                excel.Quit();
            }
        }

        public static IEnumerable<Worksheet> Sheets(this Workbook workbook)
        {
            return workbook.Sheets.Cast<Worksheet>();
        } 
        public static HashSet<T> ToSet<T>(this IEnumerable<T> items)
        {
            return new HashSet<T>(items);
        } 
        public static void WriteTo(this DataTable tbl, Worksheet dest)
        {
            dest.UsedRange.Clear();
            var arr = tbl.ToArray();
            dest.Range["A1"].Resize[arr.GetLength(0), arr.GetLength(1)].Value = arr;
        }
        public static Workbook Save(this DataTable dt,Application excel, string outputPath)
        {
            File.Delete(outputPath);
            var wb = excel.Workbooks.Add();
            dt.WriteTo(wb.Sheets().First());
            wb.SaveAs(outputPath);
            return wb;
        }

        public static void DeleteRows(this DataTable dt, Func<DataRow, bool> predicate)
        {
            foreach (var row in dt.Rows.Cast<DataRow>().Where(predicate).ToList()) row.Delete();
        }

        public static DataTable ArrayToDataTable(this object[,] data, string tableName, string primaryKey)
        {
            var dt = new DataTable(tableName);
            var cols = new Dictionary<int, string>();
            for (int col = data.GetLowerBound(1); col <= data.GetUpperBound(1); col++)
            {
                var columnName = data[data.GetLowerBound(0), col] + "";
                dt.Columns.Add(columnName, typeof(string));
                cols[col] = columnName;
            }
            dt.PrimaryKey = new[] { dt.Columns[primaryKey] };
            for (int row = data.GetLowerBound(0) + 1; row <= data.GetUpperBound(0); row++)
            {
                var dr = dt.NewRow();
                for (int col = data.GetLowerBound(1); col <= data.GetUpperBound(1); col++)
                {
                    dr[cols[col]] = data[row, col];
                }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }

        public static object[,] ToArray(this Range range)
        {
            var data = range.Value;
            if (data is object[,]) return data;
            return new object[,] { { "Url"} };
        }
        public static object[,] ToArray(this DataTable table)
        {
            object[,] ret = new object[table.Rows.Count + 1, table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                ret[0, i] = table.Columns[i].ColumnName;
            }
            for (int row = 1; row < table.Rows.Count + 1; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    ret[row, col] = table.Rows[row - 1][col];
                }
            }
            return ret;
        }

        public static DataTable MergeInputs(this List<DataTable> tables)
        {
            return tables.Aggregate((a, b) =>
            {
                var ret = a.Copy();
                ret.Merge(b);
                return ret;
            });
        }

        public static List<DataTable> ReadInputFilesToTables(this List<string> inputs, Application xl, string primaryKey)
        {
            var tables = new List<DataTable>();

            foreach (var input in inputs)
            {
                var wb = xl.Workbooks.Open(input);
                var dt = wb.ToTable(primaryKey);
                tables.Add(dt);
                wb.Close();
            }
            return tables;
        }

        public static IEnumerable<T> GetColumn<T>(this DataTable dt, string columnName)
        {
            return dt.AsEnumerable().Select(r => r.Field<T>(columnName)).ToList();
        }

        public static DataTable ToTable(this Workbook wb, string primaryKey)
        {
            var names = wb.Names().Select(n => n.Name);
            var srcRange = wb.Sheets().First().UsedRange;
            object[,] data = srcRange.ToArray(); //get named range MergeArea's values as 2D array
            var dt = data.ArrayToDataTable(wb.Name, primaryKey); //convert to datatable
            return dt;
        }

        public static IEnumerable<Name> Names(this Workbook workbook)
        {
            return workbook.Names.Cast<Name>();
        }
        public static string ToFullPath(this string fileName)
        {
            return Path.GetFullPath(fileName);
        }

        static JsonArgs LoadArgs()
        {
            if (!File.Exists("config.json"))
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(JsonArgs.Default()));
            }
            JsonArgs args;

            if (File.Exists("config.json"))
            {
                var json = File.ReadAllText("config.json");
                args = JsonConvert.DeserializeObject<JsonArgs>(json);
            }
            else
            {
                args = JsonArgs.Default();
            }
            args.Destination = args.Destination.ToFullPath();
            args.Inputs = args.Inputs.Select(ToFullPath).ToList();
            args.Master = args.Master.ToFullPath();
            return args;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using DataTable = System.Data.DataTable;

namespace ListMerge
{
    public class JsonArgs
    {
        public string Destination;
        public string PrimaryKey;
        public List<string> Inputs;

        public static JsonArgs Default()
        {
            return new JsonArgs()
            {
                Destination = "finalMerged.xlsx",
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
            var primaryKey = args.PrimaryKey;
            args.Destination = resolve(args.Destination);
            args.Inputs = args.Inputs.Select(resolve).ToList();
            var app = new Microsoft.Office.Interop.Excel.Application();
            
            if (!File.Exists(args.Destination))
            {
                Console.WriteLine(args.Destination+ " not found");
                return;
            }
            Workbook dest = app.Workbooks.Open(args.Destination);
            var firstSheet = dest.Sheets.Cast<Worksheet>().First();
            var urData = firstSheet.UsedRange.Value;
            if (!(urData is object[,]))
            {
                urData = new object[,] {{"Url"}};
            }
            object[,] destData = urData;
            var destDt = ArrayToDataTable(destData, dest.Name, primaryKey);
            
            var tables = new List<DataTable>();
            tables.Add(destDt);
            foreach (var input in args.Inputs)
            {
                var wb = app.Workbooks.Open(input);
                var dt = ReadWb(wb, primaryKey);
                tables.Add(dt);
                wb.Close();
            }
            var merged = tables.Aggregate((a, b) =>
            {
                var ret = a.Copy();
                ret.Merge(b);
                return ret;
            });

            firstSheet.UsedRange.Clear();
            var tbl = TableToArray(merged);
            firstSheet.Range["A1"].Resize[tbl.GetLength(0),tbl.GetLength(1)].Value = tbl;
            dest.Save();
            dest.Close();
            app.Quit();
        }

        static DataTable ReadWb(Workbook wb, string primaryKey)
        {
            object[,] data = wb.Names.Item("MergeArea").RefersToRange.Value; //get named range MergeArea's values as 2D array
            var dt = ArrayToDataTable(data, wb.Name, primaryKey); //convert to datatable
            return dt;
        }

        static object[,] TableToArray(DataTable table)
        {
            object[,] ret = new object[table.Rows.Count+1,table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                ret[0, i] = table.Columns[i].ColumnName;
            }
            for (int row = 1; row < table.Rows.Count+1; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    ret[row, col] = table.Rows[row-1][col];
                }
            }
            return ret;
        }
        static DataTable ArrayToDataTable(object[,] data, string tableName, string primaryKey)
        {
            var dt = new DataTable(tableName);
            var cols = new Dictionary<int, string>();
            for (int col = data.GetLowerBound(1); col <= data.GetUpperBound(1); col++)
            {
                var columnName = data[data.GetLowerBound(0), col] + "";
                dt.Columns.Add(columnName, typeof (string));
                cols[col] = columnName;
            }
            dt.PrimaryKey = new[] {dt.Columns[primaryKey]};
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

        static string resolve(string fileName)
        {
            return Path.GetFullPath(fileName);
        }
    }
}

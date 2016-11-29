using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TableDiff
{
    
    public static class DX
    {
        public delegate object TransformFunction(object item);
        public static object[] TransformFunctionMany(this object[] items,TransformFunction filter)
        {
            if (items == null) return null;
            if (filter == null) filter = PassthroughTransform;
            object[] newItems=new object[items.Length];
            for (int i = 0; i < items.Length; i++) newItems[i] = filter(items[i]);
            return newItems;
        }
        public static object PassthroughTransform(object item)
        {
            return item;
        }
        public static void AddRange<T>(this List<T> list,params T[] items)
        {
            list.AddRange(items);
        }
        public static DataTable GenerateDiffReport2(DataTable diff, DataTable first, IEnumerable<string> pkeyColumns,IEnumerable<string> ignoreColumns, TransformFunction filter)
        {
            if (filter == null) filter = PassthroughTransform;
            var allColumnSet = first.GetColumnNames().ToList();

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("OLD(0)/NEW(1)");
            resultTable.Columns.Add("PairNumber");
            resultTable.Columns.Add("PkeyDelta");
            resultTable.Columns.Add("ValueDelta");
            resultTable.Columns.Add("DeltaSummary");
            foreach (var col in allColumnSet) resultTable.Columns.Add(col);
            int columnCount = first.Columns.Count;
            int id = 0;

            for (int i = 0; i < diff.Rows.Count; i++)
            {
                var itemList1 = new List<object>();
                var itemList2 = new List<object>();
                itemList1.Add("0");
                itemList2.Add("1");
                DataRow oldRow = diff.Rows[i]["OldRow"] as DataRow;
                DataRow newRow = diff.Rows[i]["NewRow"] as DataRow;
                bool oldRowIsNull = oldRow == null;
                bool newRowIsNull = newRow == null;
                object[] firstItemArray = oldRowIsNull ? new object[columnCount] : oldRow.ItemArray;
                object[] secondItemArray = newRowIsNull ? new object[columnCount] : newRow.ItemArray;
                if (oldRowIsNull || newRowIsNull)
                {
                    itemList1.Add(""); //no id
                    itemList2.Add(""); //no id
                }
                else
                {
                    itemList1.Add(id);
                    itemList2.Add(id++);
                }

                if (oldRowIsNull) itemList2.AddRange("",""); else itemList2.AddRange(diff.Rows[i]["PkeyDelta"], diff.Rows[i]["ValueDelta"]);
                if (newRowIsNull) itemList1.AddRange("",""); else itemList1.AddRange(diff.Rows[i]["PkeyDelta"], diff.Rows[i]["ValueDelta"]);
                //string a = firstItemArray.SequenceToString(" ");
                //string b = firstItemArray.SequenceToString(" ");
                StringBuilder changeSummary = new StringBuilder();
                changeSummary.Append("\"");
                if (!oldRowIsNull && !newRowIsNull)
                {
                    for (int j = 0; j < firstItemArray.Length; j++)
                    {
                        itemList1.Add(firstItemArray[j]);
                        if (!firstItemArray[j].Equals(secondItemArray[j]))
                        {
                            itemList2.Add(secondItemArray[j]);
                            changeSummary.Append(string.Concat(allColumnSet[j], " {",filter(firstItemArray[j]), "} / {", filter(secondItemArray[j]), "}\n"));
                        }
                        else itemList2.Add("''");
                    }
                }
                else
                {
                    itemList1.AddRange(firstItemArray);
                    itemList2.AddRange(secondItemArray);
                }
                changeSummary.Append("\"");
                //firstItemArray = firstItemArray.FillNull(string.Empty).FillEmpty(" ");
                //secondItemArray = secondItemArray.FillNull(string.Empty).FillEmpty(" ");
                if (!oldRowIsNull)
                {
                    itemList1[3] = changeSummary.ToString();
                    resultTable.Rows.Add(itemList1.ToArray().TransformFunctionMany(filter).FillEmpty(" "));
                }
                if (!newRowIsNull)
                {
                    resultTable.Rows.Add(itemList2.ToArray().TransformFunctionMany(filter).FillEmpty(" "));
                }
                
            }
            return resultTable;
        }
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> collection, T item)
        {
            return collection.Concat(new[] { item });
        }
        public static IEnumerable<DataRow> GetRows(this DataTable table)
        {
            DataRow[] rows = new DataRow[table.Rows.Count];
            table.Rows.CopyTo(rows, 0);
            return rows;
        }
        public class TableIndex
        {
            public DataTable Table { get; private set; }
            private Dictionary<string, Dictionary<object, HashSet<DataRow>>> index;
            private Dictionary<DataRow, HashSet<HashSet<DataRow>>> reverse;
            public TableIndex(DataTable table)
            {
                Table = table;
                index = table.Index(out reverse);
            }
            public Dictionary<object, HashSet<DataRow>> this[string key]
            {
                get { return index[key]; }
            }
            public HashSet<HashSet<DataRow>> this[DataRow row]
            {
                get { return reverse[row]; }
            }
            public void Remove(DataRow row)
            {
                reverse.IndexRemove(row);
            }
        }
        
        public static SearchSpaceComparer mySearchSpaceCmpr = new SearchSpaceComparer();
        public static Dictionary<string,HashSet<DataRow>> SearchResults(DataRow find, int maxDelta,IEnumerable<string> columnNames,TableIndex index)
        {
            int numberOfFailures = 0;
            var results=new Dictionary<string, HashSet<DataRow>>();
            foreach (var colname in columnNames)
            {
                object cellValue = find[colname];
                HashSet<DataRow> set;
                if (index[colname].TryGetValue(cellValue, out set)) results.Add(colname, set);
                else numberOfFailures++;
                if (numberOfFailures > maxDelta) return null;
            }
            return results;
        }
        public static DataRow FindFuzzyMatch(DataRow find,int maxPkeyDelta, int maxValueDelta, string[] pkeyColumnNames,string[] valueColumnNames, TableIndex index)
        {
            var pkeySearchResults = SearchResults(find, maxPkeyDelta, pkeyColumnNames,index);
            var valueSearchResults = SearchResults(find, maxValueDelta, valueColumnNames, index);
            if (pkeySearchResults == null || valueSearchResults == null) return null;
            var numberOfPkeyFailures = pkeyColumnNames.Length - pkeySearchResults.Count;
            var numberOfValueFailures = valueColumnNames.Length - valueSearchResults.Count;
            int numPkeyDifferencesLeft = maxPkeyDelta - numberOfPkeyFailures;
            int numValueDifferencesLeft = maxValueDelta - numberOfValueFailures;

            var searchSpace = pkeySearchResults.Values.ToList();
            searchSpace.AddRange(valueSearchResults.Values);
            searchSpace.Sort(mySearchSpaceCmpr); //crawl thru search space smallest set first to increase likelihood of match
            
            DataRowValueComparer pkeyDataRowValueComparer = new DataRowValueComparer(pkeySearchResults.Keys) { NumberOfDifferences = numPkeyDifferencesLeft };
            DataRowValueComparer valueDataRowValueComparer = new DataRowValueComparer(valueSearchResults.Keys) { NumberOfDifferences = numValueDifferencesLeft };
            HashSet<DataRow> disregards = new HashSet<DataRow>();
            for (int i = 0; i < searchSpace.Count; i++)
            {
                if (i > 0)
                {
                    disregards.AddRange(searchSpace[i - 1]);
                    searchSpace[i].ExceptWith(disregards); //before searching remove previous match failures from current search set to speed search up
                }
                foreach (var row in searchSpace[i]) if (pkeyDataRowValueComparer.Equals(find, row) && valueDataRowValueComparer.Equals(find, row)) return row;
            }
            //made it thru entire search space with no matches
            return null;
        }
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items) hashSet.Add(item);
        }
        public static Dictionary<string, Dictionary<object, HashSet<DataRow>>> Index(this DataTable table, out Dictionary<DataRow, HashSet<HashSet<DataRow>>> reverseLut)
        {
            var indexes = new Dictionary<string, Dictionary<object, HashSet<DataRow>>>();
            var cols = table.GetColumnNames();
            reverseLut = new Dictionary<DataRow, HashSet<HashSet<DataRow>>>();
            foreach (var columnName in cols)
            {
                var index = new Dictionary<object, HashSet<DataRow>>();
                foreach (DataRow row in table.Rows) index.SafeAddToList(row[columnName], row, reverseLut);
                indexes[columnName] = index;
            }
            return indexes;
        }
        public static void SafeAddToList<TKey, TValue>(this Dictionary<TKey, HashSet<TValue>> dictionary, TKey key, TValue value, Dictionary<TValue, HashSet<HashSet<TValue>>> reverseLut)
        {
            HashSet<TValue> list;
            HashSet<HashSet<TValue>> lutList; //a datarow can be present in multiple column LUTs hence a set of sets
            if (!dictionary.TryGetValue(key, out list))
            {
                list = new HashSet<TValue>();
                dictionary.Add(key, list);
            }
            if (!reverseLut.TryGetValue(value, out lutList))
            {
                lutList = new HashSet<HashSet<TValue>>();
                reverseLut.Add(value, lutList);
            }
            list.Add(value);
            reverseLut[value].Add(list);
        }
        public static void IndexRemove(this Dictionary<DataRow, HashSet<HashSet<DataRow>>> reverseLut, DataRow row)
        {
            HashSet<HashSet<DataRow>> allColumns = reverseLut[row];
            foreach (var column in allColumns) column.Remove(row);
        }
        public static Dictionary<TKey, TValue> ToDictionaryDX<TKey, TValue>(this IEnumerable<TKey> items, TValue value)
        {
            return items.ToDictionary(item => item, item => value);
        }
        public static readonly object NULL = null;
        public static int DifferenceCount<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2)
        {
            var enumerator = sequence2.GetEnumerator();
            int differenceCount = 0;
            foreach (var item in sequence1)
            {
                if (!item.Equals(enumerator.Current)) differenceCount++;
                enumerator.MoveNext();
            }
            return differenceCount;
        }

        public static bool DiffWith(this DataTable first, DataTable second, IEnumerable<string> primaryKeyColumns,IEnumerable<string> valueColumns, out DataTable matches)
        {
            matches = new DataTable();
            matches.Columns.Add("PkeyDelta", typeof(int));
            matches.Columns.Add("ValueDelta", typeof(int));
            matches.Columns.Add("OldRow", typeof(DataRow));
            matches.Columns.Add("NewRow", typeof(DataRow));
            bool ret = false;
            var firstRows = first.GetRows();
            var secondRows = second.GetRows();
            var f = firstRows.ToList();
            var s = secondRows.ToList();
            string[] pkeyColumnNames = primaryKeyColumns.ToArray();
            string[] valueColumnNames = valueColumns.ToArray();
            var secondIndex = new TableIndex(second);
            Dictionary<DataRow, object> assertDictionary1 = first.GetRows().ToDictionaryDX(NULL); //these are to make sure no records are missing/lost/double removed/etc.
            Dictionary<DataRow, object> assertDictionary2 = second.GetRows().ToDictionaryDX(NULL);
            for (int pkeyDelta = 0; pkeyDelta < primaryKeyColumns.Count(); pkeyDelta++)
            {
                for (int valueDelta = 0; valueDelta < valueColumns.Count(); valueDelta++)
                {
                    List<int> removals=new List<int>();
                    for (int i = 0; i < f.Count; i++)
                    {
                        var frow = f[i];
                        DataRow found = FindFuzzyMatch(frow,pkeyDelta,valueDelta,pkeyColumnNames,valueColumnNames, secondIndex);
                        if (found != null)
                        {
                            matches.Rows.Add(pkeyDelta, valueDelta, frow, found);
                            assertDictionary2.Remove(found);
                            secondIndex.Remove(found);
                            removals.Add(i);
                        }
                    }
                    for (int i = removals.Count - 1; i >= 0; i--)
                    {
                        assertDictionary1.Remove(f[removals[i]]);
                        f.RemoveAt(removals[i]);
                    }
                    if (pkeyDelta == 0 && valueDelta == 0 && assertDictionary1.Count == 0 && assertDictionary2.Count==0) ret = true;
                }
            }
            
            for (int i = 0; i < f.Count; i++)
            {
                matches.Rows.Add(-1, -1, f[i], null);
                assertDictionary1.Remove(f[i]);
            }

            for (int i = 0; i < s.Count; i++)
            {
                matches.Rows.Add(-1, -1, null, s[i]);
                assertDictionary2.Remove(s[i]);
            }
            Debug.Assert(assertDictionary1.Count == 0);
            Debug.Assert(assertDictionary2.Count == 0);
            return ret;

        }
        public static string SequenceToString<T>(this IEnumerable<T> items, string separator)
        {
            return string.Join(separator, items.Select(item => item.ToString()).ToArray());
        }
        public static HashSet<T> SetIntersect<T>(this HashSet<T> items, HashSet<T> other)
        {
            HashSet<T> copy = items.ToHashSet();
            copy.IntersectWith(other);
            return copy;
        }
        public static HashSet<T> SetSubtract<T>(this HashSet<T> items, HashSet<T> other)
        {
            HashSet<T> copy = items.ToHashSet();
            copy.ExceptWith(other);
            return copy;
        }
        public static Stack<T> ToStack<T>(this IEnumerable<T> collection)
        {
            return new Stack<T>(collection);
        }
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            return new HashSet<T>(collection);
        }
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            return new HashSet<T>(collection, comparer);
        }
        public static void AddItem<TKey, TValue>(this Dictionary<TKey, HashSet<TValue>> map, TKey key, TValue value, IEqualityComparer<TValue> comparer)
        {
            HashSet<TValue> values;
            if (!map.TryGetValue(key, out values))
            {
                values = new HashSet<TValue>(comparer);
                map.Add(key, values);
            }
            values.Add(value);
        }
        public static void RemoveItem<TKey, TValue>(this Dictionary<TKey, HashSet<TValue>> map, TKey key, TValue item)
        {
            HashSet<TValue> values;
            if (map.TryGetValue(key, out values))
            {
                values.Remove(item);
                if (values.Count == 0) map.Remove(key);
            }
        }
        /// <summary>
        /// Make a composite hashcode from all fields in an array
        /// http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
        /// </summary>
        public static int GetHashCodeMulti(this object[] items)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == null) continue;
                    hash = hash * 23 + items[i].GetHashCode();
                }
                return hash;
            }
        }
        public static object[] GetSubItemArray(this DataRow row, IEnumerable<string> columnNames)
        {
            string[] columnNameArray = columnNames.ToArray();
            object[] itemArray = new object[columnNameArray.Length];
            if (row != null) for (int i = 0; i < columnNameArray.Length; i++) itemArray[i] = row[columnNameArray[i]];
            return itemArray;
        }
        public static bool IsNullOrEmpty(this string item)
        {
            return string.IsNullOrEmpty(item);
        }
        public static object[] FillEmpty(this object[] items, object fill)
        {
            var items2 = new object[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].ToString().IsNullOrEmpty()) items2[i] = fill;
                else items2[i] = items[i];
            }
            return items2;
        }
        public static object[] FillNull(this object[] items, object fill)
        {
            var items2 = new object[items.Length];
            for (int i = 0; i < items.Length; i++) items2[i] = items[i] ?? fill;
            return items2;
        }
        public static int DifferenceCount(this DataRow row, DataRow other)
        {
            return row.ItemArray.Where((t, i) => other.ItemArray[i] != t).Count();
        }
        public static T[] Arr<T>(params T[] items)
        {
            return items;
        }
        public static string Join(this IEnumerable<string> strings, string separator)
        {
            return string.Join(separator, strings.ToArray());
        }

        public static string Print(this DataRow row, params string[] columnNames)
        {
            HashSet<string> cn = new HashSet<string>(columnNames, StringComparer.CurrentCultureIgnoreCase);
            var cnavail = row.Table.GetColumnNames().AsHashSet(StringComparer.CurrentCultureIgnoreCase);
            var lefover = cnavail.Intersect(cn);
            return string.Concat(row.Table.TableName, "{",
                string.Join("|", lefover.Select(columnName => string.Concat(columnName, "=", row[columnName].ToString())).ToArray()), "}");
        }
        public static Dictionary<TValue, TKey> Reversed<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return dictionary.ToDictionary(pair => pair.Value, pair => pair.Key);
        }
        public static DataTable SelectByColumns(this DataTable table, bool distinct, params string[] columnNames)
        {
            return new DataView(table).ToTable(distinct, columnNames);
        }
        public static object[] ItemArrayByColumns(this DataRow row, params string[] columnNames)
        {
            int len = columnNames.Length;
            object[] itemArray = new object[len];
            for (int i = 0; i < len; i++) itemArray[i] = row[columnNames[i]];
            return itemArray;
        }
        public static IEnumerable<string> GetColumnNames(this DataTable table)
        {
            return (from DataColumn column in table.Columns select column.ColumnName);
        }
        public static IEnumerable<Type> GetColumnTypes(this DataTable table)
        {
            return (from DataColumn column in table.Columns select column.DataType);
        }
        public static HashSet<T> AsHashSet<T>(this IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            return new HashSet<T>(items, comparer);
        }
        public static string[][] ReadFileAsTabularData(string filePath, string rowDelimiter, string columnDelimiter, Encoding encoding, StringSplitOptions rowSplitOptions, StringSplitOptions colSplitOptions)
        {
            List<string[]> tableData = new List<string[]>();
            using (TextReader tr = new StreamReader(filePath, encoding))
            {
                string[] rows = tr.ReadToEnd().Split(new string[] { rowDelimiter }, rowSplitOptions);
                string[] colSplit = new string[] { columnDelimiter };
                for (int i = 0; i < rows.Length; i++) tableData.Add(rows[i].Split(colSplit, colSplitOptions));
            }
            return tableData.ToArray();
        }
        public static IEnumerable<string> AsStrings<T>(this IEnumerable<T> items)
        {
            return (from T t in items select t.ToString());
        }
        public static string PrintDiff(this object[] first, object[] second)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i].Equals(second[i])) sb.Append(first[i]);
                else sb.Append(first[i] + " / " + second[i]);
                sb.Append("|");
            }
            return sb.ToString().TrimEnd('|');
        }
        private static Type stringType = typeof(string);
        public static object GetDefault(Type type)
        {
            if (type.IsValueType) return Activator.CreateInstance(type);
            if (type == stringType) return string.Empty;
            return null;
        }

        public static void LoadData(DataTable dataTable, string filePath, string delimiter)
        {
            if (dataTable == null) throw new ArgumentNullException("loadData dataTable cannot be null");
            string[][] data = DX.ReadFileAsTabularData(filePath, Environment.NewLine, delimiter, Encoding.ASCII, StringSplitOptions.RemoveEmptyEntries, StringSplitOptions.None);

            List<Type> columnSchema = dataTable.GetColumnTypes().ToList();

            int columnCount = columnSchema.Count;
            Type guidType = typeof(Guid);
            object[] typeConvertedRow;
            foreach (string[] t in data)
            {
                typeConvertedRow = new object[columnCount];
                for (int colIndex = 0; colIndex < columnCount; colIndex++)
                {
                    string value = t[colIndex]; //make nulls empty strings
                    bool valueIsEmpty;
                    if (value == null)
                    {
                        value = string.Empty;
                        valueIsEmpty = true;
                    }
                    else valueIsEmpty = (value == string.Empty);

                    if (columnSchema[colIndex] == guidType) typeConvertedRow[colIndex] = valueIsEmpty ? Guid.Empty : new Guid(value);
                    else typeConvertedRow[colIndex] = valueIsEmpty ? GetDefault(columnSchema[colIndex]) : Convert.ChangeType(value, columnSchema[colIndex]);
                }
                dataTable.Rows.Add(typeConvertedRow);
            }
        }
    }

    public class SearchSpaceComparer : IComparer<HashSet<DataRow>>
    {
        /// <summary>
        /// compare by set cardinality
        /// </summary>
        public int Compare(HashSet<DataRow> x, HashSet<DataRow> y)
        {
            return x.Count.CompareTo(y.Count);
        }
    }

    public class DataRowValueComparer : IEqualityComparer<DataRow>
    {
        private IEnumerable<string> columnNames;
        /// <summary>
        /// fuzzy number indicating the number of differences (rank 0 = no diff) that are tolerated for a match
        /// </summary>
        public int NumberOfDifferences { get; set; }
        public DataRowValueComparer(IEnumerable<string> columnNamesToCompare)
        {
            columnNames = columnNamesToCompare;
        }
        public DataRowValueComparer()
        {

        }
        public bool Equals(DataRow x, DataRow y)
        {
            int rank = NumberOfDifferences;
            if (columnNames == null || columnNames.Count() == 0)
            {
                if (x.ItemArray.Length != y.ItemArray.Length) return false;
                for (int i = 0; i < x.ItemArray.Length; i++)
                    if (!x.ItemArray[i].Equals(y.ItemArray[i]))
                        if (--rank < 0) return false;
            }
            else
            {
                foreach (var columnName in columnNames) if (!x[columnName].Equals(y[columnName])) if (--rank < 0) return false;
            }
            return true;
        }

        public int GetHashCode(DataRow obj)
        {
            if (columnNames == null) return obj.ItemArray.GetHashCodeMulti();
            return obj.GetSubItemArray(columnNames).GetHashCodeMulti();
        }
    }
}

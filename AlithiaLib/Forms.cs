using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace AlithiaLib {
	public class Forms {
		public static void RemoveSelectedListboxItems(ListBox lb) {
			try {
				object[] items = new object[lb.SelectedItems.Count];
				lb.SelectedItems.CopyTo(items, 0);
				for (int i = 0; i < items.Length; i++) {
					lb.Items.Remove(items[i]);
				}
			} catch (Exception ex) { Errors.OnException(ex); }
		}
		public static void RemoveSelectedListboxItems<T>(ListBox lb, BindingList<T> list) {
			try {
				object[] items = new object[lb.SelectedItems.Count];
				lb.SelectedItems.CopyTo(items, 0);
				for (int i = 0; i < items.Length; i++) {
					list.Remove((T)items[i]);
				}
			} catch (Exception ex) { Errors.OnException(ex); }
		}
		public static void ResizeDataGridCols(DataGridView dgv) {
			try {
				dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
				if (dgv.Rows.Count > 0) dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
				else dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
				int[] widths = new int[dgv.Columns.Count];
				for (int i = 0; i < dgv.Columns.Count; i++) {
					widths[i] = dgv.Columns[i].Width;
				}
				dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
				for (int i = 0; i < dgv.Columns.Count; i++) {
					dgv.Columns[i].Width = widths[i];
				}
			} catch (Exception ex) { Errors.OnException(ex); }
		}
		public class SecondarySortColumn {
			DataGridView grid;
			private DataGridViewColumn column;
			public DataGridViewColumn Column {
				get { return column; }
				set {
					column = value;
					if (grid.SortOrder == SortOrder.Ascending)
						grid.Sort(grid.SortedColumn, ListSortDirection.Ascending);
					else grid.Sort(grid.SortedColumn, ListSortDirection.Descending);
				}
			}
			public SecondarySortColumn(DataGridView grid, DataGridViewColumn column) {
				this.column = column; this.grid = grid;
				grid.SortCompare += new DataGridViewSortCompareEventHandler(grid_SortCompare);
			}

			void grid_SortCompare(object sender, DataGridViewSortCompareEventArgs e) {
				e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
				if (e.SortResult == 0 && e.Column.Name != column.Name) {
					e.SortResult = String.Compare(
						grid[column.Index, e.RowIndex1].Value.ToString(),
						grid[column.Index, e.RowIndex2].Value.ToString());
				}
				e.Handled = true;
			}
		}
		public class ColorGroupsBySortedColumn {
			DataGridView grid;
			bool fixedSortCol;
			void init(DataGridView grid) {
				this.grid = grid;
				grid.Sorted += new EventHandler(grid_Sorted);
			}
			public ColorGroupsBySortedColumn(DataGridView grid) {
				init(grid);
				fixedSortCol = false;
				this.column = grid.SortedColumn;
			}
			public ColorGroupsBySortedColumn(DataGridView grid, DataGridViewColumn column) {
				init(grid);
				fixedSortCol = true;
				this.column = column;
			}
			private Color color = Color.FromArgb(175, 220, 255);
			public Color Color {
				get { return color; }
				set { color = value; paintRows(color); }
			}
			private DataGridViewColumn column;
			public DataGridViewColumn Column {
				get { return column; }
			}
			void paintRows(Color color) {
				bool odd = true;
				int colIndex = column.Index;
				if (grid.Rows.Count == 0) return;
				grid.Rows[0].DefaultCellStyle.BackColor = Color.White;
				for (int i = 1; i < grid.Rows.Count; i++) {
					
						if (!grid[colIndex, i].Value.Equals(grid[colIndex, i - 1].Value)) odd = !odd;
						if (odd) grid.Rows[i].DefaultCellStyle.BackColor = Color.White;
						else grid.Rows[i].DefaultCellStyle.BackColor = color;
					

				}
			}
			void grid_Sorted(object sender, EventArgs e) {
				if (!fixedSortCol) column = grid.SortedColumn;
				paintRows(color);
			}
		}
		public static string DataGridViewToText(DataGridView grid, TextDataFormat format) {
			string text = "";
			try {
				grid.SelectAll();
				text = grid.GetClipboardContent().GetText(format); ;
				grid.ClearSelection();
			} catch (Exception ex) { Errors.OnException(ex); }
			return text;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="grid"></param>
		/// <exception cref="System.NotSupportedException"></exception>
		public static void DataGridViewToFile(string path, DataGridView grid) {
			try {
				IO.StringToTextFile(path, DataGridViewToText(grid, TextDataFormat.Text));
			} catch (Exception ex) { Errors.OnException(ex); }
		}
	}
}

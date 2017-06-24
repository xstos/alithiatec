using System;
using System.Windows.Forms;

namespace PfxToSnk {
  public delegate void DragDropOccured(string[] files);
  public class FileDragDropHandler {
	public event DragDropOccured FilesDropped;
	public FileDragDropHandler(Control c) {
	  c.AllowDrop = true;
	  c.DragEnter += new DragEventHandler(c_DragEnter);
	  c.DragDrop += new DragEventHandler(c_DragDrop);
	}

	void c_DragDrop(object sender, DragEventArgs e) {
	  try {
		String[] a = (string[])e.Data.GetData(DataFormats.FileDrop);
		if (a != null) {
		  if (FilesDropped != null) FilesDropped(a);
		}
	  } catch (Exception ex) {
		Console.WriteLine("Error in DragDropManager.OnDragDrop function: " + ex.Message);
	  }
	}

	void c_DragEnter(object sender, DragEventArgs e) {
	  if (e.Data.GetDataPresent(DataFormats.FileDrop))
		e.Effect = DragDropEffects.Copy;
	  else
		e.Effect = DragDropEffects.None;
	}

  }

}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FolderPortal {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			if (restart) Application.Run(new Form1());
		}
		public static bool restart = false;
	}
}
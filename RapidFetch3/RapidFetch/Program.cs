using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RapidFetch {
	public static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		internal static string[] args;
		
		[STAThread]
		public static void Main(string[] a) {
			Program.args = a;
			Application.EnableVisualStyles();
			Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
			Application.SetCompatibleTextRenderingDefault(false);
			
			SingleApplication.Run(new uiMainForm());
			//Application.Run();
		}
	}
}
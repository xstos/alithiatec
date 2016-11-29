using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HTMerge {
	class Program {
		static void Main(string[] args) {
			try {
				String strDir = "";
				if (args.Length != 1) {
					Console.WriteLine("Usage: HTMerge directoryName");
					return;
				} else {
					strDir = args[0];
				}

				String[] exeFiles = System.IO.Directory.GetFiles(strDir, "*.exe");
				String[] dllFiles = System.IO.Directory.GetFiles(strDir, "*.dll");

				ArrayList ar = new ArrayList();

				Boolean bAdded = false;

				//there might be more than 1 exe file, 
				//we go for the first one that isn't the vshost exe
				foreach (String strExe in exeFiles) {
					if (!strExe.Contains("vshost")) {
						ar.Add(strExe);
						bAdded = true;
						break;
					}
				}

				if (!bAdded) {
					Console.WriteLine("Error: No exe could be found");
					//I know multiple returns are bad…
					return;
				}

				bAdded = false;

				foreach (String strDLL in dllFiles) {
					ar.Add(strDLL);
					bAdded = true;
				}

				//no point merging if nothing to merge with!
				if (!bAdded) {
					Console.WriteLine("Error: No DLLs could be found");
					//I know multiple returns are bad…
					return;
				}


				//You will need to add a reference to ILMerge.exe from Microsoft
				//See http://research.microsoft.com/~mbarnett/ILMerge.aspx
				ILMerging.ILMerge myMerge = new ILMerging.ILMerge();
				myMerge.AllowZeroPeKind = true;
				String[] files = (String[])ar.ToArray(typeof(string));

				String strTargetDir = strDir + "\\Merged";

				try {
					System.IO.Directory.CreateDirectory(strTargetDir);
				} catch {
				}

				//Here we get the first file name 
				//(which was the .exe file) and use that
				// as the output
				String strOutputFile = System.IO.Path.GetFileName(files[0]);

				myMerge.OutputFile = strTargetDir + "\\" + strOutputFile;
				myMerge.SetInputAssemblies(files);

				myMerge.Merge();
			} catch (Exception ex) {
				Console.WriteLine(String.Format("Error :{0}", ex.Message));
			}

		}
	}
}

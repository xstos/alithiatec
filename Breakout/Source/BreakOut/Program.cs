using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BreakOut {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Edge e = new Edge(P3.New(0,0), P3.New(0, -1));
			Edge e2 = new Edge(P3.New(0, -1), P3.New(0, 0));
			V3 v = new V3(1, 1, 0);
			V3 v2 = new V3(0.5F, 0, 0);
			V3 v3 = new V3(0, 1, 0);
			v3.RotateBy2D(-0.78f);
			v3.RotateBy2D(0.78f * 2);
			float d = v.ProjectionDistance(v2);
			Dictionary<Edge, int> dic = new Dictionary<Edge, int>();
			//dic.Add(e, 0);
			//dic.Add(e2, 0);
			V3 n = e.GetNormal2DRightHanded();
			V3 n2 = e2.GetNormal2DRightHanded();
			P3 p;
			Application.Run(new Form1());
		}
	}
}
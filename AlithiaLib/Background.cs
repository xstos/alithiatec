using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace AlithiaLib {
	public class Background {
		public delegate void SimpleDelegate();
		public static void BackgroundTaskNoCallback(SimpleDelegate method) {
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += new DoWorkEventHandler(bw_DoWork);
			bw.RunWorkerAsync(method);
		}

		static void bw_DoWork(object sender, DoWorkEventArgs e) {
			SimpleDelegate sd = e.Argument as SimpleDelegate;
			sd();
		}
	}
}

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;

namespace RapidFetch {
	internal class SingleApplication {
		internal SingleApplication() {

		}
		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern int IsIconic(IntPtr hWnd);

		[DllImport("USER32.DLL")]
		static extern int BroadcastSystemMessage(Int32 dwFlags, ref Int32 pdwRecipients, int uiMessage, int wParam, int lParam);
		[DllImport("USER32.DLL")]
		static extern int RegisterWindowMessage(String pString);
		const Byte BSF_IGNORECURRENTTASK = 2; //this ignores the current app Hex 2
		const Byte BSF_POSTMESSAGE = 16;  //This posts the message Hex 10
		const Byte BSM_APPLICATIONS = 8;  //This tells the windows message to just go to applications Hex 8
		internal static int AppID;
		internal static void BroadCastMsg(int id) {
			int MessageId = id;
			int BSMRecipients = BSM_APPLICATIONS; //Only go to applications
			Int32 tmpuint32 = 0;
			tmpuint32 = tmpuint32 | BSF_IGNORECURRENTTASK; //Ignore current app
			tmpuint32 = tmpuint32 | BSF_POSTMESSAGE; //Post the windows message
			try {
				int ret = BroadcastSystemMessage(tmpuint32, ref BSMRecipients, MessageId, 0, 0);
			} catch { }
		}
		private static IntPtr GetCurrentInstanceWindowHandle() {
			IntPtr hWnd = IntPtr.Zero;
			Process us = Process.GetCurrentProcess();
			Process[] processes = Process.GetProcessesByName(us.ProcessName);
			foreach (Process p in processes) {
				#region MyRegion
				// Get the first instance that is not this instance, has the
				// same process name and was started from the same file name
				// and location. Also check that the process has a valid
				// window handle in this session to filter out other user's
				// processes. 
				#endregion
				if (p.Id != us.Id && p.MainModule.FileName == us.MainModule.FileName) {
					if (p.MainWindowHandle == IntPtr.Zero) {
						try {
							BroadCastMsg(AppID);
						} catch { }
					}
					hWnd = p.MainWindowHandle;
					break;
				}
			}
			return hWnd;
		}
		/// <summary>
		/// SwitchToCurrentInstance
		/// </summary>
		private static void SwitchToCurrentInstance() {
			IntPtr hWnd = IntPtr.Zero;
			try {
				hWnd = GetCurrentInstanceWindowHandle();
			} catch { }
			if (hWnd != IntPtr.Zero) {
				// Restore window if minimised. Do not restore if already in
				// normal or maximised window state, since we don't want to
				// change the current state of the window.
				//MessageBox.Show("isiconic");
				if (IsIconic(hWnd) != 0) {
					//MessageBox.Show("showwin");
					try {
						ShowWindow(hWnd, SW_RESTORE);
					} catch { }
				}
				// Set foreground window.
				try {
					SetForegroundWindow(hWnd);
				} catch { }
			}
		}
		/// <summary>
		/// Execute a form base application if another instance already running on
		/// the system activate previous one
		/// </summary>
		/// <param name="frmMain">main form</param>
		/// <returns>true if no previous instance is running</returns>
		internal static bool Run(System.Windows.Forms.Form frmMain) {
			if (IsAlreadyRunning()) {
				//set focus on previously running app
				if (Program.args != null) {
					if (Program.args.Length > 0) {
						CopyData copyData = new CopyData();
						copyData.Channels.Add("1");
						for (int i = 0; i < Program.args.Length; i++) {
							copyData.Channels["1"].Send(Program.args[i]);
						}
					}
				}

				SwitchToCurrentInstance();
				return false;
			}
			Application.Run(frmMain);
			return true;
		}
		/// <summary>
		/// for console base application
		/// </summary>
		/// <returns></returns>
		internal static bool Run() {
			if (IsAlreadyRunning()) {
				return false;
			}
			return true;
		}
		/// <summary>
		/// check if given exe alread running or not
		/// </summary>
		/// <returns>returns true if already running</returns>
		private static bool IsAlreadyRunning() {
			string strLoc = Assembly.GetExecutingAssembly().Location;
			//MessageBox.Show(strLoc);
			string sExeName = new FileInfo(strLoc).Name;
			try {
				AppID = RegisterWindowMessage(sExeName);
			} catch { }
			bool bCreatedNew;
			mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
			if (bCreatedNew) mutex.ReleaseMutex();

			return !bCreatedNew;
		}

		static Mutex mutex;
		const int SW_RESTORE = 9;
	}
}

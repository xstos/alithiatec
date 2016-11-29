using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Win32.SafeHandles;
namespace RapidFetch {
	public class CrossInstanceMessagePasser {
		//idea! use a guid in iso store and then search for the file to get the filewatcher
		public CrossInstanceMessagePasser(string folderName) {
			IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForDomain();
			IsolatedStorageFileStream stream = new IsolatedStorageFileStream("data.xml", FileMode.OpenOrCreate,FileAccess.Write);
		}
		public void SendMessage(string message) {

		}
		public delegate void Stuff(string message);
		public event Stuff MessageReceived;
		void OnMessageReceived(string message) {
			if (MessageReceived != null) MessageReceived(message);
		}
	}
}

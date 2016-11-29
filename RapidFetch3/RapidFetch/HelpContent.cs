using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace RapidFetch {
	internal class HelpContent {
		internal sealed class HelpItem {
			internal static readonly HelpItem Empty = new HelpItem();
			internal string ShortDescription="";
			internal string ExtendedDescription="";
			internal HelpItem(string shortDesc, string longDesc) {
				ShortDescription = shortDesc;
				ExtendedDescription = longDesc;
			}
			internal HelpItem() {}
			public override string ToString() {
				return ShortDescription + Environment.NewLine + ExtendedDescription;
			}
		}
		Dictionary<string, HelpItem> helpContent = new Dictionary<string, HelpItem>();
		internal HelpContent() {
			string[] split = Properties.Resources.help_content.Split(new string[] { "#####" }, StringSplitOptions.RemoveEmptyEntries);
			string key;
			for (int i = 0; i < split.Length; i++) {
				try {
					StringReader sr = new StringReader(split[i].TrimStart(Environment.NewLine.ToCharArray()));
					key=sr.ReadLine();
					string small=sr.ReadLine(),large=sr.ReadToEnd();
					HelpItem h = new HelpItem(small,large);
					helpContent.Add(key,h);
				} catch { }
			}
		}
		internal HelpItem this[string key] {
			get {
				if (helpContent.ContainsKey(key)) return helpContent[key];
				else return HelpItem.Empty;
			}
		}

	}
}
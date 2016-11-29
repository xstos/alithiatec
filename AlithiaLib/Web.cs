using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AlithiaLib.Web {

	public class HTML {
		public static string EncodeLink(string url, string link) {
			return string.Format("<a href=\"{0}\">{1}<\\a>",url,link);
		}
		
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using vb=Microsoft.VisualBasic;
namespace AlithiaLib {
	public class Str {
		public static object ParseUnknown(string text) {
			if (vb.Information.IsNumeric(text)) {
				try {
					return long.Parse(text);
				} catch {
					return double.Parse(text);
				}
			}
			if (vb.Information.IsDate(text)) {
				return DateTime.Parse(text);
			}
			try {
				return bool.Parse(text);
			} catch {
				return text;

			}

		}
	}
}

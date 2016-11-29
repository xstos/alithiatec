using System;
using System.Collections.Generic;
using System.Text;

namespace AlithiaLib {
	public class Checksums {
		public static bool ByteArraysEqual(byte[] array1, byte[] array2) {
			if (array1 == null | array2 == null) return false;
				if (array1.LongLength != array2.LongLength) return false;
				for (long i = 0; i < array1.LongLength; i++) {
					if (array1[i] != array2[i]) return false;
				}
			return true;
		}
		public static string ByteArrayToString(byte[] array) {
			if (array == null) return "";
			StringBuilder sb = new StringBuilder();
			for (long i = 0; i < array.LongLength; i++) {
				sb.Append(array[i].ToString("X"));
			}
			return sb.ToString();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlithiaLib {
	public class Errors {
		public delegate void ExceptionHandler(Exception ex);
		public static ExceptionHandler DealWithError;
		public static void OnException(Exception ex) {
			if (DealWithError != null) DealWithError(ex);
		}
	}
}

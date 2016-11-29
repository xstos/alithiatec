using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace AlithiaLib {
	public class Reflect {
		/// <summary>
		/// Gets the value of a property for each member of an enumeration and returns an array of the values
		/// </summary>
		public static TField[] GetMemberData<TField, TData>(IEnumerable<TData> objects, string propertyName) {
			PropertyInfo pi = typeof(TData).GetProperty(propertyName);
			List<TField> results = new List<TField>();
			foreach (TData obj in objects) {
				 results.Add((TField)pi.GetValue(obj,null));
			}
			return results.ToArray();
		}
	}
}

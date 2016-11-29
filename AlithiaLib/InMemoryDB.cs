using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;
namespace AlithiaLib {
	public class InMemoryDB<T> {
		List<T> data;
		public InMemoryDB(IEnumerable<T> data) {
			this.data = new List<T>(data);
			Type t = data.GetType();
			MemberInfo[] mi = t.GetMembers();
			
		}
		private System.Collections.ObjectModel.ReadOnlyCollection<string> members;

		public System.Collections.ObjectModel.ReadOnlyCollection<string> Members {
			get { return members; }
		}
		public void IndexBy(string memberName) {
			Type t = typeof(T);
			
		}
	}
}

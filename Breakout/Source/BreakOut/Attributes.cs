using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace BreakOut {
	public class Attributes {
		Dictionary<string, object> attrib = new Dictionary<string, object>();
		public Attributes() { }
		public void Add(string key, object setting) {
			attrib.Add(key, setting);
		}
		public void Remove(string key, object setting) {
			attrib.Remove(key);
		}
		public T Get<T>(string key) {
			return (T)attrib[key];
		}
		public bool Contains(string key) {
			return attrib.ContainsKey(key);
		}
		public object this[string key] {
			get {
				return attrib[key];
			}
			set {
				if (attrib.ContainsKey(key)) attrib[key] = value;
				else attrib.Add(key, value);
			}
		}
		

	}
}

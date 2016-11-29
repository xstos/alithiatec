using System;
using System.Collections.Generic;
using System.Text;

namespace AlithiaLib {
	public class DictionaryList<TKey,TValue> :Dictionary<TKey,List<TValue>> {
		public void Add(TKey key, TValue value) {
			if (base.ContainsKey(key)) base[key].Add(value);
			else {
				base.Add(key, new List<TValue>());
				base[key].Add(value);
			}
		}
		public void Remove(TKey key, TValue value) {
			if (base.ContainsKey(key)) if (base[key].Contains(value)) base[key].Remove(value);
		}
	}
}

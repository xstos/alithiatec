using System;
using System.Collections.Generic;
using System.Text;

namespace BreakOut {
	public class Bag<T> :List<T> {
		Dictionary<T, int> refCount = new Dictionary<T, int>();
		public Bag() :base() {		}
		public Bag(int capacity) : base(capacity) { }
		public Bag(IEnumerable<T> collection):base() {
			foreach (T t in collection) {
				Add(t);
			}
		}
		public new void Add(T item) {
			if (refCount.ContainsKey(item)) refCount[item]++;
			else {
				refCount.Add(item, 1);
				base.Add(item);
			}
		}
		public new void AddRange(IEnumerable<T> collection) {
			foreach (T t in collection) {
				Add(t);
			}
		}
		public void RemoveRange(IEnumerable<T> collection) {
			foreach (T t in collection) {
				Remove(t);
			}
		}
		public new void Remove(T item) {
			refCount[item]--;
			if (refCount[item]==0) {
				refCount.Remove(item);
				base.Remove(item);
			}
		}
		public new void Clear() {
			refCount.Clear();
			base.Clear();
		}
		public int RefCount(T item) {
			if (refCount.ContainsKey(item)) return refCount[item];
			else return 0;
		}
		public List<T> GetUniqueItems() {
			List<T> items = new List<T>();
			for (int i = 0; i < base.Count; i++) {
				if (refCount[base[i]] == 1) items.Add(base[i]);
			}
			return items;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Reflection;
namespace BreakOut {
	/// <summary>
	/// When duplicate values are added to the dictionary the ref count is incremented (if the new value != old value it is overwritten).
	/// When pre-existing values are removed the ref count is decremented.
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	public class DictionaryBag<TKey, TValue> : Dictionary<TKey, TValue> {
		Dictionary<TKey, int> refCount;
		IEqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;
		public DictionaryBag()
			: base() {
			refCount = new Dictionary<TKey, int>();
		}
		public DictionaryBag(IDictionary<TKey, TValue> dictionary)
			: base(dictionary) {
			refCount = new Dictionary<TKey, int>();
			foreach (TKey key in dictionary.Keys) {
				refCount.Add(key, 1);
			}
		}
		public DictionaryBag(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: base(keyComparer) {
			refCount = new Dictionary<TKey, int>(keyComparer);
		}
		public DictionaryBag(int capacity) : base(capacity) { }
		public DictionaryBag(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: base(dictionary, keyComparer) {
			refCount = new Dictionary<TKey, int>(keyComparer);
			foreach (TKey key in dictionary.Keys) {
				refCount.Add(key, 1);
			}
			this.valueComparer = valueComparer;
		}
		public DictionaryBag(int capacity, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: base(capacity, keyComparer) {
			refCount = new Dictionary<TKey, int>(keyComparer);
			this.valueComparer = valueComparer;
		}
		public new TValue this[TKey key] {
			get {
				return base[key];
			}
			set { Add(key, value); }
		}
		public new void Add(TKey key, TValue value) {
			if (refCount.ContainsKey(key)) {
				refCount[key]++;
				if (!valueComparer.Equals(base[key], value)) {
					base.Remove(key);
					base.Add(key, value);
				}
			} else {
				refCount.Add(key, 1);
				base.Add(key, value);
			}
		}
		public bool RemoveAll(TKey key) {
			if (base.ContainsKey(key)) {
				refCount.Remove(key);
			}
			return base.Remove(key);
		}
		public int RefCount(TKey key) {
			if (refCount.ContainsKey(key)) return refCount[key];
			else return 0;
		}
		public new void Clear() {
			base.Clear();
			refCount.Clear();
		}
		public new bool Remove(TKey key) {
			if (base.ContainsKey(key)) {
				refCount[key]--;
				if (refCount[key] < 1) {
					refCount.Remove(key);
					base.Remove(key);
				}
				return true;
			} else return base.Remove(key);
		}
	}
}

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
using Microsoft.VisualBasic;
namespace RapidFetch {
	/// <summary>
	/// When duplicate values are added to the dictionary the ref count is incremented (if the new value != old value it is overwritten).
	/// When pre-existing values are removed the ref count is decremented.
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	internal class DictionaryBag<TKey, TValue> : Dictionary<TKey, TValue> {
		Dictionary<TKey, int> refCount;
		IEqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;
		internal DictionaryBag()
			: base() {
			refCount = new Dictionary<TKey, int>();
		}
		internal DictionaryBag(IDictionary<TKey, TValue> dictionary)
			: base(dictionary) {
			refCount = new Dictionary<TKey, int>();
			foreach (TKey key in dictionary.Keys) {
				refCount.Add(key, 1);
			}
		}
		internal DictionaryBag(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: base(keyComparer) {
			refCount = new Dictionary<TKey, int>(keyComparer);
		}
		internal DictionaryBag(int capacity) : base(capacity) { }
		internal DictionaryBag(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: base(dictionary, keyComparer) {
			refCount = new Dictionary<TKey, int>(keyComparer);
			foreach (TKey key in dictionary.Keys) {
				refCount.Add(key, 1);
			}
			this.valueComparer = valueComparer;
		}
		internal DictionaryBag(int capacity, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			: base(capacity, keyComparer) {
			refCount = new Dictionary<TKey, int>(keyComparer);
			this.valueComparer = valueComparer;
		}
		internal new TValue this[TKey key] {
			get {
				if (base.ContainsKey(key)) return base[key];
				else {
					Console.Error.WriteLine("DictionaryBag key{" + key.ToString() + "} not found");
					return default(TValue);
				}
			}
			set { Add(key, value); }
		}
		internal new void Add(TKey key, TValue value) {
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
		internal bool RemoveAll(TKey key) {
			if (base.ContainsKey(key)) {
				refCount.Remove(key);
			}
			return base.Remove(key);
		}
		internal int RefCount(TKey key) {
			if (refCount.ContainsKey(key)) return refCount[key];
			else return 0;
		}
		internal new void Clear() {
			base.Clear();
			refCount.Clear();
		}
		internal new bool Remove(TKey key) {
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

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace RapidFetch {
	public sealed class Tree<D> : IEqualityComparer<Tree<D>>, IEnumerable<Tree<D>> {
		public sealed class GlobalProperties {
			public string pathSeparator = "\\";
			//public Dictionary<Tree<D>, object> flatTree = new Dictionary<Tree<D>, object>();
			public Tree<D> root = null;
			public GlobalProperties(Tree<D> root) {
				this.root = root;
			}
		}
		GlobalProperties gp;
		//public Tree<D> GetRoot() {

		//    Tree<D> n = this;
		//    while (!n.IsRoot) n = n.parent;
		//    rootCache = n;
		//    return n;
		//}
		public Tree<D> Root {
			get { return gp.root; }
		}
		/// <summary>
		/// All nodes in the tree in a flat list.
		/// </summary>
		//public Dictionary<Tree<D>,object> FlatTree {
		//    get { return gp.flatTree; }
		//}
		public string PathSeparator {
			get { return gp.pathSeparator; }
			set {
				if (value == null) gp.pathSeparator = "";
				else gp.pathSeparator = value;
			}
		}
		#region Constructors
		public Tree(D data) {
			dictionary = new DictionaryBag<string, Tree<D>>();
			this.data = data;
			gp = new GlobalProperties(this);
		}
		public Tree(D data, IEqualityComparer<string> keyComparer) {
			dictionary = new DictionaryBag<string, Tree<D>>(keyComparer, this);
			this.data = data;
			gp = new GlobalProperties(this);
		}

		protected Tree(string key, D data, Tree<D> parent, GlobalProperties gp) {
			dictionary = new DictionaryBag<string, Tree<D>>(parent.dictionary.Comparer, this);
			this.data = data; this.parent = parent; this.key = key;
			this.gp = gp;
		}
		#endregion
		#region Methods
		public Tree<D> GetSubTreeByAddress(string path) {
			string[] split = path.Split(new string[] { gp.pathSeparator }, StringSplitOptions.RemoveEmptyEntries);
			Tree<D> n = this;
			for (int i = 0; i < split.Length; i++) {
				if (n.ContainsKey(split[i])) n = n[split[i]];
				else return null;
			}
			return n;
		}
		public void RemoveSubTrees() {
			Tree<D>[] st = GetSubTrees();
			for (int i = 0; i < st.Length; i++) {
				st[i].RemovePath();
			}
		}
		public void RemovePath() {
			Tree<D> n = this;
			string key;
			while (!n.IsRoot) {
				key = n.key;
				n = n.parent;
				n.Remove(key);
			}
		}
		public Tree<D> Add(string key, D item) {
			if (dictionary.ContainsKey(key)) {
				dictionary.Add(key, dictionary[key]);
				return dictionary[key];
			} else {
				Tree<D> t = new Tree<D>(key,item,this, gp);
				dictionary.Add(key, t);
				//if (!gp.flatTree.ContainsKey(t)) gp.flatTree.Add(t, null);
				return t;
			}
			
		}
		public Tree<D> CreatePath(string fullPath, D value) {
			string[] split = fullPath.Split(new string[] { gp.pathSeparator }, StringSplitOptions.RemoveEmptyEntries);
			Tree<D> n = this;
			for (int i = 0; i < split.Length; i++) n = n.Add(split[i], value);
			return n;
		}
		public void RemovePath(string fullPath) {
			string[] split = fullPath.Split(new string[] { gp.pathSeparator }, StringSplitOptions.RemoveEmptyEntries);
			Tree<D> n = this;
			for (int i = 0; i < split.Length; i++) {
				n.Remove(split[i]);
				if (n.ContainsKey(split[i])) {
					n = n[split[i]];
				} else return;
			}
		}
		public void RemoveTree(Tree<D> t) {
			RemoveTree(this, t);
		}
		void RemoveTree(Tree<D> target, Tree<D> source) {
			foreach (Tree<D> var in source) {
				target[var.key].RemovePath();
				if (target.ContainsKey(var.key)) RemoveTree(target[var.key], var);
			}
		}
		public string GetPath() {
			Stack<string> path = new Stack<string>(16);
			StringBuilder sb = new StringBuilder();
			Tree<D> n = this;
			while (!n.IsRoot) {
				path.Push(n.Key);
				n = n.Parent;
			}
			int c = path.Count;
			for (int i = 0; i < c; i++) {
				sb.Append(path.Pop());
				sb.Append(PathSeparator);
			}
			return sb.ToString();
		}
		public Tree<D>[] GetSubTrees() {
			List<Tree<D>> trees = new List<Tree<D>>();
			Queue<Tree<D>> temp = new Queue<Tree<D>>();
			temp.Enqueue(this);
			Tree<D> current;
			while (temp.Count > 0) {
				current = temp.Dequeue();
				trees.Add(current);
				foreach (Tree<D> t in current) {
					temp.Enqueue(t);
				}
			}
			return trees.ToArray();
		}
		#endregion

		#region Properties
		D data = default(D);
		protected string key = null;
		protected Tree<D> parent = null;
		DictionaryBag<string, Tree<D>> dictionary;
		
		public bool IsRoot {
			get { return (parent == null); }
		}
		
		//string path = null;
		//public string Path {
		//    get {
		//        if (path == null) path = GetPath();
		//        return path;
		//    }
		//}
		public int Count { get { return dictionary.Count; } }

		public IEqualityComparer<string> KeyComparer {
			get { return dictionary.Comparer; }
		}

		public Tree<D> Parent {
			get { return parent; }
		}

		public string Key {
			get { return key; }
		}

		public D Data {
			get { return data; }
			set { data = value; }
		}
		#endregion
		#region IEqualityComparer<Tree<D>> Members
		public bool Equals(Tree<D> x, Tree<D> y) {
			return KeyComparer.Equals(x.key, y.key);
		}

		public int GetHashCode(Tree<D> obj) {
			return KeyComparer.GetHashCode(obj.key);
		}
		#endregion
		public override string ToString() {
			return GetPath();
		}
		public Tree<D> this[string key] {
			get { return dictionary[key]; }
		}
		public bool ContainsKey(string key) {
			return dictionary.ContainsKey(key);
		}

		public void Remove(string key) {
			dictionary.Remove(key);
		}
		public void Clear() {
			dictionary.Clear();
		}
		public void ToTreeView(System.Windows.Forms.TreeView tv) {
			tv.Nodes.Clear();
			Tree<D> tree = this;
			System.Windows.Forms.TreeNodeCollection tnc;
			System.Windows.Forms.TreeNode tn;
			Tree<D> t;
			Stack<System.Windows.Forms.TreeNodeCollection> tvStack = new Stack<System.Windows.Forms.TreeNodeCollection>();
			Stack<Tree<D>> treeStack = new Stack<Tree<D>>();
			tvStack.Push(tv.Nodes);
			treeStack.Push(tree);
			while (tvStack.Count > 0) {
				tnc = tvStack.Pop();
				t = treeStack.Pop();
				foreach (Tree<D> var in t) {
					treeStack.Push(var);
					tn = tnc.Add(var.key, String.Concat(var.key, "(", var.parent.dictionary.RefCount(var.key), ")"));
					tvStack.Push(tn.Nodes);
					tn.Tag = var.data;
				}
			}
		}
		public static implicit operator System.Windows.Forms.TreeView(Tree<D> tree) {
			System.Windows.Forms.TreeView tv = new System.Windows.Forms.TreeView();
			System.Windows.Forms.TreeNodeCollection tnc;
			System.Windows.Forms.TreeNode tn;
			Tree<D> t;
			Stack<System.Windows.Forms.TreeNodeCollection> tvStack = new Stack<System.Windows.Forms.TreeNodeCollection>();
			Stack<Tree<D>> treeStack = new Stack<Tree<D>>();
			tvStack.Push(tv.Nodes);
			treeStack.Push(tree);
			while (tvStack.Count > 0) {
				tnc = tvStack.Pop();
				t = treeStack.Pop();
				foreach (Tree<D> var in t) {
					treeStack.Push(var);
					tn = tnc.Add(var.key, var.key);
					tvStack.Push(tn.Nodes);
					tn.Tag = var.data;
				}
			}
			return tv;
		}
		

		#region IEnumerable<Tree<D>> Members

		public IEnumerator<Tree<D>> GetEnumerator() {
			return (IEnumerator<Tree<D>>)dictionary.Values.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return dictionary.GetEnumerator();
		}

		#endregion
	}

}

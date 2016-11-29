using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
namespace RapidFetch {
	internal sealed class Tree<D> : IEqualityComparer<Tree<D>>, IEnumerable<Tree<D>> {
        internal static string pathSeparator = Path.DirectorySeparatorChar.ToString();
        internal sealed class GlobalProperties {
			
			//public Dictionary<Tree<D>, object> flatTree = new Dictionary<Tree<D>, object>();
			internal Tree<D> root = null;
			internal GlobalProperties(Tree<D> root) {
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
		internal Tree<D> Root {
			get { return gp.root; }
		}
		/// <summary>
		/// All nodes in the tree in a flat list.
		/// </summary>
		//public Dictionary<Tree<D>,object> FlatTree {
		//    get { return gp.flatTree; }
		//}

		#region Constructors
		internal Tree(D data) {
			dictionary = new DictionaryBag<string, Tree<D>>();
			this.data = data;
			gp = new GlobalProperties(this);
		}
		internal Tree(D data, IEqualityComparer<string> keyComparer) {
			dictionary = new DictionaryBag<string, Tree<D>>(keyComparer, this);
			this.data = data;
			gp = new GlobalProperties(this);
		}

		internal Tree(string key, D data, Tree<D> parent, GlobalProperties gp) {
			dictionary = new DictionaryBag<string, Tree<D>>(parent.dictionary.Comparer, this);
			this.data = data; this.parent = parent; this.key = key;
			this.gp = gp;
		}
		#endregion
		#region Methods
		internal Tree<D> GetSubTreeByAddress(string path) {
			string[] split = path.Split(new string[] { pathSeparator }, StringSplitOptions.RemoveEmptyEntries);
			Tree<D> n = this;
			for (int i = 0; i < split.Length; i++) {
				if (n.ContainsKey(split[i])) n = n[split[i]];
				else return null;
			}
			return n;
		}
		internal void RemoveSubTrees() {
			Tree<D>[] st = GetSubTrees();
			for (int i = 0; i < st.Length; i++) {
				st[i].RemovePath();
			}
		}
		internal void RemovePath() {
			Tree<D> n = this;
			string key;
			while (!n.IsRoot) {
				key = n.key;
				n = n.parent;
				n.Remove(key);
			}
		}
		internal Tree<D> Add(string key, D item) {
			if (dictionary.ContainsKey(key)) {
				dictionary.Add(key, dictionary[key]);
				return dictionary[key];
			} else {
				Tree<D> t = new Tree<D>(key, item, this, gp);
				dictionary.Add(key, t);
				//if (!gp.flatTree.ContainsKey(t)) gp.flatTree.Add(t, null);
				return t;
			}

		}
		internal Tree<D> CreatePath(string fullPath, D value) {
			string[] split = fullPath.Split(new string[] { pathSeparator }, StringSplitOptions.RemoveEmptyEntries);
			Tree<D> n = this;
			for (int i = 0; i < split.Length; i++) n = n.Add(split[i], value);
			return n;
		}
		internal void RemovePath(string fullPath) {
			string[] split = fullPath.Split(new string[] { pathSeparator }, StringSplitOptions.RemoveEmptyEntries);
			Tree<D> n = this;
			for (int i = 0; i < split.Length; i++) {
				n.Remove(split[i]);
				if (n.ContainsKey(split[i])) {
					n = n[split[i]];
				} else return;
			}
		}
		internal void RemoveTree(Tree<D> t) {
			RemoveTree(this, t);
		}
		void RemoveTree(Tree<D> targetTree, Tree<D> sourceTree) {
			foreach (Tree<D> subTree in sourceTree) {
				if (targetTree.ContainsKey(subTree.key)) {
					targetTree[subTree.key].RemovePath();
					if (targetTree.ContainsKey(subTree.key))
						RemoveTree(targetTree[subTree.key], subTree);
				}
			}
		}
		internal string GetPath() {
			Stack<string> path = new Stack<string>();
			//StringBuilder sb = new StringBuilder();
			Tree<D> n = this;
			while (!n.IsRoot) {
				path.Push(n.Key);
				n = n.Parent;
			}
            /*
			int c = path.Count;
			for (int i = 0; i < c; i++) {
				sb.Append(path.Pop());
                sb.Append(pathSeparator);
			}
            */
			return String.Join(pathSeparator,path.ToArray());
		}
		internal Tree<D>[] GetSubTrees() {
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
		internal string key = null;
		internal Tree<D> parent = null;
		DictionaryBag<string, Tree<D>> dictionary;

		internal bool IsRoot {
			get { return (parent == null); }
		}

		//string path = null;
		//public string Path {
		//    get {
		//        if (path == null) path = GetPath();
		//        return path;
		//    }
		//}
		internal int Count { get { return dictionary.Count; } }

		internal IEqualityComparer<string> KeyComparer {
			get { return dictionary.Comparer; }
		}

		internal Tree<D> Parent {
			get { return parent; }
		}

		internal string Key {
			get { return key; }
		}

		internal D Data {
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
		internal Tree<D> this[string key] {
			get { return dictionary[key]; }
		}
		internal bool ContainsKey(string key) {
			return dictionary.ContainsKey(key);
		}

		internal void Remove(string key) {
			dictionary.Remove(key);
		}
		internal void Clear() {
			dictionary.Clear();
		}
		internal void ToTreeView(System.Windows.Forms.TreeView tv) {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiskBackedCache
{
    public delegate void MultiEvent(object sender, FlexEventArgs e);
    public class FlexEventArgs : EventArgs
    {
        private static string[] cachedArgNamesArray;
        private static readonly List<string> cachedArgNames = new List<string>();
        public string EventName;
        public readonly Dictionary<string, object> Args = new Dictionary<string, object>();
        public FlexEventArgs(string eventName, params object[] args)
        {
            Init(eventName, null, args);
        }
        public FlexEventArgs(string eventName, string[] argNames, params object[] args)
        {
            Init(eventName, argNames, args);
        }
        private void Init(string eventName, string[] argNames, params object[] args)
        {
            int arlen = args.Length;
            if (argNames == null)
            {
                if (cachedArgNames.Count < arlen)
                {
                    for (int i = cachedArgNames.Count; i < arlen; i++) cachedArgNames.Add(i.ToString());
                    argNames = cachedArgNamesArray = cachedArgNames.ToArray();
                }
                else argNames = cachedArgNamesArray;
            }
            else
            {
                if (arlen != argNames.Length)
                    throw new Exception("number of argument names must match number of arguments");
            }

            EventName = eventName;
            for (int i = 0; i < arlen; i++)
                Args[argNames[i]] = args[i];
        }
        public object this[string key]
        {
            get { return Args[key]; }
        }
        public T Get<T>(string key) where T : class
        {
            return Args[key] as T;
        }
    }
    public class MultiEventDispatcher
    {
        protected Dictionary<string, MultiEvent> dispTable = new Dictionary<string, MultiEvent>();
        public virtual void Fire(object sender, string eventName, string[] argNames, params object[] args)
        {
            dispTable[eventName](sender, new FlexEventArgs(eventName, argNames, args));
        }
        public virtual void Fire(object sender, string eventName, params object[] args)
        {
            dispTable[eventName](sender, new FlexEventArgs(eventName, null, args));
        }
        public MultiEvent this[string key]
        {
            get { return dispTable[key]; }
            set { dispTable[key] = value; }
        }
    }
}

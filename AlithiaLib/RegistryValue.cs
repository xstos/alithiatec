using System.Collections.Generic;
using System.Data;
using Microsoft.Win32;

namespace AlithiaLib
{
    public class RegistryValue
    {
        private string name;

        public static IEnumerable<DataColumn> GetColumns()
        {
            yield return new DataColumn("Parent", typeof(string));
            yield return new DataColumn("Name", typeof(string));
            yield return new DataColumn("Kind", typeof(RegistryValueKind));
            yield return new DataColumn("Value", typeof(object));
        }
        public RegistryValueKind Kind { get; set; }
        public RegistryKey Parent { get; set; }
        public object Value { get; set; }
        public string Name { get; set; }
        public object[] values;
        public RegistryValue(RegistryKey parent, RegistryValueKind kind, object value, string name)
        {
            this.Parent = parent;
            this.Kind = kind;
            this.Value = value;
            Name = name;
            values = new[] { parent.Name, name, kind, value };
        }

    }
}
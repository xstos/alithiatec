using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace AlithiaLib
{
    public static class Extensions
    {
        public static IEnumerable<RegistryValue> GetValues(this IEnumerable<RegistryKey> keys)
        {
            foreach (var key in keys)
            {
                var values = key.GetValueNames();
                foreach (var valueName in values)
                {
                    yield return new RegistryValue(parent: key, kind: key.GetValueKind(valueName), value: key.GetValue(valueName), name: valueName);
                }
            }
        }
        public static IEnumerable<RegistryKey> GetAllRegistryKeys()
        {
            var hives = new[] { Registry.ClassesRoot, Registry.CurrentConfig, Registry.CurrentUser, Registry.LocalMachine, Registry.Users, Registry.PerformanceData };
            return hives.SelectMany(hive => hive.ChildrenRecusive());
        }

        public static IEnumerable<RegistryKey> Children(this RegistryKey key)
        {
            return key.GetSubKeyNames().Where(s => s != "Wow6432Node").Select(key.OpenSubKey);
        }
        public static IEnumerable<RegistryKey> ChildrenRecusive(this RegistryKey key)
        {
            Stack<RegistryKey> keys = new Stack<RegistryKey>();
            keys.Push(key);
            RegistryKey current;
            do
            {
                current = keys.Pop();
                foreach (var child in current.Children())
                {
                    yield return child;
                    keys.Push(child);
                }
            } while (keys.Count > 0);
        }
    }
}

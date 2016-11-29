using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DiskBackedCache
{
    public static class Util
    {
        public static byte[] BinarySerialize(this ISerializable o)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, o);
            return ms.ToArray();

            
        }
        public static T BinaryDeserialize<T>(this byte[] buffer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            return (T)bf.Deserialize(ms);
        }
    }
}

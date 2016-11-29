using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using AltSerialize;
using MassTransitLib;
using Timer = System.Threading.Timer;
using FSharpLib;
namespace DiskBackedCache
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            MassTransitLib.MassTransitUtil.Init();
            MassTransitLib.MassTransitUtil.Send(Msg.New("ehllo"));
            
            #region MyRegion

            //List<string> strings=new List<string>();
            //int c = 1000000;
            //for (int i = 0; i < c; i++)
            //{
            //    strings.Add(i.ToString().PadLeft(8, '0'));
            //}
            //Stopwatch sw=new Stopwatch();

            //int offs = 0;
            //byte[] bytes;
            //sw.Start();
            //for (int i = 0; i < c; i++)
            //{
            //    bytes = Encoding.ASCII.GetBytes(strings[i]);
            //    test.mmv.Write(bytes,0,bytes.Length);
            //    offs += bytes.Length;
            //}
            //sw.Stop();
            //SpaceTracker st=new SpaceTracker(4);
            //MultiEventDispatcher me=new MultiEventDispatcher();
            //me["full"]=st_Event;
            //me.Fire(this,"full");
            //var x = new FlexEventArgs("lalal","a", "b");
            //Ranges r=new Ranges(8);
            //List<Range> test=new List<Range>();
            //for (int i = 0; i < 8; i++)
            //{
            //    test.Add(r.Allocate(1));
            //}
            //MMF mmf=new MMF(@"mmf",1024);
            //mmf.Write("hello");
            //mmf.GrowTo(2048);
            //r.Free(test[1]);
            //r.Free(test[3]);
            //r.Free(test[5]);
            //Range r1=r.Allocate(2);
            //r.Free(test[6]);
            //r1 = r.Allocate(2);
            //r.Free(r1); 

            #endregion
        }
        void TestReaders()
        {
            MemoryMappedFile m;
            Stopwatch sw = new Stopwatch();
            List<string> lines = new List<string>();
            sw.Start(); //C:\Program Files (x86)\prairieFyre Software Inc\CCM\Logs
            foreach (var line in Util.RegularFileReader(@"e:\Reporting - Distribution.log.16062011.013834"))
            {
                //lines.Add(line);
            }
            sw.Stop();
        }
        public sealed class CachedString
        {
            static PageFileManager pfm=new PageFileManager(@"e:\cachedstring.store",1024*1024*1024);
            protected MemoryBlock mb;
            public static implicit operator string(CachedString s)
            {
                return pfm.Read(s.mb);
            }
            
            public CachedString(ref string s)
            {
                mb = pfm.WriteLengthAndString(s);
            }
        }
        class handlecomp : IEqualityComparer<myhandle>
        {
            public bool Equals(myhandle x, myhandle y)
            {
                return x.InstanceTarget.IsAlive && y.InstanceTarget.IsAlive && x.LocationName == y.LocationName &&
                       object.Equals(x.InstanceTarget.Target, y.InstanceTarget.Target);
            }
            public int GetHashCode(myhandle obj)
            {
                int hash = 17;
                hash = hash * 23 + obj.InstanceTarget.Target.GetHashCode();
                hash = hash * 23 + obj.LocationName.GetHashCode();
                return hash;

            }
        }
        public class myhandle 
        {
            public WeakReference InstanceTarget;
            public string LocationName;
            
            public myhandle(object instance,string locationName)
            {
                InstanceTarget=new WeakReference(instance);
                LocationName = locationName;
            }
            
        }

        //[Serializable]
        //public class MyAspect : LocationInterceptionAspect
        //{
        //    static Type stringType = typeof(string);
        //    static Dictionary<myhandle, MemoryBlock> offs = new Dictionary<myhandle, MemoryBlock>(new handlecomp() );
        //    static PageFileManager pfm = new PageFileManager(@"c:\pf.binary", 1024 * 1024 * 1024);
        //    public override void OnSetValue(LocationInterceptionArgs args)
        //    {
        //        if (args.Location.LocationKind == LocationKind.Property)
        //        {
        //            if (args.Location.PropertyInfo.PropertyType.Equals(stringType))
        //            {
        //                object newValue = (string)args.Value;
        //                myhandle han = new myhandle(args.Instance, args.LocationName);
        //                if (offs.ContainsKey(han))
        //                {
        //                    MemoryBlock mb = offs[han];
        //                    pfm.Delete(mb);
                            
        //                }
        //                offs[han] = pfm.Write((string)newValue);
        //                return;
        //            }
        //        }
        //        base.OnSetValue(args);
        //    }
        //    public override void OnGetValue(LocationInterceptionArgs args)
        //    {
        //        if (args.Location.LocationKind == LocationKind.Property)
        //        {
        //            if (args.Location.PropertyInfo.PropertyType.Equals(stringType))
        //            {
        //                myhandle han = new myhandle(args.Instance, args.LocationName);
        //                if (offs.ContainsKey(han))
        //                {
        //                    args.Value = pfm.Read(offs[han]);
        //                }
        //                return;
        //            }
        //        }
        //        base.OnGetValue(args);
        //    }
            
        //}

        class bar
        {
            public string foo { get; set; }
        }
        
        
        [Serializable]
        class serializeMe : ISerializable
        {
            public string y = "lalala";
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("y",y);
            }
            public serializeMe()
            {
                
            }
            public serializeMe(SerializationInfo info, StreamingContext context)
            {
                y=info.GetString("y");
            }
        }
        
        public class Util
        {
            public static IEnumerable Power(int number, int exponent)
            {
                int counter = 0;
                int result = 1;
                while (counter++ < exponent)
                {
                    result = result * number;
                    yield return result;
                }
            }
            /// <summary>
            /// Allows enumeration of a test file via memory mapped file. FTL because it's faster than light :)
            /// </summary>
            public static IEnumerable<string> FTLFileReader(string path)
            {
                FileInfo fi=new FileInfo(path);
                MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Open,Guid.NewGuid().ToString(),fi.Length);
                StreamReader sr = new StreamReader(mmf.CreateViewStream(0, fi.Length));
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
            public static IEnumerable<string> RegularFileReader(string path)
            {

                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }


        public class PageFileManager
        {
            static readonly int IntSizeInBytes = BitConverter.GetBytes((int)0).Length;
            MemoryAllocator allocator=new MemoryAllocator(int.MaxValue);
            private PageFile pageFile;
            public int Allocated { get; set; }
            public PageFileManager(string path, long size)
            {
                pageFile=new PageFile(path,size);
            }
            public MemoryBlock Write(byte[] bytes)
            {
                var block = allocator.Allocate(bytes.Length);
                pageFile.Seek(block.BlockAddress);
                pageFile.Write(bytes);
                Allocated += block.BlockSize;
                return block;
            }
            public MemoryBlock WriteLengthAndString(string text)
            {
                byte[] bytes = text.ToByteArray();
                var block = allocator.Allocate(bytes.Length + IntSizeInBytes);
                pageFile.Seek(block.BlockAddress);
                pageFile.Write(bytes.Length);
                pageFile.Write(text);
                Allocated += block.BlockSize;
                return block;
            }
            public MemoryBlock Write(string text)
            {
                byte[] bytes = text.ToByteArray();
                var block = allocator.Allocate(bytes.Length);
                pageFile.Seek(block.BlockAddress);
                pageFile.Write(text);
                Allocated += block.BlockSize;
                return block;
            }
            public void Delete(MemoryBlock block)
            {
                allocator.Free(block);
                Allocated -= block.BlockSize;
            }
            public string Read(MemoryBlock block)
            {
                pageFile.Seek(block.BlockAddress);
                return pageFile.ReadString();
            }
        }
        
        public class PageFile
        {
            static readonly int IntSizeInBytes = BitConverter.GetBytes((int)0).Length;
            MemoryMappedFile mmf;
            MemoryMappedViewStream mmv;
            public string FilePath { get; private set; }
            public long InitialSize { get; private set; }
            public long CurrentSize { get; private set; }
            public string MapName { get; private set; }
            public PageFile(string path,long size)
            {
                FilePath = path;
                InitialSize = size;
                if (File.Exists(path)) File.Delete(path);
                MapName = Guid.NewGuid().ToString();
                mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Create, MapName, size);
                mmv = mmf.CreateViewStream(0, size);
            }
            
            public void GrowTo(long size)
            {
                if (size<=CurrentSize) return;
                mmv.Dispose();
                mmf.Dispose();
                mmf = MemoryMappedFile.CreateFromFile(FilePath, FileMode.OpenOrCreate, MapName, size);
                CurrentSize = size;
                mmv = mmf.CreateViewStream(0, size);
            }
            
            public void Seek(long position)
            {
                mmv.Position = position;
            }
            public void Write(int number)
            {
                mmv.Write(BitConverter.GetBytes(number),0,IntSizeInBytes);
            }
            public void Write(string text)
            {
                byte[] bytes = text.ToByteArray();
                mmv.Write(bytes,0,bytes.Length);
            }
            public string ReadString()
            {
                byte[] bytes=new byte[IntSizeInBytes];
                mmv.Read(bytes, 0, IntSizeInBytes);
                int stringNumBytes = bytes.ToInt();
                bytes=new byte[stringNumBytes];
                mmv.Read(bytes, 0, stringNumBytes);
                return bytes.BytesToString();
            }
            public void Write(long position,byte[] bytes)
            {
                int len = bytes.Length;
                if (position+len > CurrentSize) GrowTo(Math.Max(CurrentSize + len, CurrentSize*2));
                Seek(position);
                mmv.Write(bytes,0,len);
            }
            public void Write(byte[] bytes)
            {
                int len = bytes.Length;
                mmv.Write(bytes, 0, len);
            }
            public byte[] Read(long position,int length)
            {
                Seek(position);
                byte[] bytes=new byte[length];
                mmv.Read(bytes, 0, length);
                return bytes;
            }
        }
        
    }
    public static class Extensions
    {
        public static byte[] ToByteArray(this string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
        public static byte[] ToByteArray(this int number)
        {
            return BitConverter.GetBytes(number);
        }
        public static int ToInt(this byte[] array)
        {
            return BitConverter.ToInt32(array, 0);
        }
        public static string BytesToString(this byte[] array)
        {
            return Encoding.UTF8.GetString(array);
        }
    }
}

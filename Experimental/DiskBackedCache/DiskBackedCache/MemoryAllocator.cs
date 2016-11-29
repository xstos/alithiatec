///
/// Memory Allocator
/// Jeff Tanner, jeff_tanner@earthlink.net
/// Seattle
/// http://sites.google.com/site/jeff00seattle/Home/c-sharp-coding/cs-memory-allocator
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DiskBackedCache
{
    /// <summary>
    /// Memory Block
    /// </summary>
    public sealed class MemoryBlock
    {
        public int BlockAddress { get; set; }
        public int BlockSize { get; set; }
        public MemoryBlock()
        {
            this.BlockAddress = int.MinValue;
            this.BlockSize = int.MinValue;
        }

        /// <summary>
        /// Define as Null if neither block address nor block size are defined.
        /// </summary>
        /// <returns></returns>
        public bool IsNull()
        {
            return (int.MinValue == this.BlockAddress || int.MinValue == this.BlockSize);
        }
        public override string ToString()
        {
            return String.Format("[{0} {1}], ", this.BlockAddress, this.BlockSize);
        }
        public static void Print(MemoryBlock mb)
        {
            Console.Write(mb);
        }
    }

    /// <summary>
    /// Memory Allocator
    /// </summary>
    public class MemoryAllocator
    {
        /// <summary>
        /// Memory Buffer. Available memory separated by Block Size
        /// </summary>
        public Dictionary<int, List<int>> MemoryPool { get; private set; }

        /// <summary>
        /// Print currently available blocks of memory
        /// sorted by address.
        /// </summary>
        /// <param name="ma"></param>
        public static void Print(MemoryAllocator ma)
        {
            IEnumerable<MemoryBlock> listMemoryBlocks
              = from n in ma.MemoryPool
                from d in n.Value
                select new MemoryBlock() { BlockSize = n.Key, BlockAddress = d };
            List<MemoryBlock> lstTmp = listMemoryBlocks.ToList();
            lstTmp.Sort(delegate(MemoryBlock mb1, MemoryBlock mb2) { return mb2.BlockAddress - mb1.BlockAddress; });
            lstTmp.ForEach(MemoryBlock.Print);
        }

        /// <summary>
        /// Property: Maximum memory size.
        /// </summary>
        public int MaxMemoryPool { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MemoryAllocator(int iMaxMemoryPool)
        {
            this.MaxMemoryPool = iMaxMemoryPool;
            this.Init();
        }

        /// <summary>
        /// Initialize memory block based upon MaxMemoryPool.
        /// </summary>
        private void Init()
        {
            this.MemoryPool = new Dictionary<int, List<int>>();
            this.MemoryPool.Add(this.MaxMemoryPool, new List<int>() { 0 });
        }

        /// <summary>
        /// Allocate a block of memory based upon a best fit policy.
        /// </summary>
        /// <param name="iBlockSizeRequest"></param>
        /// <returns></returns>
        public MemoryBlock Allocate(int iBlockSizeRequest)
        {
            try
            {
                IEnumerable<KeyValuePair<int, List<int>>> availableMemoryBlocks =
                   from entry in MemoryPool
                   where (entry.Key) >= iBlockSizeRequest
                   orderby entry.Key ascending
                   select entry;
                if (0 == availableMemoryBlocks.Count())
                {
                    return new MemoryBlock();
                }
                KeyValuePair<int, List<int>> smallestBlocks = availableMemoryBlocks.First();
                int iBlockSize = smallestBlocks.Key;
                int iBlockAddress = smallestBlocks.Value.First();
                smallestBlocks.Value.RemoveAt(0);

                if (0 == smallestBlocks.Value.Count())
                {
                    MemoryPool.Remove(iBlockSize);
                }

                if (iBlockSize > iBlockSizeRequest)
                {
                    int iBlockRemainderSize = iBlockSize - iBlockSizeRequest;
                    int iBlockRemainderAddress = iBlockAddress + iBlockSizeRequest;
                    if (MemoryPool.ContainsKey(iBlockRemainderSize))
                    {
                        Debug.Assert(!MemoryPool[iBlockRemainderSize].Contains(iBlockRemainderAddress));
                        MemoryPool[iBlockRemainderSize].Add(iBlockRemainderAddress);
                    }
                    else
                    {
                        MemoryPool.Add(iBlockRemainderSize, new List<int>() { iBlockRemainderAddress });
                    }
                }
                return new MemoryBlock() { BlockAddress = iBlockAddress, BlockSize = iBlockSizeRequest };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Free memory back into memory buffer.
        /// </summary>
        /// <param name="m"></param>
        public void Free(MemoryBlock m)
        {
            if (null == m || m.IsNull())
            {
                return;
            }
            try
            {
                int iBlockAddressStart = m.BlockAddress;
                int iBlockAddressEnd = m.BlockAddress + m.BlockSize;
                int iMergeBlockSize = m.BlockSize;
                int iMergeBlockAddress = m.BlockAddress;
                // If Block Address is already available, then ignore
                foreach (KeyValuePair<int, List<int>> kvp in MemoryPool)
                {
                    if (kvp.Value.Contains(m.BlockAddress))
                    {
                        return;
                    }
                }
                // Merge with existing block with start of address
                bool fMergeStart = false;
                int iMergeStartBlockSize = 0;
                int iMergeStartBlockAddress = 0;
                foreach (KeyValuePair<int, List<int>> kvp in MemoryPool)
                {
                    int iBlockSize = kvp.Key;
                    foreach (int iBlockAddress in kvp.Value)
                    {
                        if (iBlockAddress > iBlockAddressStart)
                        {
                            continue;
                        }
                        if (iBlockSize + iBlockAddress == iBlockAddressStart)
                        {
                            fMergeStart = true;
                            iMergeStartBlockSize = iBlockSize;
                            iMergeStartBlockAddress = iBlockAddress;
                            MemoryPool[iBlockSize].Remove(iBlockAddress);
                            if (0 == MemoryPool[iBlockSize].Count())
                            {
                                MemoryPool.Remove(iBlockSize);
                            }
                            break;
                        }
                    }
                    if (fMergeStart)
                    {
                        break;
                    }
                }

                // Merge existing block with the end of the block
                if (fMergeStart)
                {
                    iMergeBlockSize += iMergeStartBlockSize;
                    iMergeBlockAddress = iMergeStartBlockAddress;
                }

                bool fMergeEnd = false;
                int iMergeEndBlockSize = 0;
                int iMergeEndBlockAddress = 0;
                IEnumerable<KeyValuePair<int, List<int>>> availableMemoryBlocksWithAddressEnd =
                   from entry in MemoryPool
                   where (entry.Value.Contains(iBlockAddressEnd))
                   select entry;

                if (0 < availableMemoryBlocksWithAddressEnd.Count())
                {
                    fMergeEnd = true;
                    KeyValuePair<int, List<int>> kvp = availableMemoryBlocksWithAddressEnd.First();
                    iMergeEndBlockSize = kvp.Key;
                    iMergeEndBlockAddress = iBlockAddressEnd;
                    Debug.Assert(MemoryPool[iMergeEndBlockSize].Contains(iMergeEndBlockAddress));
                    MemoryPool[iMergeEndBlockSize].Remove(iMergeEndBlockAddress);
                    if (0 == MemoryPool[iMergeEndBlockSize].Count)
                    {
                        MemoryPool.Remove(iMergeEndBlockSize);
                    }
                }

                if (fMergeEnd)
                {
                    iMergeBlockSize += iMergeEndBlockSize;
                }

                if (MemoryPool.Keys.Contains(iMergeBlockSize))
                {
                    MemoryPool[iMergeBlockSize].Add(iMergeBlockAddress);
                }
                else
                {
                    MemoryPool.Add(iMergeBlockSize, new List<int>() { iMergeBlockAddress });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private const long histogramSize = 100000000; //100 mil
        const int  numMatrixColumns = 100000;
        private const int numMatrixRows = numMatrixColumns;
        const int longSizeBytes = sizeof(long);
        private const int rowBufferSize = numMatrixColumns*longSizeBytes;
        private string matrixFile = @"c:\matrix.bin";
        private string resultsFile = @"c:\matrix.results.txt";

        IEnumerable<long[]> GetMatrixFileRowEnumerator()
        {
            var file = File.OpenRead(matrixFile);
            byte[] buffer = new byte[rowBufferSize];
            long[] result = new long[numMatrixColumns];
            for (int i = 0; i < numMatrixRows; i++)
            {
                file.Seek((long)rowBufferSize * i, SeekOrigin.Begin);
                file.Read(buffer, 0, rowBufferSize);
                Buffer.BlockCopy(buffer, 0, result, 0, rowBufferSize);
                yield return result;
            }
            file.Close();
        }

        void readMultiplicationTableFromDiskCalculateHistogramAndWriteResultsToFile()
        {
            StreamWriter sw = new StreamWriter(resultsFile, false);
            long histogramLowerBound=1, histogramUpperBound=histogramSize, number;
            var numPasses = ((long)numMatrixColumns * numMatrixRows) / histogramSize;
            for (int pass = 1; pass <= numPasses; pass++)
            {
                int[] histogram = new int[histogramSize];
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                foreach (var matrixRow in GetMatrixFileRowEnumerator())
                {
                    for (int i = 0; i < matrixRow.Length; i++)
                    {
                        number = matrixRow[i];
                        if (number >= histogramLowerBound && number <= histogramUpperBound)
                        {
                            histogram[number - histogramLowerBound]++; //count the occurence (no need for hash table as we'd waste space, array is tighter)
                        }
                    }
                }
                stopwatch.Stop();
                Text = "Pass "+pass+" took " + stopwatch.Elapsed.ToString();
                Refresh();
                for (int i = 0; i < histogramSize; i++)
                {
                    sw.WriteLine((histogramLowerBound + i) + " " + histogram[i]); //write out results as number #occurences 
                }
                sw.Flush();
                histogramLowerBound += histogramSize;
                histogramUpperBound += histogramSize;
            }
            sw.Close();
        }
        
        void doMultiplicationsAndWriteToDisk()
        {
            long[] topRow = new long[numMatrixColumns];
            for (int i = 0; i < topRow.Length; i++)
            {
                topRow[i] = i + 1; //fill top row with 1 to 100K
            }
            
            var file = File.OpenWrite(matrixFile);
            
            for (int i = 0; i < numMatrixRows; i++)
            {
                long[] row = new long[numMatrixColumns]; //clone 1:100000 array to do math on
                Buffer.BlockCopy(topRow, 0, row, 0, rowBufferSize);

                long currentRowMultiplier = i + 1; 
                for (int j = 0; j < numMatrixColumns; j++)
                {
                    row[j] *= currentRowMultiplier; //do multiplications for this row
                }
                byte[] buffer = new byte[rowBufferSize];
                Buffer.BlockCopy(row, 0, buffer, 0, rowBufferSize);
                file.Write(buffer, 0, rowBufferSize); // write row's bytes to file
            }
            file.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doMultiplicationsAndWriteToDisk();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readMultiplicationTableFromDiskCalculateHistogramAndWriteResultsToFile();
        }
    }
}

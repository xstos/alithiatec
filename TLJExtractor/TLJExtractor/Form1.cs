
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using AlithiaLib;
namespace TLJExtractor {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void uiBtn_Click(object sender, EventArgs e) {

		}

		void dc_LoadComplete(System.IO.DirectoryInfo[] folders, System.IO.FileInfo[] files) {
			for (int i = 0; i < files.Length; i++) {
				if (files[i].Extension.ToLower() == ".iss" | files[i].Extension.ToLower() == ".xarc")
					try {
						DoStuff(files[i].FullName);
					} catch (Exception ex) {
						toolStripStatusLabel1.Text = ex.Message;
						Console.WriteLine(ex.Message);
					}
			}
			toolStripStatusLabel1.Text = "DONE";
		}

		char[] chars = "IMA_ADPCM_Sound".ToCharArray();
		int fc = 0;
		void DoStuff(string path) {
			int blockSize;
			string fileID;
			int outSize;
			int channels;
			int uk1, uk2;
			int rateDiv;
			string ver;
			int size;
			char temp;
			string name;
			MemoryStream ms;
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
				ms = new MemoryStream(AlithiaLib.IO.GetBytes(fs));
			}
			BinaryReader br = new BinaryReader(ms, Encoding.ASCII);
			while (AlithiaLib.IO.FindString(br, chars)) {
				temp = br.ReadChar();
				blockSize = int.Parse(ReadTilSpace(br));
				fileID = ReadTilSpace(br).TrimEnd('\0');
				outSize = int.Parse(ReadTilSpace(br));
				channels = int.Parse(ReadTilSpace(br)) + 1;
				uk1 = int.Parse(ReadTilSpace(br));
				rateDiv = int.Parse(ReadTilSpace(br));
				uk2 = int.Parse(ReadTilSpace(br));
				ver = ReadTilSpace(br);
				size = int.Parse(ReadTilSpace(br));
				name = Path.Combine(uiBtnOutput.Text, fileID);
				name = string.Format("{0}{1}{2}{3}{4}", name, "_", fc, "_", ".wav");
				fc++;
				toolStripStatusLabel1.Text = string.Format("{0} {1}", path, fileID);
				Console.Write(string.Concat(path, " - ", fileID));
				if (channels == 2) {
					short[] wavData;
					Console.Write(" STEREO FILE FOUND");
					wavData = IMA_ADPCM_Decompress_stereo(br, blockSize, size);
					byte[] outBytes = new byte[wavData.Length * 2 + 44];
					ms = new MemoryStream(outBytes);
					BinaryWriter bw = new BinaryWriter(ms, Encoding.ASCII);
					WriteWaveHeader(bw, wavData.Length * 2 + 36, 2, 44100 / rateDiv, wavData.Length * 2, 16);
					for (int i = 0; i < wavData.Length; i++) {
						bw.Write(wavData[i]);
					}
					using (FileStream fsout = new FileStream(name, FileMode.Create)) {
						fsout.Write(outBytes, 0, outBytes.Length);
					}
				}
				Console.WriteLine();
			}

		}

		byte HINIBBLE(int input) {
			int hi = input >> 4;
			return (byte)hi;
		}
		byte LONIBBLE(int input) {
			int low = input & 15;
			return (byte)low;
		}
		short[] IMA_ADPCM_Decompress_stereo(BinaryReader br, int blockSize, int totalSize) {
			List<short> wavData = new List<short>();
			int numBlocks = totalSize / blockSize;
			int lIndexLeft, lIndexRight, lCurSampleLeft, lCurSampleRight;
			for (int j = 0; j < numBlocks; j++) {
				//read headers
				lCurSampleLeft = br.ReadInt16();
				lIndexLeft = br.ReadInt16();
				lCurSampleRight = br.ReadInt16();
				lIndexRight = br.ReadInt16();

				for (int i = 8; i < blockSize; i++) {
					byte Input = br.ReadByte(); // current byte of compressed data
					byte Code;
					int Delta;

					Code = HINIBBLE(Input); // get HIGHER 4-bit nibble

					Delta = StepTable[lIndexLeft] >> 3;
					if ((Code & 4) > 0) Delta += StepTable[lIndexLeft];
					if ((Code & 2) > 0) Delta += StepTable[lIndexLeft] >> 1;
					if ((Code & 1) > 0) Delta += StepTable[lIndexLeft] >> 2;
					if ((Code & 8) > 0) lCurSampleLeft -= Delta; // sign bit 
					else lCurSampleLeft += Delta;

					// clip sample
					if (lCurSampleLeft > 32767) lCurSampleLeft = 32767;
					else if (lCurSampleLeft < -32768) lCurSampleLeft = -32768;

					lIndexLeft += IndexAdjust[Code]; // adjust index

					// clip index
					if (lIndexLeft < 0) lIndexLeft = 0;
					else if (lIndexLeft > 88) lIndexLeft = 88;

					Code = LONIBBLE(Input); // get LOWER 4-bit nibble

					Delta = StepTable[lIndexRight] >> 3;
					if ((Code & 4) > 0) Delta += StepTable[lIndexRight];
					if ((Code & 2) > 0) Delta += StepTable[lIndexRight] >> 1;
					if ((Code & 1) > 0) Delta += StepTable[lIndexRight] >> 2;
					if ((Code & 8) > 0) lCurSampleRight -= Delta; // sign bit
					else lCurSampleRight += Delta;

					// clip sample
					if (lCurSampleRight > 32767) lCurSampleRight = 32767;
					else if (lCurSampleRight < -32768) lCurSampleRight = -32768;
					lIndexRight += IndexAdjust[Code]; // adjust index

					// clip index
					if (lIndexRight < 0) lIndexRight = 0;
					else if (lIndexRight > 88) lIndexRight = 88;

					// Now we've got lCurSampleLeft and lCurSampleRight which form one stereo
					// sample and all is set for the next input byte...
					wavData.Add((short)lCurSampleLeft);
					wavData.Add((short)lCurSampleRight);
				}
			}

			return wavData.ToArray();
		}

		int[] IndexAdjust = new int[] { -1, -1, -1, -1, 2, 4, 6, 8, -1, -1, -1, -1, 2, 4, 6, 8 };
		int[] StepTable = new int[] 
{
   7,	   8,	  9,	 10,	11,    12,     13,    14,    16,
   17,    19,	  21,	 23,	25,    28,     31,    34,    37,
   41,    45,	  50,	 55,	60,    66,     73,    80,    88,
   97,    107,   118,	 130,	143,   157,    173,   190,   209,
   230,   253,   279,	 307,	337,   371,    408,   449,   494,
   544,   598,   658,	 724,	796,   876,    963,   1060,  1166,
   1282,  1411,  1552,  1707,	1878,  2066,   2272,  2499,  2749,
   3024,  3327,  3660,  4026,	4428,  4871,   5358,  5894,  6484,
   7132,  7845,  8630,  9493,	10442, 11487,  12635, 13899, 15289,
   16818, 18500, 20350, 22385, 24623, 27086,  29794, 32767
};

		string ReadTilSpace(BinaryReader br) {
			char read;
			List<char> chars = new List<char>();
			do {
				read = br.ReadChar();
				if (read != ' ') chars.Add(read);
			} while (read != ' ');
			return new string(chars.ToArray());
		}

		void WriteWaveHeader(BinaryWriter bw, int length, short channels, int samplerate, int DataLength, short BitsPerSample) {
			bw.Write(new char[4] { 'R', 'I', 'F', 'F' });
			bw.Write(length);
			bw.Write(new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' }); //8
			bw.Write((int)16); //4
			bw.Write((short)1); //2
			bw.Write(channels); //2
			bw.Write(samplerate); //4
			bw.Write((int)(samplerate * ((BitsPerSample * channels) / 8))); //4
			bw.Write((short)((BitsPerSample * channels) / 8)); //2
			bw.Write(BitsPerSample); //2
			bw.Write(new char[4] { 'd', 'a', 't', 'a' }); //4
			bw.Write(DataLength); //4
		}

		private void Form1_Load(object sender, EventArgs e) {
			this.Activate();
			if (Directory.Exists(@"c:\program files\tlj\")) uiBtnSource.Text = @"c:\program files\tlj\";
			else uiBtnSource.Text = System.Reflection.Assembly.GetExecutingAssembly().Location;
			uiBtnOutput.Text = System.Reflection.Assembly.GetExecutingAssembly().Location;
		}

		private void uiBtnSource_Click(object sender, EventArgs e) {
			if (uiFolderBrowser.ShowDialog() != DialogResult.Cancel) {
				uiBtnSource.Text = uiFolderBrowser.SelectedPath;
			}

		}

		private void uiBtnOutput_Click(object sender, EventArgs e) {
			if (uiFolderBrowser.ShowDialog() != DialogResult.Cancel) {
				uiBtnOutput.Text = uiFolderBrowser.SelectedPath;
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			AlithiaLib.IO.DiskCache dc = new IO.DiskCache();
			dc.LoadComplete += new IO.DiskCache.LoadCompleteDelegate(dc_LoadComplete);
			if (Directory.Exists(uiBtnSource.Text) & Directory.Exists(uiBtnOutput.Text)) dc.Load(uiBtnSource.Text);
			else toolStripStatusLabel1.Text = "Source or output directory has been deleted. Re-select it.";
		}

	}
}
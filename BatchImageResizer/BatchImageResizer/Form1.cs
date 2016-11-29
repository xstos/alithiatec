using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatchImageResizer
{
    public partial class Form1 : Form
    {
        private FileDragDropHandler ddh;
        public Form1()
        {
            InitializeComponent();
            ddh=new FileDragDropHandler(dataGridView1);
            ddh.FilesDropped += new DragDropOccured(ddh_FilesDropped);
            textBox1.Text = "50";
        }

        void ddh_FilesDropped(string[] files)
        {
            dataGridView1.Rows.Clear();
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    Image bitmap = Image.FromStream(stream,true,false);
                    dataGridView1.Rows.Add(fileInfo.Name, fileInfo.Directory.FullName, bitmap.Width, bitmap.Height, bitmap.Width, bitmap.Height);
                }
            }
            textBox1_TextChanged(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double factor;
            if (!double.TryParse(textBox1.Text,out factor)) factor = 100;
            factor = factor/100;
            if (factor <= 0) factor = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["ColNewWidth"].Value = (int)((int)row.Cells["ColWidth"].Value * factor);
                row.Cells["ColNewHeight"].Value = (int)((int)row.Cells["ColHeight"].Value * factor);
            }
        }
        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");
            if (jpegCodec == null)
            {
                MessageBox.Show("jpeg codec not found. cannot proceed");
                return;
            }
            button1.Enabled = false;
            textBox1.Enabled = false;
            int quality;
            if (!int.TryParse(textBox2.Text, out quality) || quality <= 0)
            {
                quality = 100;
                textBox2.Text = quality.ToString();
            }
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                FileInfo fileInfo = new FileInfo(Path.Combine((string)row.Cells["ColPath"].Value,(string)row.Cells["ColName"].Value));
                using (FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
                {
                    Image bitmap = Image.FromStream(stream, true, false);
                    Bitmap b = new Bitmap((int)row.Cells["ColNewWidth"].Value, (int)row.Cells["ColNewHeight"].Value);
                    Graphics g = Graphics.FromImage(b);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(bitmap, 0, 0, b.Width, b.Height);
                    b.Save(Path.Combine(fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(fileInfo.FullName) + "_resized" + ".jpg"),
                        jpegCodec, encoderParams);
                }
                Text = "processing " + fileInfo.FullName;
                Application.DoEvents();
            }
            Text = "PROCESSING COMPLETE";
            button1.Enabled = true;
            textBox1.Enabled = true;
        }
    }
}

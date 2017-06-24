using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Mono.Security;
namespace PfxToSnk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileDragDropHandler f1=new FileDragDropHandler(textBox1);
            f1.FilesDropped += new DragDropOccured(f1_FilesDropped);
            FileDragDropHandler f2 = new FileDragDropHandler(textBox3);
            f2.FilesDropped += new DragDropOccured(f2_FilesDropped);
        }

        void f2_FilesDropped(string[] files)
        {
            textBox3.Text = files.FirstOrDefault();
        }

        void f1_FilesDropped(string[] files)
        {
            textBox1.Text = files.FirstOrDefault();
            textBox3.Text = textBox1.Text + ".snk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(textBox1.Text, textBox2.Text, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                RSACryptoServiceProvider provider = (RSACryptoServiceProvider)cert.PrivateKey;

                byte[] array = provider.ExportCspBlob(!provider.PublicOnly);

                using (FileStream fs = new FileStream(textBox3.Text, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(array, 0, array.Length);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            //code needs to be put in a method
            

        }
    }
}

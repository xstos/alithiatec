using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace VPNKeepAlive
{
    public partial class Form1 : Form
    {
        public static Timer timer=new Timer();
        public MySettings mySettings=new MySettings();
        
        public Form1()
        {
            InitializeComponent();
        }

        void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        
        public void StartMonitoring()
        {
            timer.Interval = (int)mySettings.PingFrequency.TotalMilliseconds;
            timer.Start();
            Trace.WriteLine("starting keep alive timer ping every "+mySettings.PingFrequency);
            mySettings.Started = true;
        }
        public void StopMonitoring()
        {
            timer.Stop();
            mySettings.Started = false;
            Trace.WriteLine("stopping keep alive timer");
        }
        void readSettings()
        {
            if (File.Exists("settings.xml"))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer ser = new XmlSerializer(typeof(MySettings));
                    using (System.IO.StreamReader sr = new StreamReader("settings.xml"))
                    {
                        mySettings = (MySettings)ser.Deserialize(sr);
                    }
                }
                catch (Exception ee)
                {
                    File.Delete("settings.xml");
                    Trace.WriteLine(ee.ToString());
                }
            }
        }
        void writeSettings()
        {
            using (System.IO.StreamWriter sw = new StreamWriter("settings.xml"))
            {
                System.Xml.Serialization.XmlSerializer ser = new XmlSerializer(typeof (MySettings));
                ser.Serialize(sw, mySettings);
                sw.Close();
            }
            
        }
        
        string connectcmd = "rasdial \"{0}\" {1} {2} /DOMAIN:{3}";
        string disconnectcmd = "rasdial \"{0}\" /disconnect";
        void Reconnect()
        {
            string pass = mySettings.Password;
            string cxstr = string.Format(connectcmd, mySettings.VPNConnectionName, mySettings.Username, pass,
                                         mySettings.Domain);
            Util.DisplayFilter = s => s.Replace(cxstr,
                string.Format(connectcmd, mySettings.VPNConnectionName, mySettings.Username, "********", mySettings.Domain) );
            Util.ExecuteCommand(string.Format(disconnectcmd, mySettings.VPNConnectionName),this,true);
            Util.ExecuteCommand(cxstr, this, false);
        }
        void TimerTick(object sender, EventArgs e)
        {
            try
            {
                if (!Util.Ping(IPAddress.Parse(mySettings.PingServer)))
                {
                    Trace.WriteLine("Ping failed", "Attempting reconnect");
                    Reconnect();
                }
            }
            catch (Exception ee)
            {
                StopMonitoring();
            }
            
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(500); //annoying
                Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBoxTraceListener tbtl = new TextBoxTraceListener(textBox1);
            Trace.Listeners.Add(tbtl);
            TextBoxStreamWriter tbsw = new TextBoxStreamWriter(textBox1);
            Console.SetOut(tbsw);
            readSettings();
            propertyGrid1.SelectedObject = mySettings;
            timer.Tick += TimerTick;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            writeSettings();
            switch (e.ChangedItem.PropertyDescriptor.Name)
            {
                case "Started":
                    if ((bool)e.ChangedItem.Value) StartMonitoring();
                    else StopMonitoring();
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
            textBox1.Refresh();
        }
    }
    public class MySettings
    {
        [DisplayName("\t\tVPN Connection Name"), Category("General")]
        public string VPNConnectionName { get; set; }

        private string _pingServer="127.0.0.1";
        [DisplayName("\tPing Server IP Address"), Category("General"), Description("the server IP address to ping as an indicator the connection is still alive")]
        public string PingServer
        {
            get { return _pingServer; }
            set
            {
                IPAddress addr;
                if (IPAddress.TryParse(value, out addr)) _pingServer = addr.ToString();
            }
        }

        [Browsable(false)]
        public long PingFrequencyTicks { get; set; }
        [DisplayName("Ping Frequency (s)"), Category("General"), Description("how often to ping in hh:mm:ss"),XmlIgnore]
        public TimeSpan PingFrequency
        {
            get { return new TimeSpan(PingFrequencyTicks); }
            set { PingFrequencyTicks = value.Ticks; }
        }

        [DisplayName("\t\tUser Name"), Category("Authentication")]
        public string Username { get; set; }
        [DisplayName("\tPassword"), Category("Authentication"), PasswordPropertyText(true),XmlIgnore] 
        public string Password { get; set; }
        [DisplayName("Domain"), Category("Authentication")]
        public string Domain { get; set; }

        [DisplayName("Running"), Category("Actions"),
         Description("when true, runs the ping at the selected interval and keeps the connection alive"),XmlIgnore]
        public bool Started { get; set; }
        public MySettings()
        {
            PingFrequency=new TimeSpan(0,0,10);
            VPNConnectionName = "VPN Connection";
        }
    }
}

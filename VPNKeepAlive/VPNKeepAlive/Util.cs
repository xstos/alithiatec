using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using TestProcessCaller;

namespace VPNKeepAlive
{
    public static class Util
    {
        public static PingReply Ping(IPAddress address)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            int timeout = 120; 
            try
            {
                return pingSender.Send(address, timeout, Encoding.ASCII.GetBytes("BADBEEFBADBEEFBADBEEFBADBEEFBADB"), options);
            }
            catch (Exception ee)
            {
                Trace.WriteLine(ee.ToString());
                throw;
            }
        }

        public static displayFilterDelegate DisplayFilter;
        public static void ExecuteCommand(string Command,ISynchronizeInvoke isi,bool wait)
        {
            string cmdText = Command;
            if (DisplayFilter != null) cmdText = DisplayFilter(cmdText);
            Trace.WriteLine("executing command: "+ cmdText);
            ProcessCaller processCaller;
            processCaller = new ProcessCaller(isi);
            processCaller.FileName = @"cmd.exe";
            processCaller.Arguments = "/C " + Command;
            processCaller.StdOutReceived += processCaller_StdOutReceived;
            processCaller.StdErrReceived += processCaller_StdOutReceived;
            processCaller.Start();
            if (wait) processCaller.WaitUntilDone();
        }

        public delegate string displayFilterDelegate(string input);

        static void processCaller_StdOutReceived(object sender, TestProcessCaller.DataReceivedEventArgs e)
        {
            string text = e.Text;
            if (DisplayFilter != null) text = DisplayFilter(text);
            Trace.WriteLine(text);
        }

    }
}

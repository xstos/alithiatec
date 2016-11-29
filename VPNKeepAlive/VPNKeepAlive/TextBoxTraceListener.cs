using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VPNKeepAlive
{
    public class TextBoxTraceListener : TraceListener
    {
        private TextBox _target;
        private StringSendDelegate _invokeWrite;

        public TextBoxTraceListener(TextBox target)
        {
            _target = target;
            _invokeWrite = new StringSendDelegate(SendString);
        }

        public override void Write(string message)
        {
            _target.Invoke(_invokeWrite, new object[] { message });
        }

        public override void WriteLine(string message)
        {
            _target.Invoke(_invokeWrite, new object[] { message + Environment.NewLine });
        }

        private delegate void StringSendDelegate(string message);
        private void SendString(string message)
        {
            // No need to lock text box as this function will only 

            // ever be executed from the UI thread

            _target.Text += DateTime.Now+ " "+ message;
        }
    }
    public class TextBoxStreamWriter : TextWriter
	    {
	        TextBox _output = null;
	 
	        public TextBoxStreamWriter(TextBox output)
	        {
	            _output = output;
	        }
	 
	        public override void Write(char value)
	        {
	            base.Write(value);
	            _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
	        }
	 
	        public override Encoding Encoding
	        {
	            get { return System.Text.Encoding.UTF8; }
	        }
	    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace TestProcessCaller
{
	/// <summary>
	/// A simple form to launch a process using ProcessCaller
	/// and display all StdOut and StdErr in a RichTextBox.
	/// </summary>
	/// <remarks>
    /// Special thanks to Chad Christensen for suggestions
    /// on using the RichTextBox.
    /// Note there are a lot of issues with scrolling on a
    /// RichTextBox, depending upon if the cursor (selection point) 
    /// is in the RichTextBox or not, and if it is hidden or not.
    /// I've disabled the RichTextBox tabstop so that the cursor isn't
    /// automatically placed in the text box.
    /// Now setting or unsetting:
    ///    richTextBox1.HideSelection
    /// will affect if the textbox is always repositioned at the bottom
    ///   when new text is entered.
	/// </remarks>
    public class ProgressForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        // Note: richtext box can hold much longer text than a plain textbox.
        private System.Windows.Forms.RichTextBox richTextBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProgressForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

		#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.btnOk.Location = new System.Drawing.Point(286, 192);
            this.btnOk.Name = "btnOk";
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(190, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(32, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(328, 144);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // ProgressForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(386, 248);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.richTextBox1,
                                                                          this.btnCancel,
                                                                          this.btnOk});
            this.Name = "ProgressForm";
            this.Text = "ProgressForm";
            this.ResumeLayout(false);

        }

        #endregion


        private ProcessCaller processCaller;

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            this.btnOk.Enabled = false;  

            processCaller = new ProcessCaller(this);
            //processCaller.FileName = @"..\..\hello.bat";
            processCaller.FileName = @"..\..\SmallConsoleProgram.exe";
            processCaller.Arguments = "";
            processCaller.StdErrReceived += new DataReceivedHandler(writeStreamInfo);
            processCaller.StdOutReceived += new DataReceivedHandler(writeStreamInfo);
            processCaller.Completed += new EventHandler(processCompletedOrCanceled);
            processCaller.Cancelled += new EventHandler(processCompletedOrCanceled);
            // processCaller.Failed += no event handler for this one, yet.
            
            this.richTextBox1.Text = "Started function.  Please stand by.." + Environment.NewLine;

            // the following function starts a process and returns immediately,
            // thus allowing the form to stay responsive.
            processCaller.Start();  
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (processCaller != null)
            {
                processCaller.Cancel();
            }
        }

        /// <summary>
        /// Handles the events of StdErrReceived and StdOutReceived.
        /// </summary>
        /// <remarks>
        /// If stderr were handled in a separate function, it could possibly
        /// be displayed in red in the richText box, but that is beyond 
        /// the scope of this demo.
        /// </remarks>
        private void writeStreamInfo(object sender, DataReceivedEventArgs e)
        {
            this.richTextBox1.AppendText(e.Text + Environment.NewLine);
        }

        /// <summary>
        /// Handles the events of processCompleted & processCanceled
        /// </summary>
        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.btnOk.Enabled = true;
        }


        [STAThread]
        static void Main(string[] args)         
        {
            Application.Run(new ProgressForm());
        }

    }
}

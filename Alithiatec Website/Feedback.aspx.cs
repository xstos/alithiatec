using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
public partial class Bugs : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {

	}
	protected void Button1_Click(object sender, EventArgs e) {
		if (Util.FieldsEmpty(_message.Text)) {
			status.Text = "Error, no message text to send.";
			return;
		}
		status.Text=Util.SendMail(_senderEmail.Text,"chris@alithiatec.com","ALITHIATEC FEEDBACK: " + _subject.Text,_message.Text);
	}
	protected void Button1_Click1(object sender, EventArgs e) {
		_message.Text = "";
		_name.Text = "";
		_senderEmail.Text = "";
		_subject.Text = "";
		status.Text = "";
	}
}

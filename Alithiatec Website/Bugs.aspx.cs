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
public partial class Bugs : System.Web.UI.Page
{
	string xpath;
	protected void Page_Load(object sender, EventArgs e)
    {
		setVersion("RapidFetch");
    }
	
	protected void Button1_Click(object sender, EventArgs e) {
		if (Util.FieldsEmpty(bug.Text)) {
			status.Text = "Error, no message text to send.";
			return;
		}
		status.Text=Util.SendMail(senderEmail.Text,"chris@alithiatec.com","BUG: " + product.SelectedValue+ " " +productVersion.SelectedValue,"From: " + name.Text + "\n" +  bug.Text);
	}
	protected void Button1_Click1(object sender, EventArgs e) {
		senderEmail.Text = "";
		name.Text = "";
		bug.Text = "";
		status.Text = "";
	}
	void setVersion(string value) {
		xpath = String.Format("Data/Applications[@type='desktop']/item[@name='{0}']/release", value);
		productVersion.DataMember = "release";
		productVersion.DataTextField = "version";
		productVersion.DataValueField = "version";
		XmlDataSource2.XPath = xpath;
		productVersion.DataSourceID = "XmlDataSource2";
	}
	protected void product_SelectedIndexChanged(object sender, EventArgs e) {
		setVersion(product.SelectedValue);
	}
	protected void productVersion_Load(object sender, EventArgs e) {
		
	}
	protected void product_Init(object sender, EventArgs e) {
		
	}
	protected void product_PreRender(object sender, EventArgs e) {
		
	}
	
}

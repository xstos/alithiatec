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

public partial class ThumbPane : System.Web.UI.UserControl {
	private Util.WebFileList list = new Util.WebFileList();

	public string SearchPatterns {
		get { return list.SearchPatterns; }
		set { list.SearchPatterns = value; }
	}

	public string Path {
		get { return list.Path; }
		set { list.Path = value; }
	}
	protected void Page_Load(object sender, EventArgs e) {
		list.Read(this);
		Bright.WebControls.ThumbViewer tv;
		HyperLink hl;
		string url;
		for (int i = 0; i < list.Files.Count; i++) {
			tv = new Bright.WebControls.ThumbViewer();
			tv.ModalDisplayMode = Bright.WebControls.ThumbViewer.ModalDisplayModeOptions.Disabled;
			url=list.Files[i].NavigateUrl;
			tv.ImageUrl = url;
			hl = new HyperLink();
			hl.Controls.Add(tv);
			hl.NavigateUrl = "javascript:popImage('"+url+"','"+url+"')";
			Panel1.Controls.Add(hl);
		}
	}
	
}

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
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
public partial class DirectoryLister : System.Web.UI.UserControl {

	private Util.WebFileList list=new Util.WebFileList();

	public string SearchPatterns {
		get { return list.SearchPatterns; }
		set { list.SearchPatterns = value; }
	}

	public string Path {
		get { return list.Path; }
		set { list.Path=value; }
	}
	
	protected void Page_Load(object sender, EventArgs e) {
		list.Read(this);
		
		GridView1.AutoGenerateColumns = false;
		
		HyperLinkColumn urlCol = new HyperLinkColumn();
		urlCol.DataTextField = "Text";
		urlCol.DataNavigateUrlField = "NavigateUrl";
		urlCol.HeaderText = "File Name";
		
		BoundColumn size = new BoundColumn();
		size.DataField = "Size";
		size.HeaderText = "Size (Bytes)";

		BoundColumn mod = new BoundColumn();
		mod.DataField = "Modified";
		mod.HeaderText = "Last Modified";

		// Add three columns to collection.
		GridView1.Columns.Add(urlCol);
		GridView1.Columns.Add(size);
		GridView1.Columns.Add(mod);
		GridView1.DataSource = list.Files;
		GridView1.DataBind();
	}
}

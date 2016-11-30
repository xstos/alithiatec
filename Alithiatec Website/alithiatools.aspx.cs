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
using AlithiaLib;
using System.IO;
public partial class alithiatools : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {

	}

	protected void uploadButton_Click(object sender, EventArgs e) {
		//String savePath = @"c:\temp\uploads\";
		if (FileUpload1.HasFile) {
			try {
				TextReader tr = new StreamReader(FileUpload1.FileContent,System.Text.Encoding.ASCII);
				string[] line=new string[0]; 
				DataTable dt = new DataTable();
				if (tr.Peek()>-1) line = tr.ReadLine().Split('\t');
				for (int i = 0; i < line.Length; i++) {
					dt.Columns.Add(line[i]);
				}
				object[] data=new object[line.Length];
				while (tr.Peek() > -1) {
					line = tr.ReadLine().Split('\t');
					for (int i = 0; i < line.Length; i++) {
						data[i] = AlithiaLib.Str.ParseUnknown(line[i].Trim('\"'));
					}
					dt.Rows.Add(data);
				}
				GridView1.DataSource = dt;
				GridView1.DataBind();
			} catch { }
			//String fileName = FileUpload1.FileName;
			//savePath += fileName;
			//FileUpload1.SaveAs(savePath);
			//UploadStatusLabel.Text = "Your file was saved as " + fileName;
		} else {
			// Notify the user that a file was not uploaded.
			//UploadStatusLabel.Text = "You did not specify a file to upload.";
		}

	}
	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {

	}
}

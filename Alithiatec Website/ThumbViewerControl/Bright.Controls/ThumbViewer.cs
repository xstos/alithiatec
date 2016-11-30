/* --------------------------------------------------------------------------

Copyright (c) 2007 Declan Bright

This software is provided 'as-is', without any express or implied warranty. 
In no event will the authors be held liable for any damages arising from 
the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it freely, 
subject to the following restrictions:

    1. The origin of this software must not be misrepresented; you must not 
    claim that you wrote the original software. If you use this software in
    a product, an acknowledgment in the product documentation would be 
    appreciated but is not required.

    2. Altered source versions must be plainly marked as such, and must not 
    be misrepresented as being the original software.

    3. This notice may not be removed or altered from any source distribution.
 
--------------------------------------------------------------------------- */

#region Directives

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.ComponentModel;
using System.IO;
using System.Text;

#endregion

namespace Bright.WebControls
{
    /// <summary>
    /// Thumbnail Image Viewer Control
    /// </summary>
    [ToolboxData("<{0}:ThumbViewer runat=\"server\" ImageUrl=\"\" Title=\"\" Width=\"100\" Height=\"100\" />")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.Image))]
    public class ThumbViewer : System.Web.UI.WebControls.Image
    {        
        #region Properties & Fields

        #region Urls

        private string _srcImageUrl;

        [        
        Category("Appearance"),
        Description("The URL of the image."),
        DefaultValue(""),        
        Bindable(true)
        ]
        public override string ImageUrl
        {
            get
            {
                return ViewState["ImageUrl"] == null ?
                    string.Empty : ViewState["ImageUrl"].ToString();
            }
            set
            {
                ViewState["ImageUrl"] = value;
            }
        }

        [        
        Category("Appearance"),        
        Description("The URL of the thumb image."),
        DefaultValue(""),
        Bindable(true),         
        Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))
        ]
        public virtual string ThumbUrl
        {
            get
            {
                return ViewState["ThumbUrl"] == null ?
                    string.Empty : ViewState["ThumbUrl"].ToString();
            }
            set
            {
                ViewState["ThumbUrl"] = value;
            }
        }

        #endregion       

        #region Image

        [
        Category("Layout"),
        DefaultValue("100"),
        Bindable(true)        
        ]
        public override Unit Width
        {
            get
            {
                return base.Width.IsEmpty ?
                    Unit.Parse("100") : base.Width;
            }
            set
            {
                if (value.Value < 0)
                    throw new ArgumentOutOfRangeException("Width");
                base.Width = value;
            }
        }

        [
        Category("Layout"),
        DefaultValue("100"),
        Bindable(true)
        ]
        public override Unit Height
        {
            get
            {
                return base.Height.IsEmpty ? 
                    Unit.Parse("100") : base.Height;
            }
            set
            {
                if (value.Value < 0)
                    throw new ArgumentOutOfRangeException("Height");
                base.Height = value;
            }
        }

        #endregion

        #region Modal

        [        
        Category("Appearance"),
        Description("The Title of Image."),
        DefaultValue(""),
        Bindable(true)
        ]
        public virtual string Title
        {
            get
            {
                return ViewState["ImageTitle"] == null ?
                    String.Empty : ViewState["ImageTitle"].ToString();
            }
            set
            {
                ViewState["ImageTitle"] = value;
            }
        }
        
        ModalDisplayModeOptions _modalDisplayModeOption;     
        /// <summary>
        /// ModalDisplayModeOptions enum
        /// </summary>
        public enum ModalDisplayModeOptions
        {
            Stretch,
            Fixed,
            Disabled
        }

        [
        Category("Appearance"),
        Description("The display mode of the Modal Image.\nIf Stretch is selected then ModalImagePadding is applied.\nIf Fixed is selected then ModalFixedWidth and ModalFixedHeight are applied.")
        ]
        public ModalDisplayModeOptions ModalDisplayMode
        {
            get 
            { 
                return _modalDisplayModeOption; 
            }
            set 
            { 
                _modalDisplayModeOption = value; 
            }
        }            

        [
        Category("Layout"),        
        Description("The padding of the Modal Image if ModalDisplayMode is set to Stretch."),
        DefaultValue("50"),
        Bindable(true)
        ]
        public virtual Unit ModalImagePadding
        {
            get
            {
                return ViewState["ModalImagePadding"] == null ? 
                    Unit.Parse("50") : Unit.Parse(ViewState["ModalImagePadding"].ToString());
            }
            set
            {
                if (value.Value < 0) 
                    throw new ArgumentOutOfRangeException("ModalImagePadding");
                ViewState["ModalImagePadding"] = value;
            }
        }

        [
        Category("Layout"),        
        Description("The width of the Modal Image if ModalDisplayMode is set to Fixed."),
        DefaultValue("200"),
        Bindable(true)
        ]
        public virtual Unit ModalFixedWidth
        {
            get
            {
                return ViewState["ModalFixedWidth"] == null ? 
                    Unit.Parse("200") : Unit.Parse(ViewState["ModalFixedWidth"].ToString());
            }
            set
            {
                if (value.Value < 0) 
                    throw new ArgumentOutOfRangeException("ModalFixedWidth");
                ViewState["ModalFixedWidth"] = value;
            }
        }

        [
        Category("Layout"),        
        Description("The height of the Modal Image if ModalDisplayMode is set to Fixed."),
        DefaultValue("200"),
        Bindable(true)
        ]
        public virtual Unit ModalFixedHeight
        {
            get
            {
                return ViewState["ModalFixedHeight"] == null ? 
                    Unit.Parse("200") : Unit.Parse(ViewState["ModalFixedHeight"].ToString());
            }
            set
            {
                if (value.Value < 0) 
                    throw new ArgumentOutOfRangeException("ModalFixedHeight");
                ViewState["ModalFixedHeight"] = value;
            }
        }

        #endregion

        #region Other

        private string _relativeImagePath
        {
            get
            {
                return _srcImageUrl.StartsWith("~/") ? _srcImageUrl.Remove(0, 2) : _srcImageUrl;
            }
        }

        private double _aspectRatio
        {
            get
            {
                double w = (this.Width.IsEmpty ? 50 : this.Width.Value);
                double h = (this.Height.IsEmpty ? 50 : this.Height.Value);
                return h / w;
            }
        }

        #endregion
        
        #endregion

        #region OnInit

        protected override void OnInit(EventArgs e)
        {
            // Register Javascript and CSS files as the control is initialised
            SetupIncludes();

            base.OnInit(e);
        }

        #endregion

        #region Render Methods

        protected override void Render(HtmlTextWriter writer)
        {
            // Setup up the ImageUrl & ThumbUrl
            SetupUrls();

            base.Render(writer);
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (!DesignMode)
            {
                // Before the first control, write out the Modal Divs
                SetupModal(writer);
            }

            base.RenderBeginTag(writer);
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (!DesignMode)
            {
                // Setup the image Attributes
                SetupAttributes(writer);
            }

            base.AddAttributesToRender(writer);     
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Setup include files, js and css files
        /// </summary>
        private void SetupIncludes()
        {
            ClientScriptManager cs = Page.ClientScript;
            string csName = "dummyScript1";
            Type csType = this.GetType();

            if (!cs.IsStartupScriptRegistered(csType, csName))
            {
                // Register dummy startup script so that this is only added for the first control
                cs.RegisterStartupScript(csType, csName, "", true);

                // Register Javascript Resource
                cs.RegisterClientScriptInclude(
                   csType, "cs",
                   Page.ClientScript.GetWebResourceUrl(csType,
                   "Bright.WebControls.Resources.ThumbViewer.js"));

                // Add the style sheet to the document header
                string csslink = "\n<link href='" +
                   Page.ClientScript.GetWebResourceUrl(csType,
                   "Bright.WebControls.Resources.ThumbViewer.css")
                   + "' rel='stylesheet' type='text/css' />";

                LiteralControl include = new LiteralControl(csslink);
                this.Page.Header.Controls.Add(include);
            }
        }

        /// <summary>
        /// Write out the html for the Modal
        /// </summary>
        /// <param name="writer"></param>
        private void SetupModal(HtmlTextWriter writer)
        {
            ClientScriptManager cs = Page.ClientScript;
            string csName = "startupScript";
            Type csType = this.GetType();

            if (!cs.IsStartupScriptRegistered(csType, csName))
            {
                // Register startup script to set the url of the Progess.gif resource
                // This is only added for the first control
                string csScript = "pi='" + Page.ClientScript.GetWebResourceUrl(csType, "Bright.WebControls.Resources.Progress.gif") + "';";
                cs.RegisterStartupScript(csType, csName, csScript, true);

                // Add Modal html
                StringBuilder sb = new StringBuilder();
                sb.Append("<div id='modaltintdiv' style='display:none;'></div>\n\t");
                sb.Append("<div id='modalouter' onclick='javascript:closeModal();'>");
                sb.Append("<div id='modaltitle'>");
                sb.Append("<div id='modaltitleleft'></div><div id='modaltitlemiddle'><div id='imageTitle'></div></div><div id='modaltitleright'><div onclick='closeModal()'>X</div></div>");
                sb.Append("</div>");
                sb.Append("<img id='modalimage' border='0' src='' alt='' />");
                sb.Append("</div>\n\t");

                writer.Write(sb.ToString());
            }
        }

        /// <summary>
        /// Setup up the ImageUrl & ThumbUrl
        /// </summary>
        private void SetupUrls()
        {
            // If the ImageUrl is set and the ThumbUrl is not then
            // a thumbnail image needs to be generated at runtime.
            // Set the ImageUrl to the ThumbHandler.ashx and pass
            // in the appropriate paramaters
            if (ImageUrl.Length > 0 && ThumbUrl.Length == 0)
            {
                _srcImageUrl = ImageUrl;
                if (!DesignMode)
                {
                    ImageUrl = "ThumbHandler.ashx"
                        + "?i=" + ImageUrl
                        + "&w=" + Width.Value.ToString()
                        + "&h=" + Height.Value.ToString();
                }
            }
            // If both the ImageUrl and ThumbUrl are set then set the
            // ImageUrl to the ThumbUrl so that the thumb image is 
            // rendered instead of the full size image.
            else if (ThumbUrl.Length > 0 && ImageUrl.Length > 0)
            {
                _srcImageUrl = ImageUrl;
                ImageUrl = ThumbUrl;
            }
            // If the ThumbUrl is set and the ImageUrl is not then
            // set the ImageUrl to the ThumbUrl so that the thumb image 
            // is rendered. The full size image will also be the thumb 
            // image. This could used with a ModalDisplayMode of Fixed.
            else if (ThumbUrl.Length > 0 && ImageUrl.Length == 0)
            {
                _srcImageUrl = ThumbUrl;
                ImageUrl = ThumbUrl;
            }            
        }

        /// <summary>
        /// Setup the image Attributes
        /// </summary>
        /// <param name="writer"></param>
        private void SetupAttributes(HtmlTextWriter writer)
        {
            // Check that the file exists
            if (ImageUrl.Length > 0 && File.Exists(Context.Server.MapPath(_relativeImagePath)))
            {
                // Add the onclick event handler depending on the ModalDisplayModeOption
                switch (_modalDisplayModeOption)
                {
                    // If ModalDisplayMode is Stretch then write out the openModal
                    // javascript method to the Onclick event. The aspect ratio and 
                    // padding are passed as parameters and the image is displayed
                    // to the full size of the browser window with the set padding.
                    case (ModalDisplayModeOptions.Stretch):
                        writer.AddAttribute(HtmlTextWriterAttribute.Onclick,
                           "openModal('"
                           + _relativeImagePath + "', '"
                           + Title + "', "
                           + ModalImagePadding.Value.ToString() + ", "
                           + _aspectRatio.ToString() + ");");
                        break;
                    // If ModalDisplayMode is Fixed then write out the openModalDim
                    // javascript method to the Onclick event. ModalFixedWidth and 
                    // ModalFixedHeight are passed as parameters.
                    case (ModalDisplayModeOptions.Fixed):
                        writer.AddAttribute(HtmlTextWriterAttribute.Onclick,
                           "openModalDim('"
                           + _relativeImagePath + "', '"
                           + Title + "', "
                           + ModalFixedWidth.Value.ToString() + ", "
                           + ModalFixedHeight.Value.ToString() + ");");
                        break;
                    // If ModalDisplayMode is Disabled then don't add an Onclick event.
                    case (ModalDisplayModeOptions.Disabled):
                        // Do nothing
                        break;
                }
            }
            else
            {
                // If the full size image does not exits then alert the user.
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "alert('Sorry, the full size image does not exist!')");
            }

            // Add the Title as the Alternate Text attribute.
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, Title);
        }

        #endregion
    }
}

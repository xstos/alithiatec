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
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

#endregion

namespace Bright.WebControls
{
    /// <summary>
    /// Thumbnail Image Viewer Control HttpHandler
    /// </summary>
    public class ThumbHandler : IHttpHandler
	{  
        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            // Get the QueryString parameters passed
            string _imagePath = context.Request.QueryString["i"] == null ?
                string.Empty : context.Request.QueryString["i"].ToString();
            int _thumbWidth = context.Request.QueryString["w"] == null ?
                100 : int.Parse(context.Request.QueryString["w"].ToString());
            int _thumbHeight = context.Request.QueryString["h"] == null ?
                100 : int.Parse(context.Request.QueryString["h"].ToString());

            // Create a thumb image from the source image
            System.Drawing.Image _sourceImage = System.Drawing.Image.FromFile(context.Server.MapPath(_imagePath));
            System.Drawing.Image _thumbImage = this.CreateThumbnail(_sourceImage, _thumbWidth, _thumbHeight);

            // Save the thumb image to the OutputStream
            _thumbImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }

		public bool IsReusable
		{
			get { return true; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create a thumbnail image
        /// </summary>
        /// <param name="image">Full size image</param>
        /// <returns>Thumbnail image</returns>
        private System.Drawing.Image CreateThumbnail(System.Drawing.Image image, int thumbWidth, int thumbHeight)
        {
            return image.GetThumbnailImage(
                thumbWidth,
                thumbHeight, 
                delegate() { return false; }, 
                IntPtr.Zero
                );
        }

        #endregion
    }
}

using System.Windows.Forms;

namespace AlithiaLib
{
    public class CustomProfessionalToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {

            //base.OnRenderToolStripBackground(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            ToolStripLabel label = e.Item as ToolStripLabel;

            if (label != null)
            {
                TextRenderer.DrawText(e.Graphics, label.Text,
                    label.Font, e.TextRectangle,
                    label.ForeColor,
                    TextFormatFlags.EndEllipsis);
            }
            else
                base.OnRenderItemText(e);
        }
    }
}
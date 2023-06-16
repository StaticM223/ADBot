using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000027 RID: 39
	public class FlatTreeView : TreeView
	{
		// Token: 0x0600017B RID: 379 RVA: 0x00009DD4 File Offset: 0x00007FD4
		protected override void OnDrawNode(DrawTreeNodeEventArgs e)
		{
			try
			{
				Rectangle rect = new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height);
				TreeNodeStates state = this.State;
				if (state != TreeNodeStates.Selected)
				{
					if (state != TreeNodeStates.Checked)
					{
						if (state == TreeNodeStates.Default)
						{
							e.Graphics.FillRectangle(Brushes.Red, rect);
							e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8f), Brushes.LimeGreen, new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), Helpers.NearSF);
							base.Invalidate();
						}
					}
					else
					{
						e.Graphics.FillRectangle(Brushes.Green, rect);
						e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8f), Brushes.Black, new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), Helpers.NearSF);
						base.Invalidate();
					}
				}
				else
				{
					e.Graphics.FillRectangle(Brushes.Green, rect);
					e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8f), Brushes.Black, new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), Helpers.NearSF);
					base.Invalidate();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			base.OnDrawNode(e);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00009FF4 File Offset: 0x000081F4
		public FlatTreeView()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = this._BaseColor;
			this.ForeColor = Color.White;
			base.LineColor = this._LineColor;
			base.DrawMode = TreeViewDrawMode.OwnerDrawAll;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000A070 File Offset: 0x00008270
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			graphics2.DrawString(this.Text, new Font("Segoe UI", 8f), Brushes.Black, new Rectangle(base.Bounds.X + 2, base.Bounds.Y + 2, base.Bounds.Width, base.Bounds.Height), Helpers.NearSF);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000CF RID: 207
		private TreeNodeStates State;

		// Token: 0x040000D0 RID: 208
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x040000D1 RID: 209
		private Color _LineColor = Color.FromArgb(25, 27, 29);
	}
}

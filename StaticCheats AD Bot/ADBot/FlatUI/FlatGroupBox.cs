using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000013 RID: 19
	public class FlatGroupBox : ContainerControl
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00005CB4 File Offset: 0x00003EB4
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000025F4 File Offset: 0x000007F4
		[Category("Colors")]
		public Color BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00005CCC File Offset: 0x00003ECC
		// (set) Token: 0x06000098 RID: 152 RVA: 0x000025FE File Offset: 0x000007FE
		public bool ShowText
		{
			get
			{
				return this._ShowText;
			}
			set
			{
				this._ShowText = value;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00005CE4 File Offset: 0x00003EE4
		public FlatGroupBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.Size = new Size(240, 180);
			this.Font = new Font("Segoe ui", 10f);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00005D6C File Offset: 0x00003F6C
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			GraphicsPath path = new GraphicsPath();
			GraphicsPath path2 = new GraphicsPath();
			GraphicsPath path3 = new GraphicsPath();
			Rectangle rectangle = new Rectangle(8, 8, this.W - 16, this.H - 16);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			path = Helpers.RoundRec(rectangle, 8);
			graphics2.FillPath(new SolidBrush(this._BaseColor), path);
			path2 = Helpers.DrawArrow(28, 2, false);
			graphics2.FillPath(new SolidBrush(this._BaseColor), path2);
			path3 = Helpers.DrawArrow(28, 8, true);
			graphics2.FillPath(new SolidBrush(Color.FromArgb(60, 70, 73)), path3);
			bool showText = this.ShowText;
			if (showText)
			{
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(16, 16, this.W, this.H), Helpers.NearSF);
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00005EF0 File Offset: 0x000040F0
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._TextColor = colors.Flat;
		}

		// Token: 0x0400005B RID: 91
		private int W;

		// Token: 0x0400005C RID: 92
		private int H;

		// Token: 0x0400005D RID: 93
		private bool _ShowText = true;

		// Token: 0x0400005E RID: 94
		private Color _BaseColor = Color.FromArgb(60, 70, 73);

		// Token: 0x0400005F RID: 95
		private Color _TextColor = Helpers.FlatColor;
	}
}

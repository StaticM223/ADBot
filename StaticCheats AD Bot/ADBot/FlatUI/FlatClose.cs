using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200000D RID: 13
	public class FlatClose : Control
	{
		// Token: 0x0600004D RID: 77 RVA: 0x000023A3 File Offset: 0x000005A3
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000023BC File Offset: 0x000005BC
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000023D5 File Offset: 0x000005D5
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000023EE File Offset: 0x000005EE
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002407 File Offset: 0x00000607
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.X;
			base.Invalidate();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002425 File Offset: 0x00000625
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			Environment.Exit(0);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002437 File Offset: 0x00000637
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new Size(18, 18);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00005140 File Offset: 0x00003340
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002452 File Offset: 0x00000652
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

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00005158 File Offset: 0x00003358
		// (set) Token: 0x06000057 RID: 87 RVA: 0x0000245C File Offset: 0x0000065C
		[Category("Colors")]
		public Color TextColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00005170 File Offset: 0x00003370
		public FlatClose()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			base.Size = new Size(18, 18);
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 10f);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000520C File Offset: 0x0000340C
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
			graphics2.DrawString("r", this.Font, new SolidBrush(this.TextColor), new Rectangle(0, 0, base.Width, base.Height), Helpers.CenterSF);
			MouseState state = this.State;
			if (state != MouseState.Over)
			{
				if (state == MouseState.Down)
				{
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
				}
			}
			else
			{
				graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0400003F RID: 63
		private MouseState State = MouseState.None;

		// Token: 0x04000040 RID: 64
		private int x;

		// Token: 0x04000041 RID: 65
		private Color _BaseColor = Color.FromArgb(168, 35, 35);

		// Token: 0x04000042 RID: 66
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}

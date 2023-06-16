using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000009 RID: 9
	public class FlatButton : Control
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000477C File Offset: 0x0000297C
		// (set) Token: 0x06000029 RID: 41 RVA: 0x0000227A File Offset: 0x0000047A
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

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00004794 File Offset: 0x00002994
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002284 File Offset: 0x00000484
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

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000047AC File Offset: 0x000029AC
		// (set) Token: 0x0600002D RID: 45 RVA: 0x0000228E File Offset: 0x0000048E
		[Category("Options")]
		public bool Rounded
		{
			get
			{
				return this._Rounded;
			}
			set
			{
				this._Rounded = value;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002298 File Offset: 0x00000498
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000022B1 File Offset: 0x000004B1
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000022CA File Offset: 0x000004CA
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000022E3 File Offset: 0x000004E3
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000047C4 File Offset: 0x000029C4
		public FlatButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(106, 32);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 12f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004860 File Offset: 0x00002A60
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			GraphicsPath path = new GraphicsPath();
			Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			switch (this.State)
			{
			case MouseState.None:
			{
				bool rounded = this.Rounded;
				if (rounded)
				{
					path = Helpers.RoundRec(rectangle, 6);
					graphics2.FillPath(new SolidBrush(this._BaseColor), path);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			}
			case MouseState.Over:
			{
				bool rounded2 = this.Rounded;
				if (rounded2)
				{
					path = Helpers.RoundRec(rectangle, 6);
					graphics2.FillPath(new SolidBrush(this._BaseColor), path);
					graphics2.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), path);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), rectangle);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			}
			case MouseState.Down:
			{
				bool rounded3 = this.Rounded;
				if (rounded3)
				{
					path = Helpers.RoundRec(rectangle, 6);
					graphics2.FillPath(new SolidBrush(this._BaseColor), path);
					graphics2.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), path);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), rectangle);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			}
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004B7C File Offset: 0x00002D7C
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._BaseColor = colors.Flat;
		}

		// Token: 0x0400002D RID: 45
		private int W;

		// Token: 0x0400002E RID: 46
		private int H;

		// Token: 0x0400002F RID: 47
		private bool _Rounded = false;

		// Token: 0x04000030 RID: 48
		private MouseState State = MouseState.None;

		// Token: 0x04000031 RID: 49
		private Color _BaseColor = Helpers.FlatColor;

		// Token: 0x04000032 RID: 50
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}

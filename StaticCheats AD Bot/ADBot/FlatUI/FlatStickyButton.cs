using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200001E RID: 30
	public class FlatStickyButton : Control
	{
		// Token: 0x06000112 RID: 274 RVA: 0x000028F2 File Offset: 0x00000AF2
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000290B File Offset: 0x00000B0B
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00002924 File Offset: 0x00000B24
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000293D File Offset: 0x00000B3D
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00007CC4 File Offset: 0x00005EC4
		private bool[] GetConnectedSides()
		{
			bool[] array = new bool[4];
			foreach (object obj in base.Parent.Controls)
			{
				Control control = (Control)obj;
				bool flag = control is FlatStickyButton;
				if (flag)
				{
					bool flag2 = control == this || !this.Rect.IntersectsWith(this.Rect);
					if (!flag2)
					{
						double num = Math.Atan2((double)(base.Left - control.Left), (double)(base.Top - control.Top)) * 2.0 / 3.141592653589793;
						bool flag3 = num / 1.0 == num;
						if (flag3)
						{
							array[(int)num + 1] = true;
						}
					}
				}
			}
			return array;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00007DC4 File Offset: 0x00005FC4
		private Rectangle Rect
		{
			get
			{
				return new Rectangle(base.Left, base.Top, base.Width, base.Height);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00007DF4 File Offset: 0x00005FF4
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00002956 File Offset: 0x00000B56
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

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00007E0C File Offset: 0x0000600C
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00002960 File Offset: 0x00000B60
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

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00007E24 File Offset: 0x00006024
		// (set) Token: 0x0600011D RID: 285 RVA: 0x0000296A File Offset: 0x00000B6A
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

		// Token: 0x0600011E RID: 286 RVA: 0x00002974 File Offset: 0x00000B74
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000297F File Offset: 0x00000B7F
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00007E3C File Offset: 0x0000603C
		public FlatStickyButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(106, 32);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 12f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00007ED8 File Offset: 0x000060D8
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = base.Height;
			GraphicsPath path = new GraphicsPath();
			bool[] connectedSides = this.GetConnectedSides();
			GraphicsPath graphicsPath = Helpers.RoundRect(0f, 0f, (float)this.W, (float)this.H, 0.3, !connectedSides[2] && !connectedSides[1], !connectedSides[1] && !connectedSides[0], !connectedSides[3] && !connectedSides[0], !connectedSides[3] && !connectedSides[2]);
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
					path = graphicsPath;
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
					path = graphicsPath;
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
					path = graphicsPath;
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

		// Token: 0x06000122 RID: 290 RVA: 0x00008250 File Offset: 0x00006450
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._BaseColor = colors.Flat;
		}

		// Token: 0x04000093 RID: 147
		private int W;

		// Token: 0x04000094 RID: 148
		private int H;

		// Token: 0x04000095 RID: 149
		private MouseState State = MouseState.None;

		// Token: 0x04000096 RID: 150
		private bool _Rounded = false;

		// Token: 0x04000097 RID: 151
		private Color _BaseColor = Helpers.FlatColor;

		// Token: 0x04000098 RID: 152
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}

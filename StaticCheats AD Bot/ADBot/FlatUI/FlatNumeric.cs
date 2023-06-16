using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000018 RID: 24
	public class FlatNumeric : Control
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00006A7C File Offset: 0x00004C7C
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00006A94 File Offset: 0x00004C94
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				bool flag = value <= this._Max & value >= this._Min;
				if (flag)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00006AD0 File Offset: 0x00004CD0
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00006AE8 File Offset: 0x00004CE8
		public long Maximum
		{
			get
			{
				return this._Max;
			}
			set
			{
				bool flag = value > this._Min;
				if (flag)
				{
					this._Max = value;
				}
				bool flag2 = this._Value > this._Max;
				if (flag2)
				{
					this._Value = this._Max;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00006B30 File Offset: 0x00004D30
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00006B48 File Offset: 0x00004D48
		public long Minimum
		{
			get
			{
				return this._Min;
			}
			set
			{
				bool flag = value < this._Max;
				if (flag)
				{
					this._Min = value;
				}
				bool flag2 = this._Value < this._Min;
				if (flag2)
				{
					this._Value = this.Minimum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00006B90 File Offset: 0x00004D90
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.Location.X;
			this.y = e.Location.Y;
			base.Invalidate();
			bool flag = e.X < base.Width - 23;
			if (flag)
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00006C04 File Offset: 0x00004E04
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			bool flag = this.x > base.Width - 21 && this.x < base.Width - 3;
			if (flag)
			{
				bool flag2 = this.y < 15;
				if (flag2)
				{
					bool flag3 = this.Value + 1L <= this._Max;
					if (flag3)
					{
						this._Value += 1L;
					}
				}
				else
				{
					bool flag4 = this.Value - 1L >= this._Min;
					if (flag4)
					{
						this._Value -= 1L;
					}
				}
			}
			else
			{
				this.Bool = !this.Bool;
				base.Focus();
			}
			base.Invalidate();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00006CC8 File Offset: 0x00004EC8
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				bool @bool = this.Bool;
				if (@bool)
				{
					this._Value = Convert.ToInt64(this._Value.ToString() + e.KeyChar.ToString());
				}
				bool flag = this._Value > this._Max;
				if (flag)
				{
					this._Value = this._Max;
				}
				base.Invalidate();
			}
			catch
			{
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00006D50 File Offset: 0x00004F50
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			bool flag = e.KeyCode == Keys.Back;
			if (flag)
			{
				this.Value = 0L;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000027BA File Offset: 0x000009BA
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 30;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00006D80 File Offset: 0x00004F80
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x000027CE File Offset: 0x000009CE
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

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00006D98 File Offset: 0x00004F98
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x000027D8 File Offset: 0x000009D8
		[Category("Colors")]
		public Color ButtonColor
		{
			get
			{
				return this._ButtonColor;
			}
			set
			{
				this._ButtonColor = value;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00006DB0 File Offset: 0x00004FB0
		public FlatNumeric()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 10f);
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.ForeColor = Color.White;
			this._Min = 0L;
			this._Max = 9999999L;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00006E48 File Offset: 0x00005048
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			graphics2.FillRectangle(new SolidBrush(this._ButtonColor), new Rectangle(base.Width - 24, 0, 24, this.H));
			graphics2.DrawString("+", new Font("Segoe UI", 12f), Brushes.White, new Point(base.Width - 12, 8), Helpers.CenterSF);
			graphics2.DrawString("-", new Font("Segoe UI", 10f, FontStyle.Bold), Brushes.White, new Point(base.Width - 12, 22), Helpers.CenterSF);
			graphics2.DrawString(this.Value.ToString(), this.Font, Brushes.White, new Rectangle(5, 1, this.W, this.H), new StringFormat
			{
				LineAlignment = StringAlignment.Center
			});
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00006FF4 File Offset: 0x000051F4
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._ButtonColor = colors.Flat;
		}

		// Token: 0x0400006C RID: 108
		private int W;

		// Token: 0x0400006D RID: 109
		private int H;

		// Token: 0x0400006E RID: 110
		private MouseState State = MouseState.None;

		// Token: 0x0400006F RID: 111
		private int x;

		// Token: 0x04000070 RID: 112
		private int y;

		// Token: 0x04000071 RID: 113
		private long _Value;

		// Token: 0x04000072 RID: 114
		private long _Min;

		// Token: 0x04000073 RID: 115
		private long _Max;

		// Token: 0x04000074 RID: 116
		private bool Bool;

		// Token: 0x04000075 RID: 117
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000076 RID: 118
		private Color _ButtonColor = Helpers.FlatColor;
	}
}

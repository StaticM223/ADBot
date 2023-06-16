using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000024 RID: 36
	[DefaultEvent("Scroll")]
	public class FlatTrackBar : Control
	{
		// Token: 0x0600015E RID: 350 RVA: 0x000096E8 File Offset: 0x000078E8
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				this.Val = Convert.ToInt32((float)(this._Value - this._Minimum) / (float)(this._Maximum - this._Minimum) * (float)(base.Width - 11));
				this.Track = new Rectangle(this.Val, 0, 10, 20);
				this.Bool = this.Track.Contains(e.Location);
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00009774 File Offset: 0x00007974
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			bool flag = this.Bool && e.X > -1 && e.X < base.Width + 1;
			if (flag)
			{
				this.Value = this._Minimum + Convert.ToInt32((float)(this._Maximum - this._Minimum) * ((float)e.X / (float)base.Width));
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00002AC4 File Offset: 0x00000CC4
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Bool = false;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000161 RID: 353 RVA: 0x000097E8 File Offset: 0x000079E8
		// (set) Token: 0x06000162 RID: 354 RVA: 0x00002AD6 File Offset: 0x00000CD6
		public FlatTrackBar._Style Style
		{
			get
			{
				return this.Style_;
			}
			set
			{
				this.Style_ = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00009800 File Offset: 0x00007A00
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00002AE0 File Offset: 0x00000CE0
		[Category("Colors")]
		public Color TrackColor
		{
			get
			{
				return this._TrackColor;
			}
			set
			{
				this._TrackColor = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00009818 File Offset: 0x00007A18
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00002AEA File Offset: 0x00000CEA
		[Category("Colors")]
		public Color HatchColor
		{
			get
			{
				return this._HatchColor;
			}
			set
			{
				this._HatchColor = value;
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000167 RID: 359 RVA: 0x00009830 File Offset: 0x00007A30
		// (remove) Token: 0x06000168 RID: 360 RVA: 0x00009868 File Offset: 0x00007A68
		public event FlatTrackBar.ScrollEventHandler Scroll;

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000169 RID: 361 RVA: 0x000098A0 File Offset: 0x00007AA0
		// (set) Token: 0x0600016A RID: 362 RVA: 0x000098B8 File Offset: 0x00007AB8
		public int Minimum
		{
			get
			{
				return 0;
			}
			set
			{
				bool flag = value < 0;
				if (flag)
				{
				}
				this._Minimum = value;
				bool flag2 = value > this._Value;
				if (flag2)
				{
					this._Value = value;
				}
				bool flag3 = value > this._Maximum;
				if (flag3)
				{
					this._Maximum = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00009908 File Offset: 0x00007B08
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00009920 File Offset: 0x00007B20
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				bool flag = value < 0;
				if (flag)
				{
				}
				this._Maximum = value;
				bool flag2 = value < this._Value;
				if (flag2)
				{
					this._Value = value;
				}
				bool flag3 = value < this._Minimum;
				if (flag3)
				{
					this._Minimum = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00009970 File Offset: 0x00007B70
		// (set) Token: 0x0600016E RID: 366 RVA: 0x00009988 File Offset: 0x00007B88
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				bool flag = value == this._Value;
				if (!flag)
				{
					bool flag2 = value > this._Maximum || value < this._Minimum;
					if (flag2)
					{
					}
					this._Value = value;
					base.Invalidate();
					bool flag3 = this.Scroll != null;
					if (flag3)
					{
						this.Scroll(this);
					}
				}
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600016F RID: 367 RVA: 0x000099EC File Offset: 0x00007BEC
		// (set) Token: 0x06000170 RID: 368 RVA: 0x00002AF4 File Offset: 0x00000CF4
		public bool ShowValue
		{
			get
			{
				return this._ShowValue;
			}
			set
			{
				this._ShowValue = value;
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00009A04 File Offset: 0x00007C04
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			bool flag = e.KeyCode == Keys.Subtract;
			if (flag)
			{
				bool flag2 = this.Value == 0;
				if (!flag2)
				{
					this.Value--;
				}
			}
			else
			{
				bool flag3 = e.KeyCode == Keys.Add;
				if (flag3)
				{
					bool flag4 = this.Value == this._Maximum;
					if (!flag4)
					{
						this.Value++;
					}
				}
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000215B File Offset: 0x0000035B
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00002AFE File Offset: 0x00000CFE
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 23;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00009A80 File Offset: 0x00007C80
		public FlatTrackBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Height = 18;
			this.BackColor = Color.FromArgb(60, 70, 73);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00009B18 File Offset: 0x00007D18
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(1, 6, this.W - 2, 8);
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath graphicsPath2 = new GraphicsPath();
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			this.Val = Convert.ToInt32((float)(this._Value - this._Minimum) / (float)(this._Maximum - this._Minimum) * (float)(this.W - 10));
			this.Track = new Rectangle(this.Val, 0, 10, 20);
			this.Knob = new Rectangle(this.Val, 4, 11, 14);
			graphicsPath.AddRectangle(rect);
			graphics2.SetClip(graphicsPath);
			graphics2.FillRectangle(new SolidBrush(this.BaseColor), new Rectangle(0, 7, this.W, 8));
			graphics2.FillRectangle(new SolidBrush(this._TrackColor), new Rectangle(0, 7, this.Track.X + this.Track.Width, 8));
			graphics2.ResetClip();
			HatchBrush brush = new HatchBrush(HatchStyle.Plaid, this.HatchColor, this._TrackColor);
			graphics2.FillRectangle(brush, new Rectangle(-10, 7, this.Track.X + this.Track.Width, 8));
			FlatTrackBar._Style style = this.Style;
			if (style != FlatTrackBar._Style.Slider)
			{
				if (style == FlatTrackBar._Style.Knob)
				{
					graphicsPath2.AddEllipse(this.Knob);
					graphics2.FillPath(new SolidBrush(this.SliderColor), graphicsPath2);
				}
			}
			else
			{
				graphicsPath2.AddRectangle(this.Track);
				graphics2.FillPath(new SolidBrush(this.SliderColor), graphicsPath2);
			}
			bool showValue = this.ShowValue;
			if (showValue)
			{
				graphics2.DrawString(this.Value.ToString(), new Font("Segoe UI", 8f), Brushes.White, new Rectangle(1, 6, this.W, this.H), new StringFormat
				{
					Alignment = StringAlignment.Far,
					LineAlignment = StringAlignment.Far
				});
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00009DB0 File Offset: 0x00007FB0
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._TrackColor = colors.Flat;
		}

		// Token: 0x040000BC RID: 188
		private int W;

		// Token: 0x040000BD RID: 189
		private int H;

		// Token: 0x040000BE RID: 190
		private int Val;

		// Token: 0x040000BF RID: 191
		private bool Bool;

		// Token: 0x040000C0 RID: 192
		private Rectangle Track;

		// Token: 0x040000C1 RID: 193
		private Rectangle Knob;

		// Token: 0x040000C2 RID: 194
		private FlatTrackBar._Style Style_;

		// Token: 0x040000C4 RID: 196
		private int _Minimum;

		// Token: 0x040000C5 RID: 197
		private int _Maximum = 10;

		// Token: 0x040000C6 RID: 198
		private int _Value;

		// Token: 0x040000C7 RID: 199
		private bool _ShowValue = false;

		// Token: 0x040000C8 RID: 200
		private Color BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x040000C9 RID: 201
		private Color _TrackColor = Helpers.FlatColor;

		// Token: 0x040000CA RID: 202
		private Color SliderColor = Color.FromArgb(25, 27, 29);

		// Token: 0x040000CB RID: 203
		private Color _HatchColor = Color.FromArgb(23, 148, 92);

		// Token: 0x02000025 RID: 37
		[Flags]
		public enum _Style
		{
			// Token: 0x040000CD RID: 205
			Slider = 0,
			// Token: 0x040000CE RID: 206
			Knob = 1
		}

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x06000178 RID: 376
		public delegate void ScrollEventHandler(object sender);
	}
}

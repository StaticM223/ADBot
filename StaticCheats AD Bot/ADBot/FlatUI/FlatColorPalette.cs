using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200000E RID: 14
	public class FlatColorPalette : Control
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00002466 File Offset: 0x00000666
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Width = 180;
			base.Height = 80;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000533C File Offset: 0x0000353C
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002486 File Offset: 0x00000686
		[Category("Colors")]
		public Color Red
		{
			get
			{
				return this._Red;
			}
			set
			{
				this._Red = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00005354 File Offset: 0x00003554
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002490 File Offset: 0x00000690
		[Category("Colors")]
		public Color Cyan
		{
			get
			{
				return this._Cyan;
			}
			set
			{
				this._Cyan = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0000536C File Offset: 0x0000356C
		// (set) Token: 0x06000060 RID: 96 RVA: 0x0000249A File Offset: 0x0000069A
		[Category("Colors")]
		public Color Blue
		{
			get
			{
				return this._Blue;
			}
			set
			{
				this._Blue = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00005384 File Offset: 0x00003584
		// (set) Token: 0x06000062 RID: 98 RVA: 0x000024A4 File Offset: 0x000006A4
		[Category("Colors")]
		public Color LimeGreen
		{
			get
			{
				return this._LimeGreen;
			}
			set
			{
				this._LimeGreen = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000063 RID: 99 RVA: 0x0000539C File Offset: 0x0000359C
		// (set) Token: 0x06000064 RID: 100 RVA: 0x000024AE File Offset: 0x000006AE
		[Category("Colors")]
		public Color Orange
		{
			get
			{
				return this._Orange;
			}
			set
			{
				this._Orange = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000053B4 File Offset: 0x000035B4
		// (set) Token: 0x06000066 RID: 102 RVA: 0x000024B8 File Offset: 0x000006B8
		[Category("Colors")]
		public Color Purple
		{
			get
			{
				return this._Purple;
			}
			set
			{
				this._Purple = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000053CC File Offset: 0x000035CC
		// (set) Token: 0x06000068 RID: 104 RVA: 0x000024C2 File Offset: 0x000006C2
		[Category("Colors")]
		public Color Black
		{
			get
			{
				return this._Black;
			}
			set
			{
				this._Black = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000069 RID: 105 RVA: 0x000053E4 File Offset: 0x000035E4
		// (set) Token: 0x0600006A RID: 106 RVA: 0x000024CC File Offset: 0x000006CC
		[Category("Colors")]
		public Color Gray
		{
			get
			{
				return this._Gray;
			}
			set
			{
				this._Gray = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006B RID: 107 RVA: 0x000053FC File Offset: 0x000035FC
		// (set) Token: 0x0600006C RID: 108 RVA: 0x000024D6 File Offset: 0x000006D6
		[Category("Colors")]
		public Color White
		{
			get
			{
				return this._White;
			}
			set
			{
				this._White = value;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005414 File Offset: 0x00003614
		public FlatColorPalette()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			base.Size = new Size(160, 80);
			this.Font = new Font("Segoe UI", 12f);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005538 File Offset: 0x00003738
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._Red), new Rectangle(0, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Cyan), new Rectangle(20, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Blue), new Rectangle(40, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._LimeGreen), new Rectangle(60, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Orange), new Rectangle(80, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Purple), new Rectangle(100, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Black), new Rectangle(120, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Gray), new Rectangle(140, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._White), new Rectangle(160, 0, 20, 40));
			graphics2.DrawString("Color Palette", this.Font, new SolidBrush(this._White), new Rectangle(0, 22, this.W, this.H), Helpers.CenterSF);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x04000043 RID: 67
		private int W;

		// Token: 0x04000044 RID: 68
		private int H;

		// Token: 0x04000045 RID: 69
		private Color _Red = Color.FromArgb(220, 85, 96);

		// Token: 0x04000046 RID: 70
		private Color _Cyan = Color.FromArgb(10, 154, 157);

		// Token: 0x04000047 RID: 71
		private Color _Blue = Color.FromArgb(0, 128, 255);

		// Token: 0x04000048 RID: 72
		private Color _LimeGreen = Color.FromArgb(35, 168, 109);

		// Token: 0x04000049 RID: 73
		private Color _Orange = Color.FromArgb(253, 181, 63);

		// Token: 0x0400004A RID: 74
		private Color _Purple = Color.FromArgb(155, 88, 181);

		// Token: 0x0400004B RID: 75
		private Color _Black = Color.FromArgb(45, 47, 49);

		// Token: 0x0400004C RID: 76
		private Color _Gray = Color.FromArgb(63, 70, 73);

		// Token: 0x0400004D RID: 77
		private Color _White = Color.FromArgb(243, 243, 243);
	}
}

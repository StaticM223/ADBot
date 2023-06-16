using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000019 RID: 25
	public class FlatProgressBar : Control
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00007018 File Offset: 0x00005218
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00007030 File Offset: 0x00005230
		[Category("Control")]
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				bool flag = value < this._Value;
				if (flag)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00007060 File Offset: 0x00005260
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00007078 File Offset: 0x00005278
		[Category("Control")]
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				bool flag = value > this._Maximum;
				if (flag)
				{
					value = this._Maximum;
					base.Invalidate();
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000DF RID: 223 RVA: 0x000070B4 File Offset: 0x000052B4
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x000027E2 File Offset: 0x000009E2
		public bool Pattern
		{
			get
			{
				return this._Pattern;
			}
			set
			{
				this._Pattern = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x000070CC File Offset: 0x000052CC
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x000027EC File Offset: 0x000009EC
		public bool ShowBalloon
		{
			get
			{
				return this._ShowBalloon;
			}
			set
			{
				this._ShowBalloon = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x000070E4 File Offset: 0x000052E4
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x000027F6 File Offset: 0x000009F6
		public bool PercentSign
		{
			get
			{
				return this._PercentSign;
			}
			set
			{
				this._PercentSign = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x000070FC File Offset: 0x000052FC
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00002800 File Offset: 0x00000A00
		[Category("Colors")]
		public Color ProgressColor
		{
			get
			{
				return this._ProgressColor;
			}
			set
			{
				this._ProgressColor = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00007114 File Offset: 0x00005314
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x0000280A File Offset: 0x00000A0A
		[Category("Colors")]
		public Color DarkerProgress
		{
			get
			{
				return this._DarkerProgress;
			}
			set
			{
				this._DarkerProgress = value;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000216D File Offset: 0x0000036D
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 42;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00002814 File Offset: 0x00000A14
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Height = 42;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00002827 File Offset: 0x00000A27
		public void Increment(int Amount)
		{
			this.Value += Amount;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000712C File Offset: 0x0000532C
		public FlatProgressBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			base.Height = 42;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000071C8 File Offset: 0x000053C8
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 24, this.W, this.H);
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath path = new GraphicsPath();
			GraphicsPath path2 = new GraphicsPath();
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			float num = (float)this._Value / (float)this._Maximum;
			int num2 = (int)(num * (float)base.Width);
			int value = this.Value;
			if (value != 0)
			{
				if (value != 100)
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
					graphicsPath.AddRectangle(new Rectangle(0, 24, num2 - 1, this.H - 1));
					graphics2.FillPath(new SolidBrush(this._ProgressColor), graphicsPath);
					bool pattern = this._Pattern;
					if (pattern)
					{
						HatchBrush brush = new HatchBrush(HatchStyle.Plaid, this._DarkerProgress, this._ProgressColor);
						graphics2.FillRectangle(brush, new Rectangle(0, 24, num2 - 1, this.H - 1));
					}
					bool showBalloon = this._ShowBalloon;
					if (showBalloon)
					{
						Rectangle rectangle = new Rectangle(num2 - 18, 0, 34, 16);
						path = Helpers.RoundRec(rectangle, 4);
						graphics2.FillPath(new SolidBrush(this._BaseColor), path);
						path2 = Helpers.DrawArrow(num2 - 9, 16, true);
						graphics2.FillPath(new SolidBrush(this._BaseColor), path2);
						string s = this._PercentSign ? (this.Value.ToString() + "%") : this.Value.ToString();
						int x = this._PercentSign ? (num2 - 15) : (num2 - 11);
						graphics2.DrawString(s, new Font("Segoe UI", 10f), new SolidBrush(this._ProgressColor), new Rectangle(x, -2, this.W, this.H), Helpers.NearSF);
					}
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
					graphics2.FillRectangle(new SolidBrush(this._ProgressColor), new Rectangle(0, 24, num2 - 1, this.H - 1));
				}
			}
			else
			{
				graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
				graphics2.FillRectangle(new SolidBrush(this._ProgressColor), new Rectangle(0, 24, num2 - 1, this.H - 1));
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000074CC File Offset: 0x000056CC
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._ProgressColor = colors.Flat;
		}

		// Token: 0x04000077 RID: 119
		private int W;

		// Token: 0x04000078 RID: 120
		private int H;

		// Token: 0x04000079 RID: 121
		private int _Value = 0;

		// Token: 0x0400007A RID: 122
		private int _Maximum = 100;

		// Token: 0x0400007B RID: 123
		private bool _Pattern = true;

		// Token: 0x0400007C RID: 124
		private bool _ShowBalloon = true;

		// Token: 0x0400007D RID: 125
		private bool _PercentSign = false;

		// Token: 0x0400007E RID: 126
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x0400007F RID: 127
		private Color _ProgressColor = Helpers.FlatColor;

		// Token: 0x04000080 RID: 128
		private Color _DarkerProgress = Color.FromArgb(23, 148, 92);
	}
}

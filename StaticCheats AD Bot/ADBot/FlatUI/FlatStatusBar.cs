using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200001D RID: 29
	public class FlatStatusBar : Control
	{
		// Token: 0x06000104 RID: 260 RVA: 0x000028B8 File Offset: 0x00000AB8
		protected override void CreateHandle()
		{
			base.CreateHandle();
			this.Dock = DockStyle.Bottom;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000215B File Offset: 0x0000035B
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000106 RID: 262 RVA: 0x000079D0 File Offset: 0x00005BD0
		// (set) Token: 0x06000107 RID: 263 RVA: 0x000028CA File Offset: 0x00000ACA
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

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000108 RID: 264 RVA: 0x000079E8 File Offset: 0x00005BE8
		// (set) Token: 0x06000109 RID: 265 RVA: 0x000028D4 File Offset: 0x00000AD4
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

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00007A00 File Offset: 0x00005C00
		// (set) Token: 0x0600010B RID: 267 RVA: 0x000028DE File Offset: 0x00000ADE
		[Category("Colors")]
		public Color RectColor
		{
			get
			{
				return this._RectColor;
			}
			set
			{
				this._RectColor = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00007A18 File Offset: 0x00005C18
		// (set) Token: 0x0600010D RID: 269 RVA: 0x000028E8 File Offset: 0x00000AE8
		public bool ShowTimeDate
		{
			get
			{
				return this._ShowTimeDate;
			}
			set
			{
				this._ShowTimeDate = value;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00007A30 File Offset: 0x00005C30
		public string GetTimeDate()
		{
			return string.Concat(new object[]
			{
				DateTime.Now.Date,
				" ",
				DateTime.Now.Hour,
				":",
				DateTime.Now.Minute
			});
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00007A9C File Offset: 0x00005C9C
		public FlatStatusBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = Color.White;
			base.Size = new Size(base.Width, 20);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007B2C File Offset: 0x00005D2C
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
			graphics2.Clear(this.BaseColor);
			graphics2.FillRectangle(new SolidBrush(this.BaseColor), rect);
			graphics2.DrawString(this.Text, this.Font, Brushes.White, new Rectangle(10, 4, this.W, this.H), Helpers.NearSF);
			graphics2.FillRectangle(new SolidBrush(this._RectColor), new Rectangle(4, 4, 4, 14));
			bool showTimeDate = this.ShowTimeDate;
			if (showTimeDate)
			{
				graphics2.DrawString(this.GetTimeDate(), this.Font, new SolidBrush(this._TextColor), new Rectangle(-4, 2, this.W, this.H), new StringFormat
				{
					Alignment = StringAlignment.Far,
					LineAlignment = StringAlignment.Center
				});
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00007CA0 File Offset: 0x00005EA0
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._RectColor = colors.Flat;
		}

		// Token: 0x0400008D RID: 141
		private int W;

		// Token: 0x0400008E RID: 142
		private int H;

		// Token: 0x0400008F RID: 143
		private bool _ShowTimeDate = false;

		// Token: 0x04000090 RID: 144
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000091 RID: 145
		private Color _TextColor = Color.White;

		// Token: 0x04000092 RID: 146
		private Color _RectColor = Helpers.FlatColor;
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000016 RID: 22
	public class FlatMax : Control
	{
		// Token: 0x060000AF RID: 175 RVA: 0x0000268E File Offset: 0x0000088E
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000026A7 File Offset: 0x000008A7
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000026C0 File Offset: 0x000008C0
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000026D9 File Offset: 0x000008D9
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000026F2 File Offset: 0x000008F2
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.X;
			base.Invalidate();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000658C File Offset: 0x0000478C
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			FormWindowState windowState = base.FindForm().WindowState;
			if (windowState != FormWindowState.Normal)
			{
				if (windowState == FormWindowState.Maximized)
				{
					base.FindForm().WindowState = FormWindowState.Normal;
				}
			}
			else
			{
				base.FindForm().WindowState = FormWindowState.Maximized;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000065D8 File Offset: 0x000047D8
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00002710 File Offset: 0x00000910
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

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000065F0 File Offset: 0x000047F0
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x0000271A File Offset: 0x0000091A
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

		// Token: 0x060000B9 RID: 185 RVA: 0x00002437 File Offset: 0x00000637
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new Size(18, 18);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00006608 File Offset: 0x00004808
		public FlatMax()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			base.Size = new Size(18, 18);
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 12f);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000066A0 File Offset: 0x000048A0
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
			bool flag = base.FindForm().WindowState == FormWindowState.Maximized;
			if (flag)
			{
				graphics2.DrawString("1", this.Font, new SolidBrush(this.TextColor), new Rectangle(1, 1, base.Width, base.Height), Helpers.CenterSF);
			}
			else
			{
				bool flag2 = base.FindForm().WindowState == FormWindowState.Normal;
				if (flag2)
				{
					graphics2.DrawString("2", this.Font, new SolidBrush(this.TextColor), new Rectangle(1, 1, base.Width, base.Height), Helpers.CenterSF);
				}
			}
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

		// Token: 0x04000064 RID: 100
		private MouseState State = MouseState.None;

		// Token: 0x04000065 RID: 101
		private int x;

		// Token: 0x04000066 RID: 102
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000067 RID: 103
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}

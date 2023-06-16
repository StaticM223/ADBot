using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000028 RID: 40
	public class FormSkin : ContainerControl
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600017E RID: 382 RVA: 0x0000A188 File Offset: 0x00008388
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00002B12 File Offset: 0x00000D12
		[Category("Colors")]
		public Color HeaderColor
		{
			get
			{
				return this._HeaderColor;
			}
			set
			{
				this._HeaderColor = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000180 RID: 384 RVA: 0x0000A1A0 File Offset: 0x000083A0
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00002B1C File Offset: 0x00000D1C
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

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000A1B8 File Offset: 0x000083B8
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00002B26 File Offset: 0x00000D26
		[Category("Colors")]
		public Color BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				this._BorderColor = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000184 RID: 388 RVA: 0x0000A1D0 File Offset: 0x000083D0
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00002B30 File Offset: 0x00000D30
		[Category("Colors")]
		public Color FlatColor
		{
			get
			{
				return this._FlatColor;
			}
			set
			{
				this._FlatColor = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000186 RID: 390 RVA: 0x0000A1E8 File Offset: 0x000083E8
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00002B3A File Offset: 0x00000D3A
		[Category("Options")]
		public bool HeaderMaximize
		{
			get
			{
				return this._HeaderMaximize;
			}
			set
			{
				this._HeaderMaximize = value;
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000A200 File Offset: 0x00008400
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			bool flag = e.Button == MouseButtons.Left & new Rectangle(0, 0, base.Width, this.MoveHeight).Contains(e.Location);
			if (flag)
			{
				this.Cap = true;
				this.MousePoint = e.Location;
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000A260 File Offset: 0x00008460
		private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			bool headerMaximize = this.HeaderMaximize;
			if (headerMaximize)
			{
				bool flag = e.Button == MouseButtons.Left & new Rectangle(0, 0, base.Width, this.MoveHeight).Contains(e.Location);
				if (flag)
				{
					bool flag2 = base.FindForm().WindowState == FormWindowState.Normal;
					if (flag2)
					{
						base.FindForm().WindowState = FormWindowState.Maximized;
						base.FindForm().Refresh();
					}
					else
					{
						bool flag3 = base.FindForm().WindowState == FormWindowState.Maximized;
						if (flag3)
						{
							base.FindForm().WindowState = FormWindowState.Normal;
							base.FindForm().Refresh();
						}
					}
				}
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00002B44 File Offset: 0x00000D44
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000A310 File Offset: 0x00008510
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			bool cap = this.Cap;
			if (cap)
			{
				base.Parent.Location = new Point(Control.MousePosition.X - this.MousePoint.X, Control.MousePosition.Y - this.MousePoint.Y);
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000A378 File Offset: 0x00008578
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			base.ParentForm.FormBorderStyle = FormBorderStyle.None;
			base.ParentForm.AllowTransparency = false;
			base.ParentForm.TransparencyKey = Color.Fuchsia;
			base.ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
			this.Dock = DockStyle.Fill;
			base.Invalidate();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000A3DC File Offset: 0x000085DC
		public FormSkin()
		{
			base.MouseDoubleClick += this.FormSkin_MouseDoubleClick;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			this.Font = new Font("Segoe UI", 12f);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000A4FC File Offset: 0x000086FC
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Rectangle rect2 = new Rectangle(0, 0, this.W, 50);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			graphics2.FillRectangle(new SolidBrush(this._HeaderColor), rect2);
			graphics2.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(8, 16, 4, 18));
			graphics2.FillRectangle(new SolidBrush(this.FlatColor), 16, 16, 4, 18);
			graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.TextColor), new Rectangle(26, 15, this.W, this.H), Helpers.NearSF);
			graphics2.DrawRectangle(new Pen(this._BorderColor), rect);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000D2 RID: 210
		private int W;

		// Token: 0x040000D3 RID: 211
		private int H;

		// Token: 0x040000D4 RID: 212
		private bool Cap = false;

		// Token: 0x040000D5 RID: 213
		private bool _HeaderMaximize = false;

		// Token: 0x040000D6 RID: 214
		private Point MousePoint = new Point(0, 0);

		// Token: 0x040000D7 RID: 215
		private int MoveHeight = 50;

		// Token: 0x040000D8 RID: 216
		private Color _HeaderColor = Color.FromArgb(45, 47, 49);

		// Token: 0x040000D9 RID: 217
		private Color _BaseColor = Color.FromArgb(60, 70, 73);

		// Token: 0x040000DA RID: 218
		private Color _BorderColor = Color.FromArgb(53, 58, 60);

		// Token: 0x040000DB RID: 219
		private Color _FlatColor = Helpers.FlatColor;

		// Token: 0x040000DC RID: 220
		private Color TextColor = Color.FromArgb(234, 234, 234);

		// Token: 0x040000DD RID: 221
		private Color _HeaderLight = Color.FromArgb(171, 171, 172);

		// Token: 0x040000DE RID: 222
		private Color _BaseLight = Color.FromArgb(196, 199, 200);

		// Token: 0x040000DF RID: 223
		public Color TextLight = Color.FromArgb(45, 47, 49);
	}
}

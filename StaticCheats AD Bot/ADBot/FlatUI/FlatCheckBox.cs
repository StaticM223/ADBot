using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200000A RID: 10
	[DefaultEvent("CheckedChanged")]
	public class FlatCheckBox : Control
	{
		// Token: 0x06000035 RID: 53 RVA: 0x0000215B File Offset: 0x0000035B
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00004BA0 File Offset: 0x00002DA0
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000022FC File Offset: 0x000004FC
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				base.Invalidate();
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000038 RID: 56 RVA: 0x00004BB8 File Offset: 0x00002DB8
		// (remove) Token: 0x06000039 RID: 57 RVA: 0x00004BF0 File Offset: 0x00002DF0
		public event FlatCheckBox.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x0600003A RID: 58 RVA: 0x00004C28 File Offset: 0x00002E28
		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			bool flag = this.CheckedChanged != null;
			if (flag)
			{
				this.CheckedChanged(this);
			}
			base.OnClick(e);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00004C6C File Offset: 0x00002E6C
		// (set) Token: 0x0600003C RID: 60 RVA: 0x0000230D File Offset: 0x0000050D
		[Category("Options")]
		public FlatCheckBox._Options Options
		{
			get
			{
				return this.O;
			}
			set
			{
				this.O = value;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002317 File Offset: 0x00000517
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 22;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00004C84 File Offset: 0x00002E84
		// (set) Token: 0x0600003F RID: 63 RVA: 0x0000232B File Offset: 0x0000052B
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

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00004C9C File Offset: 0x00002E9C
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002335 File Offset: 0x00000535
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

		// Token: 0x06000042 RID: 66 RVA: 0x0000233F File Offset: 0x0000053F
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002358 File Offset: 0x00000558
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002371 File Offset: 0x00000571
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000238A File Offset: 0x0000058A
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00004CB4 File Offset: 0x00002EB4
		public FlatCheckBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Cursor = Cursors.Hand;
			this.Font = new Font("Segoe UI", 10f);
			base.Size = new Size(112, 22);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004D60 File Offset: 0x00002F60
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 2, base.Height - 5, base.Height - 5);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			FlatCheckBox._Options o = this.O;
			if (o != FlatCheckBox._Options.Style1)
			{
				if (o == FlatCheckBox._Options.Style2)
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
					MouseState state = this.State;
					if (state != MouseState.Over)
					{
						if (state == MouseState.Down)
						{
							graphics2.DrawRectangle(new Pen(this._BorderColor), rect);
							graphics2.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
						}
					}
					else
					{
						graphics2.DrawRectangle(new Pen(this._BorderColor), rect);
						graphics2.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
					}
					bool @checked = this.Checked;
					if (@checked)
					{
						graphics2.DrawString("ü", new Font("Wingdings", 18f), new SolidBrush(this._BorderColor), new Rectangle(5, 7, this.H - 9, this.H - 9), Helpers.CenterSF);
					}
					bool flag = !base.Enabled;
					if (flag)
					{
						graphics2.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
						graphics2.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(48, 119, 91)), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
					}
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
				}
			}
			else
			{
				graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
				MouseState state2 = this.State;
				if (state2 != MouseState.Over)
				{
					if (state2 == MouseState.Down)
					{
						graphics2.DrawRectangle(new Pen(this._BorderColor), rect);
					}
				}
				else
				{
					graphics2.DrawRectangle(new Pen(this._BorderColor), rect);
				}
				bool checked2 = this.Checked;
				if (checked2)
				{
					graphics2.DrawString("ü", new Font("Wingdings", 18f), new SolidBrush(this._BorderColor), new Rectangle(5, 7, this.H - 9, this.H - 9), Helpers.CenterSF);
				}
				bool flag2 = !base.Enabled;
				if (flag2)
				{
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), rect);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(140, 142, 143)), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
				}
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000511C File Offset: 0x0000331C
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._BorderColor = colors.Flat;
		}

		// Token: 0x04000033 RID: 51
		private int W;

		// Token: 0x04000034 RID: 52
		private int H;

		// Token: 0x04000035 RID: 53
		private MouseState State = MouseState.None;

		// Token: 0x04000036 RID: 54
		private FlatCheckBox._Options O;

		// Token: 0x04000037 RID: 55
		private bool _Checked;

		// Token: 0x04000039 RID: 57
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x0400003A RID: 58
		private Color _TextColor = Color.FromArgb(243, 243, 243);

		// Token: 0x0400003B RID: 59
		private Color _BorderColor = Helpers.FlatColor;

		// Token: 0x0200000B RID: 11
		// (Invoke) Token: 0x0600004A RID: 74
		public delegate void CheckedChangedEventHandler(object sender);

		// Token: 0x0200000C RID: 12
		[Flags]
		public enum _Options
		{
			// Token: 0x0400003D RID: 61
			Style1 = 0,
			// Token: 0x0400003E RID: 62
			Style2 = 1
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200001A RID: 26
	[DefaultEvent("CheckedChanged")]
	public class FlatRadioButton : Control
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000EF RID: 239 RVA: 0x000074F0 File Offset: 0x000056F0
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x00007508 File Offset: 0x00005708
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				this.InvalidateControls();
				bool flag = this.CheckedChanged != null;
				if (flag)
				{
					this.CheckedChanged(this);
				}
				base.Invalidate();
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000F1 RID: 241 RVA: 0x00007548 File Offset: 0x00005748
		// (remove) Token: 0x060000F2 RID: 242 RVA: 0x00007580 File Offset: 0x00005780
		public event FlatRadioButton.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x060000F3 RID: 243 RVA: 0x000075B8 File Offset: 0x000057B8
		protected override void OnClick(EventArgs e)
		{
			bool flag = !this._Checked;
			if (flag)
			{
				this.Checked = true;
			}
			base.OnClick(e);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000075E4 File Offset: 0x000057E4
		private void InvalidateControls()
		{
			bool flag = !base.IsHandleCreated || !this._Checked;
			if (!flag)
			{
				foreach (object obj in base.Parent.Controls)
				{
					Control control = (Control)obj;
					bool flag2 = control != this && control is FlatRadioButton;
					if (flag2)
					{
						((FlatRadioButton)control).Checked = false;
						base.Invalidate();
					}
				}
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00002839 File Offset: 0x00000A39
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.InvalidateControls();
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00007688 File Offset: 0x00005888
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x0000284A File Offset: 0x00000A4A
		[Category("Options")]
		public FlatRadioButton._Options Options
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

		// Token: 0x060000F8 RID: 248 RVA: 0x00002317 File Offset: 0x00000517
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 22;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00002854 File Offset: 0x00000A54
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000286D File Offset: 0x00000A6D
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00002886 File Offset: 0x00000A86
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000289F File Offset: 0x00000A9F
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000076A0 File Offset: 0x000058A0
		public FlatRadioButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Cursor = Cursors.Hand;
			base.Size = new Size(100, 22);
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Font = new Font("Segoe UI", 10f);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000774C File Offset: 0x0000594C
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 2, base.Height - 5, base.Height - 5);
			Rectangle rect2 = new Rectangle(4, 6, this.H - 12, this.H - 12);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			FlatRadioButton._Options o = this.O;
			if (o != FlatRadioButton._Options.Style1)
			{
				if (o == FlatRadioButton._Options.Style2)
				{
					graphics2.FillEllipse(new SolidBrush(this._BaseColor), rect);
					MouseState state = this.State;
					if (state != MouseState.Over)
					{
						if (state == MouseState.Down)
						{
							graphics2.DrawEllipse(new Pen(this._BorderColor), rect);
							graphics2.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
						}
					}
					else
					{
						graphics2.DrawEllipse(new Pen(this._BorderColor), rect);
						graphics2.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), rect);
					}
					bool @checked = this.Checked;
					if (@checked)
					{
						graphics2.FillEllipse(new SolidBrush(this._BorderColor), rect2);
					}
				}
			}
			else
			{
				graphics2.FillEllipse(new SolidBrush(this._BaseColor), rect);
				MouseState state2 = this.State;
				if (state2 != MouseState.Over)
				{
					if (state2 == MouseState.Down)
					{
						graphics2.DrawEllipse(new Pen(this._BorderColor), rect);
					}
				}
				else
				{
					graphics2.DrawEllipse(new Pen(this._BorderColor), rect);
				}
				bool checked2 = this.Checked;
				if (checked2)
				{
					graphics2.FillEllipse(new SolidBrush(this._BorderColor), rect2);
				}
			}
			graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(20, 2, this.W, this.H), Helpers.NearSF);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000079AC File Offset: 0x00005BAC
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._BorderColor = colors.Flat;
		}

		// Token: 0x04000081 RID: 129
		private MouseState State = MouseState.None;

		// Token: 0x04000082 RID: 130
		private int W;

		// Token: 0x04000083 RID: 131
		private int H;

		// Token: 0x04000084 RID: 132
		private FlatRadioButton._Options O;

		// Token: 0x04000085 RID: 133
		private bool _Checked;

		// Token: 0x04000087 RID: 135
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000088 RID: 136
		private Color _BorderColor = Helpers.FlatColor;

		// Token: 0x04000089 RID: 137
		private Color _TextColor = Color.FromArgb(243, 243, 243);

		// Token: 0x0200001B RID: 27
		// (Invoke) Token: 0x06000101 RID: 257
		public delegate void CheckedChangedEventHandler(object sender);

		// Token: 0x0200001C RID: 28
		[Flags]
		public enum _Options
		{
			// Token: 0x0400008B RID: 139
			Style1 = 0,
			// Token: 0x0400008C RID: 140
			Style2 = 1
		}
	}
}

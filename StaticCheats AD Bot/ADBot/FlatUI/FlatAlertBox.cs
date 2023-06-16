using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000007 RID: 7
	public class FlatAlertBox : Control
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00003F98 File Offset: 0x00002198
		// (set) Token: 0x06000015 RID: 21 RVA: 0x00003FB0 File Offset: 0x000021B0
		private Timer T
		{
			get
			{
				return this.withEventsField_T;
			}
			set
			{
				bool flag = this.withEventsField_T != null;
				if (flag)
				{
					this.withEventsField_T.Tick -= this.T_Tick;
				}
				this.withEventsField_T = value;
				bool flag2 = this.withEventsField_T != null;
				if (flag2)
				{
					this.withEventsField_T.Tick += this.T_Tick;
				}
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00004014 File Offset: 0x00002214
		// (set) Token: 0x06000017 RID: 23 RVA: 0x00002146 File Offset: 0x00000346
		[Category("Options")]
		public FlatAlertBox._Kind kind
		{
			get
			{
				return this.K;
			}
			set
			{
				this.K = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000018 RID: 24 RVA: 0x0000402C File Offset: 0x0000222C
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00004044 File Offset: 0x00002244
		[Category("Options")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				bool flag = this._Text != null;
				if (flag)
				{
					this._Text = value;
				}
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00004070 File Offset: 0x00002270
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002150 File Offset: 0x00000350
		[Category("Options")]
		public new bool Visible
		{
			get
			{
				return !base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000215B File Offset: 0x0000035B
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000216D File Offset: 0x0000036D
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 42;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002181 File Offset: 0x00000381
		public void ShowControl(FlatAlertBox._Kind Kind, string Str, int Interval)
		{
			this.K = Kind;
			this.Text = Str;
			this.Visible = true;
			this.T = new Timer();
			this.T.Interval = Interval;
			this.T.Enabled = true;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000021C1 File Offset: 0x000003C1
		private void T_Tick(object sender, EventArgs e)
		{
			this.Visible = false;
			this.T.Enabled = false;
			this.T.Dispose();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000021E5 File Offset: 0x000003E5
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000021FE File Offset: 0x000003FE
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002217 File Offset: 0x00000417
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002230 File Offset: 0x00000430
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002249 File Offset: 0x00000449
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.X = e.X;
			base.Invalidate();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002267 File Offset: 0x00000467
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this.Visible = false;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000408C File Offset: 0x0000228C
		public FlatAlertBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			base.Size = new Size(576, 42);
			base.Location = new Point(10, 61);
			this.Font = new Font("Segoe UI", 10f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000418C File Offset: 0x0000238C
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			switch (this.K)
			{
			case FlatAlertBox._Kind.Success:
			{
				graphics2.FillRectangle(new SolidBrush(this.SuccessColor), rect);
				graphics2.FillEllipse(new SolidBrush(this.SuccessText), new Rectangle(8, 9, 24, 24));
				graphics2.FillEllipse(new SolidBrush(this.SuccessColor), new Rectangle(10, 11, 20, 20));
				graphics2.DrawString("ü", new Font("Wingdings", 22f), new SolidBrush(this.SuccessText), new Rectangle(7, 7, this.W, this.H), Helpers.NearSF);
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.SuccessText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
				graphics2.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 30, this.H - 29, 17, 17));
				graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.SuccessColor), new Rectangle(this.W - 28, 16, this.W, this.H), Helpers.NearSF);
				MouseState state = this.State;
				if (state == MouseState.Over)
				{
					graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 28, 16, this.W, this.H), Helpers.NearSF);
				}
				break;
			}
			case FlatAlertBox._Kind.Error:
			{
				graphics2.FillRectangle(new SolidBrush(this.ErrorColor), rect);
				graphics2.FillEllipse(new SolidBrush(this.ErrorText), new Rectangle(8, 9, 24, 24));
				graphics2.FillEllipse(new SolidBrush(this.ErrorColor), new Rectangle(10, 11, 20, 20));
				graphics2.DrawString("r", new Font("Marlett", 16f), new SolidBrush(this.ErrorText), new Rectangle(6, 11, this.W, this.H), Helpers.NearSF);
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.ErrorText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
				graphics2.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 32, this.H - 29, 17, 17));
				graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.ErrorColor), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
				MouseState state2 = this.State;
				if (state2 == MouseState.Over)
				{
					graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 30, 15, this.W, this.H), Helpers.NearSF);
				}
				break;
			}
			case FlatAlertBox._Kind.Info:
			{
				graphics2.FillRectangle(new SolidBrush(this.InfoColor), rect);
				graphics2.FillEllipse(new SolidBrush(this.InfoText), new Rectangle(8, 9, 24, 24));
				graphics2.FillEllipse(new SolidBrush(this.InfoColor), new Rectangle(10, 11, 20, 20));
				graphics2.DrawString("¡", new Font("Segoe UI", 20f, FontStyle.Bold), new SolidBrush(this.InfoText), new Rectangle(12, -4, this.W, this.H), Helpers.NearSF);
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.InfoText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
				graphics2.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 32, this.H - 29, 17, 17));
				graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.InfoColor), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
				MouseState state3 = this.State;
				if (state3 == MouseState.Over)
				{
					graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
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

		// Token: 0x0400001C RID: 28
		private int W;

		// Token: 0x0400001D RID: 29
		private int H;

		// Token: 0x0400001E RID: 30
		private FlatAlertBox._Kind K;

		// Token: 0x0400001F RID: 31
		private string _Text;

		// Token: 0x04000020 RID: 32
		private MouseState State = MouseState.None;

		// Token: 0x04000021 RID: 33
		private int X;

		// Token: 0x04000022 RID: 34
		private Timer withEventsField_T;

		// Token: 0x04000023 RID: 35
		private Color SuccessColor = Color.FromArgb(60, 85, 79);

		// Token: 0x04000024 RID: 36
		private Color SuccessText = Color.FromArgb(35, 169, 110);

		// Token: 0x04000025 RID: 37
		private Color ErrorColor = Color.FromArgb(87, 71, 71);

		// Token: 0x04000026 RID: 38
		private Color ErrorText = Color.FromArgb(254, 142, 122);

		// Token: 0x04000027 RID: 39
		private Color InfoColor = Color.FromArgb(70, 91, 94);

		// Token: 0x04000028 RID: 40
		private Color InfoText = Color.FromArgb(97, 185, 186);

		// Token: 0x02000008 RID: 8
		[Flags]
		public enum _Kind
		{
			// Token: 0x0400002A RID: 42
			Success = 0,
			// Token: 0x0400002B RID: 43
			Error = 1,
			// Token: 0x0400002C RID: 44
			Info = 2
		}
	}
}

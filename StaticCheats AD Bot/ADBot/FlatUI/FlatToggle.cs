using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000021 RID: 33
	[DefaultEvent("CheckedChanged")]
	public class FlatToggle : Control
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600014A RID: 330 RVA: 0x00008F3C File Offset: 0x0000713C
		// (remove) Token: 0x0600014B RID: 331 RVA: 0x00008F74 File Offset: 0x00007174
		public event FlatToggle.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00008FAC File Offset: 0x000071AC
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00002A2F File Offset: 0x00000C2F
		[Category("Options")]
		public FlatToggle._Options Options
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

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00008FC4 File Offset: 0x000071C4
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00002A39 File Offset: 0x00000C39
		[Category("Options")]
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000215B File Offset: 0x0000035B
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00002A43 File Offset: 0x00000C43
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Width = 76;
			base.Height = 33;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00002A60 File Offset: 0x00000C60
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00002A79 File Offset: 0x00000C79
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00002A92 File Offset: 0x00000C92
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00002AAB File Offset: 0x00000CAB
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00008FDC File Offset: 0x000071DC
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this._Checked = !this._Checked;
			bool flag = this.CheckedChanged != null;
			if (flag)
			{
				this.CheckedChanged(this);
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00009020 File Offset: 0x00007220
		public FlatToggle()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.Size = new Size(44, base.Height + 1);
			this.Cursor = Cursors.Hand;
			this.Font = new Font("Segoe UI", 10f);
			base.Size = new Size(76, 33);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00009108 File Offset: 0x00007308
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			GraphicsPath path = new GraphicsPath();
			GraphicsPath graphicsPath = new GraphicsPath();
			Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
			Rectangle rectangle2 = new Rectangle(Convert.ToInt32(this.W / 2), 0, 38, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			switch (this.O)
			{
			case FlatToggle._Options.Style1:
			{
				path = Helpers.RoundRec(rectangle, 6);
				graphicsPath = Helpers.RoundRec(rectangle2, 6);
				graphics2.FillPath(new SolidBrush(this.BGColor), path);
				graphics2.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
				graphics2.DrawString("OFF", this.Font, new SolidBrush(this.BGColor), new Rectangle(19, 1, this.W, this.H), Helpers.CenterSF);
				bool @checked = this.Checked;
				if (@checked)
				{
					path = Helpers.RoundRec(rectangle, 6);
					graphicsPath = Helpers.RoundRec(new Rectangle(Convert.ToInt32(this.W / 2), 0, 38, this.H), 6);
					graphics2.FillPath(new SolidBrush(this.ToggleColor), path);
					graphics2.FillPath(new SolidBrush(this.BaseColor), graphicsPath);
					graphics2.DrawString("ON", this.Font, new SolidBrush(this.BaseColor), new Rectangle(8, 7, this.W, this.H), Helpers.NearSF);
				}
				break;
			}
			case FlatToggle._Options.Style2:
			{
				path = Helpers.RoundRec(rectangle, 6);
				rectangle2 = new Rectangle(4, 4, 36, this.H - 8);
				graphicsPath = Helpers.RoundRec(rectangle2, 4);
				graphics2.FillPath(new SolidBrush(this.BaseColorRed), path);
				graphics2.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
				graphics2.DrawLine(new Pen(this.BGColor), 18, 20, 18, 12);
				graphics2.DrawLine(new Pen(this.BGColor), 22, 20, 22, 12);
				graphics2.DrawLine(new Pen(this.BGColor), 26, 20, 26, 12);
				graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.TextColor), new Rectangle(19, 2, base.Width, base.Height), Helpers.CenterSF);
				bool checked2 = this.Checked;
				if (checked2)
				{
					path = Helpers.RoundRec(rectangle, 6);
					rectangle2 = new Rectangle(Convert.ToInt32(this.W / 2) - 2, 4, 36, this.H - 8);
					graphicsPath = Helpers.RoundRec(rectangle2, 4);
					graphics2.FillPath(new SolidBrush(this.BaseColor), path);
					graphics2.FillPath(new SolidBrush(this.ToggleColor), graphicsPath);
					graphics2.DrawLine(new Pen(this.BGColor), Convert.ToInt32(this.W / 2) + 12, 20, Convert.ToInt32(this.W / 2) + 12, 12);
					graphics2.DrawLine(new Pen(this.BGColor), Convert.ToInt32(this.W / 2) + 16, 20, Convert.ToInt32(this.W / 2) + 16, 12);
					graphics2.DrawLine(new Pen(this.BGColor), Convert.ToInt32(this.W / 2) + 20, 20, Convert.ToInt32(this.W / 2) + 20, 12);
					graphics2.DrawString("ü", new Font("Wingdings", 14f), new SolidBrush(this.TextColor), new Rectangle(8, 7, base.Width, base.Height), Helpers.NearSF);
				}
				break;
			}
			case FlatToggle._Options.Style3:
			{
				path = Helpers.RoundRec(rectangle, 16);
				rectangle2 = new Rectangle(this.W - 28, 4, 22, this.H - 8);
				graphicsPath.AddEllipse(rectangle2);
				graphics2.FillPath(new SolidBrush(this.ToggleColor), path);
				graphics2.FillPath(new SolidBrush(this.BaseColorRed), graphicsPath);
				graphics2.DrawString("OFF", this.Font, new SolidBrush(this.BaseColorRed), new Rectangle(-12, 2, this.W, this.H), Helpers.CenterSF);
				bool checked3 = this.Checked;
				if (checked3)
				{
					path = Helpers.RoundRec(rectangle, 16);
					rectangle2 = new Rectangle(6, 4, 22, this.H - 8);
					graphicsPath.Reset();
					graphicsPath.AddEllipse(rectangle2);
					graphics2.FillPath(new SolidBrush(this.ToggleColor), path);
					graphics2.FillPath(new SolidBrush(this.BaseColor), graphicsPath);
					graphics2.DrawString("ON", this.Font, new SolidBrush(this.BaseColor), new Rectangle(12, 2, this.W, this.H), Helpers.CenterSF);
				}
				break;
			}
			case FlatToggle._Options.Style4:
			{
				bool checked4 = this.Checked;
				if (checked4)
				{
				}
				break;
			}
			case FlatToggle._Options.Style5:
			{
				bool checked5 = this.Checked;
				if (checked5)
				{
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

		// Token: 0x06000159 RID: 345 RVA: 0x000096C4 File Offset: 0x000078C4
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this.BaseColor = colors.Flat;
		}

		// Token: 0x040000AB RID: 171
		private int W;

		// Token: 0x040000AC RID: 172
		private int H;

		// Token: 0x040000AD RID: 173
		private FlatToggle._Options O;

		// Token: 0x040000AE RID: 174
		private bool _Checked = false;

		// Token: 0x040000AF RID: 175
		private MouseState State = MouseState.None;

		// Token: 0x040000B1 RID: 177
		private Color BaseColor = Helpers.FlatColor;

		// Token: 0x040000B2 RID: 178
		private Color BaseColorRed = Color.FromArgb(220, 85, 96);

		// Token: 0x040000B3 RID: 179
		private Color BGColor = Color.FromArgb(84, 85, 86);

		// Token: 0x040000B4 RID: 180
		private Color ToggleColor = Color.FromArgb(45, 47, 49);

		// Token: 0x040000B5 RID: 181
		private Color TextColor = Color.FromArgb(243, 243, 243);

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x0600015B RID: 347
		public delegate void CheckedChangedEventHandler(object sender);

		// Token: 0x02000023 RID: 35
		[Flags]
		public enum _Options
		{
			// Token: 0x040000B7 RID: 183
			Style1 = 0,
			// Token: 0x040000B8 RID: 184
			Style2 = 1,
			// Token: 0x040000B9 RID: 185
			Style3 = 2,
			// Token: 0x040000BA RID: 186
			Style4 = 3,
			// Token: 0x040000BB RID: 187
			Style5 = 4
		}
	}
}

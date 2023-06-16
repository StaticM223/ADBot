using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000020 RID: 32
	[DefaultEvent("TextChanged")]
	public class FlatTextBox : Control
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00008838 File Offset: 0x00006A38
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00008850 File Offset: 0x00006A50
		[Category("Options")]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return this._TextAlign;
			}
			set
			{
				this._TextAlign = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.TextAlign = value;
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00008884 File Offset: 0x00006A84
		// (set) Token: 0x0600012E RID: 302 RVA: 0x0000889C File Offset: 0x00006A9C
		[Category("Options")]
		public int MaxLength
		{
			get
			{
				return this._MaxLength;
			}
			set
			{
				this._MaxLength = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.MaxLength = value;
				}
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600012F RID: 303 RVA: 0x000088D0 File Offset: 0x00006AD0
		// (set) Token: 0x06000130 RID: 304 RVA: 0x000088E8 File Offset: 0x00006AE8
		[Category("Options")]
		public bool ReadOnly
		{
			get
			{
				return this._ReadOnly;
			}
			set
			{
				this._ReadOnly = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.ReadOnly = value;
				}
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000131 RID: 305 RVA: 0x0000891C File Offset: 0x00006B1C
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00008934 File Offset: 0x00006B34
		[Category("Options")]
		public bool UseSystemPasswordChar
		{
			get
			{
				return this._UseSystemPasswordChar;
			}
			set
			{
				this._UseSystemPasswordChar = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.UseSystemPasswordChar = value;
				}
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00008968 File Offset: 0x00006B68
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00008980 File Offset: 0x00006B80
		[Category("Options")]
		public bool Multiline
		{
			get
			{
				return this._Multiline;
			}
			set
			{
				this._Multiline = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.Multiline = value;
					if (value)
					{
						this.TB.Height = base.Height - 11;
					}
					else
					{
						base.Height = this.TB.Height + 11;
					}
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000089E8 File Offset: 0x00006BE8
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000029AF File Offset: 0x00000BAF
		[Category("Options")]
		public bool FocusOnHover
		{
			get
			{
				return this._FocusOnHover;
			}
			set
			{
				this._FocusOnHover = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000137 RID: 311 RVA: 0x0000402C File Offset: 0x0000222C
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00008A00 File Offset: 0x00006C00
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
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.Text = value;
				}
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00008A34 File Offset: 0x00006C34
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00008A4C File Offset: 0x00006C4C
		[Category("Options")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				bool flag = this.TB != null;
				if (flag)
				{
					this.TB.Font = value;
					this.TB.Location = new Point(3, 5);
					this.TB.Width = base.Width - 6;
					bool flag2 = !this._Multiline;
					if (flag2)
					{
						base.Height = this.TB.Height + 11;
					}
				}
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00008ACC File Offset: 0x00006CCC
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			bool flag = !base.Controls.Contains(this.TB);
			if (flag)
			{
				base.Controls.Add(this.TB);
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000029B9 File Offset: 0x00000BB9
		private void OnBaseTextChanged(object s, EventArgs e)
		{
			this.Text = this.TB.Text;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00008B10 File Offset: 0x00006D10
		private void OnBaseKeyDown(object s, KeyEventArgs e)
		{
			bool flag = e.Control && e.KeyCode == Keys.A;
			if (flag)
			{
				this.TB.SelectAll();
				e.SuppressKeyPress = true;
			}
			bool flag2 = e.Control && e.KeyCode == Keys.C;
			if (flag2)
			{
				this.TB.Copy();
				e.SuppressKeyPress = true;
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00008B7C File Offset: 0x00006D7C
		protected override void OnResize(EventArgs e)
		{
			this.TB.Location = new Point(5, 5);
			this.TB.Width = base.Width - 10;
			bool multiline = this._Multiline;
			if (multiline)
			{
				this.TB.Height = base.Height - 11;
			}
			else
			{
				base.Height = this.TB.Height + 11;
			}
			base.OnResize(e);
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00008BF4 File Offset: 0x00006DF4
		// (set) Token: 0x06000140 RID: 320 RVA: 0x000029CE File Offset: 0x00000BCE
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

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00008BF4 File Offset: 0x00006DF4
		// (set) Token: 0x06000142 RID: 322 RVA: 0x000029CE File Offset: 0x00000BCE
		public override Color ForeColor
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

		// Token: 0x06000143 RID: 323 RVA: 0x000029D8 File Offset: 0x00000BD8
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000029F1 File Offset: 0x00000BF1
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			base.Invalidate();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00008C0C File Offset: 0x00006E0C
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			bool focusOnHover = this.FocusOnHover;
			if (focusOnHover)
			{
				this.TB.Focus();
			}
			base.Invalidate();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00002A16 File Offset: 0x00000C16
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00008C48 File Offset: 0x00006E48
		public FlatTextBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			this.TB = new TextBox();
			this.TB.Font = new Font("Segoe UI", 10f);
			this.TB.Text = this.Text;
			this.TB.BackColor = this._BaseColor;
			this.TB.ForeColor = this._TextColor;
			this.TB.MaxLength = this._MaxLength;
			this.TB.Multiline = this._Multiline;
			this.TB.ReadOnly = this._ReadOnly;
			this.TB.UseSystemPasswordChar = this._UseSystemPasswordChar;
			this.TB.BorderStyle = BorderStyle.None;
			this.TB.Location = new Point(5, 5);
			this.TB.Width = base.Width - 10;
			this.TB.Cursor = Cursors.IBeam;
			bool multiline = this._Multiline;
			if (multiline)
			{
				this.TB.Height = base.Height - 11;
			}
			else
			{
				base.Height = this.TB.Height + 11;
			}
			this.TB.TextChanged += this.OnBaseTextChanged;
			this.TB.KeyDown += this.OnBaseKeyDown;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00008E28 File Offset: 0x00007028
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			this.TB.BackColor = this._BaseColor;
			this.TB.ForeColor = this._TextColor;
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00008F18 File Offset: 0x00007118
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._BorderColor = colors.Flat;
		}

		// Token: 0x0400009E RID: 158
		private int W;

		// Token: 0x0400009F RID: 159
		private int H;

		// Token: 0x040000A0 RID: 160
		private MouseState State = MouseState.None;

		// Token: 0x040000A1 RID: 161
		private TextBox TB;

		// Token: 0x040000A2 RID: 162
		private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;

		// Token: 0x040000A3 RID: 163
		private int _MaxLength = 32767;

		// Token: 0x040000A4 RID: 164
		private bool _ReadOnly;

		// Token: 0x040000A5 RID: 165
		private bool _UseSystemPasswordChar;

		// Token: 0x040000A6 RID: 166
		private bool _Multiline;

		// Token: 0x040000A7 RID: 167
		private bool _FocusOnHover = false;

		// Token: 0x040000A8 RID: 168
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x040000A9 RID: 169
		private Color _TextColor = Color.FromArgb(192, 192, 192);

		// Token: 0x040000AA RID: 170
		private Color _BorderColor = Helpers.FlatColor;
	}
}

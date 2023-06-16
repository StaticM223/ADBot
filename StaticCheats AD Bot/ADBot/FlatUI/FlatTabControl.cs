using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200001F RID: 31
	public class FlatTabControl : TabControl
	{
		// Token: 0x06000123 RID: 291 RVA: 0x00002989 File Offset: 0x00000B89
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Alignment = TabAlignment.Top;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00008274 File Offset: 0x00006474
		// (set) Token: 0x06000125 RID: 293 RVA: 0x0000299B File Offset: 0x00000B9B
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

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000126 RID: 294 RVA: 0x0000828C File Offset: 0x0000648C
		// (set) Token: 0x06000127 RID: 295 RVA: 0x000029A5 File Offset: 0x00000BA5
		[Category("Colors")]
		public Color ActiveColor
		{
			get
			{
				return this._ActiveColor;
			}
			set
			{
				this._ActiveColor = value;
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000082A4 File Offset: 0x000064A4
		public FlatTabControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Font = new Font("Segoe UI", 10f);
			base.SizeMode = TabSizeMode.Fixed;
			base.ItemSize = new Size(120, 40);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000833C File Offset: 0x0000653C
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this._BaseColor);
			try
			{
				base.SelectedTab.BackColor = this.BGColor;
			}
			catch
			{
			}
			for (int i = 0; i <= base.TabCount - 1; i++)
			{
				Rectangle rectangle = new Rectangle(new Point(base.GetTabRect(i).Location.X + 2, base.GetTabRect(i).Location.Y), new Size(base.GetTabRect(i).Width, base.GetTabRect(i).Height));
				Rectangle rectangle2 = new Rectangle(rectangle.Location, new Size(rectangle.Width, rectangle.Height));
				bool flag = i == base.SelectedIndex;
				if (flag)
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
					graphics2.FillRectangle(new SolidBrush(this._ActiveColor), rectangle2);
					bool flag2 = base.ImageList != null;
					if (flag2)
					{
						try
						{
							bool flag3 = base.ImageList.Images[base.TabPages[i].ImageIndex] != null;
							if (flag3)
							{
								graphics2.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 6));
								graphics2.DrawString("      " + base.TabPages[i].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
							}
							else
							{
								graphics2.DrawString(base.TabPages[i].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
							}
						}
						catch (Exception ex)
						{
							throw new Exception(ex.Message);
						}
					}
					else
					{
						graphics2.DrawString(base.TabPages[i].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
					}
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
					bool flag4 = base.ImageList != null;
					if (flag4)
					{
						try
						{
							bool flag5 = base.ImageList.Images[base.TabPages[i].ImageIndex] != null;
							if (flag5)
							{
								graphics2.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 6));
								graphics2.DrawString("      " + base.TabPages[i].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
							else
							{
								graphics2.DrawString(base.TabPages[i].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
						}
						catch (Exception ex2)
						{
							throw new Exception(ex2.Message);
						}
					}
					else
					{
						graphics2.DrawString(base.TabPages[i].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
						{
							LineAlignment = StringAlignment.Center,
							Alignment = StringAlignment.Center
						});
					}
				}
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00008814 File Offset: 0x00006A14
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._ActiveColor = colors.Flat;
		}

		// Token: 0x04000099 RID: 153
		private int W;

		// Token: 0x0400009A RID: 154
		private int H;

		// Token: 0x0400009B RID: 155
		private Color BGColor = Color.FromArgb(60, 70, 73);

		// Token: 0x0400009C RID: 156
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x0400009D RID: 157
		private Color _ActiveColor = Helpers.FlatColor;
	}
}

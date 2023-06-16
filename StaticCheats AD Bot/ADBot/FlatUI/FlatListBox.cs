using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000015 RID: 21
	public class FlatListBox : Control
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00005F74 File Offset: 0x00004174
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00005F8C File Offset: 0x0000418C
		private ListBox ListBx
		{
			get
			{
				return this.withEventsField_ListBx;
			}
			set
			{
				bool flag = this.withEventsField_ListBx != null;
				if (flag)
				{
					this.withEventsField_ListBx.DrawItem -= this.Drawitem;
				}
				this.withEventsField_ListBx = value;
				bool flag2 = this.withEventsField_ListBx != null;
				if (flag2)
				{
					this.withEventsField_ListBx.DrawItem += this.Drawitem;
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00005FF0 File Offset: 0x000041F0
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00006008 File Offset: 0x00004208
		[Category("Options")]
		public string[] items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
				this.ListBx.Items.Clear();
				this.ListBx.Items.AddRange(value);
				base.Invalidate();
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000604C File Offset: 0x0000424C
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x0000261A File Offset: 0x0000081A
		[Category("Colors")]
		public Color SelectedColor
		{
			get
			{
				return this._SelectedColor;
			}
			set
			{
				this._SelectedColor = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00006064 File Offset: 0x00004264
		public string SelectedItem
		{
			get
			{
				return this.ListBx.SelectedItem.ToString();
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00006088 File Offset: 0x00004288
		public int SelectedIndex
		{
			get
			{
				return this.ListBx.SelectedIndex;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00002624 File Offset: 0x00000824
		public void Clear()
		{
			this.ListBx.Items.Clear();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000060A8 File Offset: 0x000042A8
		public void ClearSelected()
		{
			for (int i = this.ListBx.SelectedItems.Count - 1; i >= 0; i += -1)
			{
				this.ListBx.Items.Remove(this.ListBx.SelectedItems[i]);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006100 File Offset: 0x00004300
		public void Drawitem(object sender, DrawItemEventArgs e)
		{
			bool flag = e.Index < 0;
			if (!flag)
			{
				e.DrawBackground();
				e.DrawFocusRectangle();
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				bool flag2 = e.State.ToString().IndexOf("Selected,") >= 0;
				if (flag2)
				{
					e.Graphics.FillRectangle(new SolidBrush(this._SelectedColor), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
					e.Graphics.DrawString(" " + this.ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8f), Brushes.White, (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 53, 55)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
					e.Graphics.DrawString(" " + this.ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8f), Brushes.White, (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
				}
				e.Graphics.Dispose();
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000631C File Offset: 0x0000451C
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			bool flag = !base.Controls.Contains(this.ListBx);
			if (flag)
			{
				base.Controls.Add(this.ListBx);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00002638 File Offset: 0x00000838
		public void AddRange(object[] items)
		{
			this.ListBx.Items.Remove("");
			this.ListBx.Items.AddRange(items);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00002663 File Offset: 0x00000863
		public void AddItem(object item)
		{
			this.ListBx.Items.Remove("");
			this.ListBx.Items.Add(item);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00006360 File Offset: 0x00004560
		public FlatListBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.ListBx.DrawMode = DrawMode.OwnerDrawFixed;
			this.ListBx.ScrollAlwaysVisible = false;
			this.ListBx.HorizontalScrollbar = false;
			this.ListBx.BorderStyle = BorderStyle.None;
			this.ListBx.BackColor = this.BaseColor;
			this.ListBx.ForeColor = Color.White;
			this.ListBx.Location = new Point(3, 3);
			this.ListBx.Font = new Font("Segoe UI", 8f);
			this.ListBx.ItemHeight = 20;
			this.ListBx.Items.Clear();
			this.ListBx.IntegralHeight = false;
			base.Size = new Size(131, 101);
			this.BackColor = this.BaseColor;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006498 File Offset: 0x00004698
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			this.ListBx.Size = new Size(base.Width - 6, base.Height - 2);
			graphics2.FillRectangle(new SolidBrush(this.BaseColor), rect);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00006568 File Offset: 0x00004768
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._SelectedColor = colors.Flat;
		}

		// Token: 0x04000060 RID: 96
		private ListBox withEventsField_ListBx = new ListBox();

		// Token: 0x04000061 RID: 97
		private string[] _items = new string[]
		{
			""
		};

		// Token: 0x04000062 RID: 98
		private Color BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000063 RID: 99
		private Color _SelectedColor = Helpers.FlatColor;
	}
}

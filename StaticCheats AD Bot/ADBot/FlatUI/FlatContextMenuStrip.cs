using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000011 RID: 17
	public class FlatContextMenuStrip : ContextMenuStrip
	{
		// Token: 0x0600007F RID: 127 RVA: 0x0000215B File Offset: 0x0000035B
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00005C1C File Offset: 0x00003E1C
		public FlatContextMenuStrip()
		{
			base.Renderer = new ToolStripProfessionalRenderer(new FlatContextMenuStrip.TColorTable());
			base.ShowImageMargin = false;
			base.ForeColor = Color.White;
			this.Font = new Font("Segoe UI", 8f);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002588 File Offset: 0x00000788
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		}

		// Token: 0x02000012 RID: 18
		public class TColorTable : ProfessionalColorTable
		{
			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000082 RID: 130 RVA: 0x00005C6C File Offset: 0x00003E6C
			// (set) Token: 0x06000083 RID: 131 RVA: 0x000025A0 File Offset: 0x000007A0
			[Category("Colors")]
			public Color _BackColor
			{
				get
				{
					return this.BackColor;
				}
				set
				{
					this.BackColor = value;
				}
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000084 RID: 132 RVA: 0x00005C84 File Offset: 0x00003E84
			// (set) Token: 0x06000085 RID: 133 RVA: 0x000025AA File Offset: 0x000007AA
			[Category("Colors")]
			public Color _CheckedColor
			{
				get
				{
					return this.CheckedColor;
				}
				set
				{
					this.CheckedColor = value;
				}
			}

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000086 RID: 134 RVA: 0x00005C9C File Offset: 0x00003E9C
			// (set) Token: 0x06000087 RID: 135 RVA: 0x000025B4 File Offset: 0x000007B4
			[Category("Colors")]
			public Color _BorderColor
			{
				get
				{
					return this.BorderColor;
				}
				set
				{
					this.BorderColor = value;
				}
			}

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000088 RID: 136 RVA: 0x00005C6C File Offset: 0x00003E6C
			public override Color ButtonSelectedBorder
			{
				get
				{
					return this.BackColor;
				}
			}

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000089 RID: 137 RVA: 0x00005C84 File Offset: 0x00003E84
			public override Color CheckBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600008A RID: 138 RVA: 0x00005C84 File Offset: 0x00003E84
			public override Color CheckPressedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600008B RID: 139 RVA: 0x00005C84 File Offset: 0x00003E84
			public override Color CheckSelectedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600008C RID: 140 RVA: 0x00005C84 File Offset: 0x00003E84
			public override Color ImageMarginGradientBegin
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600008D RID: 141 RVA: 0x00005C84 File Offset: 0x00003E84
			public override Color ImageMarginGradientEnd
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x0600008E RID: 142 RVA: 0x00005C84 File Offset: 0x00003E84
			public override Color ImageMarginGradientMiddle
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600008F RID: 143 RVA: 0x00005C9C File Offset: 0x00003E9C
			public override Color MenuBorder
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000090 RID: 144 RVA: 0x00005C9C File Offset: 0x00003E9C
			public override Color MenuItemBorder
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000091 RID: 145 RVA: 0x00005C84 File Offset: 0x00003E84
			public override Color MenuItemSelected
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000092 RID: 146 RVA: 0x00005C9C File Offset: 0x00003E9C
			public override Color SeparatorDark
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000093 RID: 147 RVA: 0x00005C6C File Offset: 0x00003E6C
			public override Color ToolStripDropDownBackground
			{
				get
				{
					return this.BackColor;
				}
			}

			// Token: 0x04000058 RID: 88
			private Color BackColor = Color.FromArgb(45, 47, 49);

			// Token: 0x04000059 RID: 89
			private Color CheckedColor = Helpers.FlatColor;

			// Token: 0x0400005A RID: 90
			private Color BorderColor = Color.FromArgb(53, 58, 60);
		}
	}
}

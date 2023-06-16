using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000014 RID: 20
	public class FlatLabel : Label
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00002608 File Offset: 0x00000808
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00005F14 File Offset: 0x00004114
		public FlatLabel()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = Color.White;
			this.BackColor = Color.Transparent;
			this.Text = this.Text;
		}
	}
}

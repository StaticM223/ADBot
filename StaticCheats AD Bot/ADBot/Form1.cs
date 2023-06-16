using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FlatUI;

namespace ADBot
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002B58 File Offset: 0x00000D58
		private void flatButton1_Click(object sender, EventArgs e)
		{
			if (this.proxies.Items.Count < 1)
			{
				MessageBox.Show("You must load a proxy list first before you can start the bot.");
				return;
			}
			if (!this.flatToggle1.Checked)
			{
				MessageBox.Show("You must have proxies on in order to start.");
				return;
			}
			int interval = decimal.ToInt32(this.numericUpDown1.Value);
			this.browser.Navigate(this.link.Text);
			this.timer1.Interval = interval;
			this.timer1.Start();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000205E File Offset: 0x0000025E
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002BDC File Offset: 0x00000DDC
		private void flatButton3_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.ShowDialog();
			foreach (string item in Regex.Split(File.ReadAllText(openFileDialog.FileName), "\r\n|\r|\n"))
			{
				this.proxies.Items.Add(item);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002060 File Offset: 0x00000260
		private void flatButton4_Click(object sender, EventArgs e)
		{
			while (this.proxies.SelectedItems.Count != 0)
			{
				this.proxies.Items.Remove(this.proxies.SelectedItems[0]);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002097 File Offset: 0x00000297
		private void flatButton5_Click(object sender, EventArgs e)
		{
			this.proxies.Items.Add(this.add.Text);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002C30 File Offset: 0x00000E30
		private void timer1_Tick(object sender, EventArgs e)
		{
			Form1.Global.x++;
			this.piu.Text = "Proxy in Use: ";
			this.browser.Navigate(this.link.Text);
			this.piu.Text = this.piu.Text + " " + this.proxies.Items[Form1.Global.x];
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020B5 File Offset: 0x000002B5
		private void flatButton2_Click(object sender, EventArgs e)
		{
			this.timer1.Stop();
			this.browser.Navigate("about:blank");
		}

		// Token: 0x02000003 RID: 3
		public static class Global
		{
			// Token: 0x04000018 RID: 24
			public static int x = 4;
		}
	}
}

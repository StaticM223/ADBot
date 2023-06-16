namespace ADBot
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000020D2 File Offset: 0x000002D2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002CA4 File Offset: 0x00000EA4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.timer2 = new global::System.Windows.Forms.Timer(this.components);
			this.formSkin1 = new global::FlatUI.FormSkin();
			this.flatClose1 = new global::FlatUI.FlatClose();
			this.tabControl = new global::FlatUI.FlatTabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.numericUpDown1 = new global::System.Windows.Forms.NumericUpDown();
			this.piu = new global::FlatUI.FlatLabel();
			this.flatLabel1 = new global::FlatUI.FlatLabel();
			this.label1 = new global::FlatUI.FlatLabel();
			this.flatToggle2 = new global::FlatUI.FlatToggle();
			this.flatToggle1 = new global::FlatUI.FlatToggle();
			this.link = new global::FlatUI.FlatTextBox();
			this.browser = new global::System.Windows.Forms.WebBrowser();
			this.flatButton2 = new global::FlatUI.FlatButton();
			this.flatButton1 = new global::FlatUI.FlatButton();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.flatButton5 = new global::FlatUI.FlatButton();
			this.add = new global::FlatUI.FlatTextBox();
			this.flatButton4 = new global::FlatUI.FlatButton();
			this.flatButton3 = new global::FlatUI.FlatButton();
			this.proxies = new global::System.Windows.Forms.ListBox();
			this.formSkin1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			this.tabPage2.SuspendLayout();
			base.SuspendLayout();
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.formSkin1.BackColor = global::System.Drawing.Color.White;
			this.formSkin1.BaseColor = global::System.Drawing.Color.FromArgb(60, 70, 73);
			this.formSkin1.BorderColor = global::System.Drawing.Color.FromArgb(53, 58, 60);
			this.formSkin1.Controls.Add(this.flatClose1);
			this.formSkin1.Controls.Add(this.tabControl);
			this.formSkin1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.formSkin1.FlatColor = global::System.Drawing.Color.Red;
			this.formSkin1.Font = new global::System.Drawing.Font("Corbel", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.formSkin1.HeaderColor = global::System.Drawing.Color.FromArgb(45, 47, 49);
			this.formSkin1.HeaderMaximize = false;
			this.formSkin1.Location = new global::System.Drawing.Point(0, 0);
			this.formSkin1.Name = "formSkin1";
			this.formSkin1.Size = new global::System.Drawing.Size(523, 333);
			this.formSkin1.TabIndex = 0;
			this.formSkin1.Text = "StaticCheats AD Bot";
			this.flatClose1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.flatClose1.BackColor = global::System.Drawing.Color.White;
			this.flatClose1.BaseColor = global::System.Drawing.Color.FromArgb(168, 35, 35);
			this.flatClose1.Font = new global::System.Drawing.Font("Marlett", 10f);
			this.flatClose1.Location = new global::System.Drawing.Point(493, 13);
			this.flatClose1.Name = "flatClose1";
			this.flatClose1.Size = new global::System.Drawing.Size(18, 18);
			this.flatClose1.TabIndex = 1;
			this.flatClose1.Text = "flatClose1";
			this.flatClose1.TextColor = global::System.Drawing.Color.FromArgb(243, 243, 243);
			this.tabControl.ActiveColor = global::System.Drawing.Color.Red;
			this.tabControl.BaseColor = global::System.Drawing.Color.FromArgb(45, 47, 49);
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Font = new global::System.Drawing.Font("Corbel", 12.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl.ItemSize = new global::System.Drawing.Size(120, 40);
			this.tabControl.Location = new global::System.Drawing.Point(0, 50);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new global::System.Drawing.Size(523, 283);
			this.tabControl.SizeMode = global::System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl.TabIndex = 0;
			this.tabPage1.BackColor = global::System.Drawing.Color.FromArgb(60, 70, 73);
			this.tabPage1.Controls.Add(this.numericUpDown1);
			this.tabPage1.Controls.Add(this.piu);
			this.tabPage1.Controls.Add(this.flatLabel1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.flatToggle2);
			this.tabPage1.Controls.Add(this.flatToggle1);
			this.tabPage1.Controls.Add(this.link);
			this.tabPage1.Controls.Add(this.browser);
			this.tabPage1.Controls.Add(this.flatButton2);
			this.tabPage1.Controls.Add(this.flatButton1);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 44);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(515, 235);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Views";
			this.numericUpDown1.BackColor = global::System.Drawing.Color.FromArgb(45, 47, 49);
			this.numericUpDown1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.numericUpDown1.ForeColor = global::System.Drawing.Color.White;
			this.numericUpDown1.Location = new global::System.Drawing.Point(12, 44);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown1;
			int[] array = new int[4];
			array[0] = 999999;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown1;
			int[] array2 = new int[4];
			array2[0] = 10000;
			numericUpDown2.Minimum = new decimal(array2);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(229, 24);
			this.numericUpDown1.TabIndex = 10;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown1;
			int[] array3 = new int[4];
			array3[0] = 10000;
			numericUpDown3.Value = new decimal(array3);
			this.piu.AutoSize = true;
			this.piu.BackColor = global::System.Drawing.Color.Transparent;
			this.piu.Font = new global::System.Drawing.Font("Corbel", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.piu.ForeColor = global::System.Drawing.Color.White;
			this.piu.Location = new global::System.Drawing.Point(249, 211);
			this.piu.Name = "piu";
			this.piu.Size = new global::System.Drawing.Size(88, 18);
			this.piu.TabIndex = 9;
			this.piu.Text = "Proxy in Use:";
			this.flatLabel1.AutoSize = true;
			this.flatLabel1.BackColor = global::System.Drawing.Color.Transparent;
			this.flatLabel1.Font = new global::System.Drawing.Font("Corbel", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.flatLabel1.ForeColor = global::System.Drawing.Color.White;
			this.flatLabel1.Location = new global::System.Drawing.Point(173, 86);
			this.flatLabel1.Name = "flatLabel1";
			this.flatLabel1.Size = new global::System.Drawing.Size(46, 18);
			this.flatLabel1.TabIndex = 8;
			this.flatLabel1.Text = "Anon.";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Corbel", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(11, 85);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(53, 18);
			this.label1.TabIndex = 7;
			this.label1.Text = "Proxies";
			this.flatToggle2.BackColor = global::System.Drawing.Color.Transparent;
			this.flatToggle2.Checked = true;
			this.flatToggle2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.flatToggle2.Font = new global::System.Drawing.Font("Segoe UI", 10f);
			this.flatToggle2.Location = new global::System.Drawing.Point(167, 106);
			this.flatToggle2.Name = "flatToggle2";
			this.flatToggle2.Options = global::FlatUI.FlatToggle._Options.Style1;
			this.flatToggle2.Size = new global::System.Drawing.Size(76, 33);
			this.flatToggle2.TabIndex = 6;
			this.flatToggle2.Text = "flatToggle2";
			this.flatToggle1.BackColor = global::System.Drawing.Color.Transparent;
			this.flatToggle1.Checked = true;
			this.flatToggle1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.flatToggle1.Font = new global::System.Drawing.Font("Segoe UI", 10f);
			this.flatToggle1.Location = new global::System.Drawing.Point(8, 106);
			this.flatToggle1.Name = "flatToggle1";
			this.flatToggle1.Options = global::FlatUI.FlatToggle._Options.Style1;
			this.flatToggle1.Size = new global::System.Drawing.Size(76, 33);
			this.flatToggle1.TabIndex = 5;
			this.flatToggle1.Text = "flatToggle1";
			this.link.BackColor = global::System.Drawing.Color.Transparent;
			this.link.FocusOnHover = false;
			this.link.Location = new global::System.Drawing.Point(8, 6);
			this.link.MaxLength = 32767;
			this.link.Multiline = false;
			this.link.Name = "link";
			this.link.ReadOnly = false;
			this.link.Size = new global::System.Drawing.Size(235, 29);
			this.link.TabIndex = 3;
			this.link.Text = "Website Link";
			this.link.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.link.TextColor = global::System.Drawing.Color.FromArgb(192, 192, 192);
			this.link.UseSystemPasswordChar = false;
			this.browser.Location = new global::System.Drawing.Point(249, 2);
			this.browser.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.browser.Name = "browser";
			this.browser.Size = new global::System.Drawing.Size(263, 227);
			this.browser.TabIndex = 2;
			this.flatButton2.BackColor = global::System.Drawing.Color.Transparent;
			this.flatButton2.BaseColor = global::System.Drawing.Color.Red;
			this.flatButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.flatButton2.Font = new global::System.Drawing.Font("Corbel", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.flatButton2.Location = new global::System.Drawing.Point(8, 194);
			this.flatButton2.Name = "flatButton2";
			this.flatButton2.Rounded = false;
			this.flatButton2.Size = new global::System.Drawing.Size(235, 33);
			this.flatButton2.TabIndex = 1;
			this.flatButton2.Text = "Stop";
			this.flatButton2.TextColor = global::System.Drawing.Color.FromArgb(243, 243, 243);
			this.flatButton2.Click += new global::System.EventHandler(this.flatButton2_Click);
			this.flatButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.flatButton1.BaseColor = global::System.Drawing.Color.Red;
			this.flatButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.flatButton1.Font = new global::System.Drawing.Font("Corbel", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.flatButton1.Location = new global::System.Drawing.Point(8, 155);
			this.flatButton1.Name = "flatButton1";
			this.flatButton1.Rounded = false;
			this.flatButton1.Size = new global::System.Drawing.Size(235, 33);
			this.flatButton1.TabIndex = 0;
			this.flatButton1.Text = "Start";
			this.flatButton1.TextColor = global::System.Drawing.Color.FromArgb(243, 243, 243);
			this.flatButton1.Click += new global::System.EventHandler(this.flatButton1_Click);
			this.tabPage2.BackColor = global::System.Drawing.Color.FromArgb(60, 70, 73);
			this.tabPage2.Controls.Add(this.flatButton5);
			this.tabPage2.Controls.Add(this.add);
			this.tabPage2.Controls.Add(this.flatButton4);
			this.tabPage2.Controls.Add(this.flatButton3);
			this.tabPage2.Controls.Add(this.proxies);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 44);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(515, 235);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Settings";
			this.flatButton5.BackColor = global::System.Drawing.Color.Transparent;
			this.flatButton5.BaseColor = global::System.Drawing.Color.Red;
			this.flatButton5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.flatButton5.Font = new global::System.Drawing.Font("Corbel", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.flatButton5.Location = new global::System.Drawing.Point(6, 65);
			this.flatButton5.Name = "flatButton5";
			this.flatButton5.Rounded = false;
			this.flatButton5.Size = new global::System.Drawing.Size(297, 33);
			this.flatButton5.TabIndex = 4;
			this.flatButton5.Text = "Add";
			this.flatButton5.TextColor = global::System.Drawing.Color.FromArgb(243, 243, 243);
			this.flatButton5.Click += new global::System.EventHandler(this.flatButton5_Click);
			this.add.BackColor = global::System.Drawing.Color.Transparent;
			this.add.FocusOnHover = false;
			this.add.Location = new global::System.Drawing.Point(8, 30);
			this.add.MaxLength = 32767;
			this.add.Multiline = false;
			this.add.Name = "add";
			this.add.ReadOnly = false;
			this.add.Size = new global::System.Drawing.Size(295, 29);
			this.add.TabIndex = 3;
			this.add.Text = "Add single proxy";
			this.add.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Left;
			this.add.TextColor = global::System.Drawing.Color.FromArgb(192, 192, 192);
			this.add.UseSystemPasswordChar = false;
			this.flatButton4.BackColor = global::System.Drawing.Color.Transparent;
			this.flatButton4.BaseColor = global::System.Drawing.Color.Red;
			this.flatButton4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.flatButton4.Font = new global::System.Drawing.Font("Corbel", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.flatButton4.Location = new global::System.Drawing.Point(6, 194);
			this.flatButton4.Name = "flatButton4";
			this.flatButton4.Rounded = false;
			this.flatButton4.Size = new global::System.Drawing.Size(297, 33);
			this.flatButton4.TabIndex = 2;
			this.flatButton4.Text = "Remove Selected";
			this.flatButton4.TextColor = global::System.Drawing.Color.FromArgb(243, 243, 243);
			this.flatButton4.Click += new global::System.EventHandler(this.flatButton4_Click);
			this.flatButton3.BackColor = global::System.Drawing.Color.Transparent;
			this.flatButton3.BaseColor = global::System.Drawing.Color.Red;
			this.flatButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.flatButton3.Font = new global::System.Drawing.Font("Corbel", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.flatButton3.Location = new global::System.Drawing.Point(6, 155);
			this.flatButton3.Name = "flatButton3";
			this.flatButton3.Rounded = false;
			this.flatButton3.Size = new global::System.Drawing.Size(297, 33);
			this.flatButton3.TabIndex = 1;
			this.flatButton3.Text = "Browse..";
			this.flatButton3.TextColor = global::System.Drawing.Color.FromArgb(243, 243, 243);
			this.flatButton3.Click += new global::System.EventHandler(this.flatButton3_Click);
			this.proxies.BackColor = global::System.Drawing.Color.FromArgb(45, 47, 49);
			this.proxies.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.proxies.ForeColor = global::System.Drawing.Color.White;
			this.proxies.FormattingEnabled = true;
			this.proxies.ItemHeight = 21;
			this.proxies.Location = new global::System.Drawing.Point(309, 2);
			this.proxies.Name = "proxies";
			this.proxies.Size = new global::System.Drawing.Size(206, 231);
			this.proxies.TabIndex = 0;
			this.proxies.SelectedIndexChanged += new global::System.EventHandler(this.listBox1_SelectedIndexChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(523, 333);
			base.Controls.Add(this.formSkin1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form1";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Static Cheats";
			base.TransparencyKey = global::System.Drawing.Color.Fuchsia;
			this.formSkin1.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			this.tabPage2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000002 RID: 2
		private global::FlatUI.FormSkin formSkin1;

		// Token: 0x04000003 RID: 3
		private global::FlatUI.FlatTabControl tabControl;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000005 RID: 5
		private global::FlatUI.FlatLabel flatLabel1;

		// Token: 0x04000006 RID: 6
		private global::FlatUI.FlatLabel label1;

		// Token: 0x04000007 RID: 7
		private global::FlatUI.FlatToggle flatToggle2;

		// Token: 0x04000008 RID: 8
		private global::FlatUI.FlatToggle flatToggle1;

		// Token: 0x04000009 RID: 9
		private global::FlatUI.FlatTextBox link;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.WebBrowser browser;

		// Token: 0x0400000B RID: 11
		private global::FlatUI.FlatButton flatButton2;

		// Token: 0x0400000C RID: 12
		private global::FlatUI.FlatButton flatButton1;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.ListBox proxies;

		// Token: 0x0400000F RID: 15
		private global::FlatUI.FlatButton flatButton4;

		// Token: 0x04000010 RID: 16
		private global::FlatUI.FlatButton flatButton3;

		// Token: 0x04000011 RID: 17
		private global::FlatUI.FlatButton flatButton5;

		// Token: 0x04000012 RID: 18
		private global::FlatUI.FlatTextBox add;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Timer timer2;

		// Token: 0x04000015 RID: 21
		private global::FlatUI.FlatLabel piu;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.NumericUpDown numericUpDown1;

		// Token: 0x04000017 RID: 23
		private global::FlatUI.FlatClose flatClose1;
	}
}

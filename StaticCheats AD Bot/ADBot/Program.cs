using System;
using System.Windows.Forms;

namespace ADBot
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000020F9 File Offset: 0x000002F9
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000029 RID: 41
	public static class Helpers
	{
		// Token: 0x0600018F RID: 399 RVA: 0x0000A680 File Offset: 0x00008880
		public static GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = Curve * 2;
			graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
			graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
			graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 0f, 90f);
			graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 90f, 90f);
			graphicsPath.AddLine(new Point(Rectangle.X, Rectangle.Height - num + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
			return graphicsPath;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000A798 File Offset: 0x00008998
		public static GraphicsPath RoundRect(float x, float y, float w, float h, double r = 0.3, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
		{
			float num = Math.Min(w, h) * (float)r;
			float num2 = x + w;
			float num3 = y + h;
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath graphicsPath2 = graphicsPath;
			if (TL)
			{
				graphicsPath2.AddArc(x, y, num, num, 180f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(x, y, x, y);
			}
			if (TR)
			{
				graphicsPath2.AddArc(num2 - num, y, num, num, 270f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(num2, y, num2, y);
			}
			if (BR)
			{
				graphicsPath2.AddArc(num2 - num, num3 - num, num, num, 0f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(num2, num3, num2, num3);
			}
			if (BL)
			{
				graphicsPath2.AddArc(x, num3 - num, num, num, 90f, 90f);
			}
			else
			{
				graphicsPath2.AddLine(x, num3, x, num3);
			}
			graphicsPath2.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000A88C File Offset: 0x00008A8C
		public static GraphicsPath DrawArrow(int x, int y, bool flip)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = 12;
			int num2 = 6;
			if (flip)
			{
				graphicsPath.AddLine(x + 1, y, x + num + 1, y);
				graphicsPath.AddLine(x + num, y, x + num2, y + num2 - 1);
			}
			else
			{
				graphicsPath.AddLine(x, y + num2, x + num, y + num2);
				graphicsPath.AddLine(x + num, y + num2, x + num2, y);
			}
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000A904 File Offset: 0x00008B04
		public static FlatColors GetColors(Control control)
		{
			bool flag = control == null;
			if (flag)
			{
				throw new ArgumentNullException();
			}
			FlatColors flatColors = new FlatColors();
			while (control != null && control.GetType() != typeof(FormSkin))
			{
				control = control.Parent;
			}
			bool flag2 = control != null;
			if (flag2)
			{
				FormSkin formSkin = (FormSkin)control;
				flatColors.Flat = formSkin.FlatColor;
			}
			return flatColors;
		}

		// Token: 0x040000E0 RID: 224
		public static Color FlatColor = Color.FromArgb(35, 168, 109);

		// Token: 0x040000E1 RID: 225
		public static readonly StringFormat NearSF = new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Near
		};

		// Token: 0x040000E2 RID: 226
		public static readonly StringFormat CenterSF = new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};
	}
}

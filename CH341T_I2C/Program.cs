using System;
using System.Windows.Forms;

namespace CH341T_I2C
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00003AD2 File Offset: 0x00001CD2
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new CH341_I2C());
		}
	}
}

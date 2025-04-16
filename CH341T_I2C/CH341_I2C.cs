using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CH341T_I2C
{
	// Token: 0x02000003 RID: 3
	public partial class CH341_I2C : Form
	{
		// Token: 0x06000001 RID: 1
		[DllImport("CH341DLL.DLL")]
		public static extern int CH341OpenDevice(int iIndex);

		// Token: 0x06000002 RID: 2
		[DllImport("CH341DLL.DLL")]
		public static extern bool CH341ResetDevice(int iIndex);

		// Token: 0x06000003 RID: 3
		[DllImport("CH341DLL.DLL")]
		public static extern bool CH341SetDelaymS(int iIndex, int iDelay);

		// Token: 0x06000004 RID: 4
		[DllImport("CH341DLL.DLL")]
		public unsafe static extern bool CH341ReadI2C(int iIndex, byte iDevice, byte iAddr, byte* oByte);

		// Token: 0x06000005 RID: 5
		[DllImport("CH341DLL.DLL")]
		public static extern bool CH341WriteI2C(int iIndex, byte iDevice, byte iAddr, byte oByte);

		// Token: 0x06000006 RID: 6
		[DllImport("CH341DLL.DLL")]
		public unsafe static extern bool CH341StreamI2C(int iIndex, int iWriteLength, byte* iWriteBuffer, int iReadLength, byte* oReadBuffer);

		// Token: 0x06000007 RID: 7
		[DllImport("CH341DLL.DLL")]
		public static extern bool CH341SetStream(int iIndex, int iMode);

		// Token: 0x06000008 RID: 8 RVA: 0x00002050 File Offset: 0x00000250
		public CH341_I2C()
		{
			this.InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000206C File Offset: 0x0000026C
		public void Connect_check_Handler()
		{
			for (;;)
			{
				Thread.Sleep(500);
				if (CH341_I2C.CH341OpenDevice(this.CH341_driver_num) == -1)
				{
					CH341_I2C.CH341ResetDevice(0);
					if (CH341_I2C.CH341OpenDevice(this.CH341_driver_num) == -1)
					{
						this.connect_Box.ForeColor = Color.Red;
						this.connect_Box.Text = "未连接";
					}
					else
					{
						this.connect_Box.ForeColor = Color.Blue;
						this.connect_Box.Text = "已连接";
					}
				}
				else
				{
					this.connect_Box.ForeColor = Color.Blue;
					this.connect_Box.Text = "已连接";
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002110 File Offset: 0x00000310
		public void monitor_Handler()
		{
			for (;;)
			{
				if (this.read_data_str.do_ch341streami2c_mark)
				{
					this.read_data_str.do_ch341streami2c_time = this.read_data_str.do_ch341streami2c_time + 1;
					if (this.read_data_str.do_ch341streami2c_time >= this.do_ch341streami2c_overtime)
					{
						CH341_I2C.CH341ResetDevice(this.read_data_str.iIndex);
						this.read_data_str.do_ch341streami2c_time = 0;
					}
				}
				Thread.Sleep(10);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002174 File Offset: 0x00000374
		private void Form1_Load(object sender, EventArgs e)
		{
			this.read_data_str.iIndex = 0;
			this.connect_check_thread = new Thread(new ThreadStart(this.Connect_check_Handler));
			this.connect_check_thread.IsBackground = true;
			this.connect_check_thread.Start();
			this.monitor_thread = new Thread(new ThreadStart(this.monitor_Handler));
			this.monitor_thread.IsBackground = true;
			this.monitor_thread.Start();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021EC File Offset: 0x000003EC
		public byte str_to_byte(string str)
		{
			byte[] bytes = Encoding.Default.GetBytes(str);
			byte[] array = new byte[bytes.Length / 2];
			for (int i = 0; i < bytes.Length; i++)
			{
				if (bytes[i] >= 97 && bytes[i] <= 102)
				{
					bytes[i] = (byte)(bytes[i] - 97 + 58);
				}
				else if (bytes[i] >= 65 && bytes[i] <= 70)
				{
					bytes[i] = (byte)(bytes[i] - 65 + 58);
				}
			}
			for (int j = 0; j < bytes.Length / 2; j++)
			{
				array[j] = (byte)((int)(bytes[j * 2] - 48) << 4 | (int)(bytes[j * 2 + 1] - 48));
			}
			return array[0];
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002282 File Offset: 0x00000482
		private void void_CH341StreamI2C_start()
		{
			this.read_data_str.do_ch341streami2c_mark = true;
			this.read_data_str.do_ch341streami2c_time = 0;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000229C File Offset: 0x0000049C
		private void void_CH341StreamI2C_end()
		{
			this.read_data_str.do_ch341streami2c_mark = false;
			this.read_data_str.do_ch341streami2c_time = 0;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022B8 File Offset: 0x000004B8
		private unsafe void write_button_Click(object sender, EventArgs e)
		{
			if (!this.WriteButtonClickErrorCheck())
			{
				return;
			}
			string text = this.send_Box.Text.Replace(" ", "");
			if (text.Length < 2)
			{
				MessageBox.Show("写入的数据长度错误");
				return;
			}
			byte[] bytes = Encoding.Default.GetBytes(text);
			byte[] array = new byte[bytes.Length / 2];
			for (int i = 0; i < bytes.Length; i++)
			{
				if (bytes[i] >= 97 && bytes[i] <= 102)
				{
					bytes[i] = (byte)(bytes[i] - 97 + 58);
				}
				else if (bytes[i] >= 65 && bytes[i] <= 70)
				{
					bytes[i] = (byte)(bytes[i] - 65 + 58);
				}
			}
			for (int j = 0; j < bytes.Length / 2; j++)
			{
				array[j] = (byte)((int)(bytes[j * 2] - 48) << 4 | (int)(bytes[j * 2 + 1] - 48));
			}
			this.send_data_len_Box.Text = (bytes.Length / 2).ToString();
			byte* oReadBuffer = stackalloc byte[(int)(UIntPtr)1];
			byte* ptr = stackalloc byte[(int)(UIntPtr)(3 + bytes.Length / 2)];
			*ptr = this.str_to_byte(this.addr_Box.Text);
			if (this.register_Box.Text.Length == 2)
			{
				this.read_data_str.register_l = this.str_to_byte(this.register_Box.Text);
				ptr[1] = this.read_data_str.register_l;
				for (int k = 0; k < bytes.Length / 2; k++)
				{
					ptr[k + 2] = array[k];
				}
				CH341_I2C.CH341StreamI2C(this.read_data_str.iIndex, 2 + bytes.Length / 2, ptr, 0, oReadBuffer);
				return;
			}
			if (this.register_Box.Text.Length == 4)
			{
				this.read_data_str.register_l = this.str_to_byte(this.register_Box.Text.Substring(2, 2));
				this.read_data_str.register_h = this.str_to_byte(this.register_Box.Text.Substring(0, 2));
				ptr[1] = this.read_data_str.register_h;
				ptr[2] = this.read_data_str.register_l;
				for (int l = 0; l < bytes.Length / 2; l++)
				{
					ptr[l + 3] = array[l];
				}
				CH341_I2C.CH341StreamI2C(this.read_data_str.iIndex, 3 + bytes.Length / 2, ptr, 0, oReadBuffer);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002500 File Offset: 0x00000700
		private bool ReadButtonClickErrorCheck()
		{
			if (this.read_data_len_Box.Text == "")
			{
				MessageBox.Show("读取长度为空");
				return false;
			}
			if (this.addr_Box.Text.Length != 2)
			{
				MessageBox.Show("地址长度错误");
				return false;
			}
			if (this.register_Box.Text.Length != 2 && this.register_Box.Text.Length != 4)
			{
				MessageBox.Show("寄存器长度错误，8位/16位");
				return false;
			}
			return !(this.connect_Box.Text == "未连接");
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000025A0 File Offset: 0x000007A0
		private bool WriteButtonClickErrorCheck()
		{
			if (this.send_Box.Text == "")
			{
				MessageBox.Show("发送的数据为空");
				return false;
			}
			if (this.addr_Box.Text.Length != 2)
			{
				MessageBox.Show("地址长度错误");
				return false;
			}
			if (this.register_Box.Text.Length != 2 && this.register_Box.Text.Length != 4)
			{
				MessageBox.Show("寄存器长度错误，8位/16位");
				return false;
			}
			return !(this.connect_Box.Text == "未连接");
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002640 File Offset: 0x00000840
		private unsafe void read_button_Click(object sender, EventArgs e)
		{
			if (!this.ReadButtonClickErrorCheck())
			{
				return;
			}
			this.read_data_str.addr = (byte)(this.str_to_byte(this.addr_Box.Text) >> 1);
			if (this.register_Box.Text.Length == 2)
			{
				this.read_data_str.register_l = this.str_to_byte(this.register_Box.Text.Substring(0, 2));
			}
			if (this.register_Box.Text.Length == 4)
			{
				this.read_data_str.register_l = this.str_to_byte(this.register_Box.Text.Substring(2, 2));
				this.read_data_str.register_h = this.str_to_byte(this.register_Box.Text.Substring(0, 2));
			}
			this.read_data_str.read_data_len = int.Parse(this.read_data_len_Box.Text);
			byte* ptr = stackalloc byte[(int)(UIntPtr)this.read_data_str.read_data_len];
			byte* ptr2 = stackalloc byte[(int)(UIntPtr)3];
			*ptr2 = this.str_to_byte(this.addr_Box.Text);
			if (this.register_Box.Text.Length == 2)
			{
				ptr2[1] = this.read_data_str.register_l;
				CH341_I2C.CH341StreamI2C(this.read_data_str.iIndex, 2, ptr2, 0, ptr);
			}
			else
			{
				ptr2[1] = this.read_data_str.register_h;
				ptr2[2] = this.read_data_str.register_l;
				CH341_I2C.CH341StreamI2C(this.read_data_str.iIndex, 3, ptr2, 0, ptr);
			}
			*ptr2 = ((byte)(this.str_to_byte(this.addr_Box.Text) | 1));
			this.void_CH341StreamI2C_start();
			if (!CH341_I2C.CH341StreamI2C(this.read_data_str.iIndex, 1, ptr2, this.read_data_str.read_data_len, ptr))
			{
				if (this.read_data_str.do_ch341streami2c_time < this.do_ch341streami2c_overtime)
				{
					CH341_I2C.CH341ResetDevice(this.read_data_str.iIndex);
				}
				Thread.Sleep(200);
				return;
			}
			this.void_CH341StreamI2C_end();
			for (int i = 0; i < this.read_data_str.read_data_len; i++)
			{
				this.receive_Box.AppendText(ptr[i].ToString("x2") + " ");
			}
			this.receive_Box.AppendText("\r\n");
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000286B File Offset: 0x00000A6B
		private void read_data_len_Box_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000286D File Offset: 0x00000A6D
		private void read_data_len_Box_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000286D File Offset: 0x00000A6D
		private void auto_send_time_Box_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002893 File Offset: 0x00000A93
		private void button3_Click(object sender, EventArgs e)
		{
			this.receive_Box.Text = "";
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000028A5 File Offset: 0x00000AA5
		private void Auto_read_Handler()
		{
			for (;;)
			{
				Thread.Sleep(this.auto_read_time);
				this.read_button_Click(null, null);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000028BC File Offset: 0x00000ABC
		private void auto_read_checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if (this.auto_send_time_Box.Text == "")
			{
				if (this.auto_read_checkBox.Checked)
				{
					this.auto_read_checkBox.Checked = false;
				}
				return;
			}
			this.auto_read_time = int.Parse(this.auto_send_time_Box.Text);
			if (this.auto_read_checkBox.Checked)
			{
				this.auto_read_thread = new Thread(new ThreadStart(this.Auto_read_Handler));
				this.auto_read_thread.IsBackground = true;
				this.auto_read_thread.Start();
				return;
			}
			this.auto_read_thread.Abort();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000286B File Offset: 0x00000A6B
		private void auto_send_time_Box_TextChanged(object sender, EventArgs e)
		{
		}


		// Token: 0x06000021 RID: 33 RVA: 0x0000286B File Offset: 0x00000A6B
		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002998 File Offset: 0x00000B98
		private void CH341_I2C_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000029A0 File Offset: 0x00000BA0
		private void send_Box_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'a' || e.KeyChar > 'f') && (e.KeyChar < 'A' || e.KeyChar > 'F') && e.KeyChar != ' ' && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002A03 File Offset: 0x00000C03
		private void KToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CH341_I2C.CH341SetStream(this.CH341_driver_num, 0))
			{
				MessageBox.Show("设置成功，20K速率");
				return;
			}
			MessageBox.Show("设置失败");
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002A2A File Offset: 0x00000C2A
		private void KToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (CH341_I2C.CH341SetStream(this.CH341_driver_num, 1))
			{
				MessageBox.Show("设置成功，100K速率");
				return;
			}
			MessageBox.Show("设置失败");
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002A51 File Offset: 0x00000C51
		private void KToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (CH341_I2C.CH341SetStream(this.CH341_driver_num, 2))
			{
				MessageBox.Show("设置成功，400K速率");
				return;
			}
			MessageBox.Show("设置失败");
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002A78 File Offset: 0x00000C78
		private void KToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			if (CH341_I2C.CH341SetStream(this.CH341_driver_num, 3))
			{
				MessageBox.Show("设置成功，750K速率");
				return;
			}
			MessageBox.Show("设置失败");
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000286B File Offset: 0x00000A6B
		private void receive_Box_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000286B File Offset: 0x00000A6B
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000008 RID: 8
		private Thread connect_check_thread;

		// Token: 0x04000009 RID: 9
		private Thread auto_read_thread;

		// Token: 0x0400000A RID: 10
		private Thread monitor_thread;

		// Token: 0x0400000B RID: 11
		private int CH341_driver_num;

		// Token: 0x0400000C RID: 12
		private int do_ch341streami2c_overtime = 50;

		// Token: 0x0400000D RID: 13
		private int auto_read_time;

		// Token: 0x0400000E RID: 14
		private READ_DATA_STR read_data_str;
	}
}

namespace CH341T_I2C
{
	// Token: 0x02000003 RID: 3
	public partial class CH341_I2C : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002A9F File Offset: 0x00000C9F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002AC0 File Offset: 0x00000CC0
		private void InitializeComponent()
		{
            this.addr_Box = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.register_Box = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.read_button = new System.Windows.Forms.Button();
            this.write_button = new System.Windows.Forms.Button();
            this.receive_Box = new System.Windows.Forms.TextBox();
            this.send_Box = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.read_data_len_Box = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.connect_Box = new System.Windows.Forms.TextBox();
            this.send_data_len_Box = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.auto_read_checkBox = new System.Windows.Forms.CheckBox();
            this.auto_send_time_Box = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通信速率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.button7 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addr_Box
            // 
            this.addr_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addr_Box.Location = new System.Drawing.Point(119, 31);
            this.addr_Box.MaxLength = 2;
            this.addr_Box.Name = "addr_Box";
            this.addr_Box.Size = new System.Drawing.Size(67, 21);
            this.addr_Box.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(7, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "设备地址:0x";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // register_Box
            // 
            this.register_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.register_Box.Location = new System.Drawing.Point(118, 102);
            this.register_Box.MaxLength = 4;
            this.register_Box.Name = "register_Box";
            this.register_Box.Size = new System.Drawing.Size(67, 21);
            this.register_Box.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(11, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "寄存器:0x";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // read_button
            // 
            this.read_button.Location = new System.Drawing.Point(47, 186);
            this.read_button.Name = "read_button";
            this.read_button.Size = new System.Drawing.Size(139, 46);
            this.read_button.TabIndex = 4;
            this.read_button.Text = "读数据";
            this.read_button.UseVisualStyleBackColor = true;
            this.read_button.Click += new System.EventHandler(this.read_button_Click);
            // 
            // write_button
            // 
            this.write_button.Location = new System.Drawing.Point(47, 316);
            this.write_button.Name = "write_button";
            this.write_button.Size = new System.Drawing.Size(139, 48);
            this.write_button.TabIndex = 5;
            this.write_button.Text = "写数据";
            this.write_button.UseVisualStyleBackColor = true;
            this.write_button.Click += new System.EventHandler(this.write_button_Click);
            // 
            // receive_Box
            // 
            this.receive_Box.Location = new System.Drawing.Point(195, 23);
            this.receive_Box.Multiline = true;
            this.receive_Box.Name = "receive_Box";
            this.receive_Box.ReadOnly = true;
            this.receive_Box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receive_Box.Size = new System.Drawing.Size(598, 204);
            this.receive_Box.TabIndex = 6;
            this.receive_Box.TextChanged += new System.EventHandler(this.receive_Box_TextChanged);
            // 
            // send_Box
            // 
            this.send_Box.Location = new System.Drawing.Point(192, 262);
            this.send_Box.Multiline = true;
            this.send_Box.Name = "send_Box";
            this.send_Box.Size = new System.Drawing.Size(598, 101);
            this.send_Box.TabIndex = 7;
            this.send_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.send_Box_KeyPress);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(715, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "清除窗口";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // read_data_len_Box
            // 
            this.read_data_len_Box.Location = new System.Drawing.Point(119, 159);
            this.read_data_len_Box.MaxLength = 5;
            this.read_data_len_Box.Name = "read_data_len_Box";
            this.read_data_len_Box.Size = new System.Drawing.Size(67, 21);
            this.read_data_len_Box.TabIndex = 9;
            this.read_data_len_Box.TextChanged += new System.EventHandler(this.read_data_len_Box_TextChanged);
            this.read_data_len_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.read_data_len_Box_KeyPress);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(46, 159);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "读取长度";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // connect_Box
            // 
            this.connect_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.connect_Box.Location = new System.Drawing.Point(119, 262);
            this.connect_Box.Name = "connect_Box";
            this.connect_Box.Size = new System.Drawing.Size(66, 14);
            this.connect_Box.TabIndex = 11;
            // 
            // send_data_len_Box
            // 
            this.send_data_len_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.send_data_len_Box.Location = new System.Drawing.Point(120, 294);
            this.send_data_len_Box.Name = "send_data_len_Box";
            this.send_data_len_Box.ReadOnly = true;
            this.send_data_len_Box.Size = new System.Drawing.Size(66, 14);
            this.send_data_len_Box.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(47, 289);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "写入长度";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // auto_read_checkBox
            // 
            this.auto_read_checkBox.AutoSize = true;
            this.auto_read_checkBox.Location = new System.Drawing.Point(195, 238);
            this.auto_read_checkBox.Name = "auto_read_checkBox";
            this.auto_read_checkBox.Size = new System.Drawing.Size(72, 16);
            this.auto_read_checkBox.TabIndex = 14;
            this.auto_read_checkBox.Text = "定时读取";
            this.auto_read_checkBox.UseVisualStyleBackColor = true;
            this.auto_read_checkBox.CheckedChanged += new System.EventHandler(this.auto_read_checkBox_CheckedChanged);
            // 
            // auto_send_time_Box
            // 
            this.auto_send_time_Box.Location = new System.Drawing.Point(273, 235);
            this.auto_send_time_Box.MaxLength = 6;
            this.auto_send_time_Box.Name = "auto_send_time_Box";
            this.auto_send_time_Box.Size = new System.Drawing.Size(67, 21);
            this.auto_send_time_Box.TabIndex = 15;
            this.auto_send_time_Box.TextChanged += new System.EventHandler(this.auto_send_time_Box_TextChanged);
            this.auto_send_time_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.auto_send_time_Box_KeyPress);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(46, 260);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "设备状态:";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 25);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通信速率ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 通信速率ToolStripMenuItem
            // 
            this.通信速率ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kToolStripMenuItem,
            this.kToolStripMenuItem1,
            this.kToolStripMenuItem2,
            this.kToolStripMenuItem3});
            this.通信速率ToolStripMenuItem.Name = "通信速率ToolStripMenuItem";
            this.通信速率ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.通信速率ToolStripMenuItem.Text = "通信速率";
            // 
            // kToolStripMenuItem
            // 
            this.kToolStripMenuItem.Name = "kToolStripMenuItem";
            this.kToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.kToolStripMenuItem.Text = "20K";
            this.kToolStripMenuItem.Click += new System.EventHandler(this.KToolStripMenuItem_Click);
            // 
            // kToolStripMenuItem1
            // 
            this.kToolStripMenuItem1.Name = "kToolStripMenuItem1";
            this.kToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.kToolStripMenuItem1.Text = "100K";
            this.kToolStripMenuItem1.Click += new System.EventHandler(this.KToolStripMenuItem1_Click);
            // 
            // kToolStripMenuItem2
            // 
            this.kToolStripMenuItem2.Name = "kToolStripMenuItem2";
            this.kToolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
            this.kToolStripMenuItem2.Text = "400K";
            this.kToolStripMenuItem2.Click += new System.EventHandler(this.KToolStripMenuItem2_Click);
            // 
            // kToolStripMenuItem3
            // 
            this.kToolStripMenuItem3.Name = "kToolStripMenuItem3";
            this.kToolStripMenuItem3.Size = new System.Drawing.Size(105, 22);
            this.kToolStripMenuItem3.Text = "750K";
            this.kToolStripMenuItem3.Click += new System.EventHandler(this.KToolStripMenuItem3_Click);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(118, 58);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(71, 23);
            this.button7.TabIndex = 19;
            this.button7.Text = "例如: A0";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // CH341_I2C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 370);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.auto_send_time_Box);
            this.Controls.Add(this.auto_read_checkBox);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.send_data_len_Box);
            this.Controls.Add(this.connect_Box);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.read_data_len_Box);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.send_Box);
            this.Controls.Add(this.receive_Box);
            this.Controls.Add(this.write_button);
            this.Controls.Add(this.read_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.register_Box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addr_Box);
            this.Controls.Add(this.menuStrip1);
            this.Name = "CH341_I2C";
            this.Text = "CH341_I2C 调试助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CH341_I2C_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x0400000F RID: 15
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.TextBox addr_Box;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.TextBox register_Box;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Button read_button;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button write_button;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.TextBox receive_Box;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.TextBox send_Box;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button button3;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.TextBox read_data_len_Box;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button button4;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.TextBox connect_Box;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.TextBox send_data_len_Box;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Button button5;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.CheckBox auto_read_checkBox;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.TextBox auto_send_time_Box;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Button button6;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.ToolStripMenuItem 通信速率ToolStripMenuItem;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem1;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem2;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem3;
        private System.Windows.Forms.Button button7;
    }
}

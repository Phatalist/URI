using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using xNet;

namespace Widhdraw_app.TradesAPI.Exchangers.Poloniex
{
	// Token: 0x0200002A RID: 42
	public class PoloniexAPI : ExchangerBase
	{
		// Token: 0x06000171 RID: 369 RVA: 0x00006F38 File Offset: 0x00005138
		public PoloniexAPI(string publicKey, string privateKey, string baseAdress = "https://poloniex.com/tradingApi") : base(publicKey, privateKey, baseAdress)
		{
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00006F72 File Offset: 0x00005172
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00006F7A File Offset: 0x0000517A
		private BigInteger CurrentHttpPostNonce { get; set; }

		// Token: 0x06000174 RID: 372 RVA: 0x00006F84 File Offset: 0x00005184
		private string GetCurrentHttpPostNonce()
		{
			BigInteger bigInteger = new BigInteger(Math.Round(DateTime.UtcNow.Subtract(this.DateTimeUnixEpochStart).TotalMilliseconds * 1000.0, MidpointRounding.AwayFromZero));
			bool flag = bigInteger > this.CurrentHttpPostNonce;
			if (flag)
			{
				this.CurrentHttpPostNonce = bigInteger;
			}
			else
			{
				this.CurrentHttpPostNonce += 1;
			}
			return this.CurrentHttpPostNonce.ToString(this.InvariantCulture);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00007018 File Offset: 0x00005218
		public override List<Currency> GetBalance()
		{
			List<Currency> result2;
			try
			{
				string result = this.SendPrivateApiRequestAsync(this.ToQueryString(new Dictionary<string, string>
				{
					{
						"command",
						"returnBalances"
					},
					{
						"nonce",
						this.GetCurrentHttpPostNonce()
					}
				})).Result;
				Dictionary<string, double> dictionary = result.ParseJSON<Dictionary<string, double>>();
				List<Currency> list = new List<Currency>();
				foreach (KeyValuePair<string, double> keyValuePair in dictionary)
				{
					list.Add(new Currency
					{
						Name = keyValuePair.Key,
						Amount = keyValuePair.Value.ToString()
					});
				}
				list = (from x in list
				orderby x.Amount descending
				select x).ToList<Currency>();
				result2 = list;
			}
			catch (Exception ex)
			{
				result2 = new List<Currency>();
			}
			return result2;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00007128 File Offset: 0x00005328
		public override string Withdraw(decimal amount, string currency, string adress, string paymentid = null)
		{
			string result;
			try
			{
				string text = string.Empty;
				bool flag = !string.IsNullOrWhiteSpace(paymentid);
				if (flag)
				{
					text = this.SendPrivateApiRequestAsync(this.ToQueryString(new Dictionary<string, string>
					{
						{
							"command",
							"withdraw"
						},
						{
							"nonce",
							this.GetCurrentHttpPostNonce()
						},
						{
							"amount",
							amount.ToString()
						},
						{
							"currency",
							currency
						},
						{
							"adress",
							adress
						},
						{
							"paymentId",
							paymentid
						}
					})).Result;
				}
				else
				{
					text = this.SendPrivateApiRequestAsync(this.ToQueryString(new Dictionary<string, string>
					{
						{
							"command",
							"withdraw"
						},
						{
							"nonce",
							this.GetCurrentHttpPostNonce()
						},
						{
							"amount",
							amount.ToString()
						},
						{
							"currency",
							currency
						},
						{
							"adress",
							adress
						}
					})).Result;
				}
				bool flag2 = text.Contains("error");
				if (flag2)
				{
					result = "Ошибка при переводе:" + text.ParseJSON<RootObject>().error;
				}
				else
				{
					result = "Успешно";
				}
			}
			catch (Exception ex)
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00007280 File Offset: 0x00005480
		private async Task<string> SendPrivateApiRequestAsync(string myParam)
		{
			string result;
			using (HttpRequest req = new HttpRequest())
			{
				req.AddHeader("Key", this._publicKey);
				req.AddHeader("Sign", this.CreateSignature(myParam));
				req.IgnoreProtocolErrors = true;
				result = req.Post(this._baseAdress, myParam, "application/x-www-form-urlencoded").ToString();
			}
			return result;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000072D0 File Offset: 0x000054D0
		private string ToQueryString(IDictionary<string, string> dic)
		{
			string[] value = (from key in dic.Keys
			select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(dic[key]))).ToArray<string>();
			return string.Join("&", value);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000731C File Offset: 0x0000551C
		private string CreateSignature(string data)
		{
			return PoloniexAPI.ByteArrayToString(PoloniexAPI.SignHMACSHA512(this._privateKey, PoloniexAPI.StringToByteArray(data)));
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00007344 File Offset: 0x00005544
		private static byte[] SignHMACSHA512(string key, byte[] data)
		{
			HMACSHA512 hmacsha = new HMACSHA512(Encoding.ASCII.GetBytes(key));
			return hmacsha.ComputeHash(data);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00007370 File Offset: 0x00005570
		private static byte[] StringToByteArray(string str)
		{
			return Encoding.ASCII.GetBytes(str);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00007390 File Offset: 0x00005590
		private static string ByteArrayToString(byte[] hash)
		{
			return BitConverter.ToString(hash).Replace("-", "").ToLower();
		}

		// Token: 0x040000C1 RID: 193
		private readonly DateTime DateTimeUnixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x040000C2 RID: 194
		private readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
	}
}

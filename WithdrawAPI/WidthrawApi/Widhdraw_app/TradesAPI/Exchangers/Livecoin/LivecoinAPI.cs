using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using xNet;

namespace Widhdraw_app.TradesAPI.Exchangers.Livecoin
{
	// Token: 0x02000031 RID: 49
	public class LivecoinAPI : ExchangerBase
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x000061BC File Offset: 0x000043BC
		public LivecoinAPI(string publicKey, string privateKey, string baseAdress = "https://api.livecoin.net/") : base(publicKey, privateKey, baseAdress)
		{
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000076F4 File Offset: 0x000058F4
		private static string HashHMAC(string key, string message)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			byte[] bytes = utf8Encoding.GetBytes(key);
			HMACSHA256 hmacsha = new HMACSHA256(bytes);
			byte[] bytes2 = utf8Encoding.GetBytes(message);
			byte[] ba = hmacsha.ComputeHash(bytes2);
			return LivecoinAPI.ByteArrayToString(ba);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00007738 File Offset: 0x00005938
		private static string ByteArrayToString(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00007784 File Offset: 0x00005984
		private static string http_build_query(string formdata)
		{
			string text = formdata.Replace("/", "%2F");
			text = text.Replace("@", "%40");
			return text.Replace(";", "%3B");
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000077CC File Offset: 0x000059CC
		public override List<Currency> GetBalance()
		{
			List<Currency> result;
			try
			{
				List<Currency> list = new List<Currency>();
				string this2 = this.ApiQuery("payment/balances", new Dictionary<string, string>(), "GET");
				foreach (RootObjectLiveCoin rootObjectLiveCoin in this2.ParseJSON<List<RootObjectLiveCoin>>())
				{
					bool flag = rootObjectLiveCoin.type == "available";
					if (flag)
					{
						list.Add(new Currency
						{
							Name = rootObjectLiveCoin.currency,
							Amount = rootObjectLiveCoin.value.ToString()
						});
					}
				}
				list = (from x in list
				orderby x.Amount descending
				select x).ToList<Currency>();
				result = list;
			}
			catch (Exception ex)
			{
				result = new List<Currency>();
			}
			return result;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000078CC File Offset: 0x00005ACC
		public override string Withdraw(decimal amount, string currency, string adress, string paymentid = null)
		{
			string result;
			try
			{
				string text = this.ApiQuery("payment/out/coin", new Dictionary<string, string>
				{
					{
						"amount",
						amount.ToString().Replace(',', '.')
					},
					{
						"currency",
						currency
					},
					{
						"wallet",
						(currency == "XMR") ? (adress + "::" + paymentid) : adress
					}
				}, "POST");
				bool flag = text.Contains("errorMessage");
				if (flag)
				{
					result = text.ParseJSON<RootObjectLiveError>().errorMessage;
				}
				else
				{
					result = text.ParseJSON<RootObjectCoin>().state;
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000798C File Offset: 0x00005B8C
		private string ApiQuery(string apiName, IDictionary<string, string> req, string Method = "POST")
		{
			string text = ((int)Math.Round(DateTime.Now.Subtract(new DateTime(2018, 1, 1)).TotalSeconds * 100.0)).ToString();
			string result;
			using (HttpRequest httpRequest = new HttpRequest())
			{
				string text2 = LivecoinAPI.http_build_query(this.ToQueryString(req));
				string text3 = LivecoinAPI.HashHMAC(this._privateKey, text2).ToUpper();
				httpRequest.IgnoreProtocolErrors = true;
				httpRequest.AddHeader("Sign", text3);
				httpRequest.AddHeader("Api-Key", this._publicKey);
				NameValueCollection nameValueCollection = req.ToNameValueCollection<string, string>();
				string text4 = string.Empty;
				bool flag = Method == "POST";
				if (flag)
				{
					text4 = httpRequest.Post(this._baseAdress + apiName, text2, "application/x-www-form-urlencoded").ToString();
				}
				else
				{
					bool flag2 = !string.IsNullOrWhiteSpace(text2);
					if (flag2)
					{
						text4 = httpRequest.Get(this._baseAdress + apiName + "?" + text2, null).ToString();
					}
					else
					{
						text4 = httpRequest.Get(this._baseAdress + apiName, null).ToString();
					}
				}
				result = text4;
			}
			return result;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00007AE4 File Offset: 0x00005CE4
		private string ToQueryString(IDictionary<string, string> dic)
		{
			string[] value = (from key in dic.Keys
			select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(dic[key]))).ToArray<string>();
			return string.Join("&", value);
		}
	}
}

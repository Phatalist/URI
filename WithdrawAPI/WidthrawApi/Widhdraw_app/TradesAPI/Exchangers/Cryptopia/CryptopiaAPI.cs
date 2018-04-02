using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using xNet;

namespace Widhdraw_app.TradesAPI.Exchangers.Cryptopia
{
	// Token: 0x02000024 RID: 36
	public class CryptopiaAPI : ExchangerBase
	{
		// Token: 0x06000142 RID: 322 RVA: 0x000061BC File Offset: 0x000043BC
		public CryptopiaAPI(string publicKey, string privateKey, string baseAdress = "https://www.cryptopia.co.nz/Api/") : base(publicKey, privateKey, baseAdress)
		{
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00006A70 File Offset: 0x00004C70
		public override List<Currency> GetBalance()
		{
			List<Currency> result;
			try
			{
				JSONObject jsonobject = new JSONObject();
				jsonobject.AddField("", "");
				RootObjectBalance rootObjectBalance = this.MakeApiRequest("GetBalance", jsonobject).ParseJSON<RootObjectBalance>();
				List<Currency> list = new List<Currency>();
				bool success = rootObjectBalance.Success;
				if (success)
				{
					foreach (Datum datum in rootObjectBalance.Data)
					{
						list.Add(new Currency
						{
							Name = datum.Symbol,
							Amount = datum.Available
						});
					}
					list = (from x in list
					orderby x.Amount descending
					select x).ToList<Currency>();
				}
				result = list;
			}
			catch (Exception ex)
			{
				result = new List<Currency>();
			}
			return result;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00006B74 File Offset: 0x00004D74
		public override string Withdraw(decimal amount, string currency, string adress, string paymentid = null)
		{
			string result;
			try
			{
				JSONObject jsonobject = new JSONObject();
				jsonobject.AddField("Currency", currency);
				jsonobject.AddField("Address", adress);
				bool flag = !string.IsNullOrWhiteSpace(paymentid);
				if (flag)
				{
					jsonobject.AddField("PaymentId", paymentid);
				}
				jsonobject.AddField("Amount", amount.ToString().Replace(',', '.'));
				string this2 = this.MakeApiRequest("SubmitWithdraw", jsonobject);
				RootObjectWidthdraw rootObjectWidthdraw = this2.ParseJSON<RootObjectWidthdraw>();
				bool success = rootObjectWidthdraw.Success;
				if (success)
				{
					result = "Успешно";
				}
				else
				{
					result = rootObjectWidthdraw.Error;
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00006C30 File Offset: 0x00004E30
		private string MakeApiRequest(string apiMethod, JSONObject @object)
		{
			string result;
			using (HttpRequest httpRequest = new HttpRequest())
			{
				string text = this._baseAdress + apiMethod;
				string text2 = @object.ToString();
				string text3 = "POST";
				string text4 = HttpUtility.UrlEncode(text.ToLower());
				string text5 = string.Empty;
				DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				string text6 = Convert.ToUInt64((DateTime.UtcNow - d).TotalSeconds).ToString();
				string text7 = Guid.NewGuid().ToString("N");
				bool flag = !string.IsNullOrEmpty(text2);
				if (flag)
				{
					byte[] bytes = Encoding.UTF8.GetBytes(text2);
					MD5 md = MD5.Create();
					byte[] inArray = md.ComputeHash(bytes);
					text5 = Convert.ToBase64String(inArray);
				}
				string s = string.Format("{0}{1}{2}{3}{4}", new object[]
				{
					this._publicKey,
					text3,
					text4,
					text7,
					text5
				});
				byte[] key = Convert.FromBase64String(this._privateKey);
				byte[] bytes2 = Encoding.UTF8.GetBytes(s);
				using (HMACSHA256 hmacsha = new HMACSHA256(key))
				{
					byte[] inArray2 = hmacsha.ComputeHash(bytes2);
					string arg = Convert.ToBase64String(inArray2);
					string authorization = "amx " + string.Format("{0}:{1}:{2}", this._publicKey, arg, text7);
					httpRequest.Authorization = authorization;
					result = httpRequest.Post(this._baseAdress + apiMethod, text2, "application/json").ToString();
				}
			}
			return result;
		}
	}
}

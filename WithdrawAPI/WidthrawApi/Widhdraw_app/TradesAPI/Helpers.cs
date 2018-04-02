using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Script.Serialization;

namespace Widhdraw_app.TradesAPI
{
	// Token: 0x02000012 RID: 18
	public static class Helpers
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x00005B08 File Offset: 0x00003D08
		public static NameValueCollection ToNameValueCollection<TKey, TValue>(this IDictionary<TKey, TValue> dict)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			foreach (KeyValuePair<TKey, TValue> keyValuePair in dict)
			{
				string value = string.Empty;
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					TValue value2 = keyValuePair.Value;
					value = value2.ToString();
				}
				NameValueCollection nameValueCollection2 = nameValueCollection;
				TKey key = keyValuePair.Key;
				nameValueCollection2.Add(key.ToString(), value);
			}
			return nameValueCollection;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00005BAC File Offset: 0x00003DAC
		private static JavaScriptSerializer JSON
		{
			get
			{
				JavaScriptSerializer result;
				if ((result = Helpers.json) == null)
				{
					result = (Helpers.json = new JavaScriptSerializer());
				}
				return result;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005BD4 File Offset: 0x00003DD4
		public static T ParseJSON<T>(this string @this) where T : class
		{
			T result;
			try
			{
				result = Helpers.JSON.Deserialize<T>(@this.Trim());
			}
			catch
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x04000067 RID: 103
		private static JavaScriptSerializer json;
	}
}

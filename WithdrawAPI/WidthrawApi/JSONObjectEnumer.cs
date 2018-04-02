using System;
using System.Collections;
using System.Diagnostics;

// Token: 0x0200000A RID: 10
public class JSONObjectEnumer : IEnumerator
{
	// Token: 0x06000087 RID: 135 RVA: 0x000049EB File Offset: 0x00002BEB
	public JSONObjectEnumer(JSONObject jsonObject)
	{
		Debug.Assert(jsonObject.isContainer);
		this._jobj = jsonObject;
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00004A10 File Offset: 0x00002C10
	public bool MoveNext()
	{
		this.position++;
		return this.position < this._jobj.Count;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00004A43 File Offset: 0x00002C43
	public void Reset()
	{
		this.position = -1;
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600008A RID: 138 RVA: 0x00004A50 File Offset: 0x00002C50
	object IEnumerator.Current
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600008B RID: 139 RVA: 0x00004A68 File Offset: 0x00002C68
	public JSONObject Current
	{
		get
		{
			bool isArray = this._jobj.IsArray;
			JSONObject result;
			if (isArray)
			{
				result = this._jobj[this.position];
			}
			else
			{
				string index = this._jobj.keys[this.position];
				result = this._jobj[index];
			}
			return result;
		}
	}

	// Token: 0x0400003D RID: 61
	public JSONObject _jobj;

	// Token: 0x0400003E RID: 62
	private int position = -1;
}

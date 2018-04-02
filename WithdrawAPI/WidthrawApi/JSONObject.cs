using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

// Token: 0x02000002 RID: 2
public class JSONObject : IEnumerable
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public bool isContainer
	{
		get
		{
			return this.type == JSONObject.Type.ARRAY || this.type == JSONObject.Type.OBJECT;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x00002080 File Offset: 0x00000280
	public int Count
	{
		get
		{
			bool flag = this.list == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				result = this.list.Count;
			}
			return result;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000004 RID: 4 RVA: 0x000020B0 File Offset: 0x000002B0
	public float f
	{
		get
		{
			return this.n;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000005 RID: 5 RVA: 0x000020C8 File Offset: 0x000002C8
	public static JSONObject nullJO
	{
		get
		{
			return JSONObject.Create(JSONObject.Type.NULL);
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000006 RID: 6 RVA: 0x000020E0 File Offset: 0x000002E0
	public static JSONObject obj
	{
		get
		{
			return JSONObject.Create(JSONObject.Type.OBJECT);
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000007 RID: 7 RVA: 0x000020F8 File Offset: 0x000002F8
	public static JSONObject arr
	{
		get
		{
			return JSONObject.Create(JSONObject.Type.ARRAY);
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002110 File Offset: 0x00000310
	public JSONObject(JSONObject.Type t)
	{
		this.type = t;
		if (t != JSONObject.Type.OBJECT)
		{
			if (t == JSONObject.Type.ARRAY)
			{
				this.list = new List<JSONObject>();
			}
		}
		else
		{
			this.list = new List<JSONObject>();
			this.keys = new List<string>();
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002166 File Offset: 0x00000366
	public JSONObject(bool b)
	{
		this.type = JSONObject.Type.BOOL;
		this.b = b;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002185 File Offset: 0x00000385
	public JSONObject(float f)
	{
		this.type = JSONObject.Type.NUMBER;
		this.n = f;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000021A4 File Offset: 0x000003A4
	public JSONObject(int i)
	{
		this.type = JSONObject.Type.NUMBER;
		this.i = (long)i;
		this.useInt = true;
		this.n = (float)i;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000021D3 File Offset: 0x000003D3
	public JSONObject(long l)
	{
		this.type = JSONObject.Type.NUMBER;
		this.i = l;
		this.useInt = true;
		this.n = (float)l;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002204 File Offset: 0x00000404
	public JSONObject(Dictionary<string, string> dic)
	{
		this.type = JSONObject.Type.OBJECT;
		this.keys = new List<string>();
		this.list = new List<JSONObject>();
		foreach (KeyValuePair<string, string> keyValuePair in dic)
		{
			this.keys.Add(keyValuePair.Key);
			this.list.Add(JSONObject.CreateStringObject(keyValuePair.Value));
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000022A8 File Offset: 0x000004A8
	public JSONObject(Dictionary<string, JSONObject> dic)
	{
		this.type = JSONObject.Type.OBJECT;
		this.keys = new List<string>();
		this.list = new List<JSONObject>();
		foreach (KeyValuePair<string, JSONObject> keyValuePair in dic)
		{
			this.keys.Add(keyValuePair.Key);
			this.list.Add(keyValuePair.Value);
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002348 File Offset: 0x00000548
	public JSONObject(JSONObject.AddJSONContents content)
	{
		content(this);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002361 File Offset: 0x00000561
	public JSONObject(JSONObject[] objs)
	{
		this.type = JSONObject.Type.ARRAY;
		this.list = new List<JSONObject>(objs);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002388 File Offset: 0x00000588
	public static JSONObject StringObject(string val)
	{
		return JSONObject.CreateStringObject(val);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000023A0 File Offset: 0x000005A0
	public void Absorb(JSONObject obj)
	{
		this.list.AddRange(obj.list);
		this.keys.AddRange(obj.keys);
		this.str = obj.str;
		this.n = obj.n;
		this.useInt = obj.useInt;
		this.i = obj.i;
		this.b = obj.b;
		this.type = obj.type;
	}

	// Token: 0x06000013 RID: 19 RVA: 0x0000241C File Offset: 0x0000061C
	public static JSONObject Create()
	{
		return new JSONObject();
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002434 File Offset: 0x00000634
	public static JSONObject Create(JSONObject.Type t)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = t;
		if (t != JSONObject.Type.OBJECT)
		{
			if (t == JSONObject.Type.ARRAY)
			{
				jsonobject.list = new List<JSONObject>();
			}
		}
		else
		{
			jsonobject.list = new List<JSONObject>();
			jsonobject.keys = new List<string>();
		}
		return jsonobject;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002488 File Offset: 0x00000688
	public static JSONObject Create(bool val)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = JSONObject.Type.BOOL;
		jsonobject.b = val;
		return jsonobject;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000024B0 File Offset: 0x000006B0
	public static JSONObject Create(float val)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = JSONObject.Type.NUMBER;
		jsonobject.n = val;
		return jsonobject;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000024D8 File Offset: 0x000006D8
	public static JSONObject Create(int val)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = JSONObject.Type.NUMBER;
		jsonobject.n = (float)val;
		jsonobject.useInt = true;
		jsonobject.i = (long)val;
		return jsonobject;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002510 File Offset: 0x00000710
	public static JSONObject Create(long val)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = JSONObject.Type.NUMBER;
		jsonobject.n = (float)val;
		jsonobject.useInt = true;
		jsonobject.i = val;
		return jsonobject;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002548 File Offset: 0x00000748
	public static JSONObject CreateStringObject(string val)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = JSONObject.Type.STRING;
		jsonobject.str = val;
		return jsonobject;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002570 File Offset: 0x00000770
	public static JSONObject CreateBakedObject(string val)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = JSONObject.Type.BAKED;
		jsonobject.str = val;
		return jsonobject;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002598 File Offset: 0x00000798
	public static JSONObject Create(string val, int maxDepth = -2, bool storeExcessLevels = false, bool strict = false)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.Parse(val, maxDepth, storeExcessLevels, strict);
		return jsonobject;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x000025BC File Offset: 0x000007BC
	public static JSONObject Create(JSONObject.AddJSONContents content)
	{
		JSONObject jsonobject = JSONObject.Create();
		content(jsonobject);
		return jsonobject;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x000025E0 File Offset: 0x000007E0
	public static JSONObject Create(Dictionary<string, string> dic)
	{
		JSONObject jsonobject = JSONObject.Create();
		jsonobject.type = JSONObject.Type.OBJECT;
		jsonobject.keys = new List<string>();
		jsonobject.list = new List<JSONObject>();
		foreach (KeyValuePair<string, string> keyValuePair in dic)
		{
			jsonobject.keys.Add(keyValuePair.Key);
			jsonobject.list.Add(JSONObject.CreateStringObject(keyValuePair.Value));
		}
		return jsonobject;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002680 File Offset: 0x00000880
	public JSONObject()
	{
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002691 File Offset: 0x00000891
	public JSONObject(string str, int maxDepth = -2, bool storeExcessLevels = false, bool strict = false)
	{
		this.Parse(str, maxDepth, storeExcessLevels, strict);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000026B0 File Offset: 0x000008B0
	private void Parse(string str, int maxDepth = -2, bool storeExcessLevels = false, bool strict = false)
	{
		bool flag = !string.IsNullOrEmpty(str);
		if (flag)
		{
			str = str.Trim(JSONObject.WHITESPACE);
			if (strict)
			{
				bool flag2 = str[0] != '[' && str[0] != '{';
				if (flag2)
				{
					this.type = JSONObject.Type.NULL;
					Debug.WriteLine("Improper (strict) JSON formatting.  First character must be [ or {");
					return;
				}
			}
			bool flag3 = str.Length > 0;
			if (flag3)
			{
				bool flag4 = string.Compare(str, "true", true) == 0;
				if (flag4)
				{
					this.type = JSONObject.Type.BOOL;
					this.b = true;
				}
				else
				{
					bool flag5 = string.Compare(str, "false", true) == 0;
					if (flag5)
					{
						this.type = JSONObject.Type.BOOL;
						this.b = false;
					}
					else
					{
						bool flag6 = string.Compare(str, "null", true) == 0;
						if (flag6)
						{
							this.type = JSONObject.Type.NULL;
						}
						else
						{
							bool flag7 = str == "\"INFINITY\"";
							if (flag7)
							{
								this.type = JSONObject.Type.NUMBER;
								this.n = float.PositiveInfinity;
							}
							else
							{
								bool flag8 = str == "\"NEGINFINITY\"";
								if (flag8)
								{
									this.type = JSONObject.Type.NUMBER;
									this.n = float.NegativeInfinity;
								}
								else
								{
									bool flag9 = str == "\"NaN\"";
									if (flag9)
									{
										this.type = JSONObject.Type.NUMBER;
										this.n = float.NaN;
									}
									else
									{
										bool flag10 = str[0] == '"';
										if (flag10)
										{
											this.type = JSONObject.Type.STRING;
											this.str = str.Substring(1, str.Length - 2);
										}
										else
										{
											int num = 1;
											int num2 = 0;
											char c = str[num2];
											if (c != '[')
											{
												if (c != '{')
												{
													try
													{
														this.n = Convert.ToSingle(str, CultureInfo.InvariantCulture);
														bool flag11 = !str.Contains(".");
														if (flag11)
														{
															this.i = Convert.ToInt64(str);
															this.useInt = true;
														}
														this.type = JSONObject.Type.NUMBER;
													}
													catch (FormatException)
													{
														this.type = JSONObject.Type.NULL;
														Debug.WriteLine("improper JSON formatting:" + str);
													}
													return;
												}
												this.type = JSONObject.Type.OBJECT;
												this.keys = new List<string>();
												this.list = new List<JSONObject>();
											}
											else
											{
												this.type = JSONObject.Type.ARRAY;
												this.list = new List<JSONObject>();
											}
											string item = "";
											bool flag12 = false;
											bool flag13 = false;
											int num3 = 0;
											while (++num2 < str.Length)
											{
												bool flag14 = Array.IndexOf<char>(JSONObject.WHITESPACE, str[num2]) > -1;
												if (!flag14)
												{
													bool flag15 = str[num2] == '\\';
													if (flag15)
													{
														num2++;
													}
													else
													{
														bool flag16 = str[num2] == '"';
														if (flag16)
														{
															bool flag17 = flag12;
															if (flag17)
															{
																bool flag18 = !flag13 && num3 == 0 && this.type == JSONObject.Type.OBJECT;
																if (flag18)
																{
																	item = str.Substring(num + 1, num2 - num - 1);
																}
																flag12 = false;
															}
															else
															{
																bool flag19 = num3 == 0 && this.type == JSONObject.Type.OBJECT;
																if (flag19)
																{
																	num = num2;
																}
																flag12 = true;
															}
														}
														bool flag20 = flag12;
														if (!flag20)
														{
															bool flag21 = this.type == JSONObject.Type.OBJECT && num3 == 0;
															if (flag21)
															{
																bool flag22 = str[num2] == ':';
																if (flag22)
																{
																	num = num2 + 1;
																	flag13 = true;
																}
															}
															bool flag23 = str[num2] == '[' || str[num2] == '{';
															if (flag23)
															{
																num3++;
															}
															else
															{
																bool flag24 = str[num2] == ']' || str[num2] == '}';
																if (flag24)
																{
																	num3--;
																}
															}
															bool flag25 = (str[num2] == ',' && num3 == 0) || num3 < 0;
															if (flag25)
															{
																flag13 = false;
																string text = str.Substring(num, num2 - num).Trim(JSONObject.WHITESPACE);
																bool flag26 = text.Length > 0;
																if (flag26)
																{
																	bool flag27 = this.type == JSONObject.Type.OBJECT;
																	if (flag27)
																	{
																		this.keys.Add(item);
																	}
																	bool flag28 = maxDepth != -1;
																	if (flag28)
																	{
																		this.list.Add(JSONObject.Create(text, (maxDepth < -1) ? -2 : (maxDepth - 1), storeExcessLevels, false));
																	}
																	else if (storeExcessLevels)
																	{
																		this.list.Add(JSONObject.CreateBakedObject(text));
																	}
																}
																num = num2 + 1;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				this.type = JSONObject.Type.NULL;
			}
		}
		else
		{
			this.type = JSONObject.Type.NULL;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000021 RID: 33 RVA: 0x00002B68 File Offset: 0x00000D68
	public bool IsNumber
	{
		get
		{
			return this.type == JSONObject.Type.NUMBER;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000022 RID: 34 RVA: 0x00002B84 File Offset: 0x00000D84
	public bool IsNull
	{
		get
		{
			return this.type == JSONObject.Type.NULL;
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000023 RID: 35 RVA: 0x00002BA0 File Offset: 0x00000DA0
	public bool IsString
	{
		get
		{
			return this.type == JSONObject.Type.STRING;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000024 RID: 36 RVA: 0x00002BBC File Offset: 0x00000DBC
	public bool IsBool
	{
		get
		{
			return this.type == JSONObject.Type.BOOL;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000025 RID: 37 RVA: 0x00002BD8 File Offset: 0x00000DD8
	public bool IsArray
	{
		get
		{
			return this.type == JSONObject.Type.ARRAY;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000026 RID: 38 RVA: 0x00002BF4 File Offset: 0x00000DF4
	public bool IsObject
	{
		get
		{
			return this.type == JSONObject.Type.OBJECT || this.type == JSONObject.Type.BAKED;
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002C1B File Offset: 0x00000E1B
	public void Add(bool val)
	{
		this.Add(JSONObject.Create(val));
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002C2B File Offset: 0x00000E2B
	public void Add(float val)
	{
		this.Add(JSONObject.Create(val));
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002C3B File Offset: 0x00000E3B
	public void Add(int val)
	{
		this.Add(JSONObject.Create(val));
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002C4B File Offset: 0x00000E4B
	public void Add(string str)
	{
		this.Add(JSONObject.CreateStringObject(str));
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002C5B File Offset: 0x00000E5B
	public void Add(JSONObject.AddJSONContents content)
	{
		this.Add(JSONObject.Create(content));
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002C6C File Offset: 0x00000E6C
	public void Add(JSONObject obj)
	{
		bool flag = obj;
		if (flag)
		{
			bool flag2 = this.type != JSONObject.Type.ARRAY;
			if (flag2)
			{
				this.type = JSONObject.Type.ARRAY;
				bool flag3 = this.list == null;
				if (flag3)
				{
					this.list = new List<JSONObject>();
				}
			}
			this.list.Add(obj);
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002CC4 File Offset: 0x00000EC4
	public void AddField(string name, bool val)
	{
		this.AddField(name, JSONObject.Create(val));
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002CD5 File Offset: 0x00000ED5
	public void AddField(string name, float val)
	{
		this.AddField(name, JSONObject.Create(val));
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00002CE6 File Offset: 0x00000EE6
	public void AddField(string name, int val)
	{
		this.AddField(name, JSONObject.Create(val));
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002CF7 File Offset: 0x00000EF7
	public void AddField(string name, long val)
	{
		this.AddField(name, JSONObject.Create(val));
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002D08 File Offset: 0x00000F08
	public void AddField(string name, JSONObject.AddJSONContents content)
	{
		this.AddField(name, JSONObject.Create(content));
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002D19 File Offset: 0x00000F19
	public void AddField(string name, string val)
	{
		this.AddField(name, JSONObject.CreateStringObject(val));
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002D2C File Offset: 0x00000F2C
	public void AddField(string name, JSONObject obj)
	{
		bool flag = obj;
		if (flag)
		{
			bool flag2 = this.type != JSONObject.Type.OBJECT;
			if (flag2)
			{
				bool flag3 = this.keys == null;
				if (flag3)
				{
					this.keys = new List<string>();
				}
				bool flag4 = this.type == JSONObject.Type.ARRAY;
				if (flag4)
				{
					for (int i = 0; i < this.list.Count; i++)
					{
						this.keys.Add(string.Concat(i));
					}
				}
				else
				{
					bool flag5 = this.list == null;
					if (flag5)
					{
						this.list = new List<JSONObject>();
					}
				}
				this.type = JSONObject.Type.OBJECT;
			}
			this.keys.Add(name);
			this.list.Add(obj);
		}
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002DFA File Offset: 0x00000FFA
	public void SetField(string name, string val)
	{
		this.SetField(name, JSONObject.CreateStringObject(val));
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00002E0B File Offset: 0x0000100B
	public void SetField(string name, bool val)
	{
		this.SetField(name, JSONObject.Create(val));
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002E1C File Offset: 0x0000101C
	public void SetField(string name, float val)
	{
		this.SetField(name, JSONObject.Create(val));
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002E2D File Offset: 0x0000102D
	public void SetField(string name, int val)
	{
		this.SetField(name, JSONObject.Create(val));
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002E40 File Offset: 0x00001040
	public void SetField(string name, JSONObject obj)
	{
		bool flag = this.HasField(name);
		if (flag)
		{
			this.list.Remove(this[name]);
			this.keys.Remove(name);
		}
		this.AddField(name, obj);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00002E84 File Offset: 0x00001084
	public void RemoveField(string name)
	{
		bool flag = this.keys.IndexOf(name) > -1;
		if (flag)
		{
			this.list.RemoveAt(this.keys.IndexOf(name));
			this.keys.Remove(name);
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002ECC File Offset: 0x000010CC
	public bool GetField(out bool field, string name, bool fallback)
	{
		field = fallback;
		return this.GetField(ref field, name, null);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002EEC File Offset: 0x000010EC
	public bool GetField(ref bool field, string name, JSONObject.FieldNotFound fail = null)
	{
		bool flag = this.type == JSONObject.Type.OBJECT;
		if (flag)
		{
			int num = this.keys.IndexOf(name);
			bool flag2 = num >= 0;
			if (flag2)
			{
				field = this.list[num].b;
				return true;
			}
		}
		bool flag3 = fail != null;
		if (flag3)
		{
			fail(name);
		}
		return false;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002F50 File Offset: 0x00001150
	public bool GetField(out float field, string name, float fallback)
	{
		field = fallback;
		return this.GetField(ref field, name, null);
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002F70 File Offset: 0x00001170
	public bool GetField(ref float field, string name, JSONObject.FieldNotFound fail = null)
	{
		bool flag = this.type == JSONObject.Type.OBJECT;
		if (flag)
		{
			int num = this.keys.IndexOf(name);
			bool flag2 = num >= 0;
			if (flag2)
			{
				field = this.list[num].n;
				return true;
			}
		}
		bool flag3 = fail != null;
		if (flag3)
		{
			fail(name);
		}
		return false;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00002FD4 File Offset: 0x000011D4
	public bool GetField(out int field, string name, int fallback)
	{
		field = fallback;
		return this.GetField(ref field, name, null);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002FF4 File Offset: 0x000011F4
	public bool GetField(ref int field, string name, JSONObject.FieldNotFound fail = null)
	{
		bool isObject = this.IsObject;
		if (isObject)
		{
			int num = this.keys.IndexOf(name);
			bool flag = num >= 0;
			if (flag)
			{
				field = (int)this.list[num].n;
				return true;
			}
		}
		bool flag2 = fail != null;
		if (flag2)
		{
			fail(name);
		}
		return false;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00003058 File Offset: 0x00001258
	public bool GetField(out long field, string name, long fallback)
	{
		field = fallback;
		return this.GetField(ref field, name, null);
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00003078 File Offset: 0x00001278
	public bool GetField(ref long field, string name, JSONObject.FieldNotFound fail = null)
	{
		bool isObject = this.IsObject;
		if (isObject)
		{
			int num = this.keys.IndexOf(name);
			bool flag = num >= 0;
			if (flag)
			{
				field = (long)this.list[num].n;
				return true;
			}
		}
		bool flag2 = fail != null;
		if (flag2)
		{
			fail(name);
		}
		return false;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x000030DC File Offset: 0x000012DC
	public bool GetField(out uint field, string name, uint fallback)
	{
		field = fallback;
		return this.GetField(ref field, name, null);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x000030FC File Offset: 0x000012FC
	public bool GetField(ref uint field, string name, JSONObject.FieldNotFound fail = null)
	{
		bool isObject = this.IsObject;
		if (isObject)
		{
			int num = this.keys.IndexOf(name);
			bool flag = num >= 0;
			if (flag)
			{
				field = (uint)this.list[num].n;
				return true;
			}
		}
		bool flag2 = fail != null;
		if (flag2)
		{
			fail(name);
		}
		return false;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00003160 File Offset: 0x00001360
	public bool GetField(out string field, string name, string fallback)
	{
		field = fallback;
		return this.GetField(ref field, name, null);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00003180 File Offset: 0x00001380
	public bool GetField(ref string field, string name, JSONObject.FieldNotFound fail = null)
	{
		bool isObject = this.IsObject;
		if (isObject)
		{
			int num = this.keys.IndexOf(name);
			bool flag = num >= 0;
			if (flag)
			{
				field = this.list[num].str;
				return true;
			}
		}
		bool flag2 = fail != null;
		if (flag2)
		{
			fail(name);
		}
		return false;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x000031E4 File Offset: 0x000013E4
	public void GetField(string name, JSONObject.GetFieldResponse response, JSONObject.FieldNotFound fail = null)
	{
		bool flag = response != null && this.IsObject;
		if (flag)
		{
			int num = this.keys.IndexOf(name);
			bool flag2 = num >= 0;
			if (flag2)
			{
				response(this.list[num]);
				return;
			}
		}
		bool flag3 = fail != null;
		if (flag3)
		{
			fail(name);
		}
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00003244 File Offset: 0x00001444
	public JSONObject GetField(string name)
	{
		bool isObject = this.IsObject;
		if (isObject)
		{
			for (int i = 0; i < this.keys.Count; i++)
			{
				bool flag = this.keys[i] == name;
				if (flag)
				{
					return this.list[i];
				}
			}
		}
		return null;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x000032A4 File Offset: 0x000014A4
	public bool HasFields(string[] names)
	{
		bool flag = !this.IsObject;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < names.Length; i++)
			{
				bool flag2 = !this.keys.Contains(names[i]);
				if (flag2)
				{
					return false;
				}
			}
			result = true;
		}
		return result;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000032F8 File Offset: 0x000014F8
	public bool HasField(string name)
	{
		bool flag = !this.IsObject;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < this.keys.Count; i++)
			{
				bool flag2 = this.keys[i] == name;
				if (flag2)
				{
					return true;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00003354 File Offset: 0x00001554
	public void Clear()
	{
		this.type = JSONObject.Type.NULL;
		bool flag = this.list != null;
		if (flag)
		{
			this.list.Clear();
		}
		bool flag2 = this.keys != null;
		if (flag2)
		{
			this.keys.Clear();
		}
		this.str = "";
		this.n = 0f;
		this.b = false;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x000033B8 File Offset: 0x000015B8
	public JSONObject Copy()
	{
		return JSONObject.Create(this.Print(false), -2, false, false);
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000033DA File Offset: 0x000015DA
	public void Merge(JSONObject obj)
	{
		JSONObject.MergeRecur(this, obj);
	}

	// Token: 0x0600004D RID: 77 RVA: 0x000033E8 File Offset: 0x000015E8
	private static void MergeRecur(JSONObject left, JSONObject right)
	{
		bool flag = left.type == JSONObject.Type.NULL;
		if (flag)
		{
			left.Absorb(right);
		}
		else
		{
			bool flag2 = left.type == JSONObject.Type.OBJECT && right.type == JSONObject.Type.OBJECT;
			if (flag2)
			{
				for (int i = 0; i < right.list.Count; i++)
				{
					string text = right.keys[i];
					bool isContainer = right[i].isContainer;
					if (isContainer)
					{
						bool flag3 = left.HasField(text);
						if (flag3)
						{
							JSONObject.MergeRecur(left[text], right[i]);
						}
						else
						{
							left.AddField(text, right[i]);
						}
					}
					else
					{
						bool flag4 = left.HasField(text);
						if (flag4)
						{
							left.SetField(text, right[i]);
						}
						else
						{
							left.AddField(text, right[i]);
						}
					}
				}
			}
			else
			{
				bool flag5 = left.type == JSONObject.Type.ARRAY && right.type == JSONObject.Type.ARRAY;
				if (flag5)
				{
					bool flag6 = right.Count > left.Count;
					if (flag6)
					{
						Debug.WriteLine("Cannot merge arrays when right object has more elements");
					}
					else
					{
						for (int j = 0; j < right.list.Count; j++)
						{
							bool flag7 = left[j].type == right[j].type;
							if (flag7)
							{
								bool isContainer2 = left[j].isContainer;
								if (isContainer2)
								{
									JSONObject.MergeRecur(left[j], right[j]);
								}
								else
								{
									left[j] = right[j];
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x000035A4 File Offset: 0x000017A4
	public void Bake()
	{
		bool flag = this.type != JSONObject.Type.BAKED;
		if (flag)
		{
			this.str = this.Print(false);
			this.type = JSONObject.Type.BAKED;
		}
	}

	// Token: 0x0600004F RID: 79 RVA: 0x000035D8 File Offset: 0x000017D8
	public IEnumerable BakeAsync()
	{
		bool flag = this.type != JSONObject.Type.BAKED;
		if (flag)
		{
			foreach (string s in this.PrintAsync(false))
			{
				bool flag2 = s == null;
				if (flag2)
				{
					yield return s;
				}
				else
				{
					this.str = s;
				}
				s = null;
			}
			IEnumerator<string> enumerator = null;
			this.type = JSONObject.Type.BAKED;
		}
		yield break;
		yield break;
	}

	// Token: 0x06000050 RID: 80 RVA: 0x000035E8 File Offset: 0x000017E8
	public string Print(bool pretty = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		this.Stringify(0, stringBuilder, pretty);
		return stringBuilder.ToString();
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00003610 File Offset: 0x00001810
	public IEnumerable<string> PrintAsync(bool pretty = false)
	{
		StringBuilder builder = new StringBuilder();
		JSONObject.printWatch.Reset();
		JSONObject.printWatch.Start();
		foreach (object obj in this.StringifyAsync(0, builder, pretty))
		{
			IEnumerable e = (IEnumerable)obj;
			yield return null;
		}
		IEnumerator enumerator = null;
		yield return builder.ToString();
		yield break;
		yield break;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00003627 File Offset: 0x00001827
	private IEnumerable StringifyAsync(int depth, StringBuilder builder, bool pretty = false)
	{
		int num = depth;
		depth = num + 1;
		bool flag = num > 100;
		if (flag)
		{
			Debug.WriteLine("reached max depth!");
			yield break;
		}
		bool flag2 = JSONObject.printWatch.Elapsed.TotalSeconds > 0.00800000037997961;
		if (flag2)
		{
			JSONObject.printWatch.Reset();
			yield return null;
			JSONObject.printWatch.Start();
		}
		switch (this.type)
		{
		case JSONObject.Type.NULL:
			builder.Append("null");
			break;
		case JSONObject.Type.STRING:
			builder.AppendFormat("\"{0}\"", this.str);
			break;
		case JSONObject.Type.NUMBER:
		{
			bool flag3 = this.useInt;
			if (flag3)
			{
				builder.Append(this.i.ToString());
			}
			else
			{
				bool flag4 = float.IsInfinity(this.n);
				if (flag4)
				{
					builder.Append("\"INFINITY\"");
				}
				else
				{
					bool flag5 = float.IsNegativeInfinity(this.n);
					if (flag5)
					{
						builder.Append("\"NEGINFINITY\"");
					}
					else
					{
						bool flag6 = float.IsNaN(this.n);
						if (flag6)
						{
							builder.Append("\"NaN\"");
						}
						else
						{
							builder.Append(this.n.ToString());
						}
					}
				}
			}
			break;
		}
		case JSONObject.Type.OBJECT:
		{
			builder.Append("{");
			bool flag7 = this.list.Count > 0;
			if (flag7)
			{
				if (pretty)
				{
					builder.Append("\n");
				}
				for (int i = 0; i < this.list.Count; i = num + 1)
				{
					string key = this.keys[i];
					JSONObject obj = this.list[i];
					bool flag8 = obj;
					if (flag8)
					{
						if (pretty)
						{
							for (int j = 0; j < depth; j = num + 1)
							{
								builder.Append("\t");
								num = j;
							}
						}
						builder.AppendFormat("\"{0}\":", key);
						foreach (object obj2 in obj.StringifyAsync(depth, builder, pretty))
						{
							IEnumerable e = (IEnumerable)obj2;
							yield return e;
							e = null;
						}
						IEnumerator enumerator = null;
						builder.Append(",");
						if (pretty)
						{
							builder.Append("\n");
						}
					}
					key = null;
					obj = null;
					num = i;
				}
				if (pretty)
				{
					builder.Length -= 2;
				}
				else
				{
					num = builder.Length;
					builder.Length = num - 1;
				}
			}
			bool flag9 = pretty && this.list.Count > 0;
			if (flag9)
			{
				builder.Append("\n");
				for (int k = 0; k < depth - 1; k = num + 1)
				{
					builder.Append("\t");
					num = k;
				}
			}
			builder.Append("}");
			break;
		}
		case JSONObject.Type.ARRAY:
		{
			builder.Append("[");
			bool flag10 = this.list.Count > 0;
			if (flag10)
			{
				if (pretty)
				{
					builder.Append("\n");
				}
				for (int l = 0; l < this.list.Count; l = num + 1)
				{
					bool flag11 = this.list[l];
					if (flag11)
					{
						if (pretty)
						{
							for (int m = 0; m < depth; m = num + 1)
							{
								builder.Append("\t");
								num = m;
							}
						}
						foreach (object obj3 in this.list[l].StringifyAsync(depth, builder, pretty))
						{
							IEnumerable e2 = (IEnumerable)obj3;
							yield return e2;
							e2 = null;
						}
						IEnumerator enumerator2 = null;
						builder.Append(",");
						if (pretty)
						{
							builder.Append("\n");
						}
					}
					num = l;
				}
				if (pretty)
				{
					builder.Length -= 2;
				}
				else
				{
					num = builder.Length;
					builder.Length = num - 1;
				}
			}
			bool flag12 = pretty && this.list.Count > 0;
			if (flag12)
			{
				builder.Append("\n");
				for (int n = 0; n < depth - 1; n = num + 1)
				{
					builder.Append("\t");
					num = n;
				}
			}
			builder.Append("]");
			break;
		}
		case JSONObject.Type.BOOL:
		{
			bool flag13 = this.b;
			if (flag13)
			{
				builder.Append("true");
			}
			else
			{
				builder.Append("false");
			}
			break;
		}
		case JSONObject.Type.BAKED:
			builder.Append(this.str);
			break;
		}
		yield break;
		yield break;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x0000364C File Offset: 0x0000184C
	private void Stringify(int depth, StringBuilder builder, bool pretty = false)
	{
		bool flag = depth++ > 100;
		if (flag)
		{
			Debug.WriteLine("reached max depth!");
		}
		else
		{
			switch (this.type)
			{
			case JSONObject.Type.NULL:
				builder.Append("null");
				break;
			case JSONObject.Type.STRING:
				builder.AppendFormat("\"{0}\"", this.str);
				break;
			case JSONObject.Type.NUMBER:
			{
				bool flag2 = this.useInt;
				if (flag2)
				{
					builder.Append(this.i.ToString());
				}
				else
				{
					bool flag3 = float.IsInfinity(this.n);
					if (flag3)
					{
						builder.Append("\"INFINITY\"");
					}
					else
					{
						bool flag4 = float.IsNegativeInfinity(this.n);
						if (flag4)
						{
							builder.Append("\"NEGINFINITY\"");
						}
						else
						{
							bool flag5 = float.IsNaN(this.n);
							if (flag5)
							{
								builder.Append("\"NaN\"");
							}
							else
							{
								builder.Append(this.n.ToString());
							}
						}
					}
				}
				break;
			}
			case JSONObject.Type.OBJECT:
			{
				builder.Append("{");
				bool flag6 = this.list.Count > 0;
				if (flag6)
				{
					if (pretty)
					{
						builder.Append("\n");
					}
					for (int i = 0; i < this.list.Count; i++)
					{
						string arg = this.keys[i];
						JSONObject jsonobject = this.list[i];
						bool flag7 = jsonobject;
						if (flag7)
						{
							if (pretty)
							{
								for (int j = 0; j < depth; j++)
								{
									builder.Append("\t");
								}
							}
							builder.AppendFormat("\"{0}\":", arg);
							jsonobject.Stringify(depth, builder, pretty);
							builder.Append(",");
							if (pretty)
							{
								builder.Append("\n");
							}
						}
					}
					if (pretty)
					{
						builder.Length -= 2;
					}
					else
					{
						int length = builder.Length;
						builder.Length = length - 1;
					}
				}
				bool flag8 = pretty && this.list.Count > 0;
				if (flag8)
				{
					builder.Append("\n");
					for (int k = 0; k < depth - 1; k++)
					{
						builder.Append("\t");
					}
				}
				builder.Append("}");
				break;
			}
			case JSONObject.Type.ARRAY:
			{
				builder.Append("[");
				bool flag9 = this.list.Count > 0;
				if (flag9)
				{
					if (pretty)
					{
						builder.Append("\n");
					}
					for (int l = 0; l < this.list.Count; l++)
					{
						bool flag10 = this.list[l];
						if (flag10)
						{
							if (pretty)
							{
								for (int m = 0; m < depth; m++)
								{
									builder.Append("\t");
								}
							}
							this.list[l].Stringify(depth, builder, pretty);
							builder.Append(",");
							if (pretty)
							{
								builder.Append("\n");
							}
						}
					}
					if (pretty)
					{
						builder.Length -= 2;
					}
					else
					{
						int length = builder.Length;
						builder.Length = length - 1;
					}
				}
				bool flag11 = pretty && this.list.Count > 0;
				if (flag11)
				{
					builder.Append("\n");
					for (int n = 0; n < depth - 1; n++)
					{
						builder.Append("\t");
					}
				}
				builder.Append("]");
				break;
			}
			case JSONObject.Type.BOOL:
			{
				bool flag12 = this.b;
				if (flag12)
				{
					builder.Append("true");
				}
				else
				{
					builder.Append("false");
				}
				break;
			}
			case JSONObject.Type.BAKED:
				builder.Append(this.str);
				break;
			}
		}
	}

	// Token: 0x1700000D RID: 13
	public JSONObject this[int index]
	{
		get
		{
			bool flag = this.list.Count > index;
			JSONObject result;
			if (flag)
			{
				result = this.list[index];
			}
			else
			{
				result = null;
			}
			return result;
		}
		set
		{
			bool flag = this.list.Count > index;
			if (flag)
			{
				this.list[index] = value;
			}
		}
	}

	// Token: 0x1700000E RID: 14
	public JSONObject this[string index]
	{
		get
		{
			return this.GetField(index);
		}
		set
		{
			this.SetField(index, value);
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00003AFC File Offset: 0x00001CFC
	public override string ToString()
	{
		return this.Print(false);
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00003B18 File Offset: 0x00001D18
	public string ToString(bool pretty)
	{
		return this.Print(pretty);
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00003B34 File Offset: 0x00001D34
	public Dictionary<string, string> ToDictionary()
	{
		bool flag = this.type == JSONObject.Type.OBJECT;
		Dictionary<string, string> result;
		if (flag)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int i = 0;
			while (i < this.list.Count)
			{
				JSONObject jsonobject = this.list[i];
				switch (jsonobject.type)
				{
				case JSONObject.Type.STRING:
					dictionary.Add(this.keys[i], jsonobject.str);
					break;
				case JSONObject.Type.NUMBER:
					dictionary.Add(this.keys[i], string.Concat(jsonobject.n));
					break;
				case JSONObject.Type.OBJECT:
				case JSONObject.Type.ARRAY:
					goto IL_BD;
				case JSONObject.Type.BOOL:
					dictionary.Add(this.keys[i], jsonobject.b.ToString() ?? "");
					break;
				default:
					goto IL_BD;
				}
				IL_E0:
				i++;
				continue;
				IL_BD:
				Debug.WriteLine("Omitting object: " + this.keys[i] + " in dictionary conversion");
				goto IL_E0;
			}
			result = dictionary;
		}
		else
		{
			Debug.WriteLine("Tried to turn non-Object JSONObject into a dictionary");
			result = null;
		}
		return result;
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00003C54 File Offset: 0x00001E54
	public static implicit operator bool(JSONObject o)
	{
		return o != null;
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00003C6C File Offset: 0x00001E6C
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00003C84 File Offset: 0x00001E84
	public JSONObjectEnumer GetEnumerator()
	{
		return new JSONObjectEnumer(this);
	}

	// Token: 0x04000001 RID: 1
	private const int MAX_DEPTH = 100;

	// Token: 0x04000002 RID: 2
	private const string INFINITY = "\"INFINITY\"";

	// Token: 0x04000003 RID: 3
	private const string NEGINFINITY = "\"NEGINFINITY\"";

	// Token: 0x04000004 RID: 4
	private const string NaN = "\"NaN\"";

	// Token: 0x04000005 RID: 5
	public static readonly char[] WHITESPACE = new char[]
	{
		' ',
		'\r',
		'\n',
		'\t',
		'﻿',
		'\t'
	};

	// Token: 0x04000006 RID: 6
	public JSONObject.Type type = JSONObject.Type.NULL;

	// Token: 0x04000007 RID: 7
	public List<JSONObject> list;

	// Token: 0x04000008 RID: 8
	public List<string> keys;

	// Token: 0x04000009 RID: 9
	public string str;

	// Token: 0x0400000A RID: 10
	public float n;

	// Token: 0x0400000B RID: 11
	public bool useInt;

	// Token: 0x0400000C RID: 12
	public long i;

	// Token: 0x0400000D RID: 13
	public bool b;

	// Token: 0x0400000E RID: 14
	private const float maxFrameTime = 0.008f;

	// Token: 0x0400000F RID: 15
	private static readonly Stopwatch printWatch = new Stopwatch();

	// Token: 0x02000003 RID: 3
	public enum Type
	{
		// Token: 0x04000011 RID: 17
		NULL,
		// Token: 0x04000012 RID: 18
		STRING,
		// Token: 0x04000013 RID: 19
		NUMBER,
		// Token: 0x04000014 RID: 20
		OBJECT,
		// Token: 0x04000015 RID: 21
		ARRAY,
		// Token: 0x04000016 RID: 22
		BOOL,
		// Token: 0x04000017 RID: 23
		BAKED
	}

	// Token: 0x02000004 RID: 4
	// (Invoke) Token: 0x06000060 RID: 96
	public delegate void AddJSONContents(JSONObject self);

	// Token: 0x02000005 RID: 5
	// (Invoke) Token: 0x06000064 RID: 100
	public delegate void FieldNotFound(string name);

	// Token: 0x02000006 RID: 6
	// (Invoke) Token: 0x06000068 RID: 104
	public delegate void GetFieldResponse(JSONObject obj);
}

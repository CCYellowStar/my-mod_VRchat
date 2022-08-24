using System;
using System.Linq;
using System.Reflection;
using MelonLoader;
using Il2CppSystem;
using UnhollowerRuntimeLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.DataModel;
using VRC.DataModel.Core;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;

namespace Utils
{
	// Token: 0x0200001E RID: 30
	public static class Extensions
	{
		// Token: 0x060000CD RID: 205 RVA: 0x00008BF4 File Offset: 0x00006DF4
		public static GameObject FindObject(this GameObject parent, string name)
		{
			foreach (Transform transform in parent.GetComponentsInChildren<Transform>(true))
			{
				if (transform.name == name)
				{
					return transform.gameObject;
				}
			}
			return null;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00008C38 File Offset: 0x00006E38
		public static string GetPath(this GameObject gameObject)
		{
			string text = "/" + gameObject.name;
			while (gameObject.transform.parent != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
				text = "/" + gameObject.name + text;
			}
			return text;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00008C90 File Offset: 0x00006E90
		public static void DestroyChildren(this Transform transform, System.Func<Transform, bool> exclude)
		{
			for (int i = transform.childCount - 1; i >= 0; i--)
			{
				if (exclude == null || exclude(transform.GetChild(i)))
				{
					UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject);
				}
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00002AE3 File Offset: 0x00000CE3
		public static void DestroyChildren(this Transform transform)
		{
			transform.DestroyChildren(null);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00002AEC File Offset: 0x00000CEC
		public static Vector3 SetX(this Vector3 vector, float x)
		{
			return new Vector3(x, vector.y, vector.z);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00002B00 File Offset: 0x00000D00
		public static Vector3 SetY(this Vector3 vector, float y)
		{
			return new Vector3(vector.x, y, vector.z);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00002B14 File Offset: 0x00000D14
		public static Vector3 SetZ(this Vector3 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00002B28 File Offset: 0x00000D28
		public static float RoundAmount(this float i, float nearestFactor)
		{
			return (float)System.Math.Round((double)(i / nearestFactor)) * nearestFactor;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002B36 File Offset: 0x00000D36
		public static Vector3 RoundAmount(this Vector3 i, float nearestFactor)
		{
			return new Vector3(i.x.RoundAmount(nearestFactor), i.y.RoundAmount(nearestFactor), i.z.RoundAmount(nearestFactor));
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002B61 File Offset: 0x00000D61
		public static Vector2 RoundAmount(this Vector2 i, float nearestFactor)
		{
			return new Vector2(i.x.RoundAmount(nearestFactor), i.y.RoundAmount(nearestFactor));
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00008CD4 File Offset: 0x00006ED4
		public static Sprite ToSprite(this Texture2D tex)
		{
			Rect rect = new Rect(0f, 0f, (float)tex.width, (float)tex.height);
			Vector2 vector = new Vector2(0.5f, 0.5f);
			Vector4 zero = Vector4.zero;
			Sprite sprite = Sprite.CreateSprite_Injected(tex, ref rect, ref vector, 50f, 0U, SpriteMeshType.FullRect, ref zero, false);
			sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			return sprite;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00008D3C File Offset: 0x00006F3C
		public static string ReplaceFirst(this string text, string search, string replace)
		{
			int num = text.IndexOf(search);
			if (num < 0)
			{
				return text;
			}
			return text.Substring(0, num) + replace + text.Substring(num + search.Length);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00008D74 File Offset: 0x00006F74
		public static ColorBlock SetColor(this ColorBlock block, Color color)
		{
			return new ColorBlock
			{
				colorMultiplier = block.colorMultiplier,
				disabledColor = Color.grey,
				highlightedColor = color,
				normalColor = color / 1.5f,
				pressedColor = Color.white,
				selectedColor = color / 1.5f
			};
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00008DDC File Offset: 0x00006FDC
		public static void DelegateSafeInvoke(this System.Delegate @delegate, params object[] args)
		{
			System.Delegate[] invocationList = @delegate.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				try
				{
					invocationList[i].DynamicInvoke(args);
				}
				catch (System.Exception ex)
				{
					MelonLoader.MelonLogger.Error("Error while executing delegate:\n" + ex.ToString());
				}
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00008E34 File Offset: 0x00007034
		public static string ToEasyString(this System.TimeSpan timeSpan)
		{
			if (Mathf.FloorToInt((float)(timeSpan.Ticks / 864000000000L)) > 0)
			{
				return string.Format("{0:%d} days", timeSpan);
			}
			if (Mathf.FloorToInt((float)(timeSpan.Ticks / 36000000000L)) > 0)
			{
				return string.Format("{0:%h} hours", timeSpan);
			}
			if (Mathf.FloorToInt((float)(timeSpan.Ticks / 600000000L)) > 0)
			{
				return string.Format("{0:%m} minutes", timeSpan);
			}
			return string.Format("{0:%s} seconds", timeSpan);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00008ED0 File Offset: 0x000070D0
		public static void ShowAlert(this VRC.UI.Elements.QuickMenu qm, string message)
		{
			if (Extensions.ourShowAlertMethod == null)
			{
				foreach (MethodInfo methodInfo in typeof(ModalAlert).GetMethods())
				{
					MelonLoader.MelonLogger.Error(methodInfo.Name);
					if (methodInfo.Name.Contains("Method_Private_Void_") && !methodInfo.Name.Contains("PDM") && methodInfo.GetParameters().Length == 0)
					{
						qm.field_Private_ModalAlert_0.field_Private_String_0 = message;
						methodInfo.Invoke(qm.field_Private_ModalAlert_0, null);
						if (qm.transform.Find("Container/Window/QMParent/Modal_Alert/Background_Alert").gameObject.activeSelf)
						{
							Extensions.ourShowAlertMethod = methodInfo;
							return;
						}
					}
				}
				return;
			}
			qm.field_Private_ModalAlert_0.field_Private_String_0 = message;
			Extensions.ourShowAlertMethod.Invoke(qm.field_Private_ModalAlert_0, null);
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00008FA8 File Offset: 0x000071A8
		public static MethodInfo ShowOKDialogMethod
		{
			get
			{
				if (Extensions.ourShowOKDialogMethod != null)
				{
					return Extensions.ourShowOKDialogMethod;
				}
				Extensions.ourShowOKDialogMethod = typeof(VRC.UI.Elements.QuickMenu).GetMethods().First(delegate (MethodInfo it)
				{
					if (it != null && it.GetParameters().Length == 3 && it.Name.Contains("_PDM") && it.GetParameters().First<ParameterInfo>().ParameterType == typeof(string) && it.GetParameters().Last<ParameterInfo>().ParameterType == typeof(Il2CppSystem.Action))
					{
						return XrefScanner.XrefScan(it).Any(delegate (XrefInstance jt)
						{
							if (jt.Type == XrefType.Global)
							{
								Il2CppSystem.Object @object = jt.ReadAsObject();
								return ((@object != null) ? @object.ToString() : null) == "ConfirmDialog";
							}
							return false;
						});
					}
					return false;
				});
				return Extensions.ourShowOKDialogMethod;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002B80 File Offset: 0x00000D80
		public static void ShowOKDialog(this VRC.UI.Elements.QuickMenu qm, string title, string message, System.Action okButton = null)
		{
			Extensions.ShowOKDialogMethod.Invoke(qm, new object[]
			{
				title,
				message,
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(okButton)
			});
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00009008 File Offset: 0x00007208
		public static MethodInfo ShowConfirmDialogMethod
		{
			get
			{
				if (Extensions.ourShowConfirmDialogMethod != null)
				{
					return Extensions.ourShowConfirmDialogMethod;
				}
				Extensions.ourShowConfirmDialogMethod = typeof(VRC.UI.Elements.QuickMenu).GetMethods().First((MethodInfo it) => it != null && it.GetParameters().Length == 4 && it.Name.Contains("_PDM") && it.GetParameters()[0].ParameterType == typeof(string) && it.GetParameters()[1].ParameterType == typeof(string) && it.GetParameters()[2].ParameterType == typeof(Il2CppSystem.Action) && it.GetParameters()[3].ParameterType == typeof(Il2CppSystem.Action) && XrefScanner.UsedBy(it).ToList<XrefInstance>().Count > 30);
				return Extensions.ourShowConfirmDialogMethod;
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00002BA5 File Offset: 0x00000DA5
		public static void ShowConfirmDialog(this VRC.UI.Elements.QuickMenu qm, string title, string message, System.Action yesButton = null, System.Action noButton = null)
		{
			Extensions.ShowConfirmDialogMethod.Invoke(qm, new object[]
			{
				title,
				message,
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(yesButton),
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(noButton)
			});
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00009068 File Offset: 0x00007268
		public static MethodInfo ShowCustomDialogMethod
		{
			get
			{
				if (Extensions.ourShowCustomDialogMethod != null)
				{
					return Extensions.ourShowCustomDialogMethod;
				}
				Extensions.ourShowCustomDialogMethod = typeof(VRC.UI.Elements.QuickMenu).GetMethods().First(delegate (MethodInfo it)
				{
					if (it != null && it.GetParameters().Length == 8 && it.Name.Contains("Method_Public_Void_String_String_String_String_String_Action_Action_Action_PDM_"))
					{
						return XrefScanner.XrefScan(it).Any(delegate (XrefInstance jt)
						{
							if (jt.Type == XrefType.Global)
							{
								Il2CppSystem.Object @object = jt.ReadAsObject();
								return ((@object != null) ? @object.ToString() : null) == "ConfirmDialog";
							}
							return false;
						});
					}
					return false;
				});
				return Extensions.ourShowCustomDialogMethod;
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000090C8 File Offset: 0x000072C8
		public static void ShowCustomDialog(this VRC.UI.Elements.QuickMenu qm, string title, string message, string button1Text, string button2Text, string button3Text, System.Action button1Action = null, System.Action button2Action = null, System.Action button3Action = null)
		{
			Extensions.ShowCustomDialogMethod.Invoke(qm, new object[]
			{
				title,
				message,
				button1Text,
				button2Text,
				button3Text,
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(button1Action),
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(button2Action),
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(button3Action)
			});
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000911C File Offset: 0x0000731C
		public static MethodInfo AskConfirmOpenURLMethod
		{
			get
			{
				if (Extensions.ourAskConfirmOpenURLMethod != null)
				{
					return Extensions.ourAskConfirmOpenURLMethod;
				}
				Extensions.ourAskConfirmOpenURLMethod = typeof(VRC.UI.Elements.QuickMenu).GetMethods().First(delegate (MethodInfo it)
				{
					if (it != null && it.GetParameters().Length == 1 && it.Name.Contains("_Virtual_Final_New") && it.GetParameters().First<ParameterInfo>().ParameterType == typeof(string))
					{
						return XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject() != null && jt.ReadAsObject().ToString().Contains("This link will open in your web browser."));
					}
					return false;
				});
				return Extensions.ourAskConfirmOpenURLMethod;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00002BD4 File Offset: 0x00000DD4
		public static void AskConfirmOpenURL(this VRC.UI.Elements.QuickMenu qm, string url)
		{
			Extensions.AskConfirmOpenURLMethod.Invoke(qm, new object[]
			{
				url
			});
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x0000917C File Offset: 0x0000737C
		public static MethodInfo ToIUserMethod
		{
			get
			{
				if (Extensions._apiUserToIUser == null)
				{
					System.Type type2 = typeof(VRCPlayer).Assembly.GetTypes().First(delegate (System.Type type)
					{
						if (type.GetMethods().FirstOrDefault((MethodInfo method) => method.Name.StartsWith("Method_Private_Void_Action_1_ApiWorldInstance_Action_1_String_")) != null)
						{
							return type.GetMethods().FirstOrDefault((MethodInfo method) => method.Name.StartsWith("Method_Public_Virtual_Final_New_Observable_1_List_1_String_")) == null;
						}
						return false;
					});
					Extensions._apiUserToIUser = typeof(DataModelCache).GetMethod("Method_Public_TYPE_String_TYPE2_Boolean_0");
					Extensions._apiUserToIUser = Extensions._apiUserToIUser.MakeGenericMethod(new System.Type[]
					{
						type2,
						typeof(APIUser)
					});
				}
				return Extensions._apiUserToIUser;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00002BEC File Offset: 0x00000DEC
		public static IUser ToIUser(this APIUser value)
		{
			return ((Il2CppSystem.Object)Extensions._apiUserToIUser.Invoke(DataModelManager.field_Private_Static_DataModelManager_0.field_Private_DataModelCache_0, new object[]
			{
				value.id,
				value,
				false
			})).Cast<IUser>();
		}

		// Token: 0x04000044 RID: 68
		private static MethodInfo ourShowAlertMethod;

		// Token: 0x04000045 RID: 690
		private static MethodInfo ourShowOKDialogMethod;

		// Token: 0x04000046 RID: 70
		private static MethodInfo ourShowConfirmDialogMethod;

		// Token: 0x04000047 RID: 71
		private static MethodInfo ourShowCustomDialogMethod;

		// Token: 0x04000048 RID: 72
		private static MethodInfo ourAskConfirmOpenURLMethod;

		// Token: 0x04000049 RID: 73
		private static MethodInfo _apiUserToIUser;
	}
}

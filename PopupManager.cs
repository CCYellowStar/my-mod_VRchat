using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
	// Token: 0x02000015 RID: 21
	public static class PopupManager
	{
		// Token: 0x0600008B RID: 139 RVA: 0x000025DC File Offset: 0x000007DC
		public static void HideCurrentPopup(this VRCUiPopupManager vrcUiPopupManager)
		{
			VRCUiManager.prop_VRCUiManager_0.HideScreen("POPUP");
		}
		public static void ShowAlert(this VRCUiPopupManager vrcUiPopupManager, string title, string content, float timeout)
		{
			ShowUiAlertPopup(title, content, timeout);
		}
		public static void ShowStandardPopup(this VRCUiPopupManager vrcUiPopupManager, string title, string content, string buttonText, System.Action buttonAction, System.Action<VRCUiPopup> onCreated = null)
		{
			ShowUiStandardPopup2(title, content, buttonText, buttonAction, onCreated);
		}
		// Token: 0x0600008C RID: 140 RVA: 0x00004B28 File Offset: 0x00002D28
		public static void ShowInputPopup(this VRCUiPopupManager vrcUiPopupManager, string title, string preFilledText, InputField.InputType inputType, bool keypad, string buttonText, Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> buttonAction, Il2CppSystem.Action cancelAction, string boxText = "Enter text....", bool closeOnAccept = true, System.Action<VRCUiPopup> onCreated = null, bool startOnLeft = false, int characterLimit = 0)
		{
			ShowUiInputPopup(title, preFilledText, inputType, keypad, buttonText, buttonAction, cancelAction, boxText, closeOnAccept, onCreated, startOnLeft, characterLimit);
		}
		public static void ShowInputPopup(string title, string initialText, InputField.InputType inputType, bool isNumeric, string confirmButtonText, System.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> onComplete, System.Action onCancel = null, string placeholderText = "Enter text...", bool closeAfterInput = true, System.Action<VRCUiPopup> onPopupShown = null, bool showLimitLabel = false, int textLengthLimit = 0)
		{
			PopupManager.ShowUiInputPopup(title, initialText, inputType, isNumeric, confirmButtonText, onComplete, onCancel, placeholderText, closeAfterInput, onPopupShown, showLimitLabel, textLengthLimit);
		}
		public static ShowUiAlertPopupAction ShowUiAlertPopup
		{
			get
			{
				if (ourShowUiAlertPopupAction != null)
				{
					return ourShowUiAlertPopupAction;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(delegate (MethodInfo it)
				{
					if (it.GetParameters().Length == 3)
					{
						return XrefScanner.XrefScan(it).Any(delegate (XrefInstance jt)
						{
							if (jt.Type == XrefType.Global)
							{
								Il2CppSystem.Object @object = jt.ReadAsObject();
								return ((@object != null) ? @object.ToString() : null) == "UserInterface/MenuContent/Popups/AlertPopup";
							}
							return false;
						});
					}
					return false;
				});
				ourShowUiAlertPopupAction = (ShowUiAlertPopupAction)System.Delegate.CreateDelegate(typeof(ShowUiAlertPopupAction), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiAlertPopupAction;
			}
		}
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00004B64 File Offset: 0x00002D64
		public static ShowUiStandardPopup2Action ShowUiStandardPopup2
		{
			get
			{
				if (ourShowUiStandardPopup2Action != null)
				{
					return ourShowUiStandardPopup2Action;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(delegate (MethodInfo it)
				{
					if (it.GetParameters().Length == 5 && !it.Name.Contains("PDM"))
					{
						return XrefScanner.XrefScan(it).Any(delegate (XrefInstance jt)
						{
							if (jt.Type == XrefType.Global)
							{
								Il2CppSystem.Object @object = jt.ReadAsObject();
								return ((@object != null) ? @object.ToString() : null) == "UserInterface/MenuContent/Popups/StandardPopup";
							}
							return false;
						});
					}
					return false;
				});
				ourShowUiStandardPopup2Action = (ShowUiStandardPopup2Action)System.Delegate.CreateDelegate(typeof(ShowUiStandardPopup2Action), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiStandardPopup2Action;
			}
		}
		internal static PopupManager.ShowUiInputPopupAction ShowUiInputPopup
		{
			get
			{
				if (PopupManager.ourShowUiInputPopupAction != null)
				{
					return PopupManager.ourShowUiInputPopupAction;
				}
				System.Collections.Generic.List<MethodInfo> source = (from it in typeof(VRCUiPopupManager).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
																	  where it.Name.StartsWith("Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_") && !it.Name.EndsWith("_PDM")
																	  select it).ToList<MethodInfo>();
				MethodInfo methodInfo = source.SingleOrDefault((MethodInfo it) => XrefScanner.XrefScan(it).Any(delegate (XrefInstance jt)
				{
					if (jt.Type == XrefType.Global)
					{
						Il2CppSystem.Object @object = jt.ReadAsObject();
						return ((@object != null) ? @object.ToString() : null) == "UserInterface/MenuContent/Popups/InputPopup";
					}
					return false;
				}));
				if (methodInfo == null)
				{
					methodInfo = typeof(VRCUiPopupManager).GetMethod("Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0", BindingFlags.Instance | BindingFlags.Public);
				}
				PopupManager.ourShowUiInputPopupAction = (PopupManager.ShowUiInputPopupAction)System.Delegate.CreateDelegate(typeof(PopupManager.ShowUiInputPopupAction), VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, methodInfo);
				return PopupManager.ourShowUiInputPopupAction;
			}
		}

		// Token: 0x0400008C RID: 140
		private static PopupManager.ShowUiInputPopupAction ourShowUiInputPopupAction;

		// Token: 0x02000016 RID: 22
		// (Invoke) Token: 0x0600008F RID: 143
		internal delegate void ShowUiInputPopupAction(string title, string initialText, InputField.InputType inputType, bool isNumeric, string confirmButtonText, Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> onComplete, Il2CppSystem.Action onCancel, string placeholderText = "Enter text...", bool closeAfterInput = true, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null, bool bUnknown = false, int charLimit = 0);
		public delegate void ShowUiAlertPopupAction(string title, string body, float timeout);
		private static ShowUiAlertPopupAction ourShowUiAlertPopupAction;
		public delegate void ShowUiStandardPopup2Action(string title, string body, string middleButtonText, Il2CppSystem.Action middleButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);
		private static ShowUiStandardPopup2Action ourShowUiStandardPopup2Action;
	}
}

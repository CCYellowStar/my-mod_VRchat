using System;
using System.Collections;
using System.Linq;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;

namespace Utils
{
	// Token: 0x02000024 RID: 36
	public class ButtonAPI 
	{
		// Token: 0x06000118 RID: 280 RVA: 0x00002D48 File Offset: 0x00000F48
		internal static VRC.UI.Elements.QuickMenu GetQuickMenuInstance()
		{
			return Resources.FindObjectsOfTypeAll<VRC.UI.Elements.QuickMenu>().FirstOrDefault<VRC.UI.Elements.QuickMenu>();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00002D54 File Offset: 0x00000F54
		internal static MenuStateController GetMenuStateControllerInstance()
		{
			return Resources.FindObjectsOfTypeAll<VRC.UI.Elements.QuickMenu>().FirstOrDefault<VRC.UI.Elements.QuickMenu>().gameObject.GetComponent<MenuStateController>();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00002D6A File Offset: 0x00000F6A
		public static void OnUiManagerInit()
		{
			MelonCoroutines.Start(ButtonAPI.WaitForQMClone());
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00002D77 File Offset: 0x00000F77
		public static IEnumerator WaitForQMClone()
		{
			while (GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/") == null)
			{
				yield return new WaitForEndOfFrame();
			}
			ButtonAPI.singleButtonBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn").gameObject;
			for (int i = 0; i < ButtonAPI.singleButtonBase.GetComponentsInChildren<VRC.UI.Elements.Tooltips.UiTooltip>().Count; i++)
			{
				if (ButtonAPI.singleButtonBase.GetComponentsInChildren<VRC.UI.Elements.Tooltips.UiTooltip>()[i].field_Public_String_0 == "" && ButtonAPI.singleButtonBase.GetComponentsInChildren<VRC.UI.Elements.Tooltips.UiTooltip>()[i].field_Public_String_1 == "")
				{
					UnityEngine.Object.DestroyImmediate(ButtonAPI.singleButtonBase.GetComponentsInChildren<VRC.UI.Elements.Tooltips.UiTooltip>()[i]);
				}
			}
			ButtonAPI.textButtonBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_Build").gameObject;
			ButtonAPI.toggleButtonBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo").gameObject;
			ButtonAPI.buttonGroupBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions").gameObject;
			ButtonAPI.buttonGroupHeaderBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions").gameObject;
			ButtonAPI.menuPageBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").gameObject;
			ButtonAPI.menuTabBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").gameObject;
			ButtonAPI.sliderBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Audio/VolumeSlider_Master").gameObject;
			ButtonAPI.wingPageBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/Explore").gameObject;
			ButtonAPI.wingSingleButtonBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile").gameObject;
			ButtonAPI.wingPageBaseL = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer").gameObject;
			ButtonAPI.wingPageBaseR = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer").gameObject;
			ButtonAPI.onIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Notifications/Panel_NoNotifications_Message/Icon").GetComponent<Image>().sprite;
			ButtonAPI.plusIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_FavoriteWorld/Icon").GetComponent<Image>().sprite;
			ButtonAPI.xIconSprite = ButtonAPI.toggleButtonBase.transform.Find("Icon_Off").GetComponent<Image>().sprite;
			ButtonAPI.trashIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_FavoriteWorld/Icon_Secondary").GetComponent<Image>().sprite;
			yield break;
		}

		// Token: 0x0400000B RID: 11
		internal static GameObject singleButtonBase;

		// Token: 0x0400000C RID: 12
		internal static GameObject textButtonBase;

		// Token: 0x0400000D RID: 13
		internal static GameObject toggleButtonBase;

		// Token: 0x0400000E RID: 14
		internal static GameObject buttonGroupBase;

		// Token: 0x0400000F RID: 15
		internal static GameObject buttonGroupHeaderBase;

		// Token: 0x04000010 RID: 16
		internal static GameObject menuPageBase;

		// Token: 0x04000011 RID: 17
		internal static GameObject menuTabBase;

		// Token: 0x04000012 RID: 18
		internal static GameObject sliderBase;

		// Token: 0x04000013 RID: 19
		internal static GameObject wingPageBase;

		// Token: 0x04000014 RID: 20
		internal static GameObject wingSingleButtonBase;

		// Token: 0x04000015 RID: 21
		internal static GameObject wingPageBaseL;

		// Token: 0x04000016 RID: 22
		internal static GameObject wingPageBaseR;

		// Token: 0x04000017 RID: 23
		internal static Sprite onIconSprite;

		// Token: 0x04000018 RID: 24
		internal static Sprite plusIconSprite;

		// Token: 0x04000019 RID: 25
		internal static Sprite xIconSprite;

		// Token: 0x0400001A RID: 26
		internal static Sprite trashIconSprite;
	}
}

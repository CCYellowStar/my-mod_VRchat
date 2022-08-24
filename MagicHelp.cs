using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;

namespace BlackMagic
{
	// Token: 0x0200000C RID: 12
	public class MagicHelp
	{

		// Token: 0x06000044 RID: 68 RVA: 0x000041D4 File Offset: 0x000023D4
		public static bool NotExistInList(System.Collections.Generic.List<ApiAvatar> List, ApiAvatar Match)
		{
			foreach (ApiAvatar text in List)
			{
				bool flag = text.id==Match.id;
				if (flag)
				{
					return false;
				}
			}
			return true;
		}
		public static IEnumerator MagicLoop()
		{
			for (; ; )
			{
				yield return new WaitForEndOfFrame();
				
				MagicFavorite.CheakFavButton();
			}
			yield break;
		}
		[HarmonyPatch(typeof(VRCAvatarManager), "Method_Private_Boolean_ApiAvatar_GameObject_0", MethodType.Normal)]
		public class PATCH_VRCAvatarManager
		{
			// Token: 0x0600009D RID: 157 RVA: 0x000060E9 File Offset: 0x000042E9
			[HarmonyPostfix]
			public static void Postfix(VRCAvatarManager __instance, ApiAvatar param_1, GameObject param_2)
			{
				OnAvatarLoad(__instance, param_1, param_2);
			}
		}
		public static void OnAvatarLoad(VRCAvatarManager __instance, ApiAvatar param_1, GameObject param_2)
		{
			bool flag = !PlayerAvatar.ContainsKey(__instance.field_Private_VRCPlayer_0.prop_String_3);
			if (flag)
			{
				PlayerAvatar.Add(__instance.field_Private_VRCPlayer_0.prop_String_3, string.Empty + "//0");
			}
			string a = PlayerAvatar[__instance.field_Private_VRCPlayer_0.prop_String_3].Split(new string[]
			{
				"//"
			}, StringSplitOptions.None)[0];
			string s = PlayerAvatar[__instance.field_Private_VRCPlayer_0.prop_String_3].Split(new string[]
			{
				"//"
			}, StringSplitOptions.None)[1];

			bool flag2 = (a != param_1.id || DateTime.Now.Ticks / 10000L > long.Parse(s)) && __instance.field_Private_Animator_0 != null;
			if (flag2)
			{
				PlayerAvatar[__instance.field_Private_VRCPlayer_0.prop_String_3] = param_1.id + "//" + (DateTime.Now.Ticks / 10000L + 100L).ToString();

				Animator field_Private_Animator_ = __instance.field_Private_Animator_0;
				Transform boneTransform = field_Private_Animator_.GetBoneTransform(HumanBodyBones.LeftHand);
				Transform boneTransform2 = field_Private_Animator_.GetBoneTransform(HumanBodyBones.RightHand);
			}
		}

		// Token: 0x0400003A RID: 58
		public static EventSystem m_lastEventSystem;

		// Token: 0x0400003B RID: 59
		public static AmbientMode LightMode;

		// Token: 0x0400003C RID: 60
		public static float LightIntensity;

		// Token: 0x0400003D RID: 61
		public static Color LightColor;
		public static System.Collections.Generic.Dictionary<string, string> PlayerAvatar = new System.Collections.Generic.Dictionary<string, string>();
	}
}

using System;
using System.Linq;
using System.Reflection;
using Il2CppSystem.Collections.Generic;
using VRC.Core;

namespace emmVRC.Utils
{
	// Token: 0x02000035 RID: 53
	public static class UIList
	{
		// Token: 0x06000172 RID: 370 RVA: 0x0000AF48 File Offset: 0x00009148
		internal static void RenderElement( UiVRCList uivrclist, List<ApiAvatar> AvatarList)
		{
			if (!uivrclist.gameObject.activeInHierarchy || !uivrclist.isActiveAndEnabled || uivrclist.isOffScreen || !uivrclist.enabled)
			{
				return;
			}
			if (UIList.renderElementMethod == null)
			{
				UIList.renderElementMethod = typeof(UiVRCList).GetMethods().FirstOrDefault((MethodInfo a) => a.Name.Contains("Method_Protected_Void_List_1_T_Int32_Boolean")).MakeGenericMethod(new Type[]
				{
					typeof(ApiAvatar)
				});
			}
			MethodBase methodBase = UIList.renderElementMethod;
			object[] array = new object[4];
			array[0] = AvatarList;
			array[1] = 0;
			array[2] = true;
			methodBase.Invoke(uivrclist, array);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000B000 File Offset: 0x00009200
		internal static void RenderElement( UiVRCList uivrclist, List<string> idList)
		{
			if (!uivrclist.gameObject.activeInHierarchy || !uivrclist.isActiveAndEnabled || uivrclist.isOffScreen || !uivrclist.enabled)
			{
				return;
			}
			if (UIList.renderElementMethod == null)
			{
				UIList.renderElementMethod = typeof(UiVRCList).GetMethods().FirstOrDefault((MethodInfo a) => a.Name.Contains("Method_Protected_Void_List_1_T_Int32_Boolean")).MakeGenericMethod(new Type[]
				{
					typeof(ApiAvatar)
				});
			}
			MethodBase methodBase = UIList.renderElementMethod;
			object[] array = new object[4];
			array[0] = idList;
			array[1] = 0;
			array[2] = true;
			methodBase.Invoke(uivrclist, array);
		}

		// Token: 0x040000B0 RID: 176
		private static MethodInfo renderElementMethod;
	}
}

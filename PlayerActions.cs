using System;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.DataModel.Core;
using VRC.UI.Elements.Menus;

namespace Utils
{
	// Token: 0x02000014 RID: 20
	internal static class PlayerActions
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00002574 File Offset: 0x00000774
		internal static VRCPlayer GetLocalVRCPlayer()
		{
			return VRCPlayer.field_Internal_Static_VRCPlayer_0;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000257B File Offset: 0x0000077B
		internal static APIUser GetApiUser(Player player)
		{
			return player.prop_APIUser_0;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004A40 File Offset: 0x00002C40
		public static Player Target(string username)
		{
			foreach (Player player in PlayerActions.GetAllPlayers())
			{
				string displayName = PlayerActions.GetApiUser(player).displayName;
				if (displayName.ToLower().Contains(username.ToLower()))
				{
					return player;
				}
			}
			return null;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002583 File Offset: 0x00000783
		public static List<Player> GetAllPlayers()
		{
			if (PlayerActions.GetPlayerManager() == null)
			{
				return null;
			}
			return PlayerActions.GetPlayerManager().field_Private_List_1_Player_0;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000259E File Offset: 0x0000079E
		public static PlayerManager GetPlayerManager()
		{
			return PlayerManager.field_Private_Static_PlayerManager_0;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000025A5 File Offset: 0x000007A5
		public static void Teleport(VRCPlayer player)
		{
			PlayerActions.GetLocalVRCPlayer().transform.position = player.transform.position;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004A8C File Offset: 0x00002C8C
		public static APIUser GetSelectedAPIUser()
		{
			if (PlayerActions._selectedUserMenuQM == null)
			{
				PlayerActions._selectedUserMenuQM = UnityEngine.Object.FindObjectOfType<SelectedUserMenuQM>();
			}
			if (PlayerActions._selectedUserMenuQM != null)
			{
                DataModel<APIUser> dataModel = PlayerActions._selectedUserMenuQM.field_Private_IUser_0.Cast<DataModel<APIUser>>();
				return dataModel.field_Protected_TYPE_0;
			}
			
			return null;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004AE4 File Offset: 0x00002CE4
		public static Player GetPlayer(this PlayerManager instance, string UserID)
		{
			List<Player> field_Private_List_1_Player_ = instance.field_Private_List_1_Player_0;
			Player result = null;
			foreach (Player player in field_Private_List_1_Player_)
			{
				if (player.field_Private_APIUser_0.id == UserID)
				{
					result = player;
				}
			}
			return result;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000025C1 File Offset: 0x000007C1
		public static VRCPlayer SelVRCPlayer()
		{
			return PlayerManager.field_Private_Static_PlayerManager_0.GetPlayer(PlayerActions.GetSelectedAPIUser().id)._vrcplayer;
		}

		// Token: 0x0400008B RID: 139
		private static SelectedUserMenuQM _selectedUserMenuQM;
	}
}

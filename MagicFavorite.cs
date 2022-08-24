﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using emmVRC.Utils;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;
using VRC;
using Il2CppSystem.Collections.Generic;
using VRC.Core;
using VRC.DataModel;
using VRC.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using LitJson;
using Newtonsoft.Json;

namespace BlackMagic
{
	// Token: 0x02000003 RID: 3

	public class MagicFavorite
	{

		public static void OnApplicationStart()
		{
			isii = false;
			isloop = false;

		}

		public static void OnApplicationQuit()
		{
			

		}
		public static void save()
        {
			string filePath = Environment.CurrentDirectory + "/Mods/Avatar.json";
			FileInfo file = new FileInfo(filePath);
			if (PlayerData.FavoriteList.Count == 0)
			{
				return;
			}

			
            //p100
            PlayerData.range = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();
            for (var a=0; a<= PlayerData.FavoriteList.Count-1;a++)
            {
                PlayerData.range.Add(PlayerData.FavoriteList[a]);
            }
			File.WriteAllText(filePath, JsonConvert.SerializeObject(PlayerData.range));
			//         string json = JsonUtility.ToJson(ssve,true);
			//string json = "";
			////string[] jj = null;//20000iq
			//string all = null;

			//var apiavatar_type = typeof(ApiAvatar);

			//         for (int i = 0; i < PlayerData.FavoriteList.Count; i++)
			//{
			//	json = JsonUtility.ToJson(PlayerData.FavoriteList[i]);
			//	all = all + json;
			//}

			//	//MelonLogger.Msg( JsonUtility.ToJson(PlayerData.FavoriteList[i]));
			//	//all += (json.ToString());//如果这甚至管用 try it
			//}
			//try
			//{
			//File.WriteAllText(filePath, json);//???
			//}
			//catch
			//         {
			//	MelonLogger.Msg("wssb");
			//}

		}
		public static void loed()
		{


			var fill = Environment.CurrentDirectory + "/Mods/Avatar.txt";
			string filePath = Environment.CurrentDirectory + "/Mods/Avatar.json";
			if (!File.Exists(filePath))
			{
				Il2CppSystem.Collections.Generic.List<ApiAvatar> Favoritel = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();
				File.WriteAllText(filePath, JsonConvert.SerializeObject(Favoritel));

				if (File.Exists(fill))
				{
					MelonCoroutines.Start(fetchAvatars());
				}
				else
				{
					FavoriteListcopy = PlayerData.FavoriteList;
					isii = true;
				}
				return;
			}
			String strdata = File.ReadAllText(filePath);
			PlayerData.FavoriteList = new System.Collections.Generic.List<ApiAvatar>();
			var a = JsonConvert.DeserializeObject< System.Collections.Generic.List <ApiAvatar>> (strdata);
            //for (var a = 0; a <= range3.Count - 1; a++)
            //{
            //    PlayerData.FavoriteList.Add(PlayerData.range[a]);
            //}

            FavoriteListcopy = PlayerData.FavoriteList;
			if (File.Exists(fill))
			{
				var fil = File.ReadAllLines(Environment.CurrentDirectory + "/Mods/Avatar.txt");
				for (var i = 0; i < fil.Length; i++)
				{
					FavoriteListid.Add(fil[i]);
				}
			}

			//PlayerData.range = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();
			//PlayerData.range = JsonUtility.FromJson<Il2CppSystem.Collections.Generic.List<ApiAvatar>>(strdata);
			//foreach (var a in PlayerData.range)
			//         {
			//	PlayerData.FavoriteList.Add(a);
			//	FavoriteListid.Add(a.id);
			//}
			isii = true;
			MelonLogger.Msg("模型已读档！");

		}
		public static void Initialize()
		{
			//loed();
            if (File.Exists(Environment.CurrentDirectory + "/Mods/Avatar.txt"))
            {
                MelonCoroutines.Start(fetchAvatars());
                
            }
            else
            {
                isii = true;

            }
            gameObject = UnityEngine.Object.Instantiate<GameObject>(GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/ViewUserOnVRChatWebsiteButton"), GameObject.Find("UserInterface/MenuContent/Screens/Avatar").transform);
			
			favae = (UnityAction)fave;
			add = (UnityAction)AAdd;
			MagicFavorite.ModFavoList();
			gameObject.SetActive(false);
			isloop = true;

			MagicFavorite.MainAvatarMenu = GameObject.Find("UserInterface/MenuContent/Screens/Avatar");
			
			currPageAvatar = MainAvatarMenu.GetComponent<PageAvatar>();
			currPageAvatar.field_Public_SimpleAvatarPedestal_0.field_Public_Single_0 *= 0.85f;

            selectedUserGroup = new ButtonGroup(ButtonAPI.menuPageBase.transform.parent.Find("Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup"), "CCY菜单");
            

            
			gameObject.name = "FavoriteButton";
			gameObject.GetComponentInChildren<Text>().text = "Favorite";
			MagicFavorite.AvatarFavoriteButton = gameObject.GetComponent<Button>();
			MagicFavorite.AvatarFavoriteButton.interactable = true;
			MagicFavorite.AvatarFavoriteButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-90f, 900f);
			MagicFavorite.AvatarFavoriteButton.onClick = new Button.ButtonClickedEvent();
            MagicFavorite.AvatarFavoriteButton.onClick.AddListener(favae);
			favouriteAvatarButton = new SimpleSingleButton(selectedUserGroup, "收藏模型", delegate ()
			{
				//bool flag = QuickMenu.prop_QuickMenu_0.field_Private_Player_0.prop_ApiAvatar_0.releaseStatus != "private";
				//if (flag)
				{
					selectedAPIUser = UserSelectionManager.field_Private_Static_UserSelectionManager_0.field_Private_APIUser_1;
					if (selectedAPIUser == null)
					{
						selectedAPIUser = UserSelectionManager.field_Private_Static_UserSelectionManager_0.field_Private_APIUser_0;
					}

					//player = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray().FirstOrDefault((Player a) => a.field_Private_APIUser_0 != null && a.field_Private_APIUser_0.id == selectedAPIUser.id);
					//vrcplayer = (player != null) ? player._vrcplayer : null;
					MagicFavorite.Favorite(PlayerActions.Target(selectedAPIUser.displayName).prop_ApiAvatar_0);
					ButtonAPI.GetQuickMenuInstance().ShowOKDialog("CCY菜单", "已收藏！", null);
				}
			}, "模型收藏");
			TPAvatarButton = new SimpleSingleButton(selectedUserGroup, "Tp到该玩家", delegate () {
				selectedAPIUser = UserSelectionManager.field_Private_Static_UserSelectionManager_0.field_Private_APIUser_1;
				PlayerActions.Teleport(PlayerActions.Target(selectedAPIUser.displayName).prop_VRCPlayer_0);
			}, "TP");
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000273C File Offset: 0x0000093C
		public static void Favorite(ApiAvatar id)
		{
			bool flag = MagicHelp.NotExistInList(PlayerData.FavoriteList, id);
			if (flag)
			{
				PlayerData.FavoriteList.Add(id);
				FavoriteListid.Add(id.id);
				FavoriteListcopy.Add(id);
				
			}
			else
			{

				FavoriteListid.Remove(id.id);
				unFavor();
				
			}


			MagicFavorite.RefreshList();
		}

        private static void unFavor()
        {
			PlayerData.FavoriteList.Clear();
            foreach(var a in FavoriteListid)
            {
				foreach(var i in FavoriteListcopy)
                {
					if(i.id==a)
                    {
						PlayerData.FavoriteList.Add(i);
                    }
                }
            }
			FavoriteListcopy.Clear();
			foreach (var i in PlayerData.FavoriteList)
			{
				FavoriteListcopy.Add(i);
			}
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002780 File Offset: 0x00000980
        public static void ModFavoList()
		{
			PageAvatar pageAvatar = UnityEngine.Resources.FindObjectsOfTypeAll<PageAvatar>().FirstOrDefault<PageAvatar>();
			MagicFavorite.AvatarList = UnityEngine.Object.Instantiate<GameObject>(GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Legacy Avatar List"), GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content").transform).GetComponent<UiAvatarList>();
			MagicFavorite.AvatarList.name = "ccy Favorite List";
			MagicFavorite.AvatarList.clearUnseenListOnCollapse = false;
			AvatarList.field_Public_Category_0 = UiAvatarList.Category.SpecificList;
			MagicFavorite.AvatarList.transform.Find("Button/TitleText").GetComponent<Text>().text = "无限收藏夹(正在加载）";
			avText = AvatarList.transform.Find("Button").gameObject;
			ChangeButton = pageAvatar.transform.Find("Change Button").gameObject;
			refreshButton = UnityEngine.Object.Instantiate<GameObject>(ChangeButton, avText.transform.parent);
			refreshButton.GetComponentInChildren<Text>().text = "+";
			refreshButton.GetComponent<Button>().onClick.RemoveAllListeners();
			refreshButton.GetComponent<Button>().onClick.AddListener(add);
			refreshButton.GetComponent<RectTransform>().sizeDelta /= new Vector2(4f, 1f);
			refreshButton.transform.SetParent(avText.transform, true);
			refreshButton.GetComponent<RectTransform>().anchoredPosition = avText.transform.Find("ToggleIcon").GetComponent<RectTransform>().anchoredPosition + new Vector2(980f, 0f);
			refreshButton.SetActive(false);
			MagicFavorite.AvatarList.gameObject.SetActive(true);
			MagicFavorite.AvatarList.transform.SetSiblingIndex(0);
		}


		public static void AAdd()
		{
			buttonAction = (Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>)delegate (String id, Il2CppSystem.Collections.Generic.List<KeyCode>keyCodes,Text text) 
			{
                bool c = false;
                foreach (var b in PlayerData.FavoriteList)
                {
                    if (b.id == id)
                    {
                        c = true;

                    }
                }


                if (!c)
				{               
                a = new System.Collections.Generic.List<String>();
				a.Add(id);
				
				isloop = false;
				MagicFavorite.AvatarList.transform.Find("Button/TitleText").GetComponent<Text>().text = "无限收藏夹(正在加载）";
				gameObject.SetActive(false);
				refreshButton.SetActive(false);
				MelonCoroutines.Start(isRefetchAvatars(a));
				}
                else if (c)
                {
                    VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.ShowAlert("CCY", "该模型已存在！", 3f);
					MelonLogger.Msg("该模型已存在！");
				}


            };
			 VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.ShowInputPopup("输入模型id", "", InputField.InputType.Standard, false, "添加"
	,buttonAction, null, "Enter Id....", true, null, false, 0) ;
		}

		public static IEnumerator fetchAvatars()
        {
			var co = 0;
			var fill = File.ReadAllLines(Environment.CurrentDirectory + "/Mods/Avatar.txt");
			MelonLogger.Msg("开始加载模型");
			
			for (var i=0;i< fill.Length; i++)
			{
				if (fill[i]==null)
                {
					MelonLogger.Msg("已删除一个空的模型");
					if (i < fill.Length - 1)
					{
						
						continue;

					}
					else
					{
						
						break;
					}
				}
				var c = (API.Fetch<ApiAvatar>(fill[i]));
				requestFinished = false;
				MelonCoroutines.Start(Delay());
				while (!requestFinished)
				{
					yield return new WaitForEndOfFrame();
				}

				if (c.assetUrl==null&&co<10)
                {
					co++;
					MelonLogger.Msg("第"+(i+1)+"个模型正在重新第"+co+"次重新加载");
					i--;
					continue;
				}
				else if (c.assetUrl == null && co >= 10)
				{
					MelonLogger.Msg("第" + (i + 1) + "个模型加载失败，已放入错误合集下次重新加载");
                    EFavoriteListid.Add(c.id);
                    if (i<fill.Length-1)
					{
						co = 0;
						continue;
						
					}
					else
                    {
						
						break;
                    }
					
				}
				co = 0;
				MelonLogger.Msg("正在加载第"+ (i + 1) + "个，共"+ File.ReadAllLines(Environment.CurrentDirectory + "/Mods/Avatar.txt").Length+"个");


				FavoriteListid.Add(fill[i]);
				PlayerData.FavoriteList.Add(c);
				FavoriteListcopy.Add(c);

				
			}
			
			
			bool flag = File.Exists(Environment.CurrentDirectory + "/Mods/AvatarEX.txt");
			if (flag)
			{				
				var fillE= File.ReadAllLines(Environment.CurrentDirectory + "/Mods/AvatarEX.txt");
				if (fillE != null && EFavoriteListid.Count != 0)
				{

					MelonLogger.Msg("开始加载这次和上次没成功的模型");
					a = new System.Collections.Generic.List<String>();
					for (var i = 0; i < fillE.Length; i++)
					{
						a.Add(fillE[i]);

					}
					for (var i = 0; i < EFavoriteListid.Count; i++)
					{
						a.Add(EFavoriteListid[i]);

					}
					MelonCoroutines.Start(RefetchAvatars(a));
				}
				else if (fillE != null && EFavoriteListid.Count == 0)
				{
					MelonLogger.Msg("开始加载上次没成功的模型");
					a = new System.Collections.Generic.List<String>();
					for (var i = 0; i < fillE.Length; i++)
					{

						a.Add(fillE[i]);
						
					}

					MelonCoroutines.Start(RefetchAvatars(a));
				}
				if(fillE == null)
                {
					if (EFavoriteListid.Count != 0)
					{
						MelonLogger.Msg("开始加载这次没成功的模型");
						a = new System.Collections.Generic.List<String>();
						for (var i = 0; i < EFavoriteListid.Count; i++)
						{
							a.Add(EFavoriteListid[i]);
						}
						MelonCoroutines.Start(RefetchAvatars(a));

					}
					else
					{
						isii = true;

						MelonLogger.Msg("模型加载完毕");
					}
				}

			}
			if(!flag)
            {
				if (EFavoriteListid.Count != 0)
				{
					MelonLogger.Msg("开始加载这次没成功的模型");
					a = new System.Collections.Generic.List<String>();
					for (var i = 0; i < EFavoriteListid.Count; i++)
					{
						a.Add(EFavoriteListid[i]);
					}
					MelonCoroutines.Start(RefetchAvatars(a));

				}
				else
				{
					isii = true;

					MelonLogger.Msg("模型加载完毕");
				}
			}
			
			yield break;
		}
		public static IEnumerator Delay()
		{
			yield return new WaitForSeconds(0.4f);
			requestFinished = true;
			yield break;
		}
		public static IEnumerator RefetchAvatars(System.Collections.Generic.List<String> id)
		{
			var co = 0;
			if(isii)
            {
				MagicFavorite.AvatarList.transform.Find("Button/TitleText").GetComponent<Text>().text = "无限收藏夹(正在加载）";
				gameObject.SetActive(false);
				refreshButton.SetActive(false);
			}

			for (var i = 0; i < id.Count; i++)
            {
				var c = (API.Fetch<ApiAvatar>(id[i]));
				requestFinished = false;
				MelonCoroutines.Start(Delay());
				while (!requestFinished)
				{
					yield return new WaitForEndOfFrame();
				}
				if (c.assetUrl == null && co < 10)
				{
					co++;
					MelonLogger.Msg("第" + (i + 1) + "个模型正在重新第" + co + "次重新加载");
					i--;
					continue;
				}
				else if (c.assetUrl == null && co >= 10)
				{
					MelonLogger.Msg("第" + (i + 1) + "个模型加载失败，已放入错误合集下次重新加载");
					EFavoriteListid.Add(c.id);
					if (i < id.Count-1)
					{
						co = 0;
						continue;
						
					}
					else
					{
						break;
					}
				}
				co = 0;
				MelonLogger.Msg("正在加载第" + (i + 1) + "个，共" + File.ReadAllLines(Environment.CurrentDirectory + "/Mods/Avatar.txt").Length + "个");
				FavoriteListid.Add(id[i]);
				PlayerData.FavoriteList.Add(c);
				FavoriteListcopy.Add(c);
				EFavoriteListid.Remove(id[i]);
				

			}
			if (EFavoriteListid.Count != 0)
			{
				File.WriteAllLines(Environment.CurrentDirectory + "/Mods/没加载成功的Avatar备份.txt", EFavoriteListid);

			}
			
			if (isii)
            {
				gameObject.SetActive(true);
				refreshButton.SetActive(true);
			}
		    isloop = true;
			isii = true;
			MagicFavorite.RefreshList();
			MelonLogger.Msg("模型重新加载完毕");
			yield break;
		}
		public static IEnumerator isRefetchAvatars(System.Collections.Generic.List<String> id)
		{
			var s = "avtr_66c2ebc1-44f1-46cf-b467-b55eb12a8b19";
			if (id[0].Length != s.Length)
			{
				
				VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.ShowAlert("CCY", "输入id有误！", 3f);
				MelonLogger.Msg("输入id有误！");
				isloop = true;
				isii = true;
				yield break;
			}
                var co = 0;
			
			

			for (var i = 0; i < id.Count; i++)
			{
				var c = (API.Fetch<ApiAvatar>(id[i]));
				requestFinished = false;
				MelonCoroutines.Start(Delay());
				while (!requestFinished)
				{
					yield return new WaitForEndOfFrame();
				}
				if (c.assetUrl == null && co < 10)
				{
					co++;
					MelonLogger.Msg("第" + (i + 1) + "个模型正在重新第" + co + "次重新加载");
					i--;
					continue;
				}
				else if (c.assetUrl == null && co >= 10)
				{
					MelonLogger.Msg("第" + (i + 1) + "个模型加载失败，已放入错误合集下次重新加载");
					EFavoriteListid.Add(c.id);
					if (i < id.Count - 1)
					{
						co = 0;
						continue;

					}
					else
					{
						if (isii)
						{
							gameObject.SetActive(true);
							refreshButton.SetActive(true);
						}
						VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.ShowAlert("CCY", "添加失败！", 0f);
						isloop = true;
						isii = true;
						yield break;
					}
				}
				co = 0;
				MelonLogger.Msg("正在加载第" + (i + 1) + "个，共" +id.Count + "个");
				FavoriteListid.Add(id[i]);
				PlayerData.FavoriteList.Add(c);
				FavoriteListcopy.Add(c);
				//EFavoriteListid.Remove(id[i]);


			}
			if (EFavoriteListid.Count != 0)
			{
				File.WriteAllLines(Environment.CurrentDirectory + "/Mods/没加载成功的Avatar备份.txt", EFavoriteListid);

			}

			if (isii)
			{
				gameObject.SetActive(true);
				refreshButton.SetActive(true);
			}
			isloop = true;
			isii = true;
			MagicFavorite.RefreshList();
			VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.ShowAlert("CCY", "添加完成！", 0f);
			MelonLogger.Msg("模型重新加载完毕");
			yield break;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002879 File Offset: 0x00000A79
		public static IEnumerator AvatarListLoop()
		{
	      if(isloop)
		  {
				for (; ; )
				{
					yield return new WaitForSeconds(5f);
					a = new System.Collections.Generic.List<String>();
					a = MagicFavorite.ArrayMatch();
					bool flag = (MagicFavorite.MainAvatarMenu.activeInHierarchy && a.Count != 0);
					if (flag)
					{
						MelonLogger.Msg("发现空模型，正在重新加载");
						foreach (var aa in a)
						{
							FavoriteListid.Remove(aa);
						}
						unFavor();						
						isloop = false;
						MagicFavorite.AvatarList.transform.Find("Button/TitleText").GetComponent<Text>().text = "无限收藏夹(正在加载）";
						gameObject.SetActive(false);
						refreshButton.SetActive(false);
						MelonCoroutines.Start(isRefetchAvatars(a));
					}
					if (MagicFavorite.MainAvatarMenu.activeInHierarchy && PlayerData.FavoriteList.Count() != FavoriteListid.Count())
					{

					}
					if (isloop)
					{ 
                    MagicFavorite.RefreshList();
					}
				}
		  }
			yield break;


		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002884 File Offset: 0x00000A84
		private static System.Collections.Generic.List<String> ArrayMatch()
		{
            System.Collections.Generic.List<String> s = new System.Collections.Generic.List<String>();
			foreach (ApiAvatar item in PlayerData.FavoriteList)
			{

					if(item.assetUrl == null)
                    {
					  s.Add(item.id);
				    }

			}

			return s;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000028F8 File Offset: 0x00000AF8
		private static void RefreshList()
		{
			MagicFavorite.AvatarList.field_Private_Dictionary_2_String_ApiAvatar_0.Clear();
			Il2CppSystem.Collections.Generic.List<ApiAvatar> range2 = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();
			for(var i= PlayerData.FavoriteList.Count-1; i>=0;i--)
            {
				range2.Add(PlayerData.FavoriteList[i]);
            }
			UIList.RenderElement(AvatarList, range2);
			File.WriteAllLines(Environment.CurrentDirectory + "/Mods/Avatar.txt", FavoriteListid);
			//save();
			MagicFavorite.AvatarList.Method_Private_Void_0();
			MagicFavorite.AvatarList.transform.Find("Button/TitleText").GetComponent<Text>().text = "无限收藏夹" + "("+ PlayerData.FavoriteList.Count.ToString() + ")";
			
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000029A4 File Offset: 0x00000BA4
		public static void CheakFavButton()
		{
            //bool activeInHierarchy = MagicFavorite.favouriteAvatarButton.gameObject.activeInHierarchy;
            //if (activeInHierarchy)
            //{
            //	bool flag = MagicHelp.NotExistInList(MagicFavorite.FavoriteList, vrcplayer._player.prop_ApiAvatar_0.id);
            //	if (flag)
            //	{
            //		MagicFavorite.favouriteAvatarButton.SetText("Favorite");
            //	}
            //	else
            //	{
            //		MagicFavorite.favouriteAvatarButton.SetText("UnFavorite");
            //	}
            //}
            if (isii&& isloop )
            {
				refreshButton.SetActive(true);
				gameObject.SetActive(true);
                MagicFavorite.RefreshList();
                MelonCoroutines.Start(MagicFavorite.AvatarListLoop());
                isii = false;
            }
            MagicFavorite.AvatarFavoriteButton = gameObject.GetComponent<Button>();
			bool activeInHierarchy2 = MagicFavorite.AvatarFavoriteButton.gameObject.activeInHierarchy;
			if (activeInHierarchy2)
			{
				GameObject rameObject = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot/MainModel");
				bool flag2 = rameObject != null && rameObject.GetComponent<SimpleAvatarPedestal>().field_Internal_ApiAvatar_0 != null;
				if (flag2)
				{
					bool flag3 = MagicHelp.NotExistInList(PlayerData.FavoriteList, rameObject.GetComponent<SimpleAvatarPedestal>().field_Internal_ApiAvatar_0);
					if (flag3)
					{
						MagicFavorite.AvatarFavoriteButton.GetComponentInChildren<Text>().text = "Favorite";
					}
					else
					{
						MagicFavorite.AvatarFavoriteButton.GetComponentInChildren<Text>().text = "UnFavorite";
					}
				}
			}
		}
		public static void fave()
		{
			Favorite(GameObject.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot/MainModel").GetComponent<SimpleAvatarPedestal>().field_Internal_ApiAvatar_0);
		}

		// Token: 0x04000003 RID: 3
		public static Button SelectFavoriteButton;

		// Token: 0x04000004 RID: 4
		public static Button AvatarFavoriteButton;

		// Token: 0x04000005 RID: 5
		public static GameObject MainAvatarMenu;
        private static PageAvatar currPageAvatar;
		
		public static System.Collections.Generic.List<String> a = new System.Collections.Generic.List<String>();
		public static System.Collections.Generic.List<String> EFavoriteListid = new System.Collections.Generic.List<String>();
		public static System.Collections.Generic.List<ApiAvatar> FavoriteListcopy = new System.Collections.Generic.List<ApiAvatar>();
		public static System.Collections.Generic.List<String> FavoriteListid = new System.Collections.Generic.List<String>();
		// Token: 0x04000006 RID: 6


		// Token: 0x04000007 RID: 7
		public static UiAvatarList AvatarList;
        public static UnityAction favae ;
		public static UnityAction add;
		private static ButtonGroup selectedUserGroup;
		private static SimpleSingleButton favouriteAvatarButton;
		private static SimpleSingleButton TPAvatarButton;
		private static GameObject gameObject;
        public static	APIUser selectedAPIUser;
	    public static	Player player;
		public static VRCPlayer vrcplayer;
        private static bool requestFinished =true;
		public static Il2CppSystem.Action<VRC.Core.ApiContainer> ok;
		public static Il2CppSystem.Action<VRC.Core.ApiContainer> off;
		public static bool isloop;
		public static bool isii;
        private static GameObject avText;
        private static GameObject ChangeButton;
        private static GameObject refreshButton;
        private static Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> buttonAction;

	}
	[Serializable]
	public static class PlayerData 
	{
		public static System.Collections.Generic.List<ApiAvatar> FavoriteList = new System.Collections.Generic.List<ApiAvatar>();
		public static Il2CppSystem.Collections.Generic.List<ApiAvatar> range;
		
	}


}

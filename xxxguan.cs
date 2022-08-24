using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UIExpansionKit.API;
using UnityEngine;
using UnhollowerRuntimeLib;
using VRC.SDKBase;
using VRC.SDK3;
using System.Reflection;
using VRC.Udon;
using Harmony;
using VRC;
using ActionMenuApi.Pedals;
using ActionMenuApi.Api;
using VRC.Core;
using UnityEngine.UI;
using udon;
using System.Diagnostics;
using BlackMagic;
using Utils;

namespace my_mod
{
    public class xxxguan : MelonMod
    {

        public override void OnApplicationStart()
        {
            
            onmenu();
            ActMenu();
            MagicFavorite.OnApplicationStart();
            //TriggerESP.TriggerESPMod.OnApplicationStart();

        }
        public override void OnApplicationQuit()
        {
            MagicFavorite.OnApplicationQuit();
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (buildIndex != -1)
            {
                return;
            }
            
            if (islsi)
            {
                VRCEventDelegate<Player> field_Internal_VRCEventDelegate_1_Player_ = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0;
                VRCEventDelegate<Player> field_Internal_VRCEventDelegate_1_Player_2 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;
                field_Internal_VRCEventDelegate_1_Player_.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(xxxguan.OnPlayerJoin));
                field_Internal_VRCEventDelegate_1_Player_2.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(OnPlayerLeave));
                islsi = false;
                ButtonAPI.OnUiManagerInit();
                MagicFavorite.Initialize();
                MelonCoroutines.Start(MagicHelp.MagicLoop());
               
                
                
            }
        }

        private static void OnPlayerLeave(Player player)
        {
            //if(player.prop_APIUser_0.displayName != Networking.LocalPlayer.displayName)
            //{
            for (var a = 0; a < Lplayers.Count; a++)
            {
                if (player == Lplayers[a])
                {
                    return;
                }
            }
                //players.Remove(player);
                //PlayerLeavemeun(player);
                //Lplayers.Add(player);
                MelonLogger.Msg("off" + "  " + player.prop_APIUser_0.displayName);
                
            //}
            //else
            //{
                //ximenu.Show();
                //DestroyAllChildren(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/GenericPopupWindow(Clone)(Clone)/Content/Scroll View/Viewport/Content").gameObject);
                //ximenu.Hide();
            //}
        }

        private static void OnPlayerJoin(Player player)
        {
            for(var a=0;a<players.Count;a++)
            {
                if(player == players[a])
                {
                    return;
                }
            }
            if(player.field_Private_VRCPlayerApi_0.isMaster)
            {
                master = player;
            }
                //Lplayers.Remove(player);
                players.Add(player);
                PlayerJoinmeun(player);
                MelonLogger.Msg("on" + "  " + player.prop_APIUser_0.displayName);
            
        }
        private static void PlayerLeavemeun(Player player)
        {
            ximenu.Show();
            var pl = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/GenericPopupWindow(Clone)(Clone)/Content/Scroll View/Viewport/Content").gameObject;
            foreach (Transform Object in pl.GetComponentInChildren<RectTransform>())
            {
                if(Object.gameObject.name=="Text")
                {
                    if(Object.gameObject.GetComponent<Text>().text==player.prop_APIUser_0.displayName)
                    {
                        
                        UnityEngine.Object.Destroy((UnityEngine.Object)ximenu);
                        //ximenu.Hide();
                    }
                }
            }
        }
        private static void PlayerJoinmeun(Player player)
        {
            if (player.prop_APIUser_0.displayName == Networking.LocalPlayer.displayName)
            {
                DG = master.field_Private_VRCPlayerApi_0.GetGravityStrength();
                return;
            }
            udon.udon.PlayerJoinmeun(player);
                ximenu.AddSimpleButton(player.prop_APIUser_0.displayName, delegate () { playxi(player); });
                xismenu.AddSimpleButton(player.prop_APIUser_0.displayName, delegate ()
            {
                if (isStart)
                {
                    OnXiStart();
                    isStart = false;
                }
                yplyear = player;
                 isup = true;
                
            });
            zuomenu.AddSimpleButton(player.prop_APIUser_0.displayName, delegate ()
            {
                zplyear = player;
                isz = true;
            });
        }


        private static void playxi(Player player)
        {
            if (isStart)
            {
                OnXiStart();
                isStart = false;
            }
            isup = false;
            float angle = 360f / pickobj.Count;
            for (var j = 0; j < pickobj.Count; j++)
            {
                Networking.SetOwner(Networking.LocalPlayer, pickobj[j]);
                pickobj[j].transform.rotation = Quaternion.AngleAxis(angle * j, Vector3.up);
                float x = player.transform.position.x + 0.6f * Mathf.Sin((angle * j) * (3.14f / 180f));

                float y = player.transform.position.z + 0.6f * Mathf.Cos((angle * j) * (3.14f / 180f));
                pickobj[j].transform.position = new Vector3(x, GetLocalVRCPlayer().transform.position.y + 0.5f, y);
            }
        }
        private static void ActMenu()
        {
            actMenu = VRCActionMenuPage.AddSubMenu(ActionMenuPage.Main, "CCY菜单",delegate
            {
               xxdaf= CustomSubMenu.AddSubMenu( "吸星大法菜单", delegate
                {
                    CustomSubMenu.AddButton("吸星大法", new Action(OnXi));
                    CustomSubMenu.AddToggle("实时吸星", isis, new Action<bool>(iisip));
                });
                CustomSubMenu.AddButton("时光回溯", new Action(sghs));
                CustomSubMenu.AddButton("停止吸附", new Action(tzxf));
                CustomSubMenu.AddToggle("全局自动开火", iskh, new Action<bool>(iiskh));

            });
        }

        private static void tzxf()
        {
            isz = false;
            Networking.LocalPlayer.SetGravityStrength(DG);
        }

        private static void iiskh(bool obj)
        {
            iskh=obj;
        }

        public static void PlayerList()
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0 != null)
            {
                
                DestroyAllChildren(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/GenericPopupWindow(Clone)(Clone)/Content/Scroll View/Viewport/Content").gameObject);
                ximenu.AddSimpleButton("返回", delegate () { ximenu.Hide(); });
                ximenu.AddSimpleButton("手动清除", delegate () { PlayerList(); });
                players.Clear();
                Lplayers.Clear();
                //if (PlayerManager.field_Private_Static_PlayerManager_0 != null && PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0 != null)
                //{
                //    foreach (Player player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
                //    {
                //        players.Add(player);
                //        PlayerJoinmeun(player);
                //    }
                //}
            }
        }
        private static void onmenu()
        {
            ExpansionKitApi.GetExpandedMenu(ExpandedMenu.QuickMenu).AddSimpleButton("CCY菜单", delegate () { zomenu.Show(); });
            menu.AddSimpleButton("返回", delegate () { menu.Hide(); });
            menu.AddSimpleButton("吸星大法", new Action(OnXi));
            menu.AddSimpleButton("吸星大法他人", delegate () { ximenu.Show(); });
            menu.AddSimpleButton("实时吸星大法他人", delegate () { xismenu.Show(); });
            zomenu.AddSimpleButton("返回", delegate () { zomenu.Hide(); });
            zomenu.AddSimpleButton("时光回溯", delegate () { sghs(); });
            zomenu.AddSimpleButton("吸星大法菜单", delegate () { menu.Show(); });
            zomenu.AddSimpleButton("吸附别人菜单", delegate () { zuomenu.Show(); });
            zomenu.AddSimpleButton("udon变量改变菜单", delegate () { udon.udon.getudon.Show(); });
            zomenu.AddSimpleButton("udon事件广播菜单", delegate () { udon.udon.getudonm.Show(); });
            zomenu.AddToggleButton("全局自动开火", delegate (bool var) {
                if (!iskh) iskh = true;
                else iskh = false;
            }, new Func<bool>(Liiskh));
            menu.AddToggleButton("实时吸星", delegate (bool var)
            {
                if (isStart)
                {
                    OnXiStart();
                    isStart = false;
                }
                yplyear = GetLocalVRCPlayer();
                if (!isup) isup = true;
                else isup = false;
            }, new Func<bool>(Liisip));
         //   zomenu.AddSimpleButton("测试", delegate () {
         //       udon.udon.udomlien();
         //});
            zomenu.AddSimpleButton("获取模型下载链接", delegate () { udon.udon.getavatamenu.Show(); });

        }
        
        private static bool Liiskh()
        {
            return iskh;
        }

        private static bool Liisip()
        {
            return isis;
        }

        private static void iisip(bool a)
        {
            if (isStart)
            {
                OnXiStart();
                isStart = false;
            }
            isup = a;
            yplyear = GetLocalVRCPlayer();
        }
        private static void sghs()
        {
            if (isStart)
            {
                OnXiStart();
                isStart = false;
            }
            isup = false;
            
            for (var j = 0; j < pickobj.Count; j++)
            {
                Networking.SetOwner(Networking.LocalPlayer, pickobj[j]);
                pickobj[j].transform.position = p3[j];
                pickobj[j].transform.rotation = q3[j];

            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (buildIndex != -1)
            {
                return;
            }
            udon.udon.OnSceneWasLoaded();
            
            MelonDebug.Msg(sceneName);
            isStart = true;
            is3 = false;
            isup = false;
            isis = false;
            iskh = false;
            isz = false;
            
            //PlayerList();
            ximenu = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.QuickMenu4Columns));
            ximenu.AddSimpleButton("返回", delegate () { ximenu.Hide(); });
            xismenu=ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.QuickMenu4Columns));
            xismenu.AddSimpleButton("返回", delegate () { xismenu.Hide(); });
            xismenu.AddSimpleButton("停止吸星", delegate () { isup=false; });
            zuomenu = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.QuickMenu4Columns));
            zuomenu.AddSimpleButton("返回", delegate () { zuomenu.Hide(); });
            zuomenu.AddSimpleButton("停止吸附", delegate () { isz = false; Networking.LocalPlayer.SetGravityStrength(DG); });
            OnXiStart();

        }
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            if (buildIndex != -1)
            {
                return;
            }
            pickobj.Clear();
            



        }
        public override void OnFixedUpdate()
        {
            if(isup)
            {
                float angle = 360f / pickobj.Count;
                for (var j = 0; j < pickobj.Count; j++)
                {
                    Networking.SetOwner(Networking.LocalPlayer, pickobj[j]);
                    ww += Time.deltaTime/60;
                    if (ww>=360)
                    {
                        ww -= 360;
                    }

                    float x = yplyear.transform.position.x + 0.6f * Mathf.Sin((angle * j) * (3.14f / 180f) + ww);

                    float y = yplyear.transform.position.z + 0.6f * Mathf.Cos((angle * j) * (3.14f / 180f) + ww);
                    pickobj[j].transform.position = new Vector3(x, yplyear.transform.position.y + 0.5f, y);
                    //pickobj[j].transform.rotation = Quaternion.AngleAxis((angle * j), Vector3.up);
                    if(!iskh)
                    { 
                    pickobj[j].transform.LookAt(yplyear.transform);
                    }
                    //pickobj[j].transform.Rotate( Vector3.up, angle * j +  Time.deltaTime/180);
                    //pickobj[j].transform.RotateAround(GetLocalVRCPlayer().transform.position, Vector3.up, Time.deltaTime * 20);
                }
            }
            if(isz)
            {

                GetLocalVRCPlayer().transform.position = zplyear.field_Private_VRCPlayerApi_0.GetBonePosition(HumanBodyBones.Head) + new Vector3(0, 0.4f, 0);
                Networking.LocalPlayer.SetGravityStrength(0);    
                
            }
        }
        public override void OnUpdate()
        {
            if(iskh)
            {
                
                for (int i = 0; i < pickobj.Count; i++)
                {
                    if(pickobj[i].gameObject.GetComponent<UdonBehaviour>())
                    {
                        Networking.SetOwner(Networking.LocalPlayer, pickobj[i]);
                        pickobj[i].gameObject.GetComponent<UdonBehaviour>().OnPickupUseDown();
                    }
                }
            }
        }



        private static void DestroyAllChildren(GameObject gameObject)
        {
            Enumerable.Range(0, gameObject.transform.childCount).Select(i => gameObject.transform.GetChild(i).gameObject).ToList().ForEach(child => UnityEngine.Object.Destroy(child));
        }

        public static void OnXiStart()
        {
            isStart = false;
            is3 =false;
            
            
            var a = 0;
            foreach (var Object in Resources.FindObjectsOfTypeAll<VRC.SDK3.Components.VRCPickup>())
            {
                
                if(Object.gameObject.GetComponent<VRC.SDK3.Components.VRCObjectSync>()!=null)
                {
                    
                    pickobj.Add(Object.gameObject);
                    a++;
                    is3 = true;
                }
            }
            p3 = new Vector3[a];
            q3 = new Quaternion[a];
            for (var i = 0; i < a; i++)
            {
                p3[i] = pickobj[i].transform.position;
                q3[i] = pickobj[i].transform.rotation;
            }
            if (is3)
            { 
                return;
            }
            foreach (var Object in Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>())
            {

                if (Object.gameObject.GetComponent<VRCSDK2.VRC_ObjectSync>() != null)
                {
                    
                    pickobj.Add(Object.gameObject);
                    a++;
                }
                
            }
            p3 = new Vector3[a];
            q3 = new Quaternion[a];
            for (var i = 0; i < a; i++)
            {
                p3[i] = pickobj[i].transform.position;
                q3[i] = pickobj[i].transform.rotation;
            }
        }
        //public static void fps()
        //{
            
        //   var a= GetLocalVRCPlayer().prop_PlayerNet_0 ;
        //}
        public static void OnXi()
        {
            if(isStart)
            {
                OnXiStart();
                isStart = false;
            }
            isup = false;
            float angle = 360f / pickobj.Count;
            for (var j=0; j < pickobj.Count; j++)
            {
                Networking.SetOwner(Networking.LocalPlayer, pickobj[j]);
                pickobj[j].transform.rotation = Quaternion.AngleAxis(angle * j, Vector3.up);
                float x = GetLocalVRCPlayer().transform.position.x +0.6f * Mathf.Sin((angle * j) * (3.14f / 180f));

                float y = GetLocalVRCPlayer().transform.position.z + 0.6f * Mathf.Cos((angle * j) * (3.14f / 180f));
                pickobj[j].transform.position = new Vector3(x, GetLocalVRCPlayer().transform.position.y+0.5f, y);
                
            }
        }
        public static Player GetLocalVRCPlayer()
        {
            return Player.prop_Player_0;
        }

        private static List<GameObject> pickobj = new List<GameObject>();
        private static Vector3[] p3;
        private static Quaternion[] q3;
        private static bool isStart;
        private static bool islsi =true;
        private static bool is3;
        private static bool isz = false;
        internal static ICustomShowableLayoutedMenu menu = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.QuickMenu4Columns));
        internal static ICustomShowableLayoutedMenu zomenu = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.QuickMenu4Columns));
        internal static ICustomShowableLayoutedMenu ximenu;
        internal static ICustomShowableLayoutedMenu xismenu;
        internal static ICustomShowableLayoutedMenu zuomenu;
        private static Dictionary<string, Transform> buttons = new Dictionary<string, Transform>();
        internal static PedalSubMenu actMenu;
        internal static List<Player> players = new List<Player>();
        internal static List<Player> Lplayers = new List<Player>();
        public static event Action<Player> OnPlayerJoined;
        internal static Player yplyear;
        internal static Player zplyear;
        internal static Player master;
        private static bool isup=false;
        private static bool iskh = false;
        private static bool isis = false;
        private static float ww;
        internal static PedalOption xxdaf;
        public static float DG;

        public static event Action<Player> OnPlayerLeft;
       
    }

}

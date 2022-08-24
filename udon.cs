using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using my_mod;
using VRC;
using UnityEngine;
using MelonLoader;
using Utils;
using System.Diagnostics;
using UIExpansionKit.API;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace udon
{
    public  class udon 
    {

        public static void udomlien()
        {
            if (!isStart)
            {
                return;
            }
            isStart = false;
            //foreach (var Object in Resources.FindObjectsOfTypeAll<VRC.Udon.UdonBehaviour>())
            //{
                
                
                




            //}
        }

        public static void GetAvatarLink(Player player)
        {

            {
                Process.Start(player.prop_ApiAvatar_0.assetUrl);
            };
        }
        public static void PlayerJoinmeun(Player player)
        {
            getavatamenu.AddSimpleButton(player.prop_APIUser_0.displayName+ " 模型下载", delegate () { GetAvatarLink(player); });
        }
        public static void OnSceneWasLoaded()
        {
            isStart = true;
            buttonAction = delegate (String i, Il2CppSystem.Collections.Generic.List<KeyCode> keyCodes, Text text)
            {
                id = i;
            };
            getudon = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.WideSlimList));
            getudonm = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.WideSlimList));

            getudon.AddSimpleButton("设定要修改的值", delegate () {
                VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.ShowInputPopup("输入变量", "", InputField.InputType.Standard, false, "更改",
buttonAction, null, "Enter ....", true, null, false, 0);
            });
            getudon.AddSimpleButton("返回", delegate () { getudon.Hide(); });
            getudonm.AddSimpleButton("返回", delegate () { getudon.Hide(); });

            getavatamenu = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.QuickMenu4Columns));
            getavatamenu.AddSimpleButton("返回", delegate () { getavatamenu.Hide(); });
            getavatamenu.AddSimpleButton("自己模型下载", delegate () { GetAvatarLink(xxxguan.GetLocalVRCPlayer()); });
            GetUdons();

        }
        public static void OnSceneWasUnloaded()
        {
            
        }
        public static void Setudons(uint b, int swith,UdonBehaviour udon )
        {
            switch (swith)
            {
                case 1:
                    Networking.SetOwner(Networking.LocalPlayer, udon.gameObject);
                    udon._program.Heap.SetHeapVariable(b, bbool);
                    break;
                case 2:
                    Networking.SetOwner(Networking.LocalPlayer, udon.gameObject);
                    udon._program.Heap.SetHeapVariable(b, ffloat);
                    break;
                case 3:
                    Networking.SetOwner(Networking.LocalPlayer, udon.gameObject);
                    udon._program.Heap.SetHeapVariable(b, sstring);
                    break;
                case 4:
                    Networking.SetOwner(Networking.LocalPlayer, udon.gameObject);
                    udon._program.Heap.SetHeapVariable(b, iint);
                    break;
                default:
                    Networking.SetOwner(Networking.LocalPlayer, udon.gameObject);
                    udon._program.Heap.SetHeapVariable(b, sstring);
                    break;
            }
            VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.ShowAlert("CCY", "修改完成！", 0f);

        }
        public static void GetUdons()
        {
           
            foreach (var udon in Resources.FindObjectsOfTypeAll<UdonBehaviour>())
            {
                getudon.AddSimpleButton(udon.gameObject.name, delegate () {
                    Symbols = udon._program.SymbolTable.GetExportedSymbols();
                    getudonss = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.WideSlimList));
                    getudonss.AddSimpleButton("返回", delegate () { getudonss.Hide(); getudon.Show(); });
                    

                    foreach (var str in Symbols)
                    {
                        var b = udon._program.SymbolTable.GetAddressFromSymbol(str);
                        var type = udon._program.SymbolTable.GetSymbolType(str).FullName;
                        var geTT = udon._program.Heap.GetHeapVariable(b);

                        if(type== "System.Boolean")
                            val= udon._program.Heap.GetHeapVariable<bool>(b).ToString();
                        else if(type== "System.Single")
                            val = udon._program.Heap.GetHeapVariable<float>(b).ToString();
                        else if(type == "System.String")
                            val = udon._program.Heap.GetHeapVariable<string>(b).ToString();
                        else if (type == "System.Int32")
                            val = udon._program.Heap.GetHeapVariable<int>(b).ToString();
                        else
                            val = udon._program.Heap.GetHeapVariable(b).ToString();

                        getudonss.AddSimpleButton("("+type+")"+str+":"+val, delegate () {
                            
                           

                            switch (type)
                            {
                                case "System.Boolean":
                                    bbool = bool.Parse(id);
                                    Setudons(b, 1, udon);
                                    break;
                                case "System.Single":
                                    ffloat = float.Parse(id);
                                    Setudons(b, 2, udon);
                                    break;
                                case "System.String":
                                    sstring = id;
                                    Setudons(b, 3, udon);
                                    break;
                                case "System.Int32":
                                    iint = int.Parse(id);
                                    Setudons(b, 4, udon);
                                    break;
                                default:
                                    Setudons(b, 100, udon);
                                    break;
                            }

                        });
                    }
                    getudonss.Show();


                });

                getudonm.AddSimpleButton(udon.gameObject.name, delegate () {
                    events = udon._eventTable;
                    getudonmss = ExpansionKitApi.CreateCustomQuickMenuPage(new LayoutDescription?(LayoutDescription.WideSlimList));
                    getudonmss.AddSimpleButton("返回", delegate () { getudonmss.Hide(); getudonm.Show(); });

                    foreach(var Event in events)
                    {
                        getudonmss.AddSimpleButton(Event.Key, delegate () {
                            Networking.SetOwner(Networking.LocalPlayer, udon.gameObject);
                            udon.SendCustomEvent(Event.Key);
                        });
                        getudonmss.AddSimpleButton("(ALL)"+Event.Key, delegate () {
                            Networking.SetOwner(Networking.LocalPlayer, udon.gameObject);
                            udon.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, Event.Key);
                        });
                    }
                    getudonmss.Show();
                });




            }

        }



        public static bool isStart=true;
        internal static ICustomShowableLayoutedMenu getavatamenu;
        internal static ICustomShowableLayoutedMenu getudon;
        internal static ICustomShowableLayoutedMenu getudonss;
        internal static ICustomShowableLayoutedMenu getudonm;
        internal static ICustomShowableLayoutedMenu getudonmss;
        public static Il2CppSystem.Collections.Immutable.ImmutableArray<string> Symbols;
        public static Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Collections.Generic.List<uint>> events;
        private static Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> buttonAction;
        private static int iint;
        private static float ffloat;
        private static bool bbool;
        private static string sstring;
        public static string id;
        public static string val;


    }


}

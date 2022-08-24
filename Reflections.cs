using System;
using System.Linq;
using System.Reflection;
using emmVRC.Utils;

using Il2CppSystem;
using TMPro;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using VRC;
using VRC.Animation;
using VRC.Core;
using VRC.DataModel;
using VRC.UI.Elements;

namespace emmVRC.Utils
{
    // Token: 0x02000072 RID: 114
    public static class Reflections
    {
        public static GameObject menuContent(this VRCUiManager mngr)
        {
            return mngr.field_Public_GameObject_0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using HarmonyLib;

namespace ScrollableMenuButtons.Harmonies
{
    [HarmonyPatch("BeatSaberMarkupLanguage.ViewControllers.BSMLAutomaticViewController, BSML", "Content", MethodType.Getter)]
    public class BSMLAutomaticViewControllerContentGetPatch
    {
        public static void Postfix(object __instance, ref string __result)
        {
            var def = __instance.GetType().GetCustomAttribute<ViewDefinitionAttribute>();
            if (def == null) {
                return;
            }
            if (string.Equals(def.Definition, "BeatSaberMarkupLanguage.Views.main-left-screen.bsml")) {
                __result = Utilities.GetResourceContent(Assembly.GetExecutingAssembly(), "ScrollableMenuButtons.Views.MenuButtons");
            }
        }
    }
}

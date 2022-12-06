using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace Ribworld;

[StaticConstructorOnStartup]
[HarmonyPatch]
public static class MainMenuPatch
{
    
    private static readonly Texture2D ribworld = ContentFinder<Texture2D>.Get("UI/HeroArt/Ribworld");
    static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(MainMenuDrawer),"MainMenuOnGUI");
    }


    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);

        foreach (var code in codes)
        {
            
            if (code.opcode == OpCodes.Ldsfld && (FieldInfo)code.operand == AccessTools.Field(typeof(MainMenuDrawer), "TexTitle"))
            {
                code.operand = AccessTools.Field(typeof(MainMenuPatch), "ribworld");
            }

            yield return code;
        }
    }
}


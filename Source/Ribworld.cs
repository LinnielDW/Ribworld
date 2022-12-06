using System.Reflection;
using HarmonyLib;
using Verse;

namespace Ribworld;

[StaticConstructorOnStartup]
public class RibworldPatches
{
    static RibworldPatches()
    {
        Log.Warning("patching");
        var harmony = new Harmony("com.arquebus.rimworld.mod.ribworld");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}
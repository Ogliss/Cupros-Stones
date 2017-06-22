using System;
using System.Collections.Generic;
using System.Linq;

using Harmony;

using RimWorld.Planet;
using Verse;

namespace CuprosStones {
  [HarmonyPatch(typeof(World))]
  [HarmonyPatch("NaturalRockTypesIn")]
  [HarmonyPatch(new Type[] { typeof(int) })]
  public class World_NaturalRockTypesIn {

    static bool Prefix (World __instance, int tile, ref IEnumerable<ThingDef> __result) {
      Rand.PushState();
      Rand.Seed = tile;

      List<ThingDef> list = (
        from d in DefDatabase<ThingDef>.AllDefs
        where d.category == ThingCategory.Building && d.building.isNaturalRock && !d.building.isResourceRock && Settings.StoneAllowedOrUndefined(d)
        select d).ToList();

      int num = Rand.RangeInclusive(Settings.StoneTypesAvailable.min, Settings.StoneTypesAvailable.max);
      if (num > list.Count) {
        num = list.Count;
      }

      List<ThingDef> list2 = new List<ThingDef>();
      for (int i = 0; i < num; i++) {
        ThingDef item = list.RandomElement();
        list.Remove(item);
        list2.Add(item);
      }

      Rand.PopState();
      __result = list2;
      return false;
    }
  }
}

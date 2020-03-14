using Verse;

namespace CuprosStones {

  public class Settings : ModSettings {

    internal static IntRange StoneTypesAvailable = new IntRange(4, 5);

    internal static bool SpawnLimestone = true;
    internal static bool SpawnSandstone = true;
    internal static bool SpawnClaystone = true;
    internal static bool SpawnAndesite = true;
    internal static bool SpawnSyenite = true;

    internal static bool SpawnGneiss = true;
    internal static bool SpawnMarble = true;
    internal static bool SpawnQuartzite = true;
    internal static bool SpawnSlate = true;
    internal static bool SpawnSchist = true;

    internal static bool SpawnGabbro = true;
    internal static bool SpawnGranite = true;
    internal static bool SpawnDiorite = true;
    internal static bool SpawnDunite = true;
    internal static bool SpawnPegmatite = true;


		public override void ExposeData() {
      base.ExposeData();
      Scribe_Values.Look(ref StoneTypesAvailable, "StoneTypesAvailable", new IntRange(4, 5));
      Scribe_Values.Look(ref SpawnLimestone, "SpawnLimestone", true);
      Scribe_Values.Look(ref SpawnSandstone, "SpawnSandstone", true);
      Scribe_Values.Look(ref SpawnClaystone, "SpawnClaystone", true);
      Scribe_Values.Look(ref SpawnAndesite, "SpawnAndesite", true);
      Scribe_Values.Look(ref SpawnSyenite, "SpawnSyenite", true);
      Scribe_Values.Look(ref SpawnGneiss, "SpawnGneiss", true);
      Scribe_Values.Look(ref SpawnMarble, "SpawnMarble", true);
      Scribe_Values.Look(ref SpawnQuartzite, "SpawnQuartzite", true);
      Scribe_Values.Look(ref SpawnSlate, "SpawnSlate", true);
      Scribe_Values.Look(ref SpawnSchist, "SpawnSchist", true);
      Scribe_Values.Look(ref SpawnGabbro, "SpawnGabbro", true);
      Scribe_Values.Look(ref SpawnGranite, "SpawnGranite", true);
      Scribe_Values.Look(ref SpawnDiorite, "SpawnDiorite", true);
      Scribe_Values.Look(ref SpawnDunite, "SpawnDunite", true);
      Scribe_Values.Look(ref SpawnPegmatite, "SpawnPegmatite", true);
		}


    public static bool StoneAllowedOrUndefined(ThingDef stone) {
      if (stone == StoneDefOf.Limestone) {
        return SpawnLimestone;
      }
      if (stone == StoneDefOf.Sandstone) {
        return SpawnSandstone;
      }
      if (stone == StoneDefOf.Claystone) {
        return SpawnClaystone;
      }
      if (stone == StoneDefOf.Andesite) {
        return SpawnAndesite;
      }
      if (stone == StoneDefOf.Syenite) {
        return SpawnSyenite;
      }
      if (stone == StoneDefOf.Gneiss) {
        return SpawnGneiss;
      }
      if (stone == StoneDefOf.Marble) {
        return SpawnMarble;
      }
      if (stone == StoneDefOf.Quartzite) {
        return SpawnQuartzite;
      }
      if (stone == StoneDefOf.Slate) {
        return SpawnSlate;
      }
      if (stone == StoneDefOf.Schist) {
        return SpawnSchist;
      }
      if (stone == StoneDefOf.Gabbro) {
        return SpawnGabbro;
      }
      if (stone == StoneDefOf.Granite) {
        return SpawnGranite;
      }
      if (stone == StoneDefOf.Diorite) {
        return SpawnDiorite;
      }
      if (stone == StoneDefOf.Dunite) {
        return SpawnDunite;
      }
      if (stone == StoneDefOf.Pegmatite) {
        return SpawnPegmatite;
      }
      return true;
    }
  }
}

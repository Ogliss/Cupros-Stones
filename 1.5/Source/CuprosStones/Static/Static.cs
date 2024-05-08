using UnityEngine;
using Verse;

namespace CuprosStones {
	[StaticConstructorOnStartup]
  public static class Static {

		public static string LabelModName = "STN_LabelModName".Translate();
		public static string LabelStoneTypesAvailable = "STN_LabelStoneTypesAvailable".Translate();
		public static string LabelStoneTypesToSpawn = "STN_StoneTypesToSpawn".Translate();

		public static ThingDef ChunkLimestone = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkLimestone") ?? null;
		public static ThingDef Limestone = DefDatabase<ThingDef>.GetNamedSilentFail("Limestone") ?? null;
		public static ThingDef ChunkSandstone = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkSandstone") ?? null;
		public static ThingDef Sandstone = DefDatabase<ThingDef>.GetNamedSilentFail("Sandstone") ?? null;
		public static ThingDef ChunkClaystone = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkClaystone") ?? null;
		public static ThingDef Claystone = DefDatabase<ThingDef>.GetNamedSilentFail("Claystone") ?? null;
		public static ThingDef ChunkAndesite = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkAndesite") ?? null;
		public static ThingDef Andesite = DefDatabase<ThingDef>.GetNamedSilentFail("Andesite") ?? null;
		public static ThingDef ChunkSyenite = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkSyenite") ?? null;
		public static ThingDef Syenite = DefDatabase<ThingDef>.GetNamedSilentFail("Syenite") ?? null;
		public static ThingDef ChunkGneiss = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkGneiss") ?? null;
		public static ThingDef Gneiss = DefDatabase<ThingDef>.GetNamedSilentFail("Gneiss") ?? null;
		public static ThingDef ChunkMarble = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkMarble") ?? null;
		public static ThingDef Marble = DefDatabase<ThingDef>.GetNamedSilentFail("Marble") ?? null;
		public static ThingDef ChunkQuartzite = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkQuartzite") ?? null;
		public static ThingDef Quartzite = DefDatabase<ThingDef>.GetNamedSilentFail("Quartzite") ?? null;
		public static ThingDef ChunkSlate = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkSlate") ?? null;
		public static ThingDef Slate = DefDatabase<ThingDef>.GetNamedSilentFail("Slate") ?? null;
		public static ThingDef ChunkSchist = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkSchist") ?? null;
		public static ThingDef Schist = DefDatabase<ThingDef>.GetNamedSilentFail("Schist") ?? null;
		public static ThingDef ChunkGabbro = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkGabbro") ?? null;
		public static ThingDef Gabbro = DefDatabase<ThingDef>.GetNamedSilentFail("Gabbro") ?? null;
		public static ThingDef ChunkGranite = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkGranite") ?? null;
		public static ThingDef Granite = DefDatabase<ThingDef>.GetNamedSilentFail("Granite") ?? null;
		public static ThingDef ChunkDiorite = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkDiorite") ?? null;
		public static ThingDef Diorite = DefDatabase<ThingDef>.GetNamedSilentFail("Diorite") ?? null;
		public static ThingDef ChunkDunite = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkDunite") ?? null;
		public static ThingDef Dunite = DefDatabase<ThingDef>.GetNamedSilentFail("Dunite") ?? null;
		public static ThingDef ChunkPegmatite = DefDatabase<ThingDef>.GetNamedSilentFail("ChunkPegmatite") ?? null;
		public static ThingDef Pegmatite = DefDatabase<ThingDef>.GetNamedSilentFail("Pegmatite") ?? null;
		public static Color WarningColor = new Color(1f, 0.4f, 0.4f);
	}
}

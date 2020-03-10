using UnityEngine;
using Verse;

namespace CuprosStones {
	[StaticConstructorOnStartup]
  public static class Static {

    public static string LabelModName = "STN_LabelModName".Translate();
    public static string LabelStoneTypesAvailable = "STN_LabelStoneTypesAvailable".Translate();
		public static string LabelStoneTypesToSpawn = "STN_StoneTypesToSpawn".Translate();

		public static Color WarningColor = new Color(1f, 0.4f, 0.4f);
	}
}

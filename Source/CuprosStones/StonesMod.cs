using UnityEngine;
using Verse;

namespace CuprosStones {

  public sealed class StonesMod : Mod {

    public StonesMod(ModContentPack content) : base(content) {
      Harmony.HarmonyInstance.Create("CuprosStonesOverride").PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
      GetSettings<Settings>();
    }


    public override string SettingsCategory() {
      return Static.LabelModName;
    }


    public override void DoSettingsWindowContents(Rect rect) {
      Listing_Standard list = new Listing_Standard();

      list.ColumnWidth = rect.width;
      list.Begin(rect);
      list.Gap(10);
      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().Rounded();
        Rect rightRect = fullRect.RightHalf().Rounded();

        GenUI.SetLabelAlign(TextAnchor.MiddleRight);
        Widgets.Label(leftRect, Static.LabelStoneTypesAvailable);
        GenUI.ResetLabelAlign();

        Widgets.IntRange(rightRect, 316192000, ref Settings.StoneTypesAvailable, 1, 8);

        list.End();
      }
    }
  }
}

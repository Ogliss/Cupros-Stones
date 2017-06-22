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
      }

      list.Gap(25);
      {
        Rect labelRect = list.GetRect(Text.LineHeight).LeftHalf().Rounded();
        Rect labelCenteredRect = new Rect(labelRect.x + 90f, labelRect.y, 350f, 35f);
        Text.Font = GameFont.Medium;
        GenUI.SetLabelAlign(TextAnchor.MiddleCenter);
        Widgets.Label(labelCenteredRect, Static.LabelStoneTypesToSpawn);
        GenUI.ResetLabelAlign();
        Text.Font = GameFont.Small;
      }

      list.Gap(10);
      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect rightRect = fullRect.LeftHalf().RightHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();
        Rect rightIconRect = fullRect.LeftHalf().RightHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkLimestone);
        Widgets.ThingIcon(rightIconRect, StoneDefOf.ChunkSandstone);

        Widgets.CheckboxLabeled(leftRect, Static.Limestone, ref Settings.SpawnLimestone);
        Widgets.CheckboxLabeled(rightRect, Static.Sandstone, ref Settings.SpawnSandstone);
        Widgets.DrawHighlightIfMouseover(leftRect);
        Widgets.DrawHighlightIfMouseover(rightRect);

      }
      list.Gap(10);

      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect rightRect = fullRect.LeftHalf().RightHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();
        Rect rightIconRect = fullRect.LeftHalf().RightHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkClaystone);
        Widgets.ThingIcon(rightIconRect, StoneDefOf.ChunkAndesite);

        Widgets.CheckboxLabeled(leftRect, Static.Claystone, ref Settings.SpawnClaystone);
        Widgets.CheckboxLabeled(rightRect, Static.Andesite, ref Settings.SpawnAndesite);
        Widgets.DrawHighlightIfMouseover(leftRect);
        Widgets.DrawHighlightIfMouseover(rightRect);
      }
      list.Gap(10);

      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect rightRect = fullRect.LeftHalf().RightHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();
        Rect rightIconRect = fullRect.LeftHalf().RightHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkRhyolite);
        Widgets.ThingIcon(rightIconRect, StoneDefOf.ChunkGneiss);

        Widgets.CheckboxLabeled(leftRect, Static.Rhyolite, ref Settings.SpawnRhyolite);
        Widgets.CheckboxLabeled(rightRect, Static.Gneiss, ref Settings.SpawnGneiss);
        Widgets.DrawHighlightIfMouseover(leftRect);
        Widgets.DrawHighlightIfMouseover(rightRect);
      }
      list.Gap(10);

      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect rightRect = fullRect.LeftHalf().RightHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();
        Rect rightIconRect = fullRect.LeftHalf().RightHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkMarble);
        Widgets.ThingIcon(rightIconRect, StoneDefOf.ChunkQuartzite);

        Widgets.CheckboxLabeled(leftRect, Static.Marble, ref Settings.SpawnMarble);
        Widgets.CheckboxLabeled(rightRect, Static.Quartzite, ref Settings.SpawnQuartzite);
        Widgets.DrawHighlightIfMouseover(leftRect);
        Widgets.DrawHighlightIfMouseover(rightRect);
      }
      list.Gap(10);

      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect rightRect = fullRect.LeftHalf().RightHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();
        Rect rightIconRect = fullRect.LeftHalf().RightHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkSlate);
        Widgets.ThingIcon(rightIconRect, StoneDefOf.ChunkSchist);

        Widgets.CheckboxLabeled(leftRect, Static.Slate, ref Settings.SpawnSlate);
        Widgets.CheckboxLabeled(rightRect, Static.Schist, ref Settings.SpawnSchist);
        Widgets.DrawHighlightIfMouseover(leftRect);
        Widgets.DrawHighlightIfMouseover(rightRect);
      }
      list.Gap(10);

      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect rightRect = fullRect.LeftHalf().RightHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();
        Rect rightIconRect = fullRect.LeftHalf().RightHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkGabbro);
        Widgets.ThingIcon(rightIconRect, StoneDefOf.ChunkGranite);

        Widgets.CheckboxLabeled(leftRect, Static.Gabbro, ref Settings.SpawnGabbro);
        Widgets.CheckboxLabeled(rightRect, Static.Granite, ref Settings.SpawnGranite);
        Widgets.DrawHighlightIfMouseover(leftRect);
        Widgets.DrawHighlightIfMouseover(rightRect);
      }
      list.Gap(10);

      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect rightRect = fullRect.LeftHalf().RightHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();
        Rect rightIconRect = fullRect.LeftHalf().RightHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkDiorite);
        Widgets.ThingIcon(rightIconRect, StoneDefOf.ChunkDunite);

        Widgets.CheckboxLabeled(leftRect, Static.Diorite, ref Settings.SpawnDiorite);
        Widgets.CheckboxLabeled(rightRect, Static.Dunite, ref Settings.SpawnDunite);
        Widgets.DrawHighlightIfMouseover(leftRect);
        Widgets.DrawHighlightIfMouseover(rightRect);
      }
      list.Gap(10);

      {
        Rect fullRect = list.GetRect(Text.LineHeight);
        Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(100).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(32).Rounded();

        Widgets.ThingIcon(leftIconRect, StoneDefOf.ChunkPegmatite);

        Widgets.CheckboxLabeled(leftRect, Static.Pegmatite, ref Settings.SpawnPegmatite);
        Widgets.DrawHighlightIfMouseover(leftRect);
      }

      GenUI.ResetLabelAlign();
      list.End();
    }
  }
}

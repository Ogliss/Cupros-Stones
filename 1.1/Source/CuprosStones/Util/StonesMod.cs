using System;
using System.Linq;
using System.Reflection;

using HarmonyLib;
using UnityEngine;
using Verse;

namespace CuprosStones {

  public sealed class StonesMod : Mod {


		public StonesMod(ModContentPack content) : base(content) {
      new Harmony("CuprosStonesOverride").PatchAll(Assembly.GetExecutingAssembly());
      GetSettings<Settings>();
		}


    public override string SettingsCategory() {
      return Static.LabelModName;
    }


    public override void DoSettingsWindowContents(Rect rect) {
			Listing_Standard list = new Listing_Standard() {
				ColumnWidth = rect.width
			};
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
				Rect fullRect = list.GetRect(30f);
        Rect leftLabelRect = fullRect.LeftHalf().Rounded();
				Rect rightLabelRect = fullRect.RightHalf().Rounded();

        Text.Font = GameFont.Medium;
				Text.Anchor = TextAnchor.MiddleCenter;

        Widgets.Label(leftLabelRect, Static.LabelStoneTypesToSpawn);
				
				Text.Anchor = TextAnchor.UpperLeft;
				Text.Font = GameFont.Small;
			}

			list.Gap(10);
      {
				Rect fullRect = list.GetRect(30f);
				Rect rightLabelRect = fullRect.RightHalf().Rounded();

				DualCheckboxesWithIcons_ThingDef(
					fullRect.LeftHalf(),
					Static.ChunkLimestone, Static.ChunkSandstone,
					Static.Limestone?.LabelCap, Static.Sandstone?.LabelCap,
					ref Settings.SpawnLimestone, ref Settings.SpawnSandstone
				);
			}
      list.Gap(10);

			{
				Rect fullRect = list.GetRect(30f);
				DualCheckboxesWithIcons_ThingDef(
					fullRect.LeftHalf(),
					Static.ChunkClaystone, Static.ChunkAndesite,
					Static.Claystone?.LabelCap, Static.Andesite?.LabelCap,
					ref Settings.SpawnClaystone, ref Settings.SpawnAndesite
				);
			}
      list.Gap(10);

			{
				Rect fullRect = list.GetRect(30f);
				DualCheckboxesWithIcons_ThingDef(
					fullRect.LeftHalf(),
					Static.ChunkSyenite, Static.ChunkGneiss,
					Static.Syenite?.LabelCap, Static.Gneiss?.LabelCap,
					ref Settings.SpawnSyenite, ref Settings.SpawnGneiss
				);
			}
      list.Gap(10);

			{
				Rect fullRect = list.GetRect(30f);
				DualCheckboxesWithIcons_ThingDef(
					fullRect.LeftHalf(),
					Static.ChunkMarble, Static.ChunkQuartzite,
					Static.Marble?.LabelCap, Static.Quartzite?.LabelCap,
					ref Settings.SpawnMarble, ref Settings.SpawnQuartzite
				);
			}
      list.Gap(10);

			{
				Rect fullRect = list.GetRect(30f);
				DualCheckboxesWithIcons_ThingDef(
					fullRect.LeftHalf(),
					Static.ChunkSlate, Static.ChunkSchist,
					Static.Slate?.LabelCap, Static.Schist?.LabelCap,
					ref Settings.SpawnSlate, ref Settings.SpawnSchist
				);
			}
      list.Gap(10);

			{
				Rect fullRect = list.GetRect(30f);
				DualCheckboxesWithIcons_ThingDef(
					fullRect.LeftHalf(),
					Static.ChunkGabbro, Static.ChunkGranite,
					Static.Gabbro?.LabelCap, Static.Granite?.LabelCap,
					ref Settings.SpawnGabbro, ref Settings.SpawnGranite
				);
      }
      list.Gap(10);

			{
				Rect fullRect = list.GetRect(30f);
				DualCheckboxesWithIcons_ThingDef(
					fullRect.LeftHalf(),
					Static.ChunkDiorite, Static.ChunkDunite,
					Static.Diorite?.LabelCap, Static.Dunite?.LabelCap,
					ref Settings.SpawnDiorite, ref Settings.SpawnDunite
				);
      }
      list.Gap(10);

			{
				Rect fullRect = list.GetRect(30f);
				Rect leftRect = fullRect.LeftHalf().LeftHalf().RightPartPixels(150).Rounded();
        Rect leftIconRect = fullRect.LeftHalf().LeftHalf().LeftHalf().LeftHalf().RightPartPixels(30).Rounded();

        Widgets.ThingIcon(leftIconRect, Static.ChunkPegmatite);

        Widgets.CheckboxLabeled(leftRect, Static.Pegmatite?.LabelCap, ref Settings.SpawnPegmatite);
        Widgets.DrawHighlightIfMouseover(leftRect);
      }

      GenUI.ResetLabelAlign();
      list.End();
    }


		private static void DualCheckboxesWithIcons_ThingDef(Rect rect, ThingDef leftThingDef, ThingDef rightThingDef, string leftLabel, string rightLabel, ref bool leftBool, ref bool rightBool) {

            if (leftThingDef != null)
			{
				Rect leftRect = rect.LeftHalf().RightPartPixels(150).Rounded();
				Rect leftIconRect = rect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(30).Rounded();
				Widgets.ThingIcon(leftIconRect, leftThingDef);
				Widgets.CheckboxLabeled(leftRect, leftLabel, ref leftBool);
				Widgets.DrawHighlightIfMouseover(leftRect);
			}
            if (rightThingDef != null)
			{
				Rect rightRect = rect.RightHalf().RightPartPixels(150).Rounded();
				Rect rightIconRect = rect.RightHalf().LeftHalf().LeftHalf().RightPartPixels(30).Rounded();
				Widgets.ThingIcon(rightIconRect, rightThingDef);
				Widgets.CheckboxLabeled(rightRect, rightLabel, ref rightBool);
				Widgets.DrawHighlightIfMouseover(rightRect);
			}
		}


		private static void DualCheckboxesWithIcons_Texture2D(Rect rect, Texture2D leftIcon, Texture2D rightIcon, string leftLabel, string rightLabel, ref bool leftBool, ref bool rightBool) {
			Rect leftRect = rect.LeftHalf().RightPartPixels(150).Rounded();
			Rect rightRect = rect.RightHalf().RightPartPixels(150).Rounded();
			Rect leftIconRect = rect.LeftHalf().LeftHalf().LeftHalf().RightPartPixels(30).Rounded();
			Rect rightIconRect = rect.RightHalf().LeftHalf().LeftHalf().RightPartPixels(30).Rounded();

			GUI.DrawTexture(leftIconRect, leftIcon);
			GUI.DrawTexture(rightIconRect, rightIcon);

			Widgets.CheckboxLabeled(leftRect, leftLabel, ref leftBool);
			Widgets.CheckboxLabeled(rightRect, rightLabel, ref rightBool);
			Widgets.DrawHighlightIfMouseover(leftRect);
			Widgets.DrawHighlightIfMouseover(rightRect);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace CuprosStones
{

    public sealed class StonesMod : Mod
    {
        public static Settings settings;
        public static Harmony harmony = new Harmony("com.ogliss.rimworld.mod.CuprosStones");
        public StonesMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();

            var allPatches = content.Patches as List<PatchOperation>;
            foreach (var patch in Patches)
            {
                if (settings.PatchDisabled[patch] == false)
                {
                //    if (Prefs.DevMode) Log.Message("RemoveAll XML Patch: " + patch.label);
                    allPatches.RemoveAll(p => p.sourceFile.EndsWith(patch.file));
                }
                else
                {
                //    if (Prefs.DevMode) Log.Message("Running XML Patch: " + patch.label);
                }
            }
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }


        public override string SettingsCategory()
        {
            return Static.LabelModName;
        }


        public override void DoSettingsWindowContents(Rect rect)
        {
            Listing_Standard list = new Listing_Standard()
            {
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
                PatchDescription GraphicsPatch = patches.Find(x => x.file == "Patches_Core_Stone_CustomGraphics.xml");
                var status = settings.PatchDisabled[GraphicsPatch];
                Widgets.CheckboxLabeled(rightLabelRect, "Enable Cupro'ss Stone Textures", ref status);
                settings.PatchDisabled[GraphicsPatch] = status;

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

        public static void CheckboxLabeled(Rect rect, string label, ref bool checkOn, string tooltip = null, bool disabled = false, Texture2D texChechked = null, Texture2D texUnchechked = null, bool placeCheckboxNearText = false)
        {
            if (!tooltip.NullOrEmpty())
            {
                if (Mouse.IsOver(rect))
                {
                    Widgets.DrawHighlight(rect);
                }
                TooltipHandler.TipRegion(rect, tooltip);
            }
            Widgets.CheckboxLabeled(rect, label, ref checkOn, disabled, texChechked, texUnchechked, placeCheckboxNearText);
            // base.Gap(this.verticalSpacing);
        }

        private static void DualCheckboxesWithIcons_ThingDef(Rect rect, ThingDef leftThingDef, ThingDef rightThingDef, string leftLabel, string rightLabel, ref bool leftBool, ref bool rightBool)
        {

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


        private static void DualCheckboxesWithIcons_Texture2D(Rect rect, Texture2D leftIcon, Texture2D rightIcon, string leftLabel, string rightLabel, ref bool leftBool, ref bool rightBool)
        {
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

        private static List<PatchDescription> patches;
        public static List<PatchDescription> Patches
        {
            get
            {
                if (patches.NullOrEmpty())
                {
                    patches = new List<PatchDescription>();
                    patches.Add(new PatchDescription("Patches_Core_Stone_CustomGraphics.xml", "Enable Custom Stone graphics", "Enables Cupros stone graphics, if this is disabled, all stone will use vanilla graphics"));
                    if (true)
                    {

                    }
                }
                return patches;
            }
        }

    }
    public struct PatchDescription
    {
        public string file;
        public string label;
        public string tooltip;

        public PatchDescription(string file, string label, string tooltip = null)
        {
            this.file = file;
            this.label = label;
            this.tooltip = tooltip;
        }
    }
}

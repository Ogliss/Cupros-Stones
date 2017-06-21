using System;
using System.Collections.Generic;
using System.Linq;

using Harmony;
using Verse;
using Verse.Noise;

namespace CuprosStones {
  [HarmonyPatch(typeof(RockNoises))]
  [HarmonyPatch("Init")]
  [HarmonyPatch(new Type[] { typeof(Map) })]
  public class RockNoises_Init {


    static void Prefix( Map map) {
      // Adjust the frequency a bit to match the increased stones spawning in the map
      double multiplier = 0.5d * Find.World.NaturalRockTypesIn(map.Tile).ToList().Count;
      // Adjust the octaves to either be more blob-like or scattered -- base value is 6
      int octaves = Rand.RangeInclusive(3, 8);

      RockNoises.rockNoises = new List<RockNoises.RockNoise>();
      foreach (ThingDef current in Find.World.NaturalRockTypesIn(map.Tile)) {
        RockNoises.RockNoise rockNoise = new RockNoises.RockNoise();
        rockNoise.rockDef = current;
        rockNoise.noise = new Perlin((multiplier * 0.004999999888241291), 2.0, 0.5, octaves, Rand.Range(0, 2147483647), QualityMode.Medium);
        RockNoises.rockNoises.Add(rockNoise);
        NoiseDebugUI.StoreNoiseRender(rockNoise.noise, rockNoise.rockDef + " score", map.Size.ToIntVec2);
      }
    }
  }
}

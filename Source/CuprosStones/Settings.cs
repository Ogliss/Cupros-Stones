using Verse;

namespace CuprosStones {

  public class Settings : ModSettings {

    public static IntRange StoneTypesAvailable = new IntRange(2, 3);


    public override void ExposeData() {
      base.ExposeData();
      Scribe_Values.Look(ref StoneTypesAvailable, "StoneTypesAvailable", new IntRange(2, 3));
    }
  }
}

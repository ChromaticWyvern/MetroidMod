using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MetroidMod.Content.Tiles.ItemTile.Beam.Hunters
{
	public class BattleHammerTile : ItemTile
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("BattleHammer");
			AddMapEntry(new Color(255, 126, 255), name);
			DustType = 1;
		}
	}
}

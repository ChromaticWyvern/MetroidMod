using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MetroidMod.Content.Tiles.ItemTile.Beam.Hunters
{
	public class MagMaulTile : ItemTile
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("MagMaul");
			AddMapEntry(new Color(255, 126, 255), name);
			DustType = 1;
		}
	}
}

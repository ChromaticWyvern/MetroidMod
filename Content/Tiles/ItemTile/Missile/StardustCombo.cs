﻿using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MetroidMod.Content.Tiles.ItemTile.Missile
{
	public class StardustCombo : MissileAbst
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Stardust Blizzard");
			AddMapEntry(new Color(54, 71, 122), name);
			DustType = 1;
		}
	}
}

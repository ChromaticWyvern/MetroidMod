﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MetroidMod.Content.Tiles
{
	public class ChozoPillar : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.IsBeam[Type] = true;
			TileID.Sets.DrawsWalls[Type] = true;
			Main.tileDungeon[Type] = true;

			DustType = 87;
			MinPick = 65;
			HitSound = SoundID.Tink;

			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Chozite Pillar");
			AddMapEntry(new Color(200, 160, 72), name);
		}
	}
}

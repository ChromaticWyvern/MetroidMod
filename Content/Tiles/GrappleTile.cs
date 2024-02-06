﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Tiles
{
	public class GrappleTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileDungeon[Type] = true;

			DustType = 87;
			MinPick = 65;
			HitSound = SoundID.Tink;

			AddMapEntry(new Color(187, 187, 206));
		}
	}
}

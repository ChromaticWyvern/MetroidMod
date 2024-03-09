﻿using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MetroidMod.Content.Tiles.ItemTile.Missile
{
	public class DiffusionMissile : MissileAbst
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Diffusion Missile");
			AddMapEntry(new Color(255, 0, 90), name);
			DustType = 1;
		}
	}
}

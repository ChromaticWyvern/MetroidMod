﻿using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MetroidMod.Content.Tiles.ItemTile.Missile
{
	public class PlasmaMachinegun : MissileAbst
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Plasma Machinegun");
			AddMapEntry(new Color(15, 192, 39), name);
			DustType = 1;
		}
	}
}

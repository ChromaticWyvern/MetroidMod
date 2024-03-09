using MetroidMod.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Vanity.Legacy
{
	[AutoloadEquip(EquipType.Body)]
	public class LegacyLightSuitBreastplate : LegacyDarkSuitBreastplate
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Light Suit Breastplate");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<LegacyLightSuitHelmet>() && body.type == ModContent.ItemType<LegacyLightSuitBreastplate>() && legs.type == ModContent.ItemType<LegacyLightSuitGreaves>();
		}
		public override void UpdateVanitySet(Player P)
		{
			base.UpdateVanitySet(P);
			MPlayer mp = P.GetModPlayer<MPlayer>();
			mp.thrusters = false;
			mp.visorGlowColor = new Color(255, 248, 224);
		}
	}
	[AutoloadEquip(EquipType.Legs)]
	public class LegacyLightSuitGreaves : LegacyDarkSuitGreaves
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Light Suit Greaves");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
	}
	[AutoloadEquip(EquipType.Head)]
	public class LegacyLightSuitHelmet : LegacyDarkSuitHelmet
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Light Suit Helmet");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
	}
}

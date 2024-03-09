using MetroidMod.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Vanity.Legacy
{
	[AutoloadEquip(EquipType.Body)]
	public class LegacyTerraGravitySuitBreastplate : LegacyGravitySuitBreastplate
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Terra Gravity Suit Breastplate");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<LegacyTerraGravitySuitHelmet>() && body.type == ModContent.ItemType<LegacyTerraGravitySuitBreastplate>() && legs.type == ModContent.ItemType<LegacyTerraGravitySuitGreaves>();
		}
		public override void UpdateVanitySet(Player P)
		{
			base.UpdateVanitySet(P);
			P.GetModPlayer<MPlayer>().visorGlowColor = new Color(138, 255, 252);
		}
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}
	}
	[AutoloadEquip(EquipType.Legs)]
	public class LegacyTerraGravitySuitGreaves : LegacyGravitySuitGreaves
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Terra Gravity Suit Greaves");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
	}
	[AutoloadEquip(EquipType.Head)]
	public class LegacyTerraGravitySuitHelmet : LegacyGravitySuitHelmet
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Terra Gravity Suit Helmet");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
	}
}

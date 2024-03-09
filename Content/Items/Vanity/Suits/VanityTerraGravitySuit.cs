using MetroidMod.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Vanity.Suits
{
	[AutoloadEquip(EquipType.Body)]
	public class VanityTerraGravitySuitBreastplate : VanityGravitySuitBreastplate
	{
		public override string Texture => $"{nameof(MetroidMod)}/Assets/Textures/SuitAddons/TerraGravitySuit/TerraGravitySuitBreastplate";
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Outdated Terra Gravity Suit Breastplate");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<VanityTerraGravitySuitHelmet>() && body.type == ModContent.ItemType<VanityTerraGravitySuitBreastplate>() && legs.type == ModContent.ItemType<VanityTerraGravitySuitGreaves>();
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
	public class VanityTerraGravitySuitGreaves : VanityGravitySuitGreaves
	{
		public override string Texture => $"{nameof(MetroidMod)}/Assets/Textures/SuitAddons/TerraGravitySuit/TerraGravitySuitGreaves";
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Outdated Terra Gravity Suit Greaves");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
	}
	[AutoloadEquip(EquipType.Head)]
	public class VanityTerraGravitySuitHelmet : VanityGravitySuitHelmet
	{
		public override string Texture => $"{nameof(MetroidMod)}/Assets/Textures/SuitAddons/TerraGravitySuit/TerraGravitySuitHelmet";
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Outdated Terra Gravity Suit Helmet");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.rare = ItemRarityID.Lime;
		}
	}
}

﻿using Terraria;
using Terraria.ID;
using MetroidModPorted.Common.Players;

namespace MetroidModPorted.Content.Suits
{
	public class GravitySuitAddon : ModSuitAddon
	{
		public override string ItemTexture => $"{Mod.Name}/Assets/Textures/SuitAddons/GravitySuit/GravitySuitItem";

		public override string TileTexture => $"{Mod.Name}/Assets/Textures/SuitAddons/GravitySuit/GravitySuitTile";

		public override string ArmorTextureHead => $"{Mod.Name}/Assets/Textures/SuitAddons/GravitySuit/GravitySuitHelmet_Head";

		public override string ArmorTextureTorso => $"{Mod.Name}/Assets/Textures/SuitAddons/GravitySuit/GravitySuitBreastplate_Body";

		public override string ArmorTextureLegs => $"{Mod.Name}/Assets/Textures/SuitAddons/GravitySuit/GravitySuitGreaves_Legs";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gravity Suit");
			Tooltip.SetDefault("+9 defense\n" +
				"+15 overheat capacity\n" +
				"5% decreased overheat use\n" +
				"5% decreased Missile Charge Combo cost\n" +
				"5% increased hunter damage\n" +
				"7% increased hunter critical strike chance\n" +
				"Infinite breath underwater\n" +
				"Immune to knockback");
			AddonSlot = SuitAddonSlotID.Suit_Utility;
		}
		public override void SetItemDefaults(Item item)
		{
			item.value = Terraria.Item.buyPrice(0, 7, 80, 0);
			item.rare = ItemRarityID.Pink;
		}
		public override void OnUpdateArmorSet(Player player)
		{
			player.statDefense += 9;
			player.nightVision = true;
			player.fireWalk = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.noKnockback = true;
			player.ignoreWater = true;
			player.lavaMax += 420; // blaze it
			MPlayer mp = player.GetModPlayer<MPlayer>();
			HunterDamagePlayer.ModPlayer(player).HunterDamageMult += 0.05f;
			HunterDamagePlayer.ModPlayer(player).HunterCrit += 3;
			mp.maxOverheat += 15;
			mp.overheatCost -= 0.05f;
			mp.missileCost -= 0.05f;
			mp.visorGlow = true;
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemID.HallowedBar, 54)
				.AddIngredient<Items.Miscellaneous.GravityGel>(54)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

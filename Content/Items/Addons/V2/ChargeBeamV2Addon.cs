using MetroidMod.Common.GlobalItems;
using MetroidMod.ID;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Addons.V2
{
	public class ChargeBeamV2Addon : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Charge Beam V2");
			/* Tooltip.SetDefault(string.Format("[c/FF9696:Power Beam Addon V2]\n") +
			"Slot Type: Charge\n" +
			"Adds Charge Effect\n" + 
			"~Charge by holding click\n" + 
			"~Charge shots deal x4 damage, but overheat x2.5 the normal use"); */

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 10;
			Item.height = 14;
			Item.maxStack = 1;
			Item.value = 2500;
			Item.rare = ItemRarityID.LightRed;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Content.Tiles.ItemTile.Beam.ChargeBeamV2Tile>();
			MGlobalItem mItem = Item.GetGlobalItem<MGlobalItem>();
			mItem.addonSlotType = 0;
			mItem.beamSlotType = BeamChangeSlotID.ChargeV2;
			mItem.addonChargeDmg = Common.Configs.MConfigItems.Instance.damageChargeBeamV2;
			mItem.addonChargeHeat = Common.Configs.MConfigItems.Instance.overheatChargeBeamV2;
		}

		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient<ChargeBeamAddon>()
				.AddIngredient(ItemID.SoulofSight, 10)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

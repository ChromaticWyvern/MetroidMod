using Terraria.ID;
using Terraria.ModLoader;
using MetroidModPorted.Common.GlobalItems;

namespace MetroidModPorted.Content.Items.Addons.V2
{
	public class ChargeBeamV2Addon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charge Beam V2");
			Tooltip.SetDefault(string.Format("[c/FF9696:Power Beam Addon V2]\n") +
			"Slot Type: Charge\n" +
			"Adds Charge Effect\n" + 
			"~Charge by holding click\n" + 
			"~Charge shots deal x4 damage, but overheat x2.5 the normal use");
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
			mItem.addonChargeDmg = 4;
			mItem.addonChargeHeat = 2.5f;
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

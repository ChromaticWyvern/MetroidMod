using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Tiles
{
	public class BlueSwitch : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Blue Switch");

			Item.ResearchUnlockCount = 5;
		}
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Content.Tiles.BlueSwitch>();
		}
	}
}

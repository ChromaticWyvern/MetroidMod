using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Boss
{
	public class GoldenTorizoBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Treasure Bag (Golden Torizo)");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");

			ItemID.Sets.BossBag[Type] = true;
			Item.ResearchUnlockCount = 3;
		}
		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.expert = true;
			Item.rare = -12;
		}

		public override bool CanRightClick() => true;

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Accessories.ScrewAttack>()));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Tiles.TorizoMusicBox>(), 6));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Miscellaneous.EnergyShard>(), 1, 60, 144));
		}
	}
}


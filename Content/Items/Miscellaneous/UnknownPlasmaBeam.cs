using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Miscellaneous
{
	public class UnknownPlasmaBeam : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Unknown Item");
			/* Tooltip.SetDefault(string.Format("[c/9696FF:Power Beam Addon]\n") +
				"Slot Type: Primary B\n" +
				string.Format("[c/BE7878:Error: Addon is damaged and requires repairing before it can be installed.]")); */

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.maxStack = 1;
			Item.width = 10;
			Item.height = 14;
			Item.value = 100;
			Item.rare = ItemRarityID.LightRed;
		}
	}
}

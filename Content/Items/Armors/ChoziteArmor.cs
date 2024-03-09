using MetroidMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MetroidMod.Content.Items.Armors
{
	[AutoloadEquip(EquipType.Body)]
	public class ChoziteBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chozite Breastplate");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Blue;
			Item.value = 5000;
			Item.defense = Common.Configs.MConfigItems.Instance.defenseChoziteBreastplate;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) => head.type == ModContent.ItemType<ChoziteHelmet>() && body.type == ModContent.ItemType<ChoziteBreastplate>() && legs.type == ModContent.ItemType<ChoziteGreaves>();
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+2 defense" + "\n"
				+ "Allows somersaulting & wall jumping";
			player.statDefense += 2;
			if (Common.Configs.MConfigItems.Instance.enableWallJumpChoziteArmor)
			{
				player.GetModPlayer<MPlayer>().EnableWallJump = true;
			}
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient<Miscellaneous.ChoziteBar>(30)
				.AddTile(TileID.Anvils)
				.Register();
			/*ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChoziteBar", 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();*/
		}
	}
	[AutoloadEquip(EquipType.Legs)]
	public class ChoziteGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chozite Greaves");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Blue;
			Item.value = 3000;
			Item.defense = Common.Configs.MConfigItems.Instance.defenseChoziteGreaves;
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient<Miscellaneous.ChoziteBar>(25)
				.AddTile(TileID.Anvils)
				.Register();
			/*ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChoziteBar", 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();*/
		}
	}
	[AutoloadEquip(EquipType.Head)]
	public class ChoziteHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chozite Warmask");

			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Blue;
			Item.value = 3000;
			Item.defense = Common.Configs.MConfigItems.Instance.defenseChoziteHelmet;
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient<Miscellaneous.ChoziteBar>(20)
				.AddTile(TileID.Anvils)
				.Register();
			/*ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChoziteBar", 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();*/
		}
	}
}

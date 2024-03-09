using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MetroidMod.Default
{
	[Autoload(false)]
	[CloneByReference]
	internal class MBSpecialExplosion : ModProjectile
	{
		[CloneByReference]
		public ModMBSpecial modMBAddon;
		public MBSpecialExplosion(ModMBSpecial modMBAddon)
		{
			this.modMBAddon = modMBAddon;
		}

		protected override bool CloneNewInstances => true;

		public override string Texture => modMBAddon.ExplosionTexture;
		public override string Name => $"{modMBAddon.Name}Explosion";
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault(modMBAddon.DisplayName.GetDefault());
		}
		public override void SetDefaults()
		{
			modMBAddon.ExplosionProjectile = Projectile;
			modMBAddon.ExplosionProjectileType = Type;
			Projectile.width = 1000;
			Projectile.height = 750;
			Projectile.scale = 0.02f;
			Projectile.localNPCHitCooldown = 1;
			Projectile.timeLeft = 200;
			Projectile.penetrate = -1;
			modMBAddon.SetExplosionProjectileDefaults(Projectile);
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.usesLocalNPCImmunity = true;
		}
		public override void AI()
		{
			modMBAddon.ExplosionAI();
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.defense < 1000) { modifiers.FinalDamage += target.defense / 2; }
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			modMBAddon.OnHitNPC(target, damageDone, 1f, true);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			return modMBAddon.ExplosionPreDraw(ref lightColor);
		}

		public override ModProjectile Clone(Projectile newEntity)
		{
			MBSpecialExplosion inst = (MBSpecialExplosion)base.Clone(newEntity);
			inst.modMBAddon = modMBAddon;
			return inst;
		}

		public override ModProjectile NewInstance(Projectile entity)
		{
			MBSpecialExplosion inst = (MBSpecialExplosion)base.NewInstance(entity);
			inst.modMBAddon = modMBAddon;
			return inst;
		}
	}
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;

namespace MetroidMod.Content.Projectiles.VoltDriver
{
	public class VoltDriverChargeShot : MProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Volt Driver Charge Shot");
			Main.projFrames[Projectile.type] = 4;
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.scale = 1f;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 1;
			Projectile.penetrate = 1;
		}

		public override void AI()
		{
			if (shot.Contains("wave") || shot.Contains("nebula"))
			{
				Projectile.tileCollide = false;
				mProjectile.WaveBehavior(Projectile);
			}
			int shootSpeed = 2;
			Color color = MetroidMod.powColor;
			Lighting.AddLight(Projectile.Center, color.R / 255f, color.G / 255f, color.B / 255f);
			if (Projectile.numUpdates == 0)
			{
				Projectile.rotation += 0.5f * Projectile.direction;
				Projectile.frame++;
			}
			if (Projectile.frame > 3)
			{
				Projectile.frame = 0;
			}
			int dustType = 269;
			mProjectile.DustLine(Projectile.Center, Projectile.velocity, Projectile.rotation, 5, 3, dustType, 2f);
			mProjectile.HomingBehavior(Projectile, shootSpeed);
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 269, 0, 0, 100, default(Color), Projectile.scale);
			Main.dust[dust].noGravity = true;
		}

		public override void OnKill(int timeLeft)
		{
			//Projectile.position.X = Projectile.position.X + (Projectile.width / 2);
			//Projectile.position.Y = Projectile.position.Y + (Projectile.height / 2);
			Projectile.width += 32;
			Projectile.height += 32;
			Projectile.scale = 3f;
			//Projectile.position.X = Projectile.position.X - (Projectile.width / 2);
			//Projectile.position.Y = Projectile.position.Y - (Projectile.height / 2);
			//mProjectile.Diffuse(Projectile, 269);
			Projectile.Damage();
			foreach (NPC target in Main.npc)
			{
				if (Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, target.position, target.width, target.height))
				{
					Projectile.Damage();
					Projectile.usesLocalNPCImmunity = true;
					Projectile.localNPCHitCooldown = 1;
				}
			}
			mProjectile.DustyDeath(Projectile, 269);
			SoundEngine.PlaySound(Sounds.Items.Weapons.VoltDriverChargeImpactSound, Projectile.position);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			mProjectile.DrawCentered(Projectile, Main.spriteBatch);
			return false;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			SoundEngine.PlaySound(Sounds.Items.Weapons.VoltDriverDaze, Projectile.position);
			target.AddBuff(31, 180);
		}
	}
}

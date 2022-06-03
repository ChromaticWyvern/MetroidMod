﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MetroidModPorted.Content.DamageClasses
{
	public class HunterDamageClass : DamageClass
	{
		public override void SetStaticDefaults()
		{
			ClassName.SetDefault("hunter damage");
		}
		public override bool GetEffectInheritance(DamageClass damageClass)
		{
			if (damageClass == Generic)
			{
				return true;
			}
			return false;
		}
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			if (damageClass == Generic)
			{
				return StatInheritanceData.Full;
			}
			return new StatInheritanceData(
				damageInheritance: 0f,
				critChanceInheritance: 0f,
				attackSpeedInheritance: 0f,
				armorPenInheritance: 0f,
				knockbackInheritance: 0f
			);
		}
		/*protected override float GetBenefitFrom(DamageClass damageClass)
		{
			if (damageClass == Generic)
				return 1f;
			return 0;
		}*/
		/*public override void SetDefaultStats(Player player)
		{
			base.SetDefaultStats(player);
		}*/
		/*public override bool CountsAs(DamageClass damageClass)
		{
			return false;
		}*/
		public override bool UseStandardCritCalcs => base.UseStandardCritCalcs;
	}
}

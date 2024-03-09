﻿using System;
using MetroidMod.Common.Configs;
using MetroidMod.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace MetroidMod.Common.UI
{
	public class SenseMoveUI : UIState
	{
		public static bool Visible => Main.playerInventory && Main.LocalPlayer.GetModPlayer<MPlayer>().senseMove && Main.EquipPage == 0;

		SenseMovePanel senseMovePanel;

		public override void OnInitialize()
		{
			senseMovePanel = new SenseMovePanel();
			senseMovePanel.Initialize();

			this.Append(senseMovePanel);
		}
	}

	public class SenseMovePanel : DragableUIPanel
	{
		Texture2D buttonTex, buttonTex_Hover, buttonTex_Click,
		buttonTexEnabled, buttonTexEnabled_Hover, buttonTexEnabled_Click;

		public Rectangle DrawRectangle => new((int)(Parent.Left.Pixels + Left.Pixels), (int)(Parent.Top.Pixels + Top.Pixels), (int)Width.Pixels, (int)Height.Pixels);

		public override void OnInitialize()
		{
			buttonTex = ModContent.Request<Texture2D>($"{nameof(MetroidMod)}/Assets/Textures/Buttons/SenseMove_UIButton", AssetRequestMode.ImmediateLoad).Value;
			buttonTex_Hover = ModContent.Request<Texture2D>($"{nameof(MetroidMod)}/Assets/Textures/Buttons/SenseMove_UIButton_Hover", AssetRequestMode.ImmediateLoad).Value;
			buttonTex_Click = ModContent.Request<Texture2D>($"{nameof(MetroidMod)}/Assets/Textures/Buttons/SenseMove_UIButton_Click", AssetRequestMode.ImmediateLoad).Value;

			buttonTexEnabled = ModContent.Request<Texture2D>($"{nameof(MetroidMod)}/Assets/Textures/Buttons/SenseMoveEnabled_UIButton", AssetRequestMode.ImmediateLoad).Value;
			buttonTexEnabled_Hover = ModContent.Request<Texture2D>($"{nameof(MetroidMod)}/Assets/Textures/Buttons/SenseMoveEnabled_UIButton_Hover", AssetRequestMode.ImmediateLoad).Value;
			buttonTexEnabled_Click = ModContent.Request<Texture2D>($"{nameof(MetroidMod)}/Assets/Textures/Buttons/SenseMoveEnabled_UIButton_Click", AssetRequestMode.ImmediateLoad).Value;

			this.SetPadding(0);
			this.Width.Pixels = buttonTex.Width;
			this.Height.Pixels = buttonTex.Height;
			this.Left.Pixels = Main.screenWidth - Width.Pixels - (Main.netMode == NetmodeID.MultiplayerClient ? 240 : 200);
			this.Top.Pixels = 300;

			Width.Pixels = buttonTex.Width;
			Height.Pixels = buttonTex.Height;
			this.OnLeftClick += SMButtonClick;
		}

		public override void Update(GameTime gameTime)
		{
			enabled = MConfigClient.Instance.SenseMove.enabled;
			if (base.IsMouseHovering)
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (!enabled && MConfigClient.Instance.SenseMove.auto)
			{
				this.Left.Pixels = Main.screenWidth - Width.Pixels - (Main.netMode == NetmodeID.MultiplayerClient ? 240 : 200);
				this.Top.Pixels = 300;
				if (!Main.mapFullscreen && Main.mapStyle == 1)
				{
					this.Top.Pixels += Math.Min(256, Main.screenHeight - Main.instance.RecommendedEquipmentAreaPushUp);
				}
			}

			base.Update(gameTime);
		}

		bool clicked = false;
		private void SMButtonClick(UIMouseEvent evt, UIElement e)
		{
			MPlayer mp = Main.LocalPlayer.GetModPlayer<MPlayer>();

			mp.senseMoveEnabled = !mp.senseMoveEnabled;
			Terraria.Audio.SoundEngine.PlaySound(SoundID.MenuTick);
			clicked = true;
		}

		protected override void DrawSelf(SpriteBatch sb)
		{
			MPlayer mp = Main.LocalPlayer.GetModPlayer<MPlayer>();

			Texture2D tex = buttonTex, texH = buttonTex_Hover, texC = buttonTex_Click;
			if (mp.senseMoveEnabled)
			{
				tex = buttonTexEnabled;
				texH = buttonTexEnabled_Hover;
				texC = buttonTexEnabled_Click;
			}

			if (base.IsMouseHovering)
			{
				tex = texH;
				if (clicked)
				{
					tex = texC;
					clicked = false;
				}

				string smText = "Sense Move: Disabled";
				if (mp.senseMoveEnabled)
				{
					smText = "Sense Move: Enabled";
				}
				smText = smText + "\n" +
				"When enabled, double tap left or right to dodge\n" +
				"Gain 1/3 second of invulnerability while dodging\n" +
				"1 second cooldown\n" +
				"Only useable when grounded unless Space Jump is equipped";

				Main.hoverItemName = smText;
			}

			sb.Draw(tex, DrawRectangle, Color.White);
		}
	}
}

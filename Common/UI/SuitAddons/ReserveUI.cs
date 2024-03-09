﻿using System;
using MetroidMod.Common.Configs;
using MetroidMod.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace MetroidMod.Common.UI.SuitAddons
{
	public class ReserveUI : UIState
	{
		public static bool Visible => Main.playerInventory && Main.LocalPlayer.TryGetModPlayer(out MPlayer mp) && mp.ShouldShowArmorUI && mp.SuitAddonUIState == SuitAddonUIState.Reserves && Main.EquipPage == 0;

		public ReservePanel panel;

		public override void OnInitialize()
		{
			panel = new ReservePanel();
			panel.Initialize();

			Append(panel);
		}
	}

	public class ReservePanel : DragableUIPanel
	{
		private Asset<Texture2D> PanelTexture;

		private Asset<Texture2D> ModeTexture;

		private Asset<Texture2D>[] NumberTextures;

		public ReserveButton modeButton;

		public ReserveButton reserveAmt;

		private bool reserveHoldingLClick;

		private bool reserveHoldingRClick;

		public Rectangle DrawRectangle => new((int)Left.Pixels, (int)Top.Pixels, (int)Width.Pixels, (int)Height.Pixels);
		public Rectangle ModeAddRectangle => new((int)(DrawRectangle.Width * 28.0 / 168.0), (int)(DrawRectangle.Height * 16.0 / 86.0), (int)(DrawRectangle.Width * 110.0 / 168.0), (int)(DrawRectangle.Height * 10.0 / 86.0));

		public Rectangle GetNumRect(int i)
		{
			return i switch
			{
				0 => new((int)(DrawRectangle.Width * 16.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				1 => new((int)(DrawRectangle.Width * 32.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				2 => new((int)(DrawRectangle.Width * 48.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				3 => new((int)(DrawRectangle.Width * 64.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				4 => new((int)(DrawRectangle.Width * 88.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				5 => new((int)(DrawRectangle.Width * 104.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				6 => new((int)(DrawRectangle.Width * 120.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				7 => new((int)(DrawRectangle.Width * 136.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 14.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0)),
				_ => new(),
			};
		}

		public Rectangle NumButtonRect => new((int)(DrawRectangle.Width * 16.0 / 168.0), (int)(DrawRectangle.Height * 60.0 / 86.0), (int)(DrawRectangle.Width * 134.0 / 168.0), (int)(DrawRectangle.Height * 14.0 / 86.0));

		public override void OnInitialize()
		{
			PanelTexture = ModContent.Request<Texture2D>("MetroidMod/Assets/Textures/UI/ReserveUI", AssetRequestMode.ImmediateLoad);
			ModeTexture = ModContent.Request<Texture2D>("MetroidMod/Assets/Textures/UI/Reserve/MODE", AssetRequestMode.ImmediateLoad);
			NumberTextures = new Asset<Texture2D>[10];
			for (int i = 0; i < 10; i++)
			{
				NumberTextures[i] = ModContent.Request<Texture2D>($"MetroidMod/Assets/Textures/UI/Reserve/{i}", AssetRequestMode.ImmediateLoad);
			}

			SetPadding(0);
			Left.Pixels = Main.screenWidth - PanelTexture.Width() - (Main.netMode == NetmodeID.MultiplayerClient ? 290 : 250);
			Top.Pixels = 250;
			Width.Pixels = PanelTexture.Width();
			Height.Pixels = PanelTexture.Height();

			modeButton = new();
			modeButton.Left.Pixels = ModeAddRectangle.Left;
			modeButton.Top.Pixels = ModeAddRectangle.Top;
			modeButton.Width.Pixels = ModeAddRectangle.Width;
			modeButton.Height.Pixels = ModeAddRectangle.Height;
			modeButton.OnUpdate += delegate {
				if (modeButton.IsMouseHovering)
				{
					Main.LocalPlayer.mouseInterface = true;
				}
			};
			modeButton.OnLeftClick += delegate {
				Main.LocalPlayer.MetroidPlayer().SuitReservesAuto = !Main.LocalPlayer.MetroidPlayer().SuitReservesAuto;
			};
			Append(modeButton);
			reserveAmt = new();
			reserveAmt.Left.Pixels = NumButtonRect.Left;
			reserveAmt.Top.Pixels = NumButtonRect.Top;
			reserveAmt.Width.Pixels = NumButtonRect.Width;
			reserveAmt.Height.Pixels = NumButtonRect.Height;
			reserveAmt.OnUpdate += delegate {
				if (modeButton.IsMouseHovering)
				{
					Main.LocalPlayer.mouseInterface = true;
				}
			};
			reserveAmt.OnLeftMouseDown += delegate { reserveHoldingLClick = true; };
			reserveAmt.OnLeftMouseUp += delegate { reserveHoldingLClick = false; };
			reserveAmt.OnRightMouseDown += delegate { reserveHoldingRClick = true; };
			reserveAmt.OnRightMouseUp += delegate { reserveHoldingRClick = false; };
			Append(reserveAmt);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			enabled = MConfigClient.Instance.Reserves.enabled;
			if (IsMouseHovering)
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (!enabled && MConfigClient.Instance.Reserves.auto)
			{
				Left.Pixels = Main.screenWidth - Width.Pixels - (Main.netMode == NetmodeID.MultiplayerClient ? 290 : 250);
				Top.Pixels = 250;
				if (!Main.mapFullscreen && Main.mapStyle == 1)
				{
					Top.Pixels += Math.Min(256, Main.screenHeight - Main.instance.RecommendedEquipmentAreaPushUp);
				}
			}
			MPlayer mp = Main.LocalPlayer.GetModPlayer<MPlayer>();
			if (reserveHoldingLClick)
			{
				if (mp.SuitReserves < mp.SuitReserveTanks * MConfigItems.Instance.reserveTankStoreCount && mp.Energy >= 1)
				{
					mp.SuitReserves += 1;
					mp.Energy -= 1;
				}
			}
			if (reserveHoldingRClick)
			{
				if (!mp.SuitReservesAuto && mp.SuitReserves >= 1 && mp.Energy <= mp.MaxEnergy - 1)
				{
					mp.SuitReserves -= 1;
					mp.Energy += 1;
				}
			}
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			MPlayer mp = Main.LocalPlayer.GetModPlayer<MPlayer>();
			spriteBatch.Draw(PanelTexture.Value, DrawRectangle, Color.White);
			spriteBatch.Draw(ModeTexture.Value, new Rectangle(DrawRectangle.Left + ModeAddRectangle.Left, DrawRectangle.Top + ModeAddRectangle.Top, ModeAddRectangle.Width, ModeAddRectangle.Height), new(0, mp.SuitReservesAuto ? ModeTexture.Value.Height / 2 : 0, ModeTexture.Value.Width, ModeTexture.Value.Height / 2), Color.White);

			// number drawing
			int tanks = mp.SuitReserveTanks * MConfigItems.Instance.reserveTankStoreCount;
			int filled = mp.SuitReserves;
			// make leading zeros
			string e = $"{filled:D4}{tanks:D4}";
			for (int i = 0; i < e.Length; i++)
			{
				Rectangle rect = GetNumRect(i);
				spriteBatch.Draw(
					NumberTextures[int.Parse(e[i].ToString())].Value,
					new Rectangle(DrawRectangle.Left + rect.Left, DrawRectangle.Top + rect.Top, rect.Width, rect.Height),
					Color.White
					);
			}

			//modeButton.SetText($"Mode: {(mp.SuitReservesAuto ? "Auto" : "Manual")}");
			//reserveAmt.SetText($"{mp.SuitReserves}/{mp.SuitReserveTanks * MConfigItems.Instance.reserveTankStoreCount}");
			//spriteBatch.Draw(tex.Value, new Vector2(reserveBars.Left.Pixels + Left.Pixels, reserveBars.Top.Pixels + Top.Pixels), new((int)reserveBars.Left.Pixels + (int)Left.Pixels, (int)reserveBars.Top.Pixels + (int)Top.Pixels, (int)((float)tex.Width() * ((float)mp.SuitReserves / 400f)), tex.Height()), Color.White);
		}
	}
	public class ReserveButton : UIPanel
	{
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			// lol don't draw self
		}
	}
}

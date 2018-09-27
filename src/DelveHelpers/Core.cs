using System;
using SharpDX;
using SharpDX.Direct3D9;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using PoeHUD.Hud.Menu;
using PoeHUD.Hud.Settings;
using PoeHUD.Models.Enums;
using PoeHUD.Plugins;
using PoeHUD.Poe;
using PoeHUD.Models;
using PoeHUD.Poe.Components;
using PoeHUD.Poe.Elements;
using PoeHUD.Poe.EntityComponents;
using PoeHUD.Poe.RemoteMemoryObjects;

namespace DelveHelpers
{
	public class Core : BaseSettingsPlugin<Settings>
	{
		public Core()
		{
			PluginName = "DelveHelpers";
		}

		public override void Initialise()
		{
			//Called on start
		}

		private RectangleF DrawRect;
		//
		public override void Render()
		{
			DrawRect = new RectangleF(Settings.PosX, Settings.PosY, 70, 30);

			var playerStats = GameController.Player.GetComponent<Stats>().StatDictionary;

			var sc = playerStats[GameStat.DelveSulphiteCapacity];

			DrawData("Resources/Sulphite.png", GameController.Game.IngameState.ServerData.CurrentSulphiteAmount + "/" + sc);
			DrawData("Resources/Azurite.png", GameController.Game.IngameState.ServerData.CurrentAzuriteAmount.ToString());


			var buff = GameController.Player.GetComponent<Life>().Buffs.FirstOrDefault(x => x.Name == "delve_degen_buff");
			//if(buff != null)
			DrawData("Resources/Buff.png", buff == null ? "-" : buff.Charges.ToString());
		}

		private void DrawData(string icon, string data)
		{
			var textSize = Graphics.MeasureText(data, 20, FontDrawFlags.Left | FontDrawFlags.VerticalCenter);

			DrawRect.Width = DrawRect.Height + textSize.Width + 10;

			Graphics.DrawBox(DrawRect, Color.Black);

			var imgRect = DrawRect;
			imgRect.Width = imgRect.Height;
			Graphics.DrawPluginImage(Path.Combine(PluginDirectory, icon), imgRect);
			Graphics.DrawFrame(DrawRect, 2, Color.Gray);

			var textPos = DrawRect.TopLeft;
			textPos.Y += DrawRect.Height / 2;
			textPos.X += DrawRect.Height + 3;

			Graphics.DrawText(data, 20, textPos, FontDrawFlags.Left | FontDrawFlags.VerticalCenter);

		

			DrawRect.X += DrawRect.Width + 1;
		}
	}
}
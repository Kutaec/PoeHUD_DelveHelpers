using System.Windows.Forms;
using SharpDX;
using PoeHUD.Plugins;
using PoeHUD.Hud.Settings;

namespace DelveHelpers
{
	//All properties and public fields of this class will be saved to file
	public class Settings : SettingsBase
	{
		public Settings()
		{
			Enable = true;
		}

		[Menu("PosX")]
		public RangeNode<int> PosX { get; set; } = new RangeNode<int>(551, 0, 1500);

		[Menu("PosY")]
		public RangeNode<int> PosY { get; set; } = new RangeNode<int>(0, 0, 1500);

		[Menu("Width")]
		public RangeNode<int> Width { get; set; } = new RangeNode<int>(0, 0, 100);
	}
}

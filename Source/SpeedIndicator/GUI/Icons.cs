/*
	This file is part of Speed Unit Changer /L Unleashed
		© 2026 LisiasT
		© 2014-2019 Ittito (Eliseo Martin <lttito@gmail.com>)

	Speed Unit Changer /L licensed as follows:
		* GPL 3.0 : https://www.gnu.org/licenses/gpl-3.0.txt

	Speed Unit Changer /L Unleashedis distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 3.0
	along with Speed Unit Changer /L Unleashed.
	If not, see <https://www.gnu.org/licenses/>.
*/
using KSPe.Annotations;

using UnityEngine;
using H = KSPe.IO.Hierarchy<SpeedUnitChanger.Startup>;
using T = KSPe.Util.Image.Texture2D;

namespace SpeedUnitChanger.UI
{
	internal static class Icons
	{
		private const string ICONSDIR = "Icons";

		private static Texture2D _IconToolbar = null;
		internal static Texture2D IconToolbar => _IconToolbar ?? (_IconToolbar = T.LoadFromFile(H.GAMEDATA.Solve("PluginData", ICONSDIR, "iconToolbar")));
	}

	[KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
	internal class IconPreloader : MonoBehaviour
	{
		[UsedImplicitly]
		private void Start()
		{   // Preload the icons on Space Center to avoid halting the Editor at first entry.
			Log.dbg(H.GAMEDATA.Solve("PluginData", "Icons", "iconToolbar"));
			Icons.IconToolbar.GetInstanceID();
		}
	}
}

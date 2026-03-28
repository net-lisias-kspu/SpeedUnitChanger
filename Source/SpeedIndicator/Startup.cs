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
using System;
using UnityEngine;
using KSPe.Annotations;

namespace SpeedUnitChanger
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	internal class Startup:MonoBehaviour
	{
		[UsedImplicitly]
		private void Start()
		{
			Log.force("Version {0}", Version.Text);
			try
			{
				KSPe.Util.Installation.Check<Startup>(typeof(Version));
			}
			catch (KSPe.Util.InstallmentException e)
			{
				Log.error(e, this);
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
			}
		}
	}
}

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
using KSP.UI.Screens;

namespace SpeedUnitChangerToolbar
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class SpeedUnitChangerToolbar : MonoBehaviour
    {
        bool addedToGUI = false;
        ApplicationLauncherButton button;

        private void Start()
        {

            SpeedUnitChanger.SpeedUnitChanger.ToolBarEnabled = false;
            if (!addedToGUI)
            {
                OnGuiAppLauncherReady();
            }
        }

        private void OnGuiAppLauncherReady()
        {
            if (!HighLogic.CurrentGame.Parameters.CustomParams<SUC>().EnabledForSave)
                return;
            if (!this.addedToGUI)
            { 
                try
                {
                    this.button = ApplicationLauncher.Instance.AddModApplication(
                         () => SpeedUnitChanger.SpeedUnitChanger.ToolBarEnabled = true,
                         () => SpeedUnitChanger.SpeedUnitChanger.ToolBarEnabled = false,
                         null,
                         null,
                         null,
                         null,
                         ApplicationLauncher.AppScenes.FLIGHT,
                         GameDatabase.Instance.GetTexture("SpeedUnitChanger/Textures/iconToolbar", false)
                         );
                    this.addedToGUI = true;
                }
                catch (Exception ex)
                {
                    SpeedUnitChanger.SpeedUnitChanger.DebugMessage(ex.Message + "IN Catch BuildToolbar->OnGuiAppLauncherReady");
                }
            }
        }

        void OnDestroy()
        {
            GameEvents.onGUIApplicationLauncherReady.Remove(this.OnGuiAppLauncherReady);

            if (this.addedToGUI && this.button != null)
            {
                ApplicationLauncher.Instance.RemoveModApplication(this.button);
                this.addedToGUI = false;
            }
            Destroy(this);
        }
    }
}

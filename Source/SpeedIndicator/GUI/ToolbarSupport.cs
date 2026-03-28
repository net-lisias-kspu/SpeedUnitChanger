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
using UnityEngine;

using KSPe.Annotations;
using Toolbar = KSPe.UI.Toolbar;
using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;
using KSPe.UI.Toolbar;
using KSP.UI.Screens;

namespace SpeedUnitChanger.UI
{
	[KSPAddon(KSPAddon.Startup.MainMenu, true)]
	public class ToolbarController : MonoBehaviour
	{
		private static ToolbarController _Instance = null;
		internal static ToolbarController Instance => _Instance;
		private static KSPe.UI.Toolbar.Toolbar ToolbarInstance => KSPe.UI.Toolbar.Controller.Instance.Get<ToolbarController>();

		[UsedImplicitly]
		private void Awake()
		{
			_Instance = this;
		}

		[UsedImplicitly]
		private void Start()
		{
			KSPe.UI.Toolbar.Controller.Instance.Register<ToolbarController>(Version.FriendlyName);
		}

		[UsedImplicitly]
		private void OnDestroy()
		{
			ToolbarInstance.Destroy();
		}

		private SpeedUnitChanger owner = null;
		private Button button;

		internal void Create(SpeedUnitChanger owner)
		{
			this.owner = owner;
			if (null != this.button)
			{
				ToolbarInstance.ButtonsActive(true, true);
				return;
			}

			button = Toolbar.Button.Create(this
						, ApplicationLauncher.AppScenes.FLIGHT
						, Icons.IconToolbar, Icons.IconToolbar
					)
				;

			button.Toolbar
						.Add(Toolbar.Button.ToolbarEvents.Kind.Active,
							new Toolbar.Button.Event(this.OnRaisingEdge, this.OnFallingEdge)
						);
			;

			ToolbarInstance.Add(button);
		}

		internal void Destroy()
		{
			ToolbarInstance.ButtonsActive(false, false);
			this.owner = null;
		}

		internal void CloseApplication()
		{
			if (null == this.owner) return; // Better safer than sorry!
			this.button.Active = false;
		}

		private void OnRaisingEdge()
		{
			if (null == this.owner) return; // Better safer than sorry!
			this.owner.ToolBarEnabled = true;
		}

		private void OnFallingEdge()
		{
			if (null == this.owner) return; // Better safer than sorry!
			this.owner.ToolBarEnabled = false;
		}

	}
}

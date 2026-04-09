# Speed Unit Changer :: Changes

* 2026-0409: 1.7.1.2 (LisiasT) for KSP >= 1.3.1
	+ Remembering that the savegame data is not automatically available when the `MonoBehaviour` is instantiated on Flight scene, and now using `KSPe.IO.SavegameMonitor` to deal with it.
	+ Fixing the release date of the last release on the change logs - I was pretty wasted when I released it! :P
* 2026-0328: 1.7.1.1 (LisiasT) for KSP >= 1.3.1
	+ Moves the thingy to the `net.lisias.ksp` file hierarchy to prevent confusion with upstream.
	+ Adds KSPe GUI, FileSystem and Logging facilities
	+ Certifies to work downto KSP 1.3.1
	+ Adds option to automatically switch the display to ASL when flying above 1KM above local ground level or when flying over oceans;
	+ Adds option to allow negative altitude display when under water (or below sea level)

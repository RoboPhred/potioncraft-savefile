# PotionCraft Save Files

Save your PotionCraft game to the filesystem, allowing you to edit and transfer your save files.

Saves are stored in the PotionCraft directory under the `saves` folder.
Saves are prefixed with the game version, and numbered based on their index. Save `99` is the Autosave.

When the game updates, it will try to read old saves and update them, re-saving them with the new version number. Saves for older versions can be safely deleted.

When loading the game, the mod will first look for a save file on the filesystem. If none is found, it falls back to loading from the registry. This lets your existing save files still be used from before installing the mod.

When saving the game, the mod will save both to the filesystem and the registry, allowing you to safely uninstall the mod without loosing your data.

## Installation

This mod uses BepInEx 5.

- Install [version 5](https://github.com/BepInEx/BepInEx/releases) or later by extracting the BepInEx zip file into your PotionCraft folder.
- Run the game once, to let BepInEx create its folder structure.
- Download the mod from the [releases page](https://github.com/RoboPhred/potioncraft-savefile/releases).
- Place the potioncraft-savefiles.dll file from the download into `PotionCraft/BepInEx/Plugins`.

## Usage

When the mod is installed, running the game should produce copies of your save files at `PotionCraft/saves` if copies do not already exist.  These save files can then be copied to other computers where the mod is also installed.  If the game finds files in that folder that represent saves, those files will be used to load the save instead of using the registry.

## Uninstalling

The mod is safe to uninstall, and progress will not be lost. The mod saves your game to both the filesystem and to the registry, so removing the mod will let the game fall back to the registry saves.

## Development

### Dependencies

Dependencies are placed on the `/externals` folder

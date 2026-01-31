# Scene Flow

## Scenes
- **Bootstrap** (`Assets/_Project/Scenes/Bootstrap.unity`): entry scene with `GameBootstrap` singleton.
- **Game** (`Assets/_Project/Scenes/Game.unity`): main gameplay scene with starter environment.

## Load order
1. **Bootstrap** is the first scene in Build Settings.
2. `GameBootstrap` persists (`DontDestroyOnLoad`) and loads **Game**.
3. **Game** contains the base environment (ground, light, spawn).

## Responsibilities
- **GameBootstrap**: global settings holder (future input, graphics, networking), safe singleton, scene switching.
- **Game**: world setup only, no global initialization.

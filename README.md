# gta-like-unity-androidf

## Project overview
* **Unity version:** 2022.3 LTS (ProjectVersion.txt pinned to 2022.3.10f1).
* **Target platform:** Android (mobile-first, low-end device baseline).
* **Render pipeline:** Universal Render Pipeline (URP).

## Project structure
```
Assets/_Project/
  Scenes/
  Scripts/
  Prefabs/
  Art/
  UI/
  Audio/
  Settings/
  Networking/
  Docs/
```

## How to open
1. Install Unity Hub + Unity **2022.3 LTS** (matching `ProjectSettings/ProjectVersion.txt`).
2. Open the repository folder in Unity Hub.
3. Let Unity resolve packages (URP) from `Packages/manifest.json`.

## How to build (Android)
1. Open **File → Build Settings**.
2. Select **Android** and click **Switch Platform** if needed.
3. Ensure Player Settings match the baseline in `ProjectSettings/ProjectSettings.asset`.
4. Build APK/AAB.

## Notes
* This repo provides a baseline structure and settings for a lightweight URP Android project.
* If you regenerate settings via Unity, keep the mobile-first defaults (minimal post-processing, low shadow distance, SRP Batcher enabled).

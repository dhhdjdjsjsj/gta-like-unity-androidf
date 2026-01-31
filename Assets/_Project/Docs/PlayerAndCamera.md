# Player & Camera

## Overview
- **Player**: `Player` GameObject uses `CharacterController` for stable mobile-friendly movement.
- **Camera**: `ThirdPersonCamera` follows the player with damping and clamps vertical angle.

## Assets
- Player prefab: `Assets/_Project/Prefabs/Player/Player.prefab`
- Camera prefab: `Assets/_Project/Prefabs/Camera/ThirdPersonCamera.prefab`
- Scene usage: `Assets/_Project/Scenes/Game.unity`

## Player настройки
- `ThirdPersonController`
  - `moveSpeed`: скорость движения.
  - `rotationSpeed`: скорость поворота по направлению.
  - `gravity`: сила гравитации.
  - `allowJump` / `jumpHeight`: прыжок (по умолчанию выключен).
  - `cameraTransform`: ориентация движения относительно камеры.

## Camera настройки
- `ThirdPersonCamera`
  - `followOffset`: дистанция/высота камеры.
  - `positionDamping`: сглаживание.
  - `pitchLimits`: ограничения вертикального угла.
  - `obstructionLayers`: слои для коллизии камеры.

## Input
- Временные оси:
  - `Horizontal` / `Vertical` для движения.
  - `Mouse X` / `Mouse Y` для поворота камеры.
- Для мобильного управления замените ввод на джойстики/свайп.

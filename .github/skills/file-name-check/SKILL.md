---
name: file-name-check
description: "Use when: evaluating if a file or script name follows established naming conventions (e.g. PascalCase for classes, lowercase folders, etc.)."
---

# File Name Check Skill

## Purpose
Ensure that new or existing files in the project use consistent naming conventions aligned with code guidelines.

## Rules
- Class and script filenames must match the primary public class name and use PascalCase.
- MonoBehaviour scripts should be placed in appropriately named folders (no spaces, use kebab-case for directories).
- Asset files (e.g. ScriptableObjects) should use PascalCase and include a suffix indicating type if helpful (`_SO`).
- Test files should end with `Tests` (e.g. `PlayerControllerTests.cs`).
- Image assets follow `[scope]_[name]_[index]` (e.g. `ui_button_01.png`).
- Sound effects use `[scope]_[action]_[variant]` or similar (e.g. `sfx_player_jump_01.wav`).
- Visual effect prefabs use `vfx_[name]_[quality]` or `vfx_[name]_[index]` (e.g. `vfx_explosion_01.prefab`).
- Avoid underscores or special characters in filenames unless part of a specific convention (e.g. `_img` field, not filenames).

## Usage
- Input: file path or name string for evaluation.
- Output: compliance report with suggestions for renaming.

## Example
> **User:** /file-name-check
> `Assets/Scripts/playercontroller.cs`
> 
> **Agent:** Filename should be `PlayerController.cs` (PascalCase matching class name).


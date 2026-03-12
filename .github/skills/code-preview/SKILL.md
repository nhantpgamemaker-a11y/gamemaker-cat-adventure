---
name: code-preview
description: "Use when: given a C# code snippet, analyze it against the BUILD_CODE rules (SOLID, clean code, naming conventions, MVC, etc.) and provide a compliance report and suggestions."
---

# Code Preview Skill

## Purpose
Evaluate supplied C# code snippets and determine whether they follow the `BUILD_CODE` guidelines defined in the other skill. Provide actionable feedback on violations and suggestions to improve compliance.

## Usage
- Input will be one or more C# methods, classes, or script fragments.
- Output should be a bullet list explaining which rules are satisfied and which are broken, with line references if possible.
- Recommend refactors or naming fixes when issues are found.

## Example Interaction
> **User:** /code-preview
> ```csharp
> public class Player : MonoBehaviour {
>     public int Health;
>     void Update() { if(Health <= 0) Destroy(gameObject); }
> }
> ```
> 
> **Agent:**
> - Naming: `Health` is public field; prefer PascalCase property or private field with public accessor.
> - Side effects: `Destroy` call in Update may be okay, but consider flagging in player controller.
> - MVC: MonoBehaviour contains logic; ensure it's acting as controller and data lives elsewhere.

## Notes
This skill is purely analytical; it should not modify code automatically but may suggest new structure.


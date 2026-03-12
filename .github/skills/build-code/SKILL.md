---
name: build-code
description: "Use when: create or review C# Unity code for SOLID, clean code rules, and basic quality gates."
---

# Build Code Skill

## Purpose
Guide the agent to produce high-quality Unity C# code that follows SOLID and clean code principles.

## Scope
- Language: C# (Unity)
- Applies to: gameplay, UI, tools, and runtime systems

## Project Guidelines
- Organize assets into clear top-level folders (`Art`, `Scripts`, `Prefabs`, `Scenes`, etc.).
- Use assembly definition files to compartmentalize code and speed up compilation.
- Keep scene hierarchies shallow and group related objects under empty GameObjects.
- Prefabs are authoritative; modify data/config via ScriptableObjects rather than scene values.
- Avoid hard-coded paths; use `Resources` sparingly and prefer addressables.
- Leverage packages (UPM or custom) for shared code/tools to facilitate reuse across projects.
- Regularly run the built-in Unity analyzer and address warnings.
- Use consistent project settings (input axes, layers/tags) and document any non-default changes.

## Rules
1. Single Responsibility: one class or module has one clear reason to change.
2. Open/Closed: extend behavior without modifying existing code whenever possible.
3. Liskov Substitution: subclasses must preserve expected behavior of base types.
4. Interface Segregation: prefer small, focused interfaces over large general ones.
5. Dependency Inversion: depend on abstractions, not concretions.
6. Method clarity: keep methods small and focused on a single intent.
   * New methods should default to `internal` unless wider visibility is required.
   * Favor early returns; avoid deep nesting and large blocks.
   * Avoid magic numbers—use named constants instead of literals.
7. Naming: use clear, descriptive names; avoid ambiguous abbreviations.
   * Serialized fields may use short suffixes for component types (e.g. `Image` → `_img`, `TMP_Text` → `_txt`).
   * Visibility conventions:
     * `private` fields prefixed with `_` (e.g. `_health`).
     * `protected` fields use camelCase without underscore (e.g. `codeData`).
     * `public` properties/fields use PascalCase (e.g. `CodeData`).
8. Side effects: minimize side effects; if needed, make them explicit.
9. Null handling: validate inputs early; avoid silent null propagation.
10. Comments: document *why* rather than *what*; remove outdated or redundant comments.
11. Unity patterns: prefer ScriptableObject for configuration; isolate MonoBehaviour logic; avoid heavy work in Update.
11. MVC: scripts attached to GameObjects act as Controllers; keep View logic in UI components and Model as data/state.  * Controller should not hold large data—only references or interfaces to model objects.
  * Model contains configuration, runtime state, or persistence (pure C# classes or ScriptableObjects).
## Examples (placeholder)
- TODO: add good/bad code examples per rule when ready.

## Usage Notes
- When generating code, explain how it satisfies the rules.
- If a rule conflicts with performance or Unity constraints, call it out and justify.

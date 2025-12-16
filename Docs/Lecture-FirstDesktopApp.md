# FirstDesktopApp — Lecture Notes

**Title:** FirstDesktopApp — Small OOP Game Framework

**Audience:** OOP students learning game-system concepts (collision, physics, composition)

**Overview**
This document explains the architecture, classes, and runtime flow of the FirstDesktopApp project. It is organized as a lecture with definitions, code examples, diagrams (textual), and exercises.

---

## Table of Contents
1. Goals & Overview
2. Project Structure
3. Core Concepts
4. Key Files and Walkthrough
5. Systems (Physics & Collision)
6. Rigid-Body Handling
7. Example: Collision Flow
8. Design Notes & Trade-offs
9. Exercises
10. Appendix: Commands to create PDF

---

## 1. Goals & Overview
- Purpose: A compact 2D game framework for learning OOP and game systems.
- Design Principles:
  - Composition via interfaces (IMovable, ICollidable, IPhysicsObject)
  - Polymorphism: `GameObject` base class with virtual methods
  - Separation of concerns: Systems operate on objects (PhysicsSystem, CollisionSystem)

---

## 2. Project Structure (key files)
- `Core/Game.cs` — game object collection and lifecycle management
- `Entities/GameObject.cs` — base entity
- `Entities/Player.cs`, `Entities/Enemy.cs` — concrete game entities
- `Extensions/Bullet.cs`, `Extensions/PowerUp.cs` — small object types
- `Systems/PhysicsSystem.cs` — gravity and movement physics
- `Systems/CollisionSystem.cs` — collision detection and resolution
- `Interfaces/` — capability interfaces
- `GameForm.cs` — WinForms UI + game loop set up

---

## 3. Core Concepts
- Game loop: Update -> Physics -> Collision -> Cleanup -> Draw
- `IsActive`: toggles lifecycle participation
- Interfaces provide composable capabilities
- `Bounds` is an AABB (axis-aligned bounding box) represented by `RectangleF`

---

## 4. Key Files & Code Walkthrough
### `Entities/GameObject.cs`
- Properties: `Position (PointF)`, `Size (SizeF)`, `Velocity (PointF)`
- Computed property: `Bounds => new RectangleF(Position, Size)`
- Flags: `IsActive`, `HasPhysics`, `CustomGravity`, `IsRigidBody` and optional `Sprite` image
- Methods: `virtual Update(GameTime)`, `virtual Draw(Graphics)`, `virtual OnCollision(GameObject)`

Example (behavior):
- `Update` by default applies `Velocity` to `Position`.
- `Draw` uses `Sprite` if set; otherwise a default rectangle.

### `Entities/Player.cs`
- `IMovement? Movement` to decouple movement behavior
- `Update` calls `Movement?.Move(this, gameTime)` then `base.Update(gameTime)`
- `OnCollision` reduces health if colliding with an `Enemy` etc.

---

## 5. Systems
### PhysicsSystem
- Uses a global `Gravity` value; for each `IPhysicsObject` with `HasPhysics == true`:
  - `appliedGravity = physicsObj.CustomGravity ?? Gravity`
  - `Velocity.Y += appliedGravity`
  - update `Position` by `Velocity`
- Integration is simple Euler integration.

### CollisionSystem
- Collects `ICollidable` objects and checks pairwise AABB intersections.
- On intersection, computes `RectangleF.Intersect(a.Bounds, b.Bounds)` as `overlap`.
- Handles three scenarios:
  - If **one object is rigid**, push the non-rigid object out and zero its velocity.
  - If **both or neither** are rigid, separate objects by half overlap to avoid sticking.
- Afterwards calls `OnCollision` on both objects for domain logic.

---

## 6. Rigid-Body Handling
- `IPhysicsObject` exposes `IsRigidBody`.
- When rigid body collides:
  - The colliding partner is pushed out and its velocity cleared.
  - Rigid bodies themselves have `Velocity` cleared and `HasPhysics = false` to disable gravity.
- This is a simple, deterministic approach for static obstacles or objects that should not be moved by physics.

---

## 7. Example Collision Flow
1. `CollisionSystem.Check` finds `A` and `B` intersecting.
2. Compute `overlap = RectangleF.Intersect(A.Bounds, B.Bounds)`.
3. If `A.IsRigidBody` and not `B.IsRigidBody`:
   - Move `B` along the smaller axis of overlap out of `A`.
   - Set `B.Velocity = (0,0)`.
   - Optionally `B.HasPhysics = false` to stop gravity.
4. Else separate both by half overlap.
5. After resolution, both `OnCollision` handlers are invoked.

---

## 8. Design Notes & Trade-offs
- Collision resolution is intentionally simple for teaching purposes.
- Limitations: no impulse resolution, no angular dynamics, possible tunnelling at high velocities.
- Good next steps: add mass, restitution, impulse resolution, or continuous collision detection.

---

## 9. Exercises
1. Add `Mass` and `Restitution` and perform impulse resolution for bounce.
2. Add `Debug.DrawBounds` to visualize bounding boxes and overlaps.
3. Add a test harness to programmatically test the CollisionSystem away from WinForms.
4. Implement a `FollowMovement` to chase `Player`.

---

## 10. Appendix: Commands to make PDF
Recommended (install Pandoc):
- On Windows: install Pandoc from https://pandoc.org/installing.html
- Then run:

```
pandoc Lecture-FirstDesktopApp.md -o Lecture-FirstDesktopApp.pdf --pdf-engine=xelatex --toc --metadata title="FirstDesktopApp Lecture"
```

Alternative (VS Code):
- Open `Lecture-FirstDesktopApp.md` in VSCode, "Print to PDF" using the editor's print command.

---

## Contact & Next Steps
- If you want I can:
  - Create the PDF in the repo (if Pandoc is available here) — currently Pandoc isn't installed on this machine.
  - Add visuals (debug drawing) and a demo scene showing rigid-body interactions.

---

*End of lecture notes.*

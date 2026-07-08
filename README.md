# 🔫 Trigger Happy

**A fast-paced FPS. Master the movement, aim true, and survive. Pure action, nothing else.**

[![Unity](https://img.shields.io/badge/Made%20with-Unity-black?style=flat&logo=unity)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Web-green)]()
[![Pace](https://img.shields.io/badge/Pace-High_Velocity-red)]()

> *"Keep moving or you're dead."*

## 🎥 Gameplay
![Trigger Happy Screenshot](placeholder_for_thumbnail.png)

---

## 🎮 Play The Game
**[👉 PLAY THE GAME NOW 👈](https://play.unity.com/api/v1/games/game/85304add-b65f-4304-984f-384633c0a894/build/latest/frame)**

---

## 🧐 What is this?
**Trigger Happy** is a straight-up shooter built for raw speed and reflexes. There is no filler, no deep lore, and no complex skill trees. You drop into a low-poly sci-fi arena, move fast, and shoot straight. 

It is a technical showcase of tight FPS controls, responsive gunplay, and a polished visual stack designed to run smoothly right out of the gate.

---

## 🕹️ Controls

Keep it simple, keep it fast.

| Action | Input |
| :--- | :--- |
| **Move** | `W` `A` `S` `D` |
| **Jump** | `SPACE BAR` |
| **Sprint** | `SHIFT` |
| **Fire** | `LEFT CLICK` |
| **Aim** | `MOUSE` |

---

## 🧪 The Mechanics (How to Survive)

### 🏃 Movement is Life
* **The Logic:** Standing still makes you a target. 
* **The Result:** Utilize constant sprinting and jumping to outmaneuver threats. Speed is your primary defense.

### 🎯 The Targets
* **The Enemy:** Floating, geometric drones with glowing central eyes. 
* **The Rule:** Hit the target or get hit. Reflexes and precision are the only things that keep you alive in the arena.

### 💥 High-Contrast Combat
* **The Environment:** Navigate monorail stations and modular habitats against a twilight sky. 
* **The Focus:** The aesthetic is designed to make threats pop. The glowing enemies and bright muzzle flashes stand out against the flat-shaded terrain so you can focus entirely on aiming.

---

## 🛠️ Under The Hood

For the curious, here is the technical setup powering the arena:

### 📸 Multi-Camera Layering
The weapon and the environment do not share the same depth buffer. A dedicated Weapon Camera handles the first-person view, utilizing `Depth Only` clear flags. This prevents global SSAO (Screen Space Ambient Occlusion) from casting dirty, unwanted shadows onto the gun model, ensuring the weapon remains crisp while the room maintains its depth.

### 🎨 Post-Processing Stack (URP)
The visual identity relies heavily on Unity's Universal Render Pipeline. 
* **Bloom:** Drives the high-intensity neon glow of the drones and projectiles.
* **Gaussian Depth of Field:** Keeps the background softly blurred to draw the player's eye directly to the mid-ground combat zone without sacrificing web performance.
* **Tonemapping:** Balances the high-contrast lighting to maintain visibility during chaotic firefights.

### ⚙️ Responsive Controller
The character controller is built purely in C# to handle high-velocity input without input lag or floaty physics, tuned specifically for immediate web deployment.

---

## 📦 Credits

* **Engine:** Unity (URP)
* **Developer:** Kaylin Maharaj
* **Style:** Low-poly Sci-Fi

---

*Made with 💖 and a severe lack of patience for slow games.*

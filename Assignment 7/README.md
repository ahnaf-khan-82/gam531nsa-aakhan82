# Sprite Animation Project (Advanced Sprite Animation in OpenTK)

**Course:** WEB422 / Computer Programming & Analysis  
**Assignment:** Advanced Sprite Animation in OpenTK (C# + OpenGL)  
**Due Date:** November 9, 2025  
**Developed by:** Ahnaf Abrar Khan  
**Institution:** Seneca Polytechnic  

---

## Overview

This project builds upon the base [SpriteGameOpenTk](https://github.com/mouraleonardo/SpriteGameOpenTk) example by introducing new mechanics such as **jumping**, **running**, and **idle animations**, along with integrated **sound effects**.

It features a full **state machine** that smoothly transitions between **Idle**, **Walk**, **Run**, and **Jump** states, achieving lifelike character motion through OpenGL transformations and input-driven control.

The final result is a polished and responsive 2D sprite system combining animation, physics, and sound for a dynamic gameplay experience.

---

## Features

- Idle, Walk, Run, and Jump animations with correct frame timing.  
- Gravity and jump simulation using vertical velocity and ground detection.  
- Shift key sprint mechanic for faster running speed and animation rate.  
- Sound effects synchronized with player movement.  
- Directional facing (sprite flips horizontally when changing direction).  
- Organized state machine for seamless transitions.  
- Optimized rendering with OpenGL blending and VAO/VBO usage.

---

## Controls

| Key | Action |
|-----|---------|
| → / D | Move Right |
| ← / A | Move Left |
| ↑ / Space | Jump |
| Shift + ←→ / A-D | Run |
| No Input | Idle |
| Esc | Exit Game |

---

## State Machine Logic

The animation controller uses a **finite state machine** that determines which animation and sound to play based on input and character state.

| State | Description |
|--------|-------------|
| **Idle** | Subtle standing animation when no input is pressed. |
| **Walk** | Loops walking frames while moving left or right. |
| **Run** | Triggered by Shift + movement, plays faster looping animation. |
| **Jump** | Activated by pressing Space or Up, applies upward velocity and gravity. |

Each state manages frame timing, looping, and sound playback independently.  
Transitions are restricted logically (e.g., jumping only when grounded).

---

## Sound Implementation

Sound effects are loaded with `System.Media.SoundPlayer` and preloaded in `OnLoad()` for lag-free playback.

| Sound | Trigger | Behavior |
|--------|----------|-----------|
| **Walk.wav** | When walking | Loops continuously |
| **Run.wav** | When running | Loops continuously |
| **Jump.wav** | When jumping | Plays once |

All sounds are synchronized with their corresponding animation states.

---

## Challenges Faced

- **Timing Optimization** – Balancing frame speed for smoother transitions.  
- **Sound Lag Fix** – Solved by preloading WAVs before playback.  
- **Frame Alignment** – Adjusted UV coordinates for proper left/right flipping.  
- **Idle Animation** – Added looping subtle motion for realism.

---

## Assets & Credits

### Character Sprites

- **Title:** Free Shinobi Sprites Pixel Art  
- **Author:** CraftPix.net  
- **Source:** [https://craftpix.net/freebies/free-shinobi-sprites-pixel-art/](https://craftpix.net/freebies/free-shinobi-sprites-pixel-art/)  
- **License:** Royalty-free for personal and commercial use under the CraftPix Free Assets License.  
© CraftPix.net – used under the free license.

---

### Sound Effects

All sound effects are free for use under the [Pixabay Content License](https://pixabay.com/service/license-summary/).

| Sound | Title | Author | Source |
|--------|--------|---------|---------|
| Jump | Cartoon Jump | Bastianhallo (Freesound) | [https://pixabay.com/sound-effects/cartoon-jump-6462/](https://pixabay.com/sound-effects/cartoon-jump-6462/) |
| Run | Running 1 | vmgraw (Freesound) | [https://pixabay.com/sound-effects/running-1-6846/](https://pixabay.com/sound-effects/running-1-6846/) |
| Walk | Walking | wolfdoctor (Freesound) | [https://pixabay.com/sound-effects/walking-96582/](https://pixabay.com/sound-effects/walking-96582/) |

---

## Usage Note

All visual and audio assets are used under their respective royalty-free or Pixabay licenses.  
Proper credit is provided to acknowledge original creators and comply with attribution requirements.

---

## Deliverables

- Full project folder including `.csproj`, source files, and assets.  
- `README.md` (this document).  
- Compressed `.zip` submission.

---

## Grading Rubric (5 pts)

| Criteria | Description | Points |
|-----------|--------------|---------|
| **Functionality** | New movement mechanics work correctly and respond to input. | 2.0 |
| **Animation Logic** | State transitions and frame handling are consistent and bug-free. | 1.5 |
| **Code Quality** | Clean structure, readable comments, and efficient logic. | 1.0 |
| **Creativity & Polish** | Smoothness, sound sync, and visual appeal. | 0.5 |

**Total:** 5.0 / 5 pts possible

---

## Developer Info

**Developed by:** Ahnaf Abrar Khan  

# Sprite Animation Project (Advanced Sprite Animation in OpenTK)

**Course:** WEB422 / Computer Programming & Analysis  
**Assignment:** Advanced Sprite Animation in OpenTK (C# + OpenGL)  

---

## Overview

This project adds to the the original SpriteGameOpenTk example by introducing smoother, more lifelike character movement by using new run and jump mechanics with realistic gravity. It has a complete state machine that controls when the character idles, walks, runs, or jumps along with synchronized sound effects for each action. Using OpenTK and OpenGL, the game renders 2D animations, with physics and input control to create a better experience.

---

## Features

- New Movement Mechanics – Added running (Shift + left or right arrow / A–D keys) and jumping (Space / up arrow) with gravity-based motion.
- State Machine Control – Smooth transitions between Idle, Walk, Run, and Jump states for consistent animation flow.
- Sound Integration – Distinct sound effects for walking, running, and jumping, synced with their actions.
- Directional Facing – Character automatically flips horizontally based on input direction.
- Physics – Vertical velocity and gravity
- Optimized Rendering – Uses VAO/VBO structure, OpenGL blending, and uniform matrices for 2D rendering.
- Idle Animation Loop – Subtle breathing motion during inactivity.
  
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

The animation controller uses a state machine that determines which animation and sound to play based on input and character state.

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

| Sound | Trigger | Behavior |
|--------|----------|-----------|
| **Walk.wav** | When walking | Loops continuously |
| **Run.wav** | When running | Loops continuously |
| **Jump.wav** | When jumping | Plays once |

All sounds are synchronized with their corresponding animation states.

---

## Challenges Faced

- Had to adjust frame time for smoother transitions between animation states. 
- Delay in sound which I fixed by preloading sounds.
- Issue with frame allignment but made sure that the sprite aspect ratio was consistent.
- Idle animation was initially frozen but I solved it by using a loop.
  
---

## Assets & Credits

### Character Sprites

- **Title:** Free Shinobi Sprites Pixel Art  
- **Author:** CraftPix.net  
- **Source:** [https://craftpix.net/freebies/free-shinobi-sprites-pixel-art/](https://craftpix.net/freebies/free-shinobi-sprites-pixel-art/)  
- **License:** Royalty-free for personal and commercial use under the CraftPix Free Assets License.  
© CraftPix.net – used under the free license.

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


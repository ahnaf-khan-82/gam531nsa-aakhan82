# Space Pod - Midterm 3D Explorer

## Project Description
Space Pod is an interactive 3D scene built in C# with OpenTK.  
You explore a miniature solar system from a free camera point of view. The scene includes the Sun, all major planets, and Earth’s Moon. Each planet is textured and lit using Phong lighting. The planets orbit the Sun at different distances, the Earth rotates, and the Moon orbits the Earth. You can pause and resume orbital motion.

This project demonstrates topics from Weeks 1–6:
- 3D math (vectors, matrices, transforms)
- Rendering pipeline (VAO / VBO / EBO, shaders)
- Texturing
- Phong lighting (ambient / diffuse / specular)
- Camera systems and user input

---

## Gameplay Instructions
- **W / A / S / D** – Move the camera forward / left / back / right  
- **Space / Left Ctrl** – Move up / down  
- **Mouse Move** – Look around (free look camera)  
- **Mouse Wheel** – Zoom (changes camera FOV)  
- **E** – Toggle planetary orbit motion (pause / resume).  
  - When paused, planets stop orbiting but keep spinning in place.

---

## Feature List
- **Multiple 3D objects:** Sun, Mercury, Venus, Earth + Moon, Mars, Jupiter, Saturn (with ring), Uranus, Neptune, Pluto, plus a textured space background.
- **3+ meshes:**
  - UV sphere mesh (used for Sun/planets/Moon)
  - Flat ring mesh (used for Saturn’s ring)
  - Inward-facing cube mesh (used as a skybox / space background)
- **Textured environment:** Starfield background rendered as a giant inside-out cube.
- **Phong lighting:** Directional light with ambient, diffuse, and specular highlights.
- **Camera system:** Custom FPS-style free camera (position, yaw, pitch, FOV).
- **Interaction:** Press **E** to pause/resume orbital movement of the planets and Moon.
- **Scene transforms:** Each planet orbits the Sun at a different radius and speed. The Moon orbits the Earth.

---

## How to Build / Run

### Requirements
- .NET 6 (or newer) SDK  
- OpenTK 4.x (NuGet: `OpenTK`)  
- System.Drawing.Common (used to load .jpg textures into OpenGL)

### Project Structure
- `Program.cs` – App entry point  
- `Game.cs` – Main game loop, input handling, update + render  
- `GL/Shader.cs` – Compiles/links GLSL shaders and sets uniforms  
- `GL/Texture.cs` – Loads images (JPG) into OpenGL textures and binds them  
- `GL/Mesh.cs` – Creates VAO/VBO/EBO for:
  - UV sphere mesh (planets/sun)
  - Saturn’s ring mesh
  - Inward-facing sky cube mesh
- `GL/FpsCamera.cs` – FPS-style camera (yaw/pitch, view + projection matrices)
- `Shaders/vertex.glsl` / `Shaders/fragment.glsl` – GLSL 330 core shaders (Phong lighting, texturing)
- `Assets/` – Texture images for planets, moon, sun, and space background

### Build / Run Steps
1. Restore NuGet packages (OpenTK, System.Drawing.Common).
2. Make sure `Assets/` and `Shaders/` are marked as “Copy if newer” or “Copy always” so they end up next to the built .exe in `bin/Debug` or `bin/Release`.
3. Build and run:
   - Visual Studio: `F5`  
   - Command line: `dotnet run`

---

## Credits

All textures are royalty-free for educational / noncommercial use, or are public domain:

- **Sun, Mercury, Mars, Jupiter, Pluto**  
  NASA / JPL / USGS planetary maps and mosaics. These are U.S. government science products that are released as public domain. Attribution to NASA / JPL / USGS / New Horizons teams is requested for scientific use.

- **Earth Day Map**  
  "solarsystemscope_texture_8k_earth_daymap.jpg" by Solar System Scope / inove.  
  Licensed under CC BY 4.0 (free to use with attribution).

- **Moon Map**  
  "solarsystemscope_texture_8k_moon.jpg" by Solar System Scope / inove.  
  Licensed under CC BY 4.0 (free to use with attribution).

- **Venus**  
  Cylindrical Venus surface map derived from NASA / JPL radar data.  
  Shared on Wikimedia Commons for educational reuse with attribution.

- **Saturn, Uranus, Neptune**  
  Processed cylindrical planet maps created by Björn Jónsson using NASA Voyager / Cassini mission imagery.  
  Allowed for educational / noncommercial use when credit is given.  
  (Credit: NASA / JPL / Cassini / Voyager 2 / Björn Jónsson)

- **Milky Way Background / Space Sky**  
  ESO (European Southern Observatory) Milky Way panorama, published for free reuse with attribution to ESO and the listed astrophotographers.

No commercial assets, paid packs, or copyrighted game art were used.

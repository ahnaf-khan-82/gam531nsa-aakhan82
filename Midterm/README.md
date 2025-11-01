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
- SUN: https://commons.wikimedia.org/wiki/File%3AMap_of_the_full_sun.jpg?utm_source=chatgpt.com
- MERCURY: https://astrogeology.usgs.gov/search/map/mercury_messenger_mdis_basemap_enhanced_color_global_mosaic_665
- MARS: https://astrogeology.usgs.gov/ckan/dataset/7131d503-cdc9-45a5-8f83-5126c0fd397e/resource/6afad901-1caa-48a7-8b62-3911da0004c2/download/mars_viking_mdim21_clrmosaic_global_1024.jpg
- JUPITER: https://commons.wikimedia.org/wiki/File%3AJupiter_Cylindrical_Map_-_Dec_2000_PIA07782.jpg
- PLUTO: https://astrogeology.usgs.gov/search/map/pluto_new_horizons_lorri_mvic_global_dem_300
  NASA / JPL / USGS planetary maps and mosaics. These are U.S. government science products that are released as public domain.

- **Earth Day Map**
- https://commons.wikimedia.org/wiki/File%3ASolarsystemscope_texture_8k_earth_daymap.jpg
  "solarsystemscope_texture_8k_earth_daymap.jpg" by Solar System Scope / inove.  

- **Moon Map**
- https://commons.wikimedia.org/wiki/File:Solarsystemscope_texture_8k_moon.jpg
  "solarsystemscope_texture_8k_moon.jpg" by Solar System Scope / inove.  


- **Venus**
- https://upload.wikimedia.org/wikipedia/commons/1/19/Cylindrical_Map_of_Venus.jpg
  Cylindrical Venus surface map derived from NASA / JPL radar data.  
  Shared on Wikimedia Commons for educational reuse.

- **Saturn, Uranus, Neptune**
- SATURN: https://bjj.mmedia.is/data/saturn/index.html
- URANUS: https://www.planetary.org/space-images/cylindrical-map-of-uranus-from-voyager-2-data
- NEPTUNE: https://bjj.mmedia.is/data/neptune/index.html
  Processed cylindrical planet maps created by Björn Jónsson using NASA Voyager / Cassini mission imagery.  
  Allowed for educational / noncommercial use when credit is given.  
  (Credit: NASA / JPL / Cassini / Voyager 2 / Björn Jónsson)

- **Milky Way Background / Space Sky**
- https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/ESO_-_Milky_Way.jpg/960px-ESO_-_Milky_Way.jpg?20121015100932
  ESO (European Southern Observatory) Milky Way panorama, published for free reuse with attribution to ESO and the listed astrophotographers.

No commercial assets, paid packs, or copyrighted game art were used.

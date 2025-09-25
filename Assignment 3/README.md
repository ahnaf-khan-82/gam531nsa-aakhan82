# Assignment 3: Rendering a 3D Cube

## Overview
This assignment demonstrates rendering a basic 3D object (a cube) using OpenTK in C#.  
It builds upon earlier assignments by introducing 3D graphics concepts such as perspective projection, transformations, and depth rendering.

## Library Used
**OpenTK** – (Windowing, Graphics.OpenGL4, Mathematics)

## Implementation Details
- **Cube Geometry**: Defined using 8 unique vertices and indexed with an element buffer (EBO) to create 12 triangles (6 faces).  
- **Shaders**: Minimal vertex and fragment shaders render the cube in solid blue.  
- **Matrices**:  
  - **Model Matrix** – Rotates the cube continuously on the Y-axis.  
  - **View Matrix** – Translates the camera back along the Z-axis.  
  - **Projection Matrix** – Applies perspective projection so the cube appears in 3D.  
- **Depth Test**: Enabled to correctly render overlapping cube faces.  
- **Appearance**: Background is pink, cube is blue.

## Example Screenshot
<img width="801" height="628" alt="image" src="https://github.com/user-attachments/assets/553e7d46-55d8-42bb-b7c5-75cb5525f534" />
<img width="801" height="634" alt="image" src="https://github.com/user-attachments/assets/d04ea5fa-01e6-4cb1-9c13-f389636516da" />


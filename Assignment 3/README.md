# Assignment 3: Rendering a 3D Cube

## Overview
This assignment demonstrates rendering a basic 3D object (a cube) using OpenTK in C#.  
It builds upon earlier assignments by introducing 3D graphics concepts such as perspective projection, transformations, and depth rendering.

## Library Used
**OpenTK** – Windowing, Graphics.OpenGL4, Mathematics

## Implementation Details
- **Cube Geometry**: Defined using 8 unique vertices and indexed with an element buffer (EBO) to create 12 triangles (6 faces).  
- **Shaders**: Minimal vertex and fragment shaders render the cube in solid blue.  
- **Matrices**:  
  - **Model Matrix** – Rotates the cube continuously on the Y-axis.  
  - **View Matrix** – Translates the camera back along the Z-axis.  
  - **Projection Matrix** – Applies perspective projection so the cube appears in 3D.  

## Example Screenshot
<img width="798" height="601" alt="image" src="https://github.com/user-attachments/assets/e7954ad7-64d6-4818-a8be-a19caa595294" />



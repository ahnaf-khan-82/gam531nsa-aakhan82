# Assignment 2 Vector & Matrix Operations

## Overview
This assignment demonstrates basic vector and matrix operations using **OpenTK** in C#.  
It covers fundamental 3D math operations, including vector addition, subtraction, dot product, cross product, and matrix transformations (identity, scaling, rotation).

## Library Used
**OpenTK.Mathematics** – for `Vector3`, `Vector4`, `Matrix4`

## Implemented Operations

### Vector Operations
- Addition (`+`)  
- Subtraction (`-`)  
- Dot product (`Vector3.Dot`)  
- Cross product (`Vector3.Cross`)  

### Matrix Operations
- Identity matrix (`Matrix4.Identity`)  
- Scaling (`Matrix4.CreateScale`)  
- Rotation around Y-axis (`Matrix4.CreateRotationY`)  
- Applying a matrix to a vector (`Vector3.TransformPosition`)

## Sample Output

VECTOR OPERATIONS:

v1 = (2, -1, 5)
v2 = (-3, 4, 1)
v1 + v2 = (-1, 3, 6)
v1 - v2 = (5, -5, 4)
Dot(v1, v2) = -5
Cross(v1, v2) = (-21, -17, 5)

MATRIX OPERATIONS:

Identity Matrix:
(1, 0, 0, 0)
(0, 1, 0, 0)
(0, 0, 1, 0)
(0, 0, 0, 1)

Scaling Matrix (3,1,2):
(3, 0, 0, 0)
(0, 1, 0, 0)
(0, 0, 2, 0)
(0, 0, 0, 1)

Y-axis Rotation Matrix (60°):
(0.5, 0, -0.866, 0)
(0, 1, 0, 0)
(0.866, 0, 0.5, 0)
(0, 0, 0, 1)

Scaled v1 = (6, -1, 10)
Rotated v1 around Y-axis = (5.33, -1, 0.768)

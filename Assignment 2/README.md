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
<img width="441" height="501" alt="image" src="https://github.com/user-attachments/assets/9e483457-94f0-42dd-a617-ba4151a6d30d" />


It performs addition, subtraction, dot product, and cross product to show fundamental 3D vector calculations. Then, it creates an identity matrix, a scaling matrix, and a rotation matrix around the Y-axis, then applies these transformations to a sample vector.

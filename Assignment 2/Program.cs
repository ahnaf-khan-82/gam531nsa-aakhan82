using System;
using OpenTK.Mathematics;

class Program
{
    static void Main()
    {
        Console.WriteLine("VECTOR OPERATIONS:\n");

        Vector3 v1 = new Vector3(2, -1, 5);
        Vector3 v2 = new Vector3(-3, 4, 1);

        Console.WriteLine($"v1 = {v1}");
        Console.WriteLine($"v2 = {v2}");

        Vector3 add = v1 + v2;
        Vector3 sub = v1 - v2;

        float dot = Vector3.Dot(v1, v2);

        Vector3 cross = Vector3.Cross(v1, v2);

        Console.WriteLine($"v1 + v2 = {add}");
        Console.WriteLine($"v1 - v2 = {sub}");
        Console.WriteLine($"Dot(v1, v2) = {dot}");
        Console.WriteLine($"Cross(v1, v2) = {cross}");
        Console.WriteLine("\nMATRIX OPERATIONS:\n");

        Matrix4 identity = Matrix4.Identity;
        Matrix4 scale = Matrix4.CreateScale(3.0f, 1.0f, 2.0f);
        Matrix4 rotationY = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(60));
        Console.WriteLine("Identity Matrix:");
        PrintMatrix(identity);
        Console.WriteLine("\nScaling Matrix (3,1,2):");
        PrintMatrix(scale);
        Console.WriteLine("\nY-axis Rotation Matrix (60°):");
        PrintMatrix(rotationY);

        Vector3 scaledVector = Vector3.TransformPosition(v1, scale);
        Vector3 rotatedVector = Vector3.TransformPosition(v1, rotationY);

        Console.WriteLine($"\nScaled v1 = {scaledVector}");
        Console.WriteLine($"Rotated v1 around Y-axis = {rotatedVector}");
    }

    static void PrintMatrix(Matrix4 m)
    {
        Console.WriteLine($"({m.M11}, {m.M12}, {m.M13}, {m.M14})");
        Console.WriteLine($"({m.M21}, {m.M22}, {m.M23}, {m.M24})");
        Console.WriteLine($"({m.M31}, {m.M32}, {m.M33}, {m.M34})");
        Console.WriteLine($"({m.M41}, {m.M42}, {m.M43}, {m.M44})");
    }
}

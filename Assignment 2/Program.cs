using System;
using OpenTK.Mathematics;
using VectorMatrixLib;

class Program
{
    static void Main()
    {
        Console.WriteLine("VECTOR OPERATIONS:\n");

        Vector3 v1 = new Vector3(2, -1, 5);
        Vector3 v2 = new Vector3(-3, 4, 1);

        Console.WriteLine($"v1 = {v1}");
        Console.WriteLine($"v2 = {v2}");
        Console.WriteLine($"v1 + v2 = {VectorOperations.Add(v1, v2)}");
        Console.WriteLine($"v1 - v2 = {VectorOperations.Subtract(v1, v2)}");
        Console.WriteLine($"Dot(v1, v2) = {VectorOperations.Dot(v1, v2)}");
        Console.WriteLine($"Cross(v1, v2) = {VectorOperations.Cross(v1, v2)}");
        Console.WriteLine("\nMATRIX OPERATIONS:\n");

        Matrix4 identity = MatrixOperations.Identity();
        Matrix4 scale = MatrixOperations.Scale(3, 1, 2);
        Matrix4 rotateY = MatrixOperations.RotateY(60); // Y-axis rotation

        Console.WriteLine("Identity Matrix:");
        PrintMatrix(identity);
        Console.WriteLine("\nScaling Matrix (3,1,2):");
        PrintMatrix(scale);
        Console.WriteLine("\nY-axis Rotation Matrix (60°):");
        PrintMatrix(rotateY);

        Vector4 v1_4 = new Vector4(v1, 1);

        Vector4 scaledVector = MatrixOperations.Multiply(scale, v1_4);
        Vector4 rotatedVector = MatrixOperations.Multiply(rotateY, v1_4);

        Console.WriteLine($"\nScaled v1 = {scaledVector.X}, {scaledVector.Y}, {scaledVector.Z}");
        Console.WriteLine($"Rotated v1 around Y-axis = {rotatedVector.X}, {rotatedVector.Y}, {rotatedVector.Z}");
    }

    static void PrintMatrix(Matrix4 m)
    {
        Console.WriteLine($"({m.M11}, {m.M12}, {m.M13}, {m.M14})");
        Console.WriteLine($"({m.M21}, {m.M22}, {m.M23}, {m.M24})");
        Console.WriteLine($"({m.M31}, {m.M32}, {m.M33}, {m.M34})");
        Console.WriteLine($"({m.M41}, {m.M42}, {m.M43}, {m.M44})");
    }
}

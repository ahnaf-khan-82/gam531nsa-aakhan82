using System;
using OpenTK.Mathematics;

namespace VectorMatrixLib
{
    public static class MatrixOperations
    {
        public static Matrix4 Identity()
        {
            return Matrix4.Identity;
        }

        public static Matrix4 Scale(float sx, float sy, float sz)
        {
            return new Matrix4(
                sx, 0, 0, 0,
                 0, sy, 0, 0,
                 0, 0, sz, 0,
                 0, 0, 0, 1
            );
        }

        public static Matrix4 RotateY(float degrees)
        {
            float rad = MathHelper.DegreesToRadians(degrees);
            float cos = MathF.Cos(rad);
            float sin = MathF.Sin(rad);

            return new Matrix4(
                cos, 0, sin, 0,
                0, 1, 0, 0,
               -sin, 0, cos, 0,
                0, 0, 0, 1
            );
        }

        public static Vector4 Multiply(Matrix4 m, Vector4 v)
        {
            return m * v;
        }
    }
}

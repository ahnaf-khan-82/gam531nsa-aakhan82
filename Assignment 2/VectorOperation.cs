using System;
using OpenTK.Mathematics;

namespace VectorMatrixLib
{
    public static class VectorOperations
    {
        public static Vector3 Add(Vector3 v1, Vector3 v2)
        {
            return v1 + v2;
        }

        public static Vector3 Subtract(Vector3 v1, Vector3 v2)
        {
            return v1 - v2;
        }

        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return Vector3.Dot(v1, v2);
        }

        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return Vector3.Cross(v1, v2);
        }
    }
}

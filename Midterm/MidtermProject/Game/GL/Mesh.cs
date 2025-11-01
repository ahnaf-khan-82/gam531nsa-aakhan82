using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using GL = OpenTK.Graphics.OpenGL4.GL;

namespace MidtermProject
{
    public sealed class Mesh : IDisposable
    {
        public int VAO { get; private set; }
        private int _vbo, _ebo;
        private int _indexCount;

        private const int STRIDE_FLOATS = 8;

        private Mesh(float[] interleaved, uint[] indices, int strideFloats)
        {
            _indexCount = indices.Length;

            VAO = GL.GenVertexArray();
            _vbo = GL.GenBuffer();

            _ebo = GL.GenBuffer();

            GL.BindVertexArray(VAO);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer,

                interleaved.Length * sizeof(float),
                interleaved,
                BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                indices.Length * sizeof(uint),
                indices,
                BufferUsageHint.StaticDraw);

            int strideBytes = strideFloats * sizeof(float);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(
                index: 0,
                size: 3,
                type: VertexAttribPointerType.Float,
                normalized: false,

                stride: strideBytes,
                offset: 0);

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(
                index: 1,
                size: 3,
                type: VertexAttribPointerType.Float,
                normalized: false,
                stride: strideBytes,
                offset: 3 * sizeof(float));

            GL.EnableVertexAttribArray(2);

            GL.VertexAttribPointer(

                index: 2,
                size: 2,
                type: VertexAttribPointerType.Float,
                normalized: false,
                stride: strideBytes,
                offset: 6 * sizeof(float));

            GL.BindVertexArray(0);
        }

        public void Draw()
        {
            GL.BindVertexArray(VAO);
            GL.DrawElements(PrimitiveType.Triangles, _indexCount, DrawElementsType.UnsignedInt, 0);
        }

        public void Dispose()
        {
            if (VAO != 0) GL.DeleteVertexArray(VAO);
            if (_vbo != 0) GL.DeleteBuffer(_vbo);
            if (_ebo != 0) GL.DeleteBuffer(_ebo);
            VAO = _vbo = _ebo = 0;
        }

        private static void AddVertex(List<float> verts, Vector3 pos, Vector3 normal, Vector2 uv)
        {
            verts.Add(pos.X);
            verts.Add(pos.Y);
            verts.Add(pos.Z);

            verts.Add(normal.X);
            verts.Add(normal.Y);

            verts.Add(normal.Z);

            verts.Add(uv.X);
            verts.Add(uv.Y);
        }

        public static Mesh CreateUvSphere(float radius, int lonSegments = 64, int latSegments = 32)
        {
            var verts = new List<float>();
            var inds = new List<uint>();

            for (int y = 0; y <= latSegments; y++)
            {
                float v = y / (float)latSegments;   
                float phi = MathHelper.Pi * v;       

                float cosPhi = MathF.Cos(phi);

                float sinPhi = MathF.Sin(phi);

                for (int x = 0; x <= lonSegments; x++)
                {
                    float u = x / (float)lonSegments;
                    float theta = MathHelper.TwoPi * u;
                    float cosTheta = MathF.Cos(theta);
                    float sinTheta = MathF.Sin(theta);

                    float nx = sinPhi * cosTheta;
                    float ny = cosPhi;
                    float nz = sinPhi * sinTheta;

                    Vector3 normal = new Vector3(nx, ny, nz);

                    Vector3 pos = normal * radius;

                    if (y == 0 || y == latSegments)
                    {
                        u = 0.5f;
                    }

                    Vector2 uv = new Vector2(u, v);

                    AddVertex(verts, pos, normal, uv);
                }
            }

            uint stride = (uint)(lonSegments + 1);
            for (uint y = 0; y < latSegments; y++)
            {
                for (uint x = 0; x < lonSegments; x++)
                {
                    uint i0 = y * stride + x;
                    uint i1 = (y + 1) * stride + x;
                    uint i2 = (y + 1) * stride + (x + 1);

                    uint i3 = y * stride + (x + 1);


                    inds.Add(i0);
                    inds.Add(i1);
                    inds.Add(i2);


                    inds.Add(i0);
                    inds.Add(i2);
                    inds.Add(i3);
                }
            }

            return new Mesh(verts.ToArray(), inds.ToArray(), STRIDE_FLOATS);
        }

        public static Mesh CreateRing(float innerRadius, float outerRadius, int segments)
        {
            var verts = new List<float>();
            var inds = new List<uint>();

            for (int i = 0; i <= segments; i++)
            {
                float t = i / (float)segments;
                float angle = t * MathHelper.TwoPi;
                float cosA = MathF.Cos(angle);
                float sinA = MathF.Sin(angle);

                {
                    Vector3 pos = new Vector3(
                        innerRadius * cosA,
                        0f,
                        innerRadius * sinA
                    );

                    Vector3 normal = new Vector3(0f, 1f, 0f); 
                    Vector2 uv = new Vector2(t, 0f);     

                    AddVertex(verts, pos, normal, uv);
                }

                {
                    Vector3 pos = new Vector3(
                        outerRadius * cosA,
                        0f,
                        outerRadius * sinA
                    );

                    Vector3 normal = new Vector3(0f, 1f, 0f);
                    Vector2 uv = new Vector2(t, 1f);   

                    AddVertex(verts, pos, normal, uv);
                }
            }

            for (int i = 0; i < segments; i++)
            {
                uint i0 = (uint)(i * 2);
                uint i1 = (uint)(i * 2 + 1);
                uint i2 = (uint)((i + 1) * 2);
                uint i3 = (uint)((i + 1) * 2 + 1);

                inds.Add(i0);
                inds.Add(i1);
                inds.Add(i2);


                inds.Add(i1);
                inds.Add(i3);
                inds.Add(i2);
            }

            return new Mesh(verts.ToArray(), inds.ToArray(), STRIDE_FLOATS);
        }

        public static Mesh CreateSkyCube(float size = 60f)
        {
            var verts = new List<float>();
            var inds = new List<uint>();

            float s = size;

            void AddFace(
                Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, 
                Vector3 normal,
                Vector2 uv0, Vector2 uv1, Vector2 uv2, Vector2 uv3)
            {

                uint baseIndex = (uint)(verts.Count / STRIDE_FLOATS);


                AddVertex(verts, p0, normal, uv0); 
                AddVertex(verts, p1, normal, uv1); 
                AddVertex(verts, p2, normal, uv2); 
                AddVertex(verts, p3, normal, uv3); 


                inds.Add(baseIndex + 0);
                inds.Add(baseIndex + 1);
                inds.Add(baseIndex + 2);

                inds.Add(baseIndex + 0);
                inds.Add(baseIndex + 2);
                inds.Add(baseIndex + 3);
            }


            AddFace(
                new Vector3(-s, -s, s),
                new Vector3(s, -s, s),

                new Vector3(s, s, s),
                new Vector3(-s, s, s),
                new Vector3(0f, 0f, -1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f),
                new Vector2(1f, 1f),
                new Vector2(0f, 1f)
            );


            AddFace(
                new Vector3(s, -s, -s),
                new Vector3(-s, -s, -s),
                new Vector3(-s, s, -s),
                new Vector3(s, s, -s),
                new Vector3(0f, 0f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f),

                new Vector2(1f, 1f),
                new Vector2(0f, 1f)
            );


            AddFace(
                new Vector3(-s, -s, -s),
                new Vector3(-s, -s, s),
                new Vector3(-s, s, s),
                new Vector3(-s, s, -s),

                new Vector3(1f, 0f, 0f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f),
                new Vector2(1f, 1f),

                new Vector2(0f, 1f)
            );


            AddFace(
                new Vector3(s, -s, s),
                new Vector3(s, -s, -s),
                new Vector3(s, s, -s),
                new Vector3(s, s, s),
                new Vector3(-1f, 0f, 0f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f),
                new Vector2(1f, 1f),
                new Vector2(0f, 1f)
            );

            AddFace(
                new Vector3(-s, -s, -s),
                new Vector3(s, -s, -s),
                new Vector3(s, -s, s),
                new Vector3(-s, -s, s),

                new Vector3(0f, 1f, 0f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f),
                new Vector2(1f, 1f),
                new Vector2(0f, 1f)
            );


            AddFace(
                new Vector3(-s, s, s),
                new Vector3(s, s, s),
                new Vector3(s, s, -s),

                new Vector3(-s, s, -s),
                new Vector3(0f, -1f, 0f),
                new Vector2(0f, 0f),

                new Vector2(1f, 0f),
                new Vector2(1f, 1f),
                new Vector2(0f, 1f)
            );

            return new Mesh(verts.ToArray(), inds.ToArray(), STRIDE_FLOATS);
        }
    }
}

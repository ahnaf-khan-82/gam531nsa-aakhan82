using System;
using System.IO;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using GL = OpenTK.Graphics.OpenGL4.GL;

namespace MidtermProject
{
    public class Shader : IDisposable
    {
        public int Handle { get; private set; }

        public Shader(string vertexPath, string fragmentPath)
        {
            string vertexSource = File.ReadAllText(vertexPath);
            string fragmentSource = File.ReadAllText(fragmentPath);


            int vs = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vs, vertexSource);
            GL.CompileShader(vs);

            CheckCompileErrors(vs, "VERTEX");

            int fs = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fs, fragmentSource);
            GL.CompileShader(fs);
            CheckCompileErrors(fs, "FRAGMENT");


            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vs);
            GL.AttachShader(Handle, fs);

            GL.LinkProgram(Handle);
            CheckLinkErrors(Handle);


            GL.DetachShader(Handle, vs);

            GL.DetachShader(Handle, fs);
            GL.DeleteShader(vs);
            GL.DeleteShader(fs);

        }

        public void Use() => GL.UseProgram(Handle);

        private static void CheckCompileErrors(int shader, string stage)
        {
            GL.GetShader(shader, ShaderParameter.CompileStatus, out int ok);
            if (ok == 0)
            {
                var log = GL.GetShaderInfoLog(shader);
                Console.WriteLine($"[Shader {stage}] {log}");
            }
        }

        private static void CheckLinkErrors(int program)
        {
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out int ok);
            if (ok == 0)
            {
                var log = GL.GetProgramInfoLog(program);
                Console.WriteLine($"[Program Link] {log}");
            }
        }

        public void SetInt(string name, int v)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            GL.Uniform1(loc, v);
        }

        public void SetFloat(string name, float v)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            GL.Uniform1(loc, v);
        }

        public void SetVec3(string name, Vector3 v)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            GL.Uniform3(loc, v);
        }

        public void SetMat4(string name, Matrix4 m)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            GL.UniformMatrix4(loc, false, ref m);
        }

        public void Dispose()
        {
            if (Handle != 0)
            {
                GL.DeleteProgram(Handle);
                Handle = 0;
            }
        }
    }
}

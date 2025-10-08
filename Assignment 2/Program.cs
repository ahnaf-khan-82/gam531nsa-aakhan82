using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace WindowOpenTK
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            using var game = new Game();
            game.Run();
        }
    }

    public sealed class Game : GameWindow
    {

        private int _vao, _vbo, _program;
        private int _uModel, _uView, _uProj, _uColor;
        private float _t;

        private static readonly float[] Vert = {
            -0.25f,  0.60f, 0f,
            -0.25f, -0.60f, 0f,
             0.25f,  0.60f, 0f,
             0.25f, -0.60f, 0f
        };

        public Game()
        : base(GameWindowSettings.Default, new NativeWindowSettings
        {
            Title = "Assignment 2",
            Size = new Vector2i(960, 720)
        })
        { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(1.0f, 182f / 255f, 193f / 255f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            _program = CreateProgram(
                @"#version 330 core
                  layout(location=0) in vec3 aPos;
                  uniform mat4 uModel, uView, uProj;
                  void main() {
                    gl_Position = uProj * uView * uModel * vec4(aPos, 1.0);
                  }",
                @"#version 330 core
                  uniform vec4 uColor;
                  out vec4 FragColor;
                  void main() { FragColor = uColor; }"
            );

            _uModel = GL.GetUniformLocation(_program, "uModel");
            _uView = GL.GetUniformLocation(_program, "uView");
            _uProj = GL.GetUniformLocation(_program, "uProj");
            _uColor = GL.GetUniformLocation(_program, "uColor");
            _vao = GL.GenVertexArray();
            _vbo = GL.GenBuffer();

            GL.BindVertexArray(_vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, Vert.Length * sizeof(float), Vert, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.Escape)) Close();
            _t += (float)args.Time;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.UseProgram(_program);
            GL.BindVertexArray(_vao);
            GL.Uniform4(_uColor, new Vector4(0f, 0f, 1f, 1f));


            float aspect = Size.X / (float)Size.Y;
            Matrix4 view = Matrix4.LookAt(new Vector3(0, 0, 3), Vector3.Zero, Vector3.UnitY);
            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60f), aspect, 0.1f, 100f);


            GL.UniformMatrix4(_uView, false, ref view);
            GL.UniformMatrix4(_uProj, false, ref proj);


            float angle = MathHelper.DegreesToRadians(90f) * _t;
            float scale = 1.0f + 0.20f * MathF.Sin(MathF.Tau * 1.0f * _t);
            Matrix4 model = Matrix4.CreateScale(scale) * Matrix4.CreateRotationY(angle);

            GL.UniformMatrix4(_uModel, false, ref model);
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
            GL.BindVertexArray(0);
            SwapBuffers();
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            if (_vbo != 0) GL.DeleteBuffer(_vbo);
            if (_vao != 0) GL.DeleteVertexArray(_vao);
            if (_program != 0) GL.DeleteProgram(_program);
        }

        private static int CreateProgram(string vsSrc, string fsSrc)
        {
            int vs = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vs, vsSrc);
            GL.CompileShader(vs);
            GL.GetShader(vs, ShaderParameter.CompileStatus, out var okV);
            
            if (okV == 0) throw new Exception("Vertex shader: " + GL.GetShaderInfoLog(vs));

            int fs = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(fs, fsSrc);
            GL.CompileShader(fs);
            GL.GetShader(fs, ShaderParameter.CompileStatus, out var okF);

            if (okF == 0) throw new Exception("Fragment shader: " + GL.GetShaderInfoLog(fs));
            int prog = GL.CreateProgram();

            GL.AttachShader(prog, vs);
            GL.AttachShader(prog, fs);
            GL.LinkProgram(prog);
            GL.GetProgram(prog, GetProgramParameterName.LinkStatus, out var okP);
            GL.DetachShader(prog, vs);
            GL.DetachShader(prog, fs);
            GL.DeleteShader(vs);
            GL.DeleteShader(fs);
            
            if (okP == 0) throw new Exception("Program link: " + GL.GetProgramInfoLog(prog));
            return prog;
        }
    }
}

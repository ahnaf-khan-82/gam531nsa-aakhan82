using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

class CubeWindow : GameWindow
{
    private float _rotation = 0.0f;

    private int _vbo;
    private int _vao;
    private int _ebo;
    private int _shaderProgram;

    private readonly float[] _vertices =
    {
        -0.5f, -0.5f, -0.5f, 
         0.5f, -0.5f, -0.5f, 
         0.5f,  0.5f, -0.5f, 
        -0.5f,  0.5f, -0.5f,
        -0.5f, -0.5f,  0.5f, 
         0.5f, -0.5f,  0.5f, 
         0.5f,  0.5f,  0.5f, 
        -0.5f,  0.5f,  0.5f  
    };

    private readonly uint[] _indices =
    {
        0,1,2, 2,3,0, 
        4,5,6, 6,7,4, 
        0,4,7, 7,3,0, 
        1,5,6, 6,2,1, 
        3,2,6, 6,7,3, 
        0,1,5, 5,4,0  
    };

    public CubeWindow(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) { }

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor(1.0f, 0.75f, 0.8f, 1.0f);
        GL.Enable(EnableCap.DepthTest);

        _vao = GL.GenVertexArray();
        _vbo = GL.GenBuffer();
        _ebo = GL.GenBuffer();

        GL.BindVertexArray(_vao);
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        string vertexShaderSrc = @"
            #version 330 core
            layout (location = 0) in vec3 aPosition;
            uniform mat4 model;
            uniform mat4 view;
            uniform mat4 projection;
            void main()
            {
                gl_Position = projection * view * model * vec4(aPosition, 1.0);
            }
        ";
        string fragmentShaderSrc = @"
            #version 330 core
            out vec4 FragColor;
            void main()
            {
                // Cube color = blue
                FragColor = vec4(0.2, 0.3, 1.0, 1.0);
            }
        ";

        int vertexShader = GL.CreateShader(ShaderType.VertexShader);

        GL.ShaderSource(vertexShader, vertexShaderSrc);
        GL.CompileShader(vertexShader);

        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);

        GL.ShaderSource(fragmentShader, fragmentShaderSrc);
        GL.CompileShader(fragmentShader);

        _shaderProgram = GL.CreateProgram();

        GL.AttachShader(_shaderProgram, vertexShader);
        GL.AttachShader(_shaderProgram, fragmentShader);
        GL.LinkProgram(_shaderProgram);
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.UseProgram(_shaderProgram);

        _rotation += 1.0f * (float)args.Time;
        Matrix4 model = Matrix4.CreateRotationY(_rotation);

        Matrix4 view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);

        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
            MathHelper.DegreesToRadians(45f),
            Size.X / (float)Size.Y,
            0.1f,
            100f
        );

        int modelLoc = GL.GetUniformLocation(_shaderProgram, "model");
        int viewLoc = GL.GetUniformLocation(_shaderProgram, "view");
        int projLoc = GL.GetUniformLocation(_shaderProgram, "projection");

        GL.UniformMatrix4(modelLoc, false, ref model);
        GL.UniformMatrix4(viewLoc, false, ref view);
        GL.UniformMatrix4(projLoc, false, ref projection);

        GL.BindVertexArray(_vao);
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

        SwapBuffers();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
        GL.DeleteBuffer(_vbo);
        GL.DeleteBuffer(_ebo);
        GL.DeleteVertexArray(_vao);
        GL.DeleteProgram(_shaderProgram);
    }
}

class Program
{
    static void Main()
    {
        var gws = GameWindowSettings.Default;
        var nws = new NativeWindowSettings()
        {
            Size = new Vector2i(800, 600),
            Title = "Assignment 3 - Rotating Blue Cube on Pink Background"
        };

        using (var window = new CubeWindow(gws, nws))
        {
            window.Run();
        }
    }
}

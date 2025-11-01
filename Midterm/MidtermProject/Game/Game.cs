using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using GL = OpenTK.Graphics.OpenGL4.GL;

namespace MidtermProject
{
    public sealed class SpacePodGame : GameWindow
    {
        private Shader _shader = null!;
        private FpsCamera _cam = null!;

        private Mesh _sphere = null!;
        private Mesh _skyCube = null!;
        private Mesh _saturnRingMesh = null!;

        private Texture _sunTex = null!;
        private Texture _mercuryTex = null!;
        private Texture _venusTex = null!;
        private Texture _earthTex = null!;
        private Texture _moonTex = null!;
        private Texture _marsTex = null!;
        private Texture _jupiterTex = null!;
        private Texture _saturnTex = null!;
        private Texture _uranusTex = null!;
        private Texture _neptuneTex = null!;
        private Texture _plutoTex = null!;
        private Texture _spaceTex = null!;

        private float _sunSelfDeg = 0f;

        private float _mercuryOrbitDeg = 0f;
        private float _mercurySelfDeg = 0f;

        private float _venusOrbitDeg = 0f;
        private float _venusSelfDeg = 0f;

        private float _earthOrbitDeg = 0f;
        private float _earthSpinDeg = 0f;

        private float _moonOrbitDeg = 0f;
        private float _moonSelfDeg = 0f;

        private float _marsOrbitDeg = 0f;
        private float _marsSelfDeg = 0f;

        private float _jupiterOrbitDeg = 0f;
        private float _jupiterSelfDeg = 0f;

        private float _saturnOrbitDeg = 0f;
        private float _saturnSelfDeg = 0f;

        private float _uranusOrbitDeg = 0f;
        private float _uranusSelfDeg = 0f;

        private float _neptuneOrbitDeg = 0f;
        private float _neptuneSelfDeg = 0f;

        private float _plutoOrbitDeg = 0f;
        private float _plutoSelfDeg = 0f;

        private bool _orbitsPaused = false;
        private bool _eWasDown = false;

        private bool _firstMouse = true;
        private Vector2 _lastMouse;
        private float _mouseSensitivity = 0.12f;

        public SpacePodGame(GameWindowSettings gws, NativeWindowSettings nws)
            : base(gws, nws)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            VSync = VSyncMode.On;

            GL.Enable(EnableCap.DepthTest);

            GL.ClearColor(0.02f, 0.02f, 0.05f, 1f);

            _shader = new Shader("Shaders/vertex.glsl", "Shaders/fragment.glsl");

            _cam = new FpsCamera(
                new Vector3(0f, 1.2f, 3.5f),
                Size.X / (float)Size.Y
            );

            CursorState = CursorState.Grabbed;

            _sphere = Mesh.CreateUvSphere(1.0f, 64, 32);
            _skyCube = Mesh.CreateSkyCube(60f);
            _saturnRingMesh = Mesh.CreateRing(1.3f, 2.1f, 64);

            _sunTex = Texture.FromFile("Assets/sun.jpg", true);
            _mercuryTex = Texture.FromFile("Assets/mercury.jpg", true);

            _venusTex = Texture.FromFile("Assets/venus.jpg", true);
            _earthTex = Texture.FromFile("Assets/earth.jpg", true);
            _moonTex = Texture.FromFile("Assets/moon.jpg", true);

            _marsTex = Texture.FromFile("Assets/mars.jpg", true);

            _jupiterTex = Texture.FromFile("Assets/jupiter.jpg", true);
            _saturnTex = Texture.FromFile("Assets/saturn.jpg", true);
            _uranusTex = Texture.FromFile("Assets/uranus.jpg", true);

            _neptuneTex = Texture.FromFile("Assets/neptune.jpg", true);
            _plutoTex = Texture.FromFile("Assets/pluto.jpg", true);
            _spaceTex = Texture.FromFile("Assets/space.jpg", true);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (!IsFocused) return;

            var kb = KeyboardState;

            if (kb.IsKeyDown(Keys.Escape))
            {
                CursorState = CursorState == CursorState.Grabbed
                    ? CursorState.Normal

                    : CursorState.Grabbed;

                _firstMouse = true;
            }

            bool eDown = kb.IsKeyDown(Keys.E);
            if (eDown && !_eWasDown)
            {
                _orbitsPaused = !_orbitsPaused;
            }
            _eWasDown = eDown;

            float dt = (float)e.Time;
            float moveSpeed = kb.IsKeyDown(Keys.LeftShift) ? 8f : 4f;

            if (kb.IsKeyDown(Keys.W)) _cam.Position += _cam.Forward * moveSpeed * dt;
            if (kb.IsKeyDown(Keys.S)) _cam.Position -= _cam.Forward * moveSpeed * dt;
            if (kb.IsKeyDown(Keys.A)) _cam.Position -= _cam.Right * moveSpeed * dt;

            if (kb.IsKeyDown(Keys.D)) _cam.Position += _cam.Right * moveSpeed * dt;

            if (kb.IsKeyDown(Keys.Space)) _cam.Position += _cam.Up * moveSpeed * dt;
            if (kb.IsKeyDown(Keys.LeftControl)) _cam.Position -= _cam.Up * moveSpeed * dt;

            if (CursorState == CursorState.Grabbed)
            {
                var m = MouseState;
                if (_firstMouse)
                {
                    _lastMouse = new Vector2(m.X, m.Y);
                    _firstMouse = false;
                }

                float dx = m.X - _lastMouse.X;
                float dy = m.Y - _lastMouse.Y;
                _lastMouse = new Vector2(m.X, m.Y);

                _cam.AddYawPitch(dx * _mouseSensitivity, -dy * _mouseSensitivity);
            }

            _sunSelfDeg += 5f * dt;

            _mercurySelfDeg += 50f * dt;
            _venusSelfDeg += 30f * dt;
            _earthSpinDeg += 40f * dt;
            _marsSelfDeg += 30f * dt;
            _jupiterSelfDeg += 20f * dt;
            _saturnSelfDeg += 15f * dt;
            _uranusSelfDeg += 10f * dt;
            _neptuneSelfDeg += 8f * dt;
            _plutoSelfDeg += 12f * dt;

            _moonSelfDeg += 40f * dt; 


            if (!_orbitsPaused)
            {
               
                float mercurySpeed = 60f * dt;
                float venusSpeed = 50f * dt;

                float earthSpeed = 40f * dt;

                float marsSpeed = 32f * dt;
                float jupiterSpeed = 20f * dt;
                float saturnSpeed = 16f * dt;
                float uranusSpeed = 12f * dt;

                float neptuneSpeed = 10f * dt;

                float plutoSpeed = 8f * dt;

                float moonOrbitSpeed = 90f * dt; 

                _mercuryOrbitDeg += mercurySpeed;
                _venusOrbitDeg += venusSpeed;
                _earthOrbitDeg += earthSpeed;
                _marsOrbitDeg += marsSpeed;
                _jupiterOrbitDeg += jupiterSpeed;
                _saturnOrbitDeg += saturnSpeed;
                _uranusOrbitDeg += uranusSpeed;
                _neptuneOrbitDeg += neptuneSpeed;
                _plutoOrbitDeg += plutoSpeed;


                _moonOrbitDeg += moonOrbitSpeed;
            }
        }


        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _cam.Fov -= e.OffsetY;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            _cam.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _shader.Use();
            _shader.SetMat4("uView", _cam.ViewMatrix);
            _shader.SetMat4("uProjection", _cam.ProjectionMatrix);
            _shader.SetVec3("uViewPos", _cam.Position);


            _shader.SetVec3("lightDir", new Vector3(-0.4f, -0.6f, -0.7f));

            _shader.SetVec3("lightAmbient", new Vector3(0.15f, 0.15f, 0.15f));

            _shader.SetVec3("lightDiffuse", new Vector3(1.0f, 1.0f, 1.0f));
            _shader.SetVec3("lightSpecular", new Vector3(1.0f, 1.0f, 1.0f));
            _shader.SetFloat("uShininess", 8f);

            GL.DepthMask(false);

            UseTexture0();
            SetInt("uUseTexture", 1);
            SetInt("uUnlit", 1);
            _shader.SetVec3("uTint", Vector3.One);

            _spaceTex.Bind(TextureUnit.Texture0);

            var skyModel = Matrix4.CreateTranslation(_cam.Position);
            _shader.SetMat4("uModel", skyModel);
            _skyCube.Draw();

            GL.DepthMask(true);

            Vector3 systemCenter = new Vector3(0f, 0f, -6f);
            Vector3 OrbitXZ(float radius, float deg, float y = 0f)
            {
                float r = MathHelper.DegreesToRadians(deg);
                return new Vector3(
                    radius * MathF.Cos(r),
                    y,
                    radius * MathF.Sin(r)
                );
            }

            // SUN

            {
                UseTexture0();
                SetInt("uUseTexture", 1);

                SetInt("uUnlit", 1);
                _shader.SetVec3("uTint", new Vector3(1.5f, 1.2f, 0.6f));

                _sunTex.Bind(TextureUnit.Texture0);

                var sunModel =
                    Matrix4.CreateScale(3.0f) *

                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_sunSelfDeg)) *
                    Matrix4.CreateTranslation(systemCenter);

                _shader.SetMat4("uModel", sunModel);
                _sphere.Draw();
            }


            SetInt("uUnlit", 0);
            _shader.SetVec3("uTint", Vector3.One);

            float mercuryRad = 4f;
            float venusRad = 6f;
            float earthRad = 8f;

            float marsRad = 10f;

            float jupiterRad = 14f;
            float saturnRad = 18f;
            float uranusRad = 22f;
            float neptuneRad = 26f;

            float plutoRad = 30f;

            //MERCURY
            {
                Vector3 worldPos = systemCenter + OrbitXZ(mercuryRad, _mercuryOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);

                _shader.SetVec3("uTint", Vector3.One);

                _mercuryTex.Bind(TextureUnit.Texture0);

                var model =
                    Matrix4.CreateScale(0.15f) *

                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_mercurySelfDeg)) *
                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", model);
                _sphere.Draw();
            }

            //VENUS
            {
                Vector3 worldPos = systemCenter + OrbitXZ(venusRad, _venusOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);

                _shader.SetVec3("uTint", Vector3.One);


                _venusTex.Bind(TextureUnit.Texture0);

                var model =
                    Matrix4.CreateScale(0.30f) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_venusSelfDeg)) *

                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", model);
                _sphere.Draw();
            }

            //EARTH
            Vector3 earthWorldPos;
            {
                earthWorldPos = systemCenter + OrbitXZ(earthRad, _earthOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);
                _shader.SetVec3("uTint", Vector3.One);

                _earthTex.Bind(TextureUnit.Texture0);

                var earthModel =
                    Matrix4.CreateScale(0.32f) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_earthSpinDeg)) *
                    Matrix4.CreateTranslation(earthWorldPos);

                _shader.SetMat4("uModel", earthModel);
                _sphere.Draw();
            }

            //MOON
            {

                float moonOrbitRad = 0.8f;
                Vector3 moonLocal = OrbitXZ(moonOrbitRad, _moonOrbitDeg, 0.1f);

                Vector3 moonWorldPos = earthWorldPos + moonLocal;

                UseTexture0();
                SetInt("uUseTexture", 1);
                _shader.SetVec3("uTint", Vector3.One);

                _moonTex.Bind(TextureUnit.Texture0);

                var moonModel =
                    Matrix4.CreateScale(0.08f) * 

                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_moonSelfDeg)) *
                    Matrix4.CreateTranslation(moonWorldPos);

                _shader.SetMat4("uModel", moonModel);
                _sphere.Draw();
            }

            //MARS
            {
                Vector3 worldPos = systemCenter + OrbitXZ(marsRad, _marsOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);
                _shader.SetVec3("uTint", Vector3.One);

                _marsTex.Bind(TextureUnit.Texture0);

                var model =
                    Matrix4.CreateScale(0.25f) *

                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_marsSelfDeg)) *
                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", model);
                _sphere.Draw();
            }

            //JUPITER
            {
                Vector3 worldPos = systemCenter + OrbitXZ(jupiterRad, _jupiterOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);
                _shader.SetVec3("uTint", Vector3.One);


                _jupiterTex.Bind(TextureUnit.Texture0);

                var model =

                    Matrix4.CreateScale(1.5f) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_jupiterSelfDeg)) *
                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", model);
                _sphere.Draw();
            }

            //SATURN
            {
                Vector3 worldPos = systemCenter + OrbitXZ(saturnRad, _saturnOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);
                _shader.SetVec3("uTint", Vector3.One);

                _saturnTex.Bind(TextureUnit.Texture0);

                var saturnModel =
                    Matrix4.CreateScale(1.2f) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_saturnSelfDeg)) *
                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", saturnModel);
                _sphere.Draw();

                //RING MESH

                _saturnTex.Bind(TextureUnit.Texture0);

                var ringModel =
                    Matrix4.CreateRotationX(MathHelper.DegreesToRadians(20f)) *

                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", ringModel);
                _saturnRingMesh.Draw();
            }



            //URANUS
            {
                Vector3 worldPos = systemCenter + OrbitXZ(uranusRad, _uranusOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);
                _shader.SetVec3("uTint", Vector3.One);

                _uranusTex.Bind(TextureUnit.Texture0);

                var model =
                    Matrix4.CreateScale(0.8f) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_uranusSelfDeg)) *
                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", model);
                _sphere.Draw();
            }

            //NEPTUNE
            {
                Vector3 worldPos = systemCenter + OrbitXZ(neptuneRad, _neptuneOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);

                _shader.SetVec3("uTint", Vector3.One);

                _neptuneTex.Bind(TextureUnit.Texture0);

                var model =
                    Matrix4.CreateScale(0.8f) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_neptuneSelfDeg)) *

                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", model);
                _sphere.Draw();
            }

            //PLUTO
            {
                Vector3 worldPos = systemCenter + OrbitXZ(plutoRad, _plutoOrbitDeg);

                UseTexture0();
                SetInt("uUseTexture", 1);
                _shader.SetVec3("uTint", Vector3.One);

                _plutoTex.Bind(TextureUnit.Texture0);

                var model =
                    Matrix4.CreateScale(0.07f) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_plutoSelfDeg)) *
                    Matrix4.CreateTranslation(worldPos);

                _shader.SetMat4("uModel", model);
                _sphere.Draw();
            }

            SwapBuffers();
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            _sphere?.Dispose();
            _skyCube?.Dispose();
            _saturnRingMesh?.Dispose();

            _sunTex?.Dispose();
            _mercuryTex?.Dispose();
            _venusTex?.Dispose();

            _earthTex?.Dispose();
            _moonTex?.Dispose();

            _marsTex?.Dispose();
            _jupiterTex?.Dispose();
            _saturnTex?.Dispose();
            _uranusTex?.Dispose();
            _neptuneTex?.Dispose();

            _plutoTex?.Dispose();
            _spaceTex?.Dispose();

            _shader?.Dispose();
        }

        private void UseTexture0()
        {
            int loc = GL.GetUniformLocation(_shader.Handle, "uTexture0");
            GL.Uniform1(loc, 0);
        }
        private void SetInt(string name, int v)
        {
            int loc = GL.GetUniformLocation(_shader.Handle, name);
            GL.Uniform1(loc, v);
        }
    }
}

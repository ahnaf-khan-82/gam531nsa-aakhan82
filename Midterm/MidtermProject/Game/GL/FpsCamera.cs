using OpenTK.Mathematics;

namespace MidtermProject
{
    public class FpsCamera
    {
        public Vector3 Position;
        public float Yaw = -90f;

        public float Pitch = 0f;

        public float Fov = 60f;
        public float AspectRatio;

        public FpsCamera(Vector3 startPos, float aspectRatio)
        {
            Position = startPos;

            AspectRatio = aspectRatio;
        }


        public Vector3 Forward
        {
            get
            {
                Vector3 dir;
                dir.X = MathF.Cos(MathHelper.DegreesToRadians(Yaw)) * MathF.Cos(MathHelper.DegreesToRadians(Pitch));

                dir.Y = MathF.Sin(MathHelper.DegreesToRadians(Pitch));
                dir.Z = MathF.Sin(MathHelper.DegreesToRadians(Yaw)) * MathF.Cos(MathHelper.DegreesToRadians(Pitch));

                return Vector3.Normalize(dir);
            }
        }

        public Vector3 Right => Vector3.Normalize(Vector3.Cross(Forward, Vector3.UnitY));
        public Vector3 Up => Vector3.Normalize(Vector3.Cross(Right, Forward));



        public Matrix4 ViewMatrix => Matrix4.LookAt(Position, Position + Forward, Vector3.UnitY);
        public Matrix4 ProjectionMatrix => Matrix4.CreatePerspectiveFieldOfView(
            MathHelper.DegreesToRadians(Fov), AspectRatio, 0.1f, 100f);

        public void AddYawPitch(float deltaYaw, float deltaPitch)
        {
            Yaw += deltaYaw;
            Pitch += deltaPitch;
            Pitch = MathHelper.Clamp(Pitch, -89f, 89f);
        }
    }
}

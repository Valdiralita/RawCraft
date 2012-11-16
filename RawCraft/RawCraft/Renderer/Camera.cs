using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RawCraft.Storage;

namespace RawCraft.Renderer
{
    class Camera
    {
        public Matrix ViewMatrix, ProjectionMatrix;
        Matrix rotationMatrix;
        Vector3 CameraPosition;
        float rotateSpeed, moveSpeed;
        int centerX, centerY;

        public Camera(float mSpeed, float rSpeed, GraphicsDevice device)
        {
            CameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);
            moveSpeed = mSpeed;
            rotateSpeed = rSpeed;

            ViewMatrix = Matrix.CreateLookAt(CameraPosition, Vector3.Zero, Vector3.Forward);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60f), device.Viewport.AspectRatio, 0.3f, 10000f);
            centerX = device.Viewport.Width / 2;
            centerY = device.Viewport.Height / 2;
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.W))
            {
                Vector3 v = new Vector3(0, 0, -1) * moveSpeed;
                moveCamera(v);
            }
            if (kState.IsKeyDown(Keys.S))
            {
                Vector3 v = new Vector3(0, 0, 1) * moveSpeed;
                moveCamera(v);
            }
            if (kState.IsKeyDown(Keys.A))
            {
                Vector3 v = new Vector3(-1, 0, 0) * moveSpeed;
                moveCamera(v);
            }
            if (kState.IsKeyDown(Keys.D))
            {
                Vector3 v = new Vector3(1, 0, 0) * moveSpeed;
                moveCamera(v);
            }
            if (kState.IsKeyDown(Keys.Q))
            {
                Vector3 v = new Vector3(0, -1, 0) * moveSpeed;
                moveCamera(v);
            }
            if (kState.IsKeyDown(Keys.E))
            {
                Vector3 v = new Vector3(0, 1, 0) * moveSpeed;
                moveCamera(v);
            }

            MouseState mState = Mouse.GetState();

            Player.Yaw -= rotateSpeed * (mState.X - centerX);
            Player.Pitch -= rotateSpeed * (mState.Y - centerY);

            if (Math.Abs(Player.Pitch) > Math.PI / 2 - 0.001)
                Player.Pitch = (float)((Math.PI / 2 - 0.001) * Math.Sign(Player.Pitch)); // just Math.PI / 2 makes the world invisible at max and min pitch

            if (Math.Abs(Player.Yaw) >= Math.PI)
                Player.Yaw -= 2 * (float)(Math.PI * Math.Sign(Player.Yaw));

            UpdateMatrices();
            ResetMousePos();
            CameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);
        }

        private void ResetMousePos()
        {
            Mouse.SetPosition(centerX, centerY);
        }

        private void UpdateMatrices()
        {
            rotationMatrix = Matrix.CreateRotationX(Player.Pitch) * Matrix.CreateRotationY(Player.Yaw);
            Vector3 TransformedReference = Vector3.Transform(new Vector3(0, 0, -1), rotationMatrix); // 0 0 -1
            Vector3 lookAt = TransformedReference + CameraPosition;
            ViewMatrix = Matrix.CreateLookAt(CameraPosition, lookAt, Vector3.Up);
        }

        private void moveCamera(Vector3 v)
        {
            v = Vector3.Transform(v, rotationMatrix);
            Player.X = Player.X + v.X;
            Player.Y = Player.Y + v.Y;
            Player.Stance = Player.Y + 1.62f;
            Player.Z = Player.Z + v.Z;

            CameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);
        }
    }
}

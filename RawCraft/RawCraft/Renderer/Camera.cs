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
        Matrix _rotationMatrix;
        Vector3 _cameraPosition;
        readonly float _rotateSpeed, _moveSpeed;
        int _centerX, _centerY;
        public BoundingFrustum _viewFrustum { get; private set; }

        public Camera(float mSpeed, float rSpeed, GraphicsDevice device)
        {
            _cameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);
            _moveSpeed = mSpeed;
            _rotateSpeed = rSpeed;

            ViewMatrix = Matrix.CreateLookAt(_cameraPosition, Vector3.Zero, Vector3.Forward);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60f), device.Viewport.AspectRatio, 0.3f, 10000f);
            _centerX = device.Viewport.Width / 2;
            _centerY = device.Viewport.Height / 2;

            _viewFrustum = new BoundingFrustum(ViewMatrix * ProjectionMatrix);
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.W))
            {
                Vector3 v = new Vector3(0, 0, -1) * _moveSpeed;
                MoveCamera(v);
            }
            if (kState.IsKeyDown(Keys.S))
            {
                Vector3 v = new Vector3(0, 0, 1) * _moveSpeed;
                MoveCamera(v);
            }
            if (kState.IsKeyDown(Keys.A))
            {
                Vector3 v = new Vector3(-1, 0, 0) * _moveSpeed;
                MoveCamera(v);
            }
            if (kState.IsKeyDown(Keys.D))
            {
                Vector3 v = new Vector3(1, 0, 0) * _moveSpeed;
                MoveCamera(v);
            }
            if (kState.IsKeyDown(Keys.Q))
            {
                Vector3 v = new Vector3(0, -1, 0) * _moveSpeed;
                MoveCamera(v);
            }
            if (kState.IsKeyDown(Keys.E))
            {
                Vector3 v = new Vector3(0, 1, 0) * _moveSpeed;
                MoveCamera(v);
            }

            MouseState mState = Mouse.GetState();

            Player.Yaw -= _rotateSpeed * (mState.X - _centerX);
            Player.Pitch -= _rotateSpeed * (mState.Y - _centerY);

            if (Math.Abs(Player.Pitch) > Math.PI / 2 - 0.001)
                Player.Pitch = (float)((Math.PI / 2 - 0.001) * Math.Sign(Player.Pitch)); // just Math.PI / 2 makes the world invisible at max and min pitch

            if (Math.Abs(Player.Yaw) >= Math.PI)
                Player.Yaw -= 2 * (float)(Math.PI * Math.Sign(Player.Yaw));

            UpdateMatrices();
            ResetMousePos();
            _cameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);
            _viewFrustum.Matrix = ViewMatrix * ProjectionMatrix;
        }

        private void ResetMousePos()
        {
            Mouse.SetPosition(_centerX, _centerY);
        }

        private void UpdateMatrices()
        {
            _rotationMatrix = Matrix.CreateRotationX(Player.Pitch) * Matrix.CreateRotationY(Player.Yaw);
            Vector3 transformedReference = Vector3.Transform(new Vector3(0, 0, -1), _rotationMatrix); // 0 0 -1
            Vector3 lookAt = transformedReference + _cameraPosition;
            ViewMatrix = Matrix.CreateLookAt(_cameraPosition, lookAt, Vector3.Up);
        }

        private void MoveCamera(Vector3 v)
        {
            v = Vector3.Transform(v, _rotationMatrix);
            Player.X = Player.X + v.X;
            Player.Y = Player.Y + v.Y;
            Player.Stance = Player.Y + 1.62f;
            Player.Z = Player.Z + v.Z;

            _cameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);
        }
    }
}

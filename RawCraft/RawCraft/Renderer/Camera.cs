﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Storage
{
    class Camera
    {
        public Vector3 CameraPosition;
        public float MoveSpeed;
        public Matrix ViewMatrix, ProjectionMatrix;
        Matrix RotationMatrix;
        float RotateSpeed;
        int OldX, OldY;
        int centerX;
        int centerY;

        public Camera(float moveSpeed, float rotateSpeed, GraphicsDevice device)
        {
            CameraPosition = new Vector3((float)Storage.Player.X, (float)Storage.Player.Stance, (float)Storage.Player.Z);
            MoveSpeed = moveSpeed;
            RotateSpeed = rotateSpeed;

            ViewMatrix = Matrix.CreateLookAt(CameraPosition, Vector3.Zero, Vector3.Forward);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60f), device.Viewport.AspectRatio, 0.3f, 10000f);
            centerX = device.Viewport.Width / 2;
            centerY = device.Viewport.Height / 2;
            ResetMousePos();
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.W))
            {
                Vector3 v = new Vector3(0, 0, -1) * MoveSpeed;
                move(v);
            }
            if (kState.IsKeyDown(Keys.S))
            {
                Vector3 v = new Vector3(0, 0, 1) * MoveSpeed;
                move(v);
            }
            if (kState.IsKeyDown(Keys.A))
            {
                Vector3 v = new Vector3(-1, 0, 0) * MoveSpeed;
                move(v);
            }
            if (kState.IsKeyDown(Keys.D))
            {
                Vector3 v = new Vector3(1, 0, 0) * MoveSpeed;
                move(v);
            }
            if (kState.IsKeyDown(Keys.Q))
            {
                Vector3 v = new Vector3(0, -1, 0) * MoveSpeed;
                move(v);
            }
            if (kState.IsKeyDown(Keys.E))
            {
                Vector3 v = new Vector3(0, 1, 0) * MoveSpeed;
                move(v);
            }

            MouseState mState = Mouse.GetState();

            Player.Yaw -= RotateSpeed * (mState.X - OldX) * 2;
            Player.Pitch -= RotateSpeed * (mState.Y - OldY) * 2;

            if (Math.Abs(Player.Pitch) > 1.57)
                Player.Pitch = (float)(1.57 * Math.Sign(Player.Pitch));

            if (Math.Abs(Player.Yaw) >= Math.PI)
                Player.Yaw -= 2 * (float)(Math.PI * Math.Sign(Player.Yaw));

            UpdateMatrices();
            ResetMousePos();
            CameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);
        }

        private void ResetMousePos()
        {
            Mouse.SetPosition(centerX, centerY);
            OldX = centerX;
            OldY = centerY;
        }

        private void UpdateMatrices()
        {
            RotationMatrix = Matrix.CreateRotationX(Player.Pitch) * Matrix.CreateRotationY(Player.Yaw);
            Vector3 TransformedReference = Vector3.Transform(new Vector3(0, 0, -1), RotationMatrix); // 0 0 -1
            Vector3 lookAt = TransformedReference + CameraPosition;
            ViewMatrix = Matrix.CreateLookAt(CameraPosition, lookAt, Vector3.Up);
        }

        private void move(Vector3 v)
        {
            v = Vector3.Transform(v, RotationMatrix);
            Player.X = Player.X + v.X;
            Player.Y = Player.Y + v.Y;
            Player.Stance = Player.Y + 1.5f;
            Player.Z = Player.Z + v.Z;

            CameraPosition = new Vector3((float)Player.X, (float)Player.Stance, (float)Player.Z);

        }
    }
}

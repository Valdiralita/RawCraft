#region File Description
//-----------------------------------------------------------------------------
// GeometricPrimitive.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements

using System;
using Microsoft.Xna.Framework.Graphics;
using RawCraft.Storage;

#endregion

namespace RawCraft.Renderer
{
    public class Mesh : IDisposable
    {
        #region Fields

        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;
        int IndicesCount;

        #endregion

        public Mesh(VertexPositionNormalTexture[] vertices, int[] indices)
        {

            vertexBuffer = new VertexBuffer(Misc.graphics, typeof(VertexPositionNormalTexture), vertices.Length, BufferUsage.None);
            vertexBuffer.SetData(vertices);

            if (indices.Length < ushort.MaxValue) // saves about 50-60MB ram at view distance of 15 (cpu usage increase was not measurable) 
            {
                ushort[] ushortindex = new ushort[indices.Length];

                for (int i = 0; i < indices.Length; i++)
                {
                    ushortindex[i] = (ushort)indices[i];
                }

                indexBuffer = new IndexBuffer(Misc.graphics, IndexElementSize.SixteenBits, indices.Length, BufferUsage.None);
                indexBuffer.SetData(ushortindex);
            }
            else
            {
                indexBuffer = new IndexBuffer(Misc.graphics, IndexElementSize.ThirtyTwoBits, indices.Length, BufferUsage.None);
                indexBuffer.SetData(indices);
            }
            IndicesCount = indices.Length;

        }

        ~Mesh()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (vertexBuffer != null)
                    vertexBuffer.Dispose();

                if (indexBuffer != null)
                    indexBuffer.Dispose();
            }
        }

        #region Draw

        public void Draw()
        {
            Misc.effect.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            Misc.effect.GraphicsDevice.Indices = indexBuffer;

            foreach (EffectPass effectPass in Misc.effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                Misc.effect.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, IndicesCount, 0, IndicesCount / 3);
            }
        }

        #endregion
    }
}

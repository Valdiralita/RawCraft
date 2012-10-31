using System;
using Microsoft.Xna.Framework.Graphics;
using RawCraft.Storage;

namespace RawCraft.Renderer
{
    public class Mesh
    {
        #region Fields

        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;
        int IndicesCount;

        #endregion

        public Mesh(GraphicsDevice gd, VertexPositionNormalTexture[] vertices, int[] indices)
        {
            vertexBuffer = new VertexBuffer(gd, typeof(VertexPositionNormalTexture), vertices.Length, BufferUsage.None);
            vertexBuffer.SetData(vertices);

            if (indices.Length < ushort.MaxValue) // saves about 50-60MB ram at view distance of 15 (cpu usage increase was not measurable) 
            {
                ushort[] ushortindex = new ushort[indices.Length];

                for (int i = 0; i < indices.Length; i++)
                {
                    ushortindex[i] = (ushort)indices[i];
                }

                indexBuffer = new IndexBuffer(gd, IndexElementSize.SixteenBits, indices.Length, BufferUsage.None);
                indexBuffer.SetData(ushortindex);
            }
            else
            {
                indexBuffer = new IndexBuffer(gd, IndexElementSize.ThirtyTwoBits, indices.Length, BufferUsage.None);
                indexBuffer.SetData(indices);
            }
            IndicesCount = indices.Length;
        }

        ~Mesh()
        {
            if (vertexBuffer != null)
                vertexBuffer.Dispose();
            if (indexBuffer != null)
                indexBuffer.Dispose();
        }

        public void Draw(Effect effect)
        {
            effect.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            effect.GraphicsDevice.Indices = indexBuffer;

            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                effect.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, IndicesCount, 0, IndicesCount / 3);
            }
        }
    }
}

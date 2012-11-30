using Microsoft.Xna.Framework.Graphics;

namespace RawCraft.Renderer
{
    public class Mesh
    {
        #region Fields

        VertexBuffer _vertexBuffer;
        IndexBuffer _indexBuffer;
        int _indicesCount;

        #endregion

        public Mesh(GraphicsDevice gd, VertexPositionNormalTexture[] vertices, int[] indices)
        {
            _vertexBuffer = new VertexBuffer(gd, typeof(VertexPositionNormalTexture), vertices.Length, BufferUsage.None);
            _vertexBuffer.SetData(vertices);

            if (indices.Length < ushort.MaxValue) // saves about 50-60MB ram at view distance of 15 (cpu usage increase was not measurable) 
            {
                ushort[] ushortIndices = new ushort[indices.Length];

                for (int i = 0; i < indices.Length; i++)
                {
                    ushortIndices[i] = (ushort)indices[i];
                }

                _indexBuffer = new IndexBuffer(gd, IndexElementSize.SixteenBits, indices.Length, BufferUsage.None);
                _indexBuffer.SetData(ushortIndices);
            }
            else
            {
                _indexBuffer = new IndexBuffer(gd, IndexElementSize.ThirtyTwoBits, indices.Length, BufferUsage.None);
                _indexBuffer.SetData(indices);
            }
            _indicesCount = indices.Length;
        }

        ~Mesh()
        {
            if (_vertexBuffer != null)
                _vertexBuffer.Dispose();
            if (_indexBuffer != null)
                _indexBuffer.Dispose();
        }

        public void Draw(Effect effect)
        {
            effect.GraphicsDevice.SetVertexBuffer(_vertexBuffer);
            effect.GraphicsDevice.Indices = _indexBuffer;

            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                effect.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _indicesCount, 0, _indicesCount / 3);
            }
        }
    }
}

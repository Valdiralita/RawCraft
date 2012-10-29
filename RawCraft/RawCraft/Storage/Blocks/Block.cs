namespace RawCraft.Storage.Blocks
{
    class Block
    {
        private bool transparent, multitex, metadata, notablock;

        public Block()
        {
        }

        public bool IsTransparent
        {
            get { return transparent; }
            set { transparent = value; }
        }

        public bool IsMultitex
        {
            get { return multitex; }
            set { multitex = value; }
        }

        public bool HasMetadata
        {
            get { return metadata; }
            set { metadata = value; }
        }

        public bool NotABlock
        {
            get { return notablock; }
            set { notablock = value; }
        }
    }
}

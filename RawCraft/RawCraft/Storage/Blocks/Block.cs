namespace RawCraft.Storage.Blocks
{
    class Block
    {
        private bool transparent, multitex, metadata, entity;

        public Block()
        {
            transparent = false;
            multitex = false;
            metadata = false;
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

        public bool IsEntity
        {
            get { return entity; }
            set { entity = value; }
        }
    }
}

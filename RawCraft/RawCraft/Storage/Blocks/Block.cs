namespace RawCraft.Storage.Blocks
{
    class Block
    {
        private bool transparent, multitex, metadata, notablock, xsprite;

        // transparent: has the block(!) a texture with any transparency (this is NOT true if notablock is true). eg: mob spawner
        // multitex: has the block multiple textures. eg: grass_block, log
        // metadata: has the object metadata. eg: log, repeater
        // notablock: is the object not a full block. eg: fence, torch, repeater
        // *** RENDER ***
        // xsprite: is the model an X (with 2 sprites)

        public Block()
        {
        }

        public bool IsXSprite
        {
            get { return xsprite; }
            set { xsprite = value; }
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

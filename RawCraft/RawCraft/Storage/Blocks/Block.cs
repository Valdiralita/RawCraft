namespace RawCraft.Storage.Blocks
{
    class Block
    {
        // transparent: has the block(!) a texture with any transparency (this is NOT true if notablock is true). eg: mob spawner
        // multitex: has the block multiple textures. eg: grass_block, log
        // metadata: has the object metadata. eg: log, repeater
        // notablock: is the object not a full block. eg: fence, torch, repeater
        // *** RENDER ***
        // xsprite: is the model an X (with 2 sprites)

        public bool IsXSprite { get; set; }

        public bool IsTransparent { get; set; }

        public bool IsMultitex { get; set; }

        public bool HasMetadata { get; set; }

        public bool NotABlock { get; set; }
    }
}

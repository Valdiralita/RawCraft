namespace RawCraft.Network.Packets
{
    class EntityRelativeMove
    {
        public EntityRelativeMove(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

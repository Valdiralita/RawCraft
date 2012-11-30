namespace RawCraft.Network.Packets
{
    class EntityLookRelativeMove
    {
        public EntityLookRelativeMove(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

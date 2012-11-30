namespace RawCraft.Network.Packets
{
    class EntityVelocity
    {
        public EntityVelocity(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadShort();
            s.ReadShort();
            s.ReadShort();
        }
    }
}

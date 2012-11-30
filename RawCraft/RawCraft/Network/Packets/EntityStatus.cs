namespace RawCraft.Network.Packets
{
    class EntityStatus
    {
        public EntityStatus(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
        }
    }
}

namespace RawCraft.Network.Packets
{
    class EntityTeleport
    {
        public EntityTeleport(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

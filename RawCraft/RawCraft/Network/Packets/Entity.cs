namespace RawCraft.Network.Packets
{
    class Entity
    {
        public Entity(EnhancedStream s)
        {
            s.ReadInt();
        }
    }
}

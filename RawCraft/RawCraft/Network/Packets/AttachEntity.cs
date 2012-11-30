namespace RawCraft.Network.Packets
{
    class AttachEntity
    {
        public AttachEntity(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadInt();
        }
    }
}

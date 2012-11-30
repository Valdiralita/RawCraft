namespace RawCraft.Network.Packets
{
    class Animation
    {
        public Animation(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadByte();
        }
    }
}

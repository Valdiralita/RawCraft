namespace RawCraft.Network.Packets
{
    class IncrementStatistic
    {
        public IncrementStatistic(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadByte();
        }
    }
}

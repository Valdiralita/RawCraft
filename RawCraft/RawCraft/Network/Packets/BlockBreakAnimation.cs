namespace RawCraft.Network.Packets
{
    class BlockBreakAnimation
    {
        public BlockBreakAnimation(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
        }
    }
}

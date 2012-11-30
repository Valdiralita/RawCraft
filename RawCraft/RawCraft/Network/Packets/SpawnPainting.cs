namespace RawCraft.Network.Packets
{
    class SpawnPainting
    {
        public SpawnPainting(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadString();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
        }
    }
}

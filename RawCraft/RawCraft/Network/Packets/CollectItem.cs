namespace RawCraft.Network.Packets
{
    class CollectItem
    {
        public CollectItem(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadInt();
        }
    }
}

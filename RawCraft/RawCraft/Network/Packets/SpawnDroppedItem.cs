namespace RawCraft.Network.Packets
{
    class SpawnDroppedItem
    {
        public SpawnDroppedItem(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadSlot();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

namespace RawCraft.Network.Packets
{
    class CreativeInventoryAction
    {
        public CreativeInventoryAction(EnhancedStream s)
        {
            s.ReadShort();
            s.ReadSlot();
        }
    }
}

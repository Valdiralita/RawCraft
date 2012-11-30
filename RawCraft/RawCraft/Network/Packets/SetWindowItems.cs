namespace RawCraft.Network.Packets
{
    class SetWindowItems
    {
        public SetWindowItems(EnhancedStream stream) 
        {
            stream.ReadByte();
            int slots = stream.ReadShort();

            for (int i = 0; i < slots; i++)
                stream.ReadSlot();
        }
    }
}

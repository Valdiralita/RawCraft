namespace RawCraft.Network.Packets
{
    class ConfirmTransaction
    {
        public ConfirmTransaction(EnhancedStream s)
        {
            s.ReadByte();
            s.ReadShort();
            s.ReadByte();
        }
    }
}

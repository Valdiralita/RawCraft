namespace RawCraft.Network.Packets
{
    class UpdateHealth
    {
        public UpdateHealth(EnhancedStream s) 
        {
            s.ReadShort();
            s.ReadShort();
            s.ReadFloat();
        }
    }
}

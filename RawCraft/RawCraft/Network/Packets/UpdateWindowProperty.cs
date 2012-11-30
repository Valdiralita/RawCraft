namespace RawCraft.Network.Packets
{
    class UpdateWindowProperty
    {
        public UpdateWindowProperty(EnhancedStream s) 
        {
            s.ReadByte();
            s.ReadShort();
            s.ReadShort();
        }
    }
}

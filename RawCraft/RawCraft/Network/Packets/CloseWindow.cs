namespace RawCraft.Network.Packets
{
    class CloseWindow
    {
        public CloseWindow(EnhancedStream s) 
        {
            s.ReadByte();
        }
    }
}

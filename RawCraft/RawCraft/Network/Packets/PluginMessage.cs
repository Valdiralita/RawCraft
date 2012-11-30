namespace RawCraft.Network.Packets
{
    class PluginMessage
    {
        public PluginMessage(EnhancedStream s)
        {
            s.ReadString();
            s.ReadData(s.ReadShort());
        }
    }
}

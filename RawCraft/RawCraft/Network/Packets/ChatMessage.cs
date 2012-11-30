namespace RawCraft.Network.Packets
{
    class ChatMessage
    {
        public ChatMessage(EnhancedStream s)
        {
            s.ReadString();
        }
    }
}

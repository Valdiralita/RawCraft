namespace RawCraft.Network.Packets
{
    class ClientStatuses
    {
        EnhancedStream _stream;

        public ClientStatuses(EnhancedStream s)
        {
            _stream = s;
        }

        public void Send(byte payload)
        {
            _stream.WriteByte(0xCD);
            _stream.WriteByte(payload);
        }
    }
}

namespace RawCraft.Network.Packets
{
    class KeepAlive
    {
        EnhancedStream _stream;

        public KeepAlive(EnhancedStream s)
        {
            _stream = s;
            Send(_stream.ReadData(4));
        }

        private void Send(byte[] keepAliveID)
        {
            _stream.WriteByte(0);
            _stream.WriteData(keepAliveID);
        }
    }
}

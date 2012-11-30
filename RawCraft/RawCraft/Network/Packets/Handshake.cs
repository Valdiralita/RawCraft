namespace RawCraft.Network.Packets
{
    class Handshake
    {
        EnhancedStream _stream;

        public Handshake(EnhancedStream stream)
        {
            _stream = stream;
        }

        public void Send(string username, string server, int port)
        {
            _stream.WriteByte(0x02); //packet ID
            _stream.WriteByte(49); // protocol version
            _stream.WriteString(username);
            _stream.WriteString(server);
            _stream.WriteInt(port);
        }
    }
}

namespace RawCraft.Network.Packets
{
    class ClientSettings
    {
        EnhancedStream _stream;

        public ClientSettings(EnhancedStream s)
        {
            _stream = s;
        }

        public void Send()
        {
            string locale = "en_US";
            _stream.WriteByte(0xCC); //packet id
            _stream.WriteString(locale);
            _stream.WriteByte(0);
            _stream.WriteByte(8);
            _stream.WriteByte(0);
            _stream.WriteByte(1);
        }
    }
}

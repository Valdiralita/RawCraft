namespace RawCraft.Network.Packets
{
    class EncryptionKeyResponse
    {
        EnhancedStream _stream;

        public EncryptionKeyResponse(EnhancedStream s)
        {
            _stream = s;
        }

        public void Get()
        {
            _stream.ReadData(_stream.ReadShort());
            _stream.ReadData(_stream.ReadShort());
        }

        public void Send(byte[] encodedSharedSecret, byte[] token)
        {
            _stream.WriteByte(0xFC);
            _stream.WriteShort(128);
            _stream.WriteData(encodedSharedSecret);
            _stream.WriteShort(128);
            _stream.WriteData(token);
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EncryptionKeyResponse
    {
        EnhancedStream stream;

        public EncryptionKeyResponse(EnhancedStream s)
        {
            stream = s;
        }

        public void Get()
        {
            stream.ReadData(stream.ReadShort());
            stream.ReadData(stream.ReadShort());
        }

        public void Send(byte[] encodedSharedSecret, byte[] token)
        {
            stream.WriteByte(0xFC);
            stream.WriteShort(128);
            stream.WriteData(encodedSharedSecret);
            stream.WriteShort(128);
            stream.WriteData(token);
        }
    }
}

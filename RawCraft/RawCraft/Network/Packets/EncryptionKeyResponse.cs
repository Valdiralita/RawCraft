using System;
using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network.Packets
{
    class EncryptionKeyResponse
    {
        Stream stream;
        public EncryptionKeyResponse(Stream s)
        {
            stream = s;
        }

        public void Get()
        {
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Encryption Key Response (0xFC)");

            Reader.ReadData(stream, Reader.ReadShort(stream));
            Reader.ReadData(stream, Reader.ReadShort(stream));

            Misc.Log.Write("========== Enabling encryption ==========");

            Misc.isConnected = true;
        }

        public void Send(byte[] encodedSharedSecret, byte[] token)
        {
            Writer.WriteByte(0xFC, stream);
            Writer.WriteShort(128, stream);
            Writer.WriteData(encodedSharedSecret, stream);
            Writer.WriteShort(128, stream);
            Writer.WriteData(token, stream);
        }
    }
}

using System;
using System.IO;
using RawCraft.Storage;

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
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Encryption Key Response (0xFC)");

            stream.ReadData(stream.ReadShort());
            stream.ReadData(stream.ReadShort());

            Misc.Log.Write("========== Enabling encryption ==========");

            Misc.isConnected = true;
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

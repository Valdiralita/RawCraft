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

            Reader.ReadData(stream, Reader.ReadSignedShort(stream));
            Reader.ReadData(stream, Reader.ReadSignedShort(stream));

            Misc.Log.Write("========== Enabling encryption ==========");

            Misc.isConnected = true;
        }

        public void Send(byte[] encodedSharedSecret, byte[] token)
        {
            var helper = new byte[2] { 0, 128 }; // remove this

            var memStream = new MemoryStream();
            memStream.WriteByte(0xFC);
            memStream.Write(helper, 0, 2);
            memStream.Write(encodedSharedSecret, 0, encodedSharedSecret.Length);
            memStream.Write(helper, 0, 2);
            memStream.Write(token, 0, token.Length);

            byte[] packet = memStream.ToArray();

            stream.Write(packet, 0, packet.Length);
            Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending: 0xFC Packet");
        }
    }
}

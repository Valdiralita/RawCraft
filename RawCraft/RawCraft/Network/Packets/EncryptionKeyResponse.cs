using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Storage;

namespace Network.Packet
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
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Encryption Key Response (0xFC)");

            Reader.ReadData(stream, Reader.ReadSignedShort(stream));
            Reader.ReadData(stream, Reader.ReadSignedShort(stream));

            Storage.Misc.Log.Write("========== Enabling encryption ==========");

            Misc.isConnected = true;
        }

        public void Send(byte[] enc_sharedsecret, byte[] token)
        {
            byte[] helper = new byte[2] { 0, 128 }; // remove this

            MemoryStream MemStream = new MemoryStream();
            MemStream.WriteByte(0xFC);
            MemStream.Write(helper, 0, 2);
            MemStream.Write(enc_sharedsecret, 0, enc_sharedsecret.Length);
            MemStream.Write(helper, 0, 2);
            MemStream.Write(token, 0, token.Length);

            byte[] Packet = MemStream.ToArray();

            stream.Write(Packet, 0, Packet.Length);
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending: 0xFC Packet");
        }
    }
}

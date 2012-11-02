using System;
using System.IO;


namespace RawCraft.Network.Packets
{
    class ClientSettings
    {
        EnhancedStream stream;

        public ClientSettings(EnhancedStream s)
        {
            stream = s;
        }

        public void Send()
        {
            string locale = "en_US";
            stream.WriteByte((byte)0xCC); //packet id
            stream.WriteString(locale);
            stream.WriteByte(0);
            stream.WriteByte(8);
            stream.WriteByte(0);
            stream.WriteByte(1);
        }
    }
}

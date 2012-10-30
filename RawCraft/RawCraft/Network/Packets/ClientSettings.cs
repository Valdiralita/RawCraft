using System;
using System.IO;


namespace RawCraft.Network.Packets
{
    class ClientSettings
    {
        Stream stream;

        public ClientSettings(Stream stream)
        {
            this.stream = stream;
        }

        public void Send()
        {
            string locale = "en_GB";
            Writer.WriteByte((byte)0xCC, stream); //packet id
            Writer.WriteString(locale, stream);
            Writer.WriteByte(0, stream);
            Writer.WriteByte(8, stream);
            Writer.WriteByte(0, stream);
            Writer.WriteByte(1, stream);
        }
    }
}

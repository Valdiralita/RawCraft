using System;
using System.Linq;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Handshake
    {
        Stream stream;

        public Handshake(Stream stream)
        {
            this.stream = stream;
        }

        public void Send(string username, string server, int port)
        {
            Writer.WriteByte(0x02, stream); //packet ID
            Writer.WriteByte((byte)47, stream); // protocol version
            Writer.WriteString(username, stream); 
            Writer.WriteString(server, stream);
            Writer.WriteInt(port, stream);
        }
    }
}

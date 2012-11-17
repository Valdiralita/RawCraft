using System;
using System.Linq;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Handshake
    {
        EnhancedStream stream;

        public Handshake(EnhancedStream stream)
        {
            this.stream = stream;
        }

        public void Send(string username, string server, int port)
        {
            stream.WriteByte(0x02); //packet ID
            stream.WriteByte((byte)49); // protocol version
            stream.WriteString(username);
            stream.WriteString(server);
            stream.WriteInt(port);
        }
    }
}

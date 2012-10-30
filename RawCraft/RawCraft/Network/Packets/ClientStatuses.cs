using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ClientStatuses
    {
        Stream stream;

        public ClientStatuses(Stream stream)
        {
            this.stream = stream;
        }

        public void Send(byte payload)
        {
            Writer.WriteByte(0xCD, stream);
            Writer.WriteByte(payload, stream);
        }
    }
}

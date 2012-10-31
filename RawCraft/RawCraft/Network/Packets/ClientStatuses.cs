using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ClientStatuses
    {
        MyStream stream;

        public ClientStatuses(MyStream s)
        {
            stream = s;
        }

        public void Send(byte payload)
        {
            stream.WriteByte(0xCD);
            stream.WriteByte(payload);
        }
    }
}

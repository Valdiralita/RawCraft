using System;
using System.Linq;
using System.IO;

namespace RawCraft.Network.Packets
{
    class KeepAlive
    {
        EnhancedStream stream;

        public KeepAlive(EnhancedStream s)
        {
            stream = s;
            Send(stream.ReadData(4));
        }

        private void Send(byte[] keepAliveID)
        {
            stream.WriteByte(0);
            stream.WriteData(keepAliveID);
        }
    }
}

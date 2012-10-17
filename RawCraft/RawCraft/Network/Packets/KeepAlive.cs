using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class KeepAlive
    {
        static byte[] PacketID = new byte[1] { 0x00 };

        public KeepAlive(Stream stream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: KeepAlive Packet (0x00)");
            Send(stream, Reader.ReadData(stream, 4));
        }

        private void Send(Stream Stream, byte[] KeepAliveID)
        {
            Stream.Write(PacketID.Concat(KeepAliveID).ToArray(), 0, 5);
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending back KeepAlive!");
        }
    }
}

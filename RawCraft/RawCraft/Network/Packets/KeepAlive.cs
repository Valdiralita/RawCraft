using System;
using System.Linq;
using System.IO;

namespace RawCraft.Network.Packets
{
    class KeepAlive
    {
        static byte[] packetID = new byte[1] { 0x00 };

        public KeepAlive(Stream stream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: KeepAlive Packet (0x00)");
            Send(stream, Reader.ReadData(stream, 4));
        }

        private void Send(Stream stream, byte[] keepAliveID)
        {
            stream.Write(packetID.Concat(keepAliveID).ToArray(), 0, 5);
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending back KeepAlive!");
        }
    }
}

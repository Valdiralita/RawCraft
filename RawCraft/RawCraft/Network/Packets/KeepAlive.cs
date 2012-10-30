using System;
using System.Linq;
using System.IO;

namespace RawCraft.Network.Packets
{
    class KeepAlive
    {
        public KeepAlive(Stream stream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: KeepAlive Packet (0x00)");
            Send(stream, Reader.ReadData(stream, 4));
        }

        private void Send(Stream stream, byte[] keepAliveID)
        {
            Writer.WriteByte(0, stream);
            Writer.WriteData(keepAliveID, stream);
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending back KeepAlive!");
        }
    }
}

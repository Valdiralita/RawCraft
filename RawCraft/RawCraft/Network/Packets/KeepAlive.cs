using System;
using System.Linq;
using System.IO;

namespace RawCraft.Network.Packets
{
    class KeepAlive
    {
        MyStream stream;

        public KeepAlive(MyStream s)
        {
            stream = s;
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: KeepAlive Packet (0x00)");
            Send(stream.ReadData(4));
        }

        private void Send(byte[] keepAliveID)
        {
            stream.WriteByte(0);
            stream.WriteData(keepAliveID);
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending back KeepAlive!");
        }
    }
}

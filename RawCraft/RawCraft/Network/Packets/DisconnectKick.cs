using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using Storage;

namespace Network.Packet
{
    class DisconnectKick
    {
        public DisconnectKick(Stream AESStream, Timer PositionUpdater, Socket NetworkSocket)
        {
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Disconnect/Kick (0xFF)");
            Misc.Log.Write("We got kicked due to: " + Reader.ReadString(AESStream, Reader.ReadUnsignedShort(AESStream)));
            PositionUpdater.Dispose();
            AESStream.Close();
            NetworkSocket.Disconnect(false);
            Storage.Misc.isConnected = false;
        }
    }
}

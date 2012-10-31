using System;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network.Packets
{
    class DisconnectKick
    {
        public DisconnectKick(EnhancedStream s, Socket networkSocket)
        {
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Disconnect/Kick (0xFF)");
            Misc.Log.Write("We got kicked due to: " + s.ReadString(s.ReadShort()));
            s.Close();
            networkSocket = null;
            Misc.isConnected = false;
        }
    }
}

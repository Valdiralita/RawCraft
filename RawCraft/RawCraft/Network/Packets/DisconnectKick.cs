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
            string reason = s.ReadString();
            s.Close();
            networkSocket = null;
            Storage.Network.isConnected = false; 
            throw new Exception("Kicked due to: " + reason);
        }
    }
}

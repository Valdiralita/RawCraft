﻿using System;
using System.Net.Sockets;

namespace RawCraft.Network.Packets
{
    class DisconnectKick
    {
        public DisconnectKick(EnhancedStream s)
        {
            string reason = s.ReadString();
            s.Close();
            Storage.Network.IsConnected = false; 
            throw new Exception("Kicked due to: " + reason);
        }
    }
}

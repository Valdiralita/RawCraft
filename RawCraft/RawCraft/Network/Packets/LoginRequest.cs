using System;
using System.Net.Sockets;
using System.IO;

namespace RawCraft.Network.Packets
{
    class LoginRequest
    {
        public LoginRequest(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadString(s.ReadShort());
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

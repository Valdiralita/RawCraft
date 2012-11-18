using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class OpenWindow
    {
        public OpenWindow(EnhancedStream stream) 
        {
            stream.ReadByte();
            stream.ReadByte();
            stream.ReadString();
            stream.ReadByte();
        }
    }
}

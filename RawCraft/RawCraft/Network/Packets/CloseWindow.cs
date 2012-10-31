using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class CloseWindow
    {
        public CloseWindow(EnhancedStream s) 
        {
            s.ReadByte();
        }
    }
}

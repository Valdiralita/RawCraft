using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateWindowProperty
    {
        public UpdateWindowProperty(EnhancedStream s) 
        {
            s.ReadByte();
            s.ReadShort();
            s.ReadShort();
        }
    }
}

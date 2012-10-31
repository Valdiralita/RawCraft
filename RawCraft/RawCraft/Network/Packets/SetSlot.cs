using System;
using System.IO;

namespace RawCraft.Network.Packets 
{
    class SetSlot
    {
        public SetSlot(EnhancedStream stream) 
        {
            stream.ReadByte();
            stream.ReadShort();
            stream.ReadSlot();
        }
    }
}

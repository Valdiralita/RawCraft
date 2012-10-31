using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockChange
    {
        public BlockChange(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Change (0x35)");
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadShort();
            s.ReadByte();
        }
    }
}

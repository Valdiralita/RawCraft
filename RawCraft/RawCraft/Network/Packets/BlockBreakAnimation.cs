using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockBreakAnimation
    {
        public BlockBreakAnimation(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Break Animation (0x37)");
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
        }
    }
}

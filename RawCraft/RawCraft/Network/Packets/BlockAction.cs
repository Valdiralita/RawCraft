using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockAction
    {
        public BlockAction(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Action (0x36)");
            s.ReadInt();
            s.ReadShort();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
        }
    }
}

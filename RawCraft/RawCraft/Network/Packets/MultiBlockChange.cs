using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class MultiBlockChange
    {
        public MultiBlockChange(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Multi Block Change (0x34)");
            s.ReadInt();
            s.ReadInt();
            s.ReadShort();
            s.ReadData(s.ReadInt());
        }
    }
}

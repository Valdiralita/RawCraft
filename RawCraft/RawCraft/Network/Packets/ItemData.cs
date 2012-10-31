using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ItemData
    {
        public ItemData(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Item Data (0x83)"); 
            s.ReadShort();
            s.ReadShort();
            s.ReadData(s.ReadByte());
        }
    }
}

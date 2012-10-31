using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class CollectItem
    {
        public CollectItem(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Collect Item (0x16)");
            s.ReadInt();
            s.ReadInt();
        }
    }
}

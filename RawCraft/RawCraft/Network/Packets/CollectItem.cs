using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class CollectItem
    {
        public CollectItem(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Collect Item (0x16)");
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
        }
    }
}

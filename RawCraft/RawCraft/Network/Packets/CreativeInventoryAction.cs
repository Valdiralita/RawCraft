using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class CreativeInventoryAction
    {
        public CreativeInventoryAction(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Creative Inventory Action (0x6B)");
            s.ReadShort();
            s.ReadSlot();
        }
    }
}

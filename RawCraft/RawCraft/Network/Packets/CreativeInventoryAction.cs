using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class CreativeInventoryAction
    {
        public CreativeInventoryAction(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Creative Inventory Action (0x6B)");
            Reader.ReadShort(aesStream);
            Reader.ReadSlot(aesStream);
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EnchantItem
    {
        public EnchantItem(Stream stream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Enchant Item (0x6C)");
            stream.ReadByte();
            stream.ReadByte();
        }
    }
}

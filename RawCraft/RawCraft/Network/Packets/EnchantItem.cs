using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EnchantItem
    {
        public EnchantItem(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Enchant Item (0x6C)");
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EnchantItem
    {
        public EnchantItem(Stream stream)
        {
            stream.ReadByte();
            stream.ReadByte();
        }
    }
}

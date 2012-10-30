using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ItemData
    {
        public ItemData(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Item Data (0x83)"); 
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadData(aesStream, Reader.ReadByte(aesStream));
        }
    }
}

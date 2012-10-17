using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ItemData
    {
        public ItemData(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Item Data (0x83)"); 
            Reader.ReadSignedShort(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadData(aesStream, Reader.ReadUnsignedByte(aesStream));
        }
    }
}

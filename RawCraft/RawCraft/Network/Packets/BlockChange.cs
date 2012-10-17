using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockChange
    {
        public BlockChange(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Change (0x35)");
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedShort(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

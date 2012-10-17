using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockBreakAnimation
    {
        public BlockBreakAnimation(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Break Animation (0x37)");
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

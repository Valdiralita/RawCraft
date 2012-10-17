using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class BlockAction
    {
        public BlockAction(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Block Action (0x36)");
            Reader.ReadInt(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadSignedShort(aesStream);
        }
    }
}

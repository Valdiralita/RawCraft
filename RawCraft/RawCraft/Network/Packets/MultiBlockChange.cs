using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class MultiBlockChange
    {
        public MultiBlockChange(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Multi Block Change (0x34)");
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadData(aesStream, Reader.ReadInt(aesStream));
        }
    }
}

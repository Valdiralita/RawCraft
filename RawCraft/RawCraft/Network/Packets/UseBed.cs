using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UseBed
    {
        public UseBed(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Use Bed (0x11)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadInt(aesStream);
        }
    }
}

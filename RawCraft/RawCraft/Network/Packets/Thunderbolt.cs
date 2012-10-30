using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Thunderbolt
    {
        public Thunderbolt(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Thunderbolt (0x47)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
        }
    }
}

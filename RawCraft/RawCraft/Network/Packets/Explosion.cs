using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Explosion
    {
        public Explosion(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Explosion (0x3C)");
            Reader.ReadDouble(aesStream);
            Reader.ReadDouble(aesStream);
            Reader.ReadDouble(aesStream);
            Reader.ReadFloat(aesStream);
            Reader.ReadData(aesStream, Reader.ReadInt(aesStream) * 3);
            Reader.ReadFloat(aesStream);
            Reader.ReadFloat(aesStream);
            Reader.ReadFloat(aesStream);
        }
    }
}

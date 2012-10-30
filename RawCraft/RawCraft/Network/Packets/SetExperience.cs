using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SetExperience
    {
        public SetExperience(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Experience (0x2B)");
            Reader.ReadFloat(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
        }
    }
}

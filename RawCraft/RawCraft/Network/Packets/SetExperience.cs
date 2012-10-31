using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SetExperience
    {
        public SetExperience(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Experience (0x2B)");
            s.ReadFloat();
            s.ReadShort();
            s.ReadShort();
        }
    }
}

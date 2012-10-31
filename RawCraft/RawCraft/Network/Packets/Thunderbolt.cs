using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Thunderbolt
    {
        public Thunderbolt(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Thunderbolt (0x47)");
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
        }
    }
}

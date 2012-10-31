using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Explosion
    {
        public Explosion(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Explosion (0x3C)");
            s.ReadDouble();
            s.ReadDouble();
            s.ReadDouble();
            s.ReadFloat();
            s.ReadData(s.ReadInt() * 3);
            s.ReadFloat();
            s.ReadFloat();
            s.ReadFloat();
        }
    }
}

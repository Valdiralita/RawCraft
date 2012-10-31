using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnExperienceOrb
    {
        public SpawnExperienceOrb(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Experience Orb (0x1A)"); 
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadShort();
        }
    }
}

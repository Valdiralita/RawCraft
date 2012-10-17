using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnExperienceOrb
    {
        public SpawnExperienceOrb(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Experience Orb (0x1A)"); 
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadSignedShort(aesStream);
        }
    }
}

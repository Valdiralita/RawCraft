using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SoundParticleEffect
    {
        public SoundParticleEffect(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Sound/Particle Effect (0x3D)");
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
        }
    }
}

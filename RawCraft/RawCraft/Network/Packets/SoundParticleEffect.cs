using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SoundParticleEffect
    {
        public SoundParticleEffect(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
        }
    }
}

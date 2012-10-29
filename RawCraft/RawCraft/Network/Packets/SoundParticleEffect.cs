using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SoundParticleEffect
    {
        public SoundParticleEffect(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Sound/Particle Effect (0x3D)");
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

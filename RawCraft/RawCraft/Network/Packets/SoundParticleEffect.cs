using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class SoundParticleEffect
    {
        public SoundParticleEffect(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Sound/Particle Effect (0x3D)");
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
        }
    }
}

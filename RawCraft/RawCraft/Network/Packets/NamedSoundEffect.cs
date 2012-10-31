using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class NamedSoundEffect
    {
        public NamedSoundEffect(EnhancedStream s) 
        {
            s.ReadString(s.ReadShort());
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadFloat();
            s.ReadByte();
        }
    }
}

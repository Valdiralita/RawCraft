using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SetExperience
    {
        public SetExperience(EnhancedStream s)
        {
            s.ReadFloat();
            s.ReadShort();
            s.ReadShort();
        }
    }
}

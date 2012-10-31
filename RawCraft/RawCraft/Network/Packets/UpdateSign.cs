using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateSign
    {
        public UpdateSign(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadShort();
            s.ReadInt();
            s.ReadString(s.ReadShort());
            s.ReadString(s.ReadShort());
            s.ReadString(s.ReadShort());
            s.ReadString(s.ReadShort());
        }
    }
}

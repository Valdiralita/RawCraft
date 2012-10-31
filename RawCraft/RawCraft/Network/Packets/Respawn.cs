using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class RespawnPacket
    {
        public RespawnPacket(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Respawn (0x09)");
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadShort();
            s.ReadString(s.ReadShort());
        }
    }
}

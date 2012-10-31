using System;
using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network.Packets
{
    class SpawnPosition
    {
        public SpawnPosition(EnhancedStream s)
        {
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Position (0x06) (see compass)");
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
        }
    }
}

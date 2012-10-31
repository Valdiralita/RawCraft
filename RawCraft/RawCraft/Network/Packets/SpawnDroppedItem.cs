using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnDroppedItem
    {
        public SpawnDroppedItem(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Dropped Item (0x15)");
            s.ReadInt();
            s.ReadSlot();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

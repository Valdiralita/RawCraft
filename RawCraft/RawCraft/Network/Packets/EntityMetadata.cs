using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityMetadata
    {
        public EntityMetadata(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Metadata (0x28)");
            s.ReadInt();
            s.ReadMetaData();
        }
    }
}

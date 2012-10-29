using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityMetadata
    {
        public EntityMetadata(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Metadata (0x28)");
            Reader.ReadInt(aesStream);
            Reader.ReadMetaData(aesStream);
        }
    }
}

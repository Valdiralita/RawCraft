using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnNamedEntity 
    {
        public SpawnNamedEntity(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Named Entity (0x14)");
            Reader.ReadInt(aesStream);
            Reader.ReadString(aesStream, Reader.ReadShort(aesStream));
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadMetaData(aesStream);
        }
    }
}

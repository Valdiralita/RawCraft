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
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadMetaData(aesStream);
        }
    }
}

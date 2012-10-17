using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnMob
    {
        public SpawnMob(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Mob (0x18)");
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadMetaData(aesStream);
        }
    }
}

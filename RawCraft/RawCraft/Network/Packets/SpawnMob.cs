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
            Reader.ReadByte(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadMetaData(aesStream);
        }
    }
}

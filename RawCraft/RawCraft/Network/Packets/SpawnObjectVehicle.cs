using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnObjectVehicle
    {
        public SpawnObjectVehicle(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Object/Vehicle (0x17)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            int throwerID = Reader.ReadInt(aesStream); // TODO: This is not correctly done
            if (throwerID != 0)
            {
                Reader.ReadShort(aesStream);
                Reader.ReadShort(aesStream);
                Reader.ReadShort(aesStream);
            }
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnObjectVehicle
    {
        public SpawnObjectVehicle(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Object/Vehicle (0x17)");
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            int throwerID = s.ReadInt(); // TODO: This is not correctly done
            if (throwerID != 0)
            {
                s.ReadShort();
                s.ReadShort();
                s.ReadShort();
            }
        }
    }
}

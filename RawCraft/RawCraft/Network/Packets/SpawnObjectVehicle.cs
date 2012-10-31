using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnObjectVehicle
    {
        public SpawnObjectVehicle(EnhancedStream s) 
        {
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

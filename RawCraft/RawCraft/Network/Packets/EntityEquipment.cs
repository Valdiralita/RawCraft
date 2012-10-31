using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityEquipment
    {
        public EntityEquipment(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Equipment (0x05)");
            s.ReadInt();
            s.ReadShort();

            s.ReadSlot();
        }
    }
}

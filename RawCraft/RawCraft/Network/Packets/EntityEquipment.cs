using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityEquipment
    {
        public EntityEquipment(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Equipment (0x05)");
            s.ReadInt();
            s.ReadShort();

            s.ReadSlot();
        }
    }
}

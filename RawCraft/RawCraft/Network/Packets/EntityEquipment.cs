using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityEquipment
    {
        public EntityEquipment(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Equipment (0x05)");
            Reader.ReadInt(aesStream);
            Reader.ReadShort(aesStream);

            Reader.ReadSlot(aesStream);
        }
    }
}

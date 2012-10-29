using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnDroppedItem
    {
        public SpawnDroppedItem(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Dropped Item (0x15)");
            Reader.ReadInt(aesStream);
            Reader.ReadSlot(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

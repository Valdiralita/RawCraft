using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityRelativeMove
    {
        public EntityRelativeMove(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Relative Move (0x1F)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}

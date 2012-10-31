using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityRelativeMove
    {
        public EntityRelativeMove(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Relative Move (0x1F)");
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

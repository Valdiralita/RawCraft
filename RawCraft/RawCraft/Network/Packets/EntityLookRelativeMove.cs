using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityLookRelativeMove
    {
        public EntityLookRelativeMove(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Look and Relative Move (0x21)");
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

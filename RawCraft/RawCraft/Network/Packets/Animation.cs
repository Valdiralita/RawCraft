using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Animation
    {
        public Animation(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Animation (0x12)");
            s.ReadInt();
            s.ReadByte();
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnPainting
    {
        public SpawnPainting(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Painting (0x19)");
            s.ReadInt();
            s.ReadString(s.ReadShort());
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
        }
    }
}

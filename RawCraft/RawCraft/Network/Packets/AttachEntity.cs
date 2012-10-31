using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class AttachEntity
    {
        public AttachEntity(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Attach Entity (0x27)");
            s.ReadInt();
            s.ReadInt();
        }
    }
}

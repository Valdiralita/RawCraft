using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class RemoveEntityEffect
    {
        public RemoveEntityEffect(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Remove Entity Effect (0x2A)");
            s.ReadInt();
            s.ReadByte();
        }
    }
}

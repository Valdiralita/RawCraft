using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateHealth
    {
        public UpdateHealth(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Health (0x08)");
            s.ReadShort();
            s.ReadShort();
            s.ReadFloat();
        }
    }
}

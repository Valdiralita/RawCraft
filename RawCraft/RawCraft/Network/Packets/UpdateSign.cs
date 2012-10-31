using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateSign
    {
        public UpdateSign(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Sign (0x82)"); 
            s.ReadInt();
            s.ReadShort();
            s.ReadInt();
            s.ReadString(s.ReadShort());
            s.ReadString(s.ReadShort());
            s.ReadString(s.ReadShort());
            s.ReadString(s.ReadShort());
        }
    }
}

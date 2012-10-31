using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class NamedSoundEffect
    {
        public NamedSoundEffect(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Named Sound Effect (0x3E)");
            s.ReadString(s.ReadShort());
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadFloat();
            s.ReadByte();
        }
    }
}

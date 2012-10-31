using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateWindowProperty
    {
        public UpdateWindowProperty(MyStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Window Property (0x69)");
            s.ReadByte();
            s.ReadShort();
            s.ReadShort();
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets 
{
    class SetSlot
    {
        public SetSlot(MyStream stream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Slot (0x67)");
            stream.ReadByte();
            stream.ReadShort();
            stream.ReadSlot();
        }
    }
}

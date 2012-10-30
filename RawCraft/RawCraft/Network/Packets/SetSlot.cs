using System;
using System.IO;

namespace RawCraft.Network.Packets 
{
    class SetSlot
    {
        public SetSlot(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Slot (0x67)");
            Reader.ReadByte(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadSlot(aesStream);
        }
    }
}

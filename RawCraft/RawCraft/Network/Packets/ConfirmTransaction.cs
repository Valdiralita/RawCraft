using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ConfirmTransaction
    {
        public ConfirmTransaction(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Confirm Transaction (0x6A)");
            s.ReadByte();
            s.ReadShort();
            s.ReadByte();
        }
    }
}

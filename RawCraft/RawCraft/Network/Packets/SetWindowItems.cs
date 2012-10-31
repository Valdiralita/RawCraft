using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SetWindowItems
    {
        public SetWindowItems(EnhancedStream stream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Window Items (0x68)");
            stream.ReadByte();
            int slots = stream.ReadShort();

            for (int i = 0; i < slots; i++)
                stream.ReadSlot();
        }
    }
}

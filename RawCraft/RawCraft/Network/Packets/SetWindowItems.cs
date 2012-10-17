using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SetWindowItems
    {
        public SetWindowItems(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Set Window Items (0x68)");
            Reader.ReadSignedByte(aesStream);
            int slots = Reader.ReadSignedShort(aesStream);

            for (int i = 0; i < slots; i++)
                Reader.ReadSlot(aesStream);
        }
    }
}

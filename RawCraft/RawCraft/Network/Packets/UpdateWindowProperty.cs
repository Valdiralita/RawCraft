using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateWindowProperty
    {
        public UpdateWindowProperty(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Window Property (0x69)");
            Reader.ReadByte(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
        }
    }
}

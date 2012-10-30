using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateHealth
    {
        public UpdateHealth(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Health (0x08)");
            Reader.ReadShort(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadFloat(aesStream);
        }
    }
}

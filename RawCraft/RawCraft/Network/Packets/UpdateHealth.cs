using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateHealth
    {
        public UpdateHealth(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Health (0x08)");
            Reader.ReadSignedShort(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadFloat(aesStream);
        }
    }
}

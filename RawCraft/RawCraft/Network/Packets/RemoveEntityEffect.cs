using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class RemoveEntityEffect
    {
        public RemoveEntityEffect(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Remove Entity Effect (0x2A)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}

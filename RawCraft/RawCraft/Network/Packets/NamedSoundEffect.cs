using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class NamedSoundEffect
    {
        public NamedSoundEffect(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Named Sound Effect (0x3E)");
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadFloat(aesStream);
            Reader.ReadSignedByte(aesStream);
        }
    }
}

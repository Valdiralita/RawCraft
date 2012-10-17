using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class AttachEntity
    {
        public AttachEntity(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Attach Entity (0x27)");
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
        }
    }
}

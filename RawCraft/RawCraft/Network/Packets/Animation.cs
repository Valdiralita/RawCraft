using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Animation
    {
        public Animation(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Animation (0x12)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class TimeUpdate
    {
        public TimeUpdate(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Time Update (0x04)");
            Reader.ReadLong(aesStream);
        }
    }
}

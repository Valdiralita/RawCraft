using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class TimeUpdate
    {
        public TimeUpdate(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Time Update (0x04)");
            s.ReadLong();
            s.ReadLong();
        }
    }
}

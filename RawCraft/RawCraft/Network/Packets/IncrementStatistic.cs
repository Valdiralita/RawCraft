using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class IncrementStatistic
    {
        public IncrementStatistic(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Increment Statistic (0xC8)"); 
            s.ReadInt();
            s.ReadByte();
        }
    }
}

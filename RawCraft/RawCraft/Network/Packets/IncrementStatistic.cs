using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class IncrementStatistic
    {
        public IncrementStatistic(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Increment Statistic (0xC8)"); 
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}

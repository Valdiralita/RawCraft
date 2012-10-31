using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class DestroyEntity
    {
        public DestroyEntity(EnhancedStream s) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Destroy Entity (0x1D)");
            byte count = (byte)s.ReadByte();

            for (int i = 0; i < count; i++)
            {
                s.ReadInt();
            }
        }
    }
}

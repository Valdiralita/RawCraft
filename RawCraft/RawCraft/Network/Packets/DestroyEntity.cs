using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class DestroyEntity
    {
        public DestroyEntity(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Destroy Entity (0x1D)");
            byte count = Reader.ReadByte(aesStream);

            for (int i = 0; i < count; i++)
            {
                Reader.ReadInt(aesStream);
            }
        }
    }
}

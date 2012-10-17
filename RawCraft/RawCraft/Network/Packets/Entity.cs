using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Entity
    {
        public Entity(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity (0x1E)");
            Reader.ReadInt(aesStream);
        }
    }
}

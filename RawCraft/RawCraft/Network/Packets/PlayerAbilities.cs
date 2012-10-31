using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerAbilities
    {
        public PlayerAbilities(Stream stream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player Abilities (0xCA)");
            stream.ReadByte();
            stream.ReadByte();
            stream.ReadByte();
        }
    }
}

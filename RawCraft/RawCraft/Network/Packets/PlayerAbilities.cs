using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerAbilities
    {
        public PlayerAbilities(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player Abilities (0xCA)"); 
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}

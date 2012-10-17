using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerAbilities
    {
        public PlayerAbilities(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player Abilities (0xCA)"); 
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

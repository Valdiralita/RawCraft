using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerAbilities
    {
        public PlayerAbilities(Stream stream)
        {
            stream.ReadByte();
            stream.ReadByte();
            stream.ReadByte();
        }
    }
}

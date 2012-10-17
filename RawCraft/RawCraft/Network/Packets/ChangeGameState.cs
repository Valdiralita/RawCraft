using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ChangeGameState
    {
        public ChangeGameState(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Change Game State (0x46)");
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

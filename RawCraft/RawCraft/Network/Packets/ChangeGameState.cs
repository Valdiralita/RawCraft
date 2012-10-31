using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class ChangeGameState
    {
        public ChangeGameState(Stream stream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Change Game State (0x46)");
            stream.ReadByte();
            stream.ReadByte();
        }
    }
}

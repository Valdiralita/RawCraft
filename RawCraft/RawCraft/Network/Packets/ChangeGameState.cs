using System.IO;

namespace RawCraft.Network.Packets
{
    class ChangeGameState
    {
        public ChangeGameState(Stream stream) 
        {
            stream.ReadByte();
            stream.ReadByte();
        }
    }
}

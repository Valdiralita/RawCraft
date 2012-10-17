using System.IO;

namespace RawCraft.Network.Packets
{
    class ClientStatuses
    {
        Stream stream;

        public ClientStatuses(Stream stream)
        {
            this.stream = stream;
        }

        public void Send(byte payload)
        {
            stream.Write(new byte[2] { 0xCD, payload }, 0, 2);
        }
    }
}

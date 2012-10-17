using System.Net.Sockets;
using RawCraft.Storage;

namespace RawCraft.Network.Packets
{
    class ServerListPing
    {
        public ServerListPing(string server, int port)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var infos = new string[1];

            socket.Connect(server, port);
            var stream = new NetworkStream(socket);
            stream.WriteByte(0xFE);
            Reader.ReadSignedByte(stream);
            infos[0] = Reader.ReadString(stream, Reader.ReadUnsignedShort(stream));
            infos = infos[0].Split('§');

            Misc.Log.Write("Server Name : " + infos[0]);
            Misc.Log.Write("Online Players : " + infos[1]);
            Misc.Log.Write("Max Players : " + infos[2]);
            socket.Close();
        }
    }
}

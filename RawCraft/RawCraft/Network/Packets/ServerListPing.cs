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
            EnhancedStream stream = new EnhancedStream(socket);
            stream.WriteByte(0xFE);
            stream.ReadByte();
            infos[0] = stream.ReadString();
            infos = infos[0].Split('§');

            //Misc.Log.Write("Server Name : " + infos[0]);
            //Misc.Log.Write("Online Players : " + infos[1]);
            //Misc.Log.Write("Max Players : " + infos[2]);
            stream.Close();
            socket.Close();
        }
    }
}

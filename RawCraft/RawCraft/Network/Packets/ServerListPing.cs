using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Network;

namespace Network.Packet
{
    class ServerListPing
    {
        public ServerListPing(string Server, int Port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            System.Text.ASCIIEncoding PingReceive = new System.Text.ASCIIEncoding();
            string[] Infos = new string[1];

            socket.Connect(Server, Port);
            NetworkStream Stream = new NetworkStream(socket);
            Stream.WriteByte(0xFE);
            Reader.ReadSignedByte(Stream);
            Infos[0] = Reader.ReadString(Stream, Reader.ReadUnsignedShort(Stream));
            Infos = Infos[0].Split('§');

            Storage.Misc.Log.Write("Server Name : " + Infos[0]);
            Storage.Misc.Log.Write("Online Players : " + Infos[1]);
            Storage.Misc.Log.Write("Max Players : " + Infos[2]);
            socket.Close();
        
        }
    }
}

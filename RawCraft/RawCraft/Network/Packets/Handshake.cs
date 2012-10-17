using System;
using System.Linq;
using System.IO;

namespace RawCraft.Network.Packets
{
    class Handshake
    {
        Stream stream;
        public Handshake(Stream stream)
        {
            this.stream = stream;
        }

        public void Send(string username, string server, int port)
        {
            var packet = new byte[2 + 2 + username.Length * 2 + 2 + server.Length * 2 + 4];

            packet[0] = 0x02; //ID
            packet[1] = 39;
            packet[3] = Convert.ToByte(username.Length); // int (2 bytes) länge vom folgenden string     
            packet[5 + username.Length * 2] = Convert.ToByte(server.Length);


            int bytePos = 5; //start at packet[4]
            int j = 0; //counter (playername.length)

            while (j < username.Length)
            {
                packet[bytePos] = Convert.ToByte(username[j]);
                j++;
                bytePos += 2;
            }
            j = 0;
            bytePos = username.Length * 2 + 7;

            while (j < server.Length)
            {
                packet[bytePos] = Convert.ToByte(server[j]);
                j++;
                bytePos += 2;
            }

            packet[5 + username.Length * 2 + server.Length * 2 + 1] = BitConverter.GetBytes(port).ElementAt(3);
            packet[5 + username.Length * 2 + server.Length * 2 + 2] = BitConverter.GetBytes(port).ElementAt(2);
            packet[5 + username.Length * 2 + server.Length * 2 + 3] = BitConverter.GetBytes(port).ElementAt(1);
            packet[5 + username.Length * 2 + server.Length * 2 + 4] = BitConverter.GetBytes(port).ElementAt(0);

            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending Handshake... (0x02)");
            stream.Write(packet, 0, packet.Length);
        }
    }
}

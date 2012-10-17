using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class Handshake
    {
        Stream stream;
        public Handshake(Stream stream)
        {
            this.stream = stream;
        }

        public void Send(string Username, string Server, int Port)
        {
            byte[] packet = new byte[2 + 2 + Username.Length * 2 + 2 + Server.Length * 2 + 4];

            packet[0] = 0x02; //ID
            packet[1] = 39;
            packet[3] = Convert.ToByte(Username.Length); // int (2 bytes) länge vom folgenden string     
            packet[5 + Username.Length * 2] = Convert.ToByte(Server.Length);


            int BytePos = 5; //start at packet[4]
            int j = 0; //counter (playername.length)

            while (j < Username.Length)
            {
                packet[BytePos] = Convert.ToByte(Username[j]);
                j++;
                BytePos += 2;
            }
            j = 0;
            BytePos = Username.Length * 2 + 7;

            while (j < Server.Length)
            {
                packet[BytePos] = Convert.ToByte(Server[j]);
                j++;
                BytePos += 2;
            }

            packet[5 + Username.Length * 2 + Server.Length * 2 + 1] = BitConverter.GetBytes(Port).ElementAt(3);
            packet[5 + Username.Length * 2 + Server.Length * 2 + 2] = BitConverter.GetBytes(Port).ElementAt(2);
            packet[5 + Username.Length * 2 + Server.Length * 2 + 3] = BitConverter.GetBytes(Port).ElementAt(1);
            packet[5 + Username.Length * 2 + Server.Length * 2 + 4] = BitConverter.GetBytes(Port).ElementAt(0);

            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending Handshake... (0x02)");
            stream.Write(packet, 0, packet.Length);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace Network.Packet
{
    class LoginRequest
    {
        public LoginRequest(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Login Request (0x01)");
            Storage.Misc.Log.Write("Player Entity ID: " + Reader.ReadInt(AESStream));                        // The Players Entity ID
            Storage.Misc.Log.Write("World type: " + Reader.ReadString(AESStream, Reader.ReadSignedShort(AESStream)));  // default/flat/largebiomes
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }

        public static void Packet_0x01_LoginRequest_Send(NetworkStream Stream, string PlayerName)
        {
            byte[] packet = new byte[20 + PlayerName.Length * 2];

            packet[0] = 0x01; //ID
            packet[4] = 0x1D; // packet version (29)
            packet[6] = Convert.ToByte(PlayerName.Length); // (eigentlich short, aber max länge = 16) länge vom folgenden string    

            int BytePos = 8; //start at packet[8]
            int j = 0; //counter to (playername.length)
            for (int i = 0; i < PlayerName.Length; i++)
            {
                packet[BytePos] = Convert.ToByte(PlayerName[j]);
                BytePos += 2;
                j++;
            }
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending 0x01 Packet");
            Stream.Write(packet, 0, packet.Length);
        }
    }
}

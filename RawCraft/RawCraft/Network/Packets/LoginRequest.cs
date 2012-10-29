using System;
using System.Net.Sockets;
using System.IO;

namespace RawCraft.Network.Packets
{
    class LoginRequest
    {
        public LoginRequest(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Login Request (0x01)");
            Storage.Misc.Log.Write("Player Entity ID: " + Reader.ReadInt(aesStream));                        // The Players Entity ID
            Storage.Misc.Log.Write("World type: " + Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream)));  // default/flat/largebiomes
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }

        public static void Send(NetworkStream stream, string playerName) // not used anymore ?!
        {
            byte[] packet = new byte[20 + playerName.Length * 2];
            
            packet[0] = 0x01; //ID
            packet[4] = 0x1D; // packet version (29)
            packet[6] = Convert.ToByte(playerName.Length); // (eigentlich short, aber max länge = 16) länge vom folgenden string    
            
            int bytePos = 8; //start at packet[8]
            int j = 0; //counter to (playername.length)
            for (int i = 0; i < playerName.Length; i++)
            {
                packet[bytePos] = Convert.ToByte(playerName[j]);
                bytePos += 2;
                j++;
            }
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending 0x01 Packet");
            stream.Write(packet, 0, packet.Length);
        }
    }
}

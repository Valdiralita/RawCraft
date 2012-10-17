using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Storage;
using System.IO;

namespace Network.Packet
{
    class PlayerPositionLook
    { 
        static byte[] PacketID = new byte[1] { 0x0D };

        public PlayerPositionLook(Stream Stream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player Position & Look (0x0D)");
            Player.X = Reader.ReadDouble(Stream);
            Player.Stance = Reader.ReadDouble(Stream);
            Player.Y = Reader.ReadDouble(Stream);
            Player.Z = Reader.ReadDouble(Stream);
            Player.Yaw = Reader.ReadFloat(Stream);
            Player.Pitch = Reader.ReadFloat(Stream);
            Player.OnGround = Convert.ToBoolean(Reader.ReadSignedByte(Stream));

            Storage.Misc.Log.Write("X: " + Player.X);
            Storage.Misc.Log.Write("Y: " + Player.Y);
            Storage.Misc.Log.Write("Z: " + Player.Z);
            Storage.Misc.Log.Write("Stance: " + Player.Stance);
            Storage.Misc.Log.Write("Yaw: " + Player.Yaw);
            Storage.Misc.Log.Write("Pitch: " + Player.Pitch);
            Storage.Misc.Log.Write("OnGround: " + Player.OnGround);
        }

        public static void Send(Stream Stream)
        {
            byte[] packet = PacketID.Concat(BitConverter.GetBytes(Player.X).Reverse()).Concat(BitConverter.GetBytes(Player.Y).Reverse()).Concat(BitConverter.GetBytes(Player.Stance).Reverse()).Concat(BitConverter.GetBytes(Player.Z).Reverse()).Concat(BitConverter.GetBytes(Player.Yaw).Reverse()).Concat(BitConverter.GetBytes(Player.Pitch).Reverse()).Concat(BitConverter.GetBytes(Player.OnGround)).ToArray();
            Stream.Write(packet, 0, packet.Length);
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending: 0x0D Packet");
        }
    }
}

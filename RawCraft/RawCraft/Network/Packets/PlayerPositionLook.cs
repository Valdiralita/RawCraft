using System;
using System.Linq;
using RawCraft.Storage;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerPositionLook
    { 
        static byte[] PacketID = new byte[1] { 0x0D };

        public PlayerPositionLook(Stream stream)
        {
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player Position & Look (0x0D)");
            Player.X = Reader.ReadDouble(stream);
            Player.Stance = Reader.ReadDouble(stream);
            Player.Y = Reader.ReadDouble(stream);
            Player.Z = Reader.ReadDouble(stream);
            Player.Yaw = Reader.ReadFloat(stream);
            Player.Pitch = Reader.ReadFloat(stream);
            Player.OnGround = Convert.ToBoolean(Reader.ReadSignedByte(stream));

            Misc.Log.Write("X: " + Player.X);
            Misc.Log.Write("Y: " + Player.Y);
            Misc.Log.Write("Z: " + Player.Z);
            Misc.Log.Write("Stance: " + Player.Stance);
            Misc.Log.Write("Yaw: " + Player.Yaw);
            Misc.Log.Write("Pitch: " + Player.Pitch);
            Misc.Log.Write("OnGround: " + Player.OnGround);
        }

        public static void Send(Stream stream)
        {
            // I have no words to describe the following line.
            byte[] packet = PacketID.Concat(BitConverter.GetBytes(Player.X).Reverse()).Concat(BitConverter.GetBytes(Player.Y).Reverse()).Concat(BitConverter.GetBytes(Player.Stance).Reverse()).Concat(BitConverter.GetBytes(Player.Z).Reverse()).Concat(BitConverter.GetBytes(Player.Yaw).Reverse()).Concat(BitConverter.GetBytes(Player.Pitch).Reverse()).Concat(BitConverter.GetBytes(Player.OnGround)).ToArray();
            stream.Write(packet, 0, packet.Length);
            Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending: 0x0D Packet");
        }
    }
}

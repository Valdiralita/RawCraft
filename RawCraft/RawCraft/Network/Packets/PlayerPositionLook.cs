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
            Player.OnGround = Convert.ToBoolean(Reader.ReadByte(stream));

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
            Writer.WriteByte(0x0D, stream);
            Writer.WriteDouble(Player.X, stream);
            Writer.WriteDouble(Player.Y, stream);
            Writer.WriteDouble(Player.Stance, stream);
            Writer.WriteDouble(Player.Z, stream);
            Writer.WriteFloat(Player.Yaw, stream);
            Writer.WriteFloat(Player.Pitch, stream);
            Writer.WriteBool(Player.OnGround, stream);

            Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending: 0x0D Packet");
        }
    }
}

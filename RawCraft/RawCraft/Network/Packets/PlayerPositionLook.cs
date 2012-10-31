using System;
using System.Linq;
using RawCraft.Storage;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerPositionLook
    { 
        byte[] PacketID = new byte[1] { 0x0D };
        MyStream stream;

        public PlayerPositionLook(MyStream s)
        {
            stream = s;
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player Position & Look (0x0D)");
            Player.X = stream.ReadDouble();
            Player.Stance = stream.ReadDouble();
            Player.Y = stream.ReadDouble();
            Player.Z = stream.ReadDouble();
            Player.Yaw = stream.ReadFloat();
            Player.Pitch = stream.ReadFloat();
            Player.OnGround = Convert.ToBoolean(stream.ReadByte());

            Misc.Log.Write("X: " + Player.X);
            Misc.Log.Write("Y: " + Player.Y);
            Misc.Log.Write("Z: " + Player.Z);
            Misc.Log.Write("Stance: " + Player.Stance);
            Misc.Log.Write("Yaw: " + Player.Yaw);
            Misc.Log.Write("Pitch: " + Player.Pitch);
            Misc.Log.Write("OnGround: " + Player.OnGround);
        }

        public void Send()
        {
            stream.WriteByte(0x0D);
            stream.WriteDouble(Player.X);
            stream.WriteDouble(Player.Y);
            stream.WriteDouble(Player.Stance);
            stream.WriteDouble(Player.Z);
            stream.WriteFloat(Player.Yaw);
            stream.WriteFloat(Player.Pitch);
            stream.WriteBool(Player.OnGround);

            Misc.Log.Write(DateTime.Now.TimeOfDay + " Sending: 0x0D Packet");
        }
    }
}

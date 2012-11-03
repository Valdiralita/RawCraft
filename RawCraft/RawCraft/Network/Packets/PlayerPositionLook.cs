using System;
using System.Linq;
using RawCraft.Storage;
using System.IO;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class PlayerPositionLook
    { 
        byte[] PacketID = new byte[1] { 0x0D };
        EnhancedStream stream;

        public PlayerPositionLook(EnhancedStream s)
        {
            stream = s;
            Player.X = stream.ReadDouble();
            Player.Stance = stream.ReadDouble();
            Player.Y = stream.ReadDouble();
            Player.Z = stream.ReadDouble();
            Player.Yaw = stream.ReadFloat();
            Player.Pitch = stream.ReadFloat();
            Player.OnGround = Convert.ToBoolean(stream.ReadByte());
        }

        public void Send()
        {
            stream.WriteByte(0x0D);
            stream.WriteDouble(Player.X);
            stream.WriteDouble(Player.Y);
            stream.WriteDouble(Player.Stance);
            stream.WriteDouble(Player.Z);
            stream.WriteFloat(180 - MathHelper.ToDegrees(Player.Yaw));
            stream.WriteFloat(-MathHelper.ToDegrees(Player.Pitch));
            stream.WriteBool(Player.OnGround);
        }
    }
}

using System;
using RawCraft.Storage;
using Microsoft.Xna.Framework;

namespace RawCraft.Network.Packets
{
    class PlayerPositionLook
    {
        EnhancedStream _stream;

        public PlayerPositionLook(EnhancedStream s)
        {
            _stream = s;
            Player.X = _stream.ReadDouble();
            Player.Stance = _stream.ReadDouble();
            Player.Y = _stream.ReadDouble();
            Player.Z = _stream.ReadDouble();
            Player.Yaw = _stream.ReadFloat();
            Player.Pitch = _stream.ReadFloat();
            Player.OnGround = Convert.ToBoolean(_stream.ReadByte());
            Send();
        }

        public void Send()
        {
            _stream.WriteByte(0x0D);
            _stream.WriteDouble(Player.X);
            _stream.WriteDouble(Player.Y);
            _stream.WriteDouble(Player.Stance);
            _stream.WriteDouble(Player.Z);
            _stream.WriteFloat(180 - MathHelper.ToDegrees(Player.Yaw));
            _stream.WriteFloat(-MathHelper.ToDegrees(Player.Pitch));
            _stream.WriteBool(Player.OnGround);
        }
    }
}

namespace RawCraft.Network.Packets
{
    class SpawnObjectVehicle
    {
        public SpawnObjectVehicle(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            int throwerID = s.ReadInt();
            if (throwerID == 0) return;
            s.ReadShort();
            s.ReadShort();
            s.ReadShort();
        }
    }
}

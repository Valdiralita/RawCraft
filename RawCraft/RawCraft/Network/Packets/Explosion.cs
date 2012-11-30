namespace RawCraft.Network.Packets
{
    class Explosion
    {
        public Explosion(EnhancedStream s)
        {
            s.ReadDouble();
            s.ReadDouble();
            s.ReadDouble();
            s.ReadFloat();
            s.ReadData(s.ReadInt() * 3);
            s.ReadFloat();
            s.ReadFloat();
            s.ReadFloat();
        }
    }
}

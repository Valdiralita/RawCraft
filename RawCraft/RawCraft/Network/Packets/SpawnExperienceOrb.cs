namespace RawCraft.Network.Packets
{
    class SpawnExperienceOrb
    {
        public SpawnExperienceOrb(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadShort();
        }
    }
}

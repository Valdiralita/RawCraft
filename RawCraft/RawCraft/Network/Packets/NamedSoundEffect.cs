namespace RawCraft.Network.Packets
{
    class NamedSoundEffect
    {
        public NamedSoundEffect(EnhancedStream s) 
        {
            s.ReadString();
            s.ReadInt();
            s.ReadInt();
            s.ReadInt();
            s.ReadFloat();
            s.ReadByte();
        }
    }
}

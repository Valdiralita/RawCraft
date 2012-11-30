namespace RawCraft.Network.Packets
{
    class EntityLook
    {
        public EntityLook(EnhancedStream s) 
        {
            s.ReadInt();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

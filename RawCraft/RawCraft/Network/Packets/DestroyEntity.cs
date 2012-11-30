namespace RawCraft.Network.Packets
{
    class DestroyEntity
    {
        public DestroyEntity(EnhancedStream s) 
        {
            byte count = (byte)s.ReadByte();

            for (int i = 0; i < count; i++)
            {
                s.ReadInt();
            }
        }
    }
}

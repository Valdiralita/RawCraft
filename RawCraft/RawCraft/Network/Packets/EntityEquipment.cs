namespace RawCraft.Network.Packets
{
    class EntityEquipment
    {
        public EntityEquipment(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadShort();
            s.ReadSlot();
        }
    }
}

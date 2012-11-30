namespace RawCraft.Network.Packets
{
    class UpdateTileEntity
    {
        public UpdateTileEntity(EnhancedStream s)
        {
            s.ReadInt();
            s.ReadShort();
            s.ReadInt();
            s.ReadByte();
            s.ReadData(s.ReadShort());
        }
    }
}

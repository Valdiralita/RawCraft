using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateTileEntity
    {
        public UpdateTileEntity(EnhancedStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Tile Entity (0x84)"); 
            s.ReadInt();
            s.ReadShort();
            s.ReadInt();
            s.ReadByte();
            s.ReadData(s.ReadShort());
        }
    }
}

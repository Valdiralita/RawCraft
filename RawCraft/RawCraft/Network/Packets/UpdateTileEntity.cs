using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateTileEntity
    {
        public UpdateTileEntity(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Tile Entity (0x84)"); 
            Reader.ReadInt(aesStream);
            Reader.ReadShort(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadData(aesStream, Reader.ReadShort(aesStream));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class UpdateTileEntity
    {
        public UpdateTileEntity(Stream AESStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Tile Entity (0x84)"); 
            Reader.ReadInt(AESStream);
            Reader.ReadSignedShort(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadData(AESStream, Reader.ReadSignedShort(AESStream));
        }
    }
}

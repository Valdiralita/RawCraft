using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class UpdateSign
    {
        public UpdateSign(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Update Sign (0x82)"); 
            Reader.ReadInt(aesStream);
            Reader.ReadSignedShort(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
        }
    }
}

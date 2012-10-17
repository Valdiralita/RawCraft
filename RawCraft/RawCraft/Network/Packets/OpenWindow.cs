using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class OpenWindow
    {
        public OpenWindow(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Open Window (0x64)");
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadUnsignedByte(aesStream);
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

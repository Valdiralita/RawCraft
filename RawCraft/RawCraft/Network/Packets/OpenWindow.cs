using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class OpenWindow
    {
        public OpenWindow(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Open Window (0x64)");
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadString(aesStream, Reader.ReadShort(aesStream));
            Reader.ReadByte(aesStream);
        }
    }
}

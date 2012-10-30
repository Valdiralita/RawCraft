using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PluginMessage
    {
        public PluginMessage(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Plugin Message (0xFA)"); 
            Storage.Misc.Log.Write(Reader.ReadString(aesStream, Reader.ReadShort(aesStream)));
            Reader.ReadData(aesStream, Reader.ReadShort(aesStream));
        }
    }
}

using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class TabComplete
    {
        public TabComplete(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Tab-complete (0xCB)"); 
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
        }
    }
}

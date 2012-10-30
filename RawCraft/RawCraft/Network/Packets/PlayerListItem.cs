using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerListItem
    {
        public PlayerListItem(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player List Item (0xC9)"); 
            Storage.Misc.Log.Write("PlayerName: " + Reader.ReadString(aesStream, Reader.ReadShort(aesStream)));
            Reader.ReadByte(aesStream);
            Storage.Misc.Log.Write("Ping: " + Reader.ReadShort(aesStream));
        }
    }
}

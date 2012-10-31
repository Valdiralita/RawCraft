using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class PlayerListItem
    {
        public PlayerListItem(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Player List Item (0xC9)"); 
            Storage.Misc.Log.Write("PlayerName: " + s.ReadString(s.ReadShort()));
            s.ReadByte();
            Storage.Misc.Log.Write("Ping: " + s.ReadShort());
        }
    }
}

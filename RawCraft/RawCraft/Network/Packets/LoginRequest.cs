using System;
using System.Net.Sockets;
using System.IO;

namespace RawCraft.Network.Packets
{
    class LoginRequest
    {
        public LoginRequest(MyStream s)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Login Request (0x01)");
            Storage.Misc.Log.Write("Player Entity ID: " + s.ReadInt());                        // The Players Entity ID
            Storage.Misc.Log.Write("World type: " + s.ReadString(s.ReadShort()));  // default/flat/largebiomes
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
            s.ReadByte();
        }
    }
}

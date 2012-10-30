using System;
using System.Net.Sockets;
using System.IO;

namespace RawCraft.Network.Packets
{
    class LoginRequest
    {
        public LoginRequest(Stream aesStream)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Login Request (0x01)");
            Storage.Misc.Log.Write("Player Entity ID: " + Reader.ReadInt(aesStream));                        // The Players Entity ID
            Storage.Misc.Log.Write("World type: " + Reader.ReadString(aesStream, Reader.ReadShort(aesStream)));  // default/flat/largebiomes
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}

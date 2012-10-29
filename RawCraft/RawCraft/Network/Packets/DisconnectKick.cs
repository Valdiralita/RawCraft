using System;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network.Packets
{
    class DisconnectKick
    {
        public DisconnectKick(Stream aesStream,Socket networkSocket)
        {
            Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Disconnect/Kick (0xFF)");
            Misc.Log.Write("We got kicked due to: " + Reader.ReadString(aesStream, Reader.ReadUnsignedShort(aesStream)));
            aesStream.Close();
            networkSocket = null;
            Misc.isConnected = false;
        }
    }
}

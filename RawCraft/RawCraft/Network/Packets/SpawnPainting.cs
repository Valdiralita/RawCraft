using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class SpawnPainting
    {
        public SpawnPainting(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Spawn Painting (0x19)");
            Reader.ReadInt(aesStream);
            Reader.ReadString(aesStream, Reader.ReadSignedShort(aesStream));
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
            Reader.ReadInt(aesStream);
        }
    }
}

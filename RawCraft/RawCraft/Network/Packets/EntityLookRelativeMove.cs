using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityLookRelativeMove
    {
        public EntityLookRelativeMove(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Look and Relative Move (0x21)");
            Reader.ReadInt(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
            Reader.ReadByte(aesStream);
        }
    }
}

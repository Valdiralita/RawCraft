﻿using System;
using System.IO;

namespace RawCraft.Network.Packets
{
    class EntityStatus
    {
        public EntityStatus(Stream aesStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Status (0x26)");
            Reader.ReadInt(aesStream);
            Reader.ReadUnsignedByte(aesStream);
        }
    }
}

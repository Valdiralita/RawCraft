﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EntityTeleport
    {
        public EntityTeleport(Stream AESStream) 
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Entity Teleport (0x22)");
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadInt(AESStream);
            Reader.ReadUnsignedByte(AESStream);
            Reader.ReadUnsignedByte(AESStream);
        }
    }
}

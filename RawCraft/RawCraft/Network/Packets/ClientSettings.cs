﻿using System;
using System.IO;


namespace RawCraft.Network.Packets
{
    class ClientSettings
    {
        MyStream stream;

        public ClientSettings(MyStream s)
        {
            stream = s;
        }

        public void Send()
        {
            string locale = "en_GB";
            stream.WriteByte((byte)0xCC); //packet id
            stream.WriteString(locale);
            stream.WriteByte(0);
            stream.WriteByte(8);
            stream.WriteByte(0);
            stream.WriteByte(1);
        }
    }
}

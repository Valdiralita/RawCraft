using System;
using System.IO;


namespace RawCraft.Network.Packets
{
    class ClientSettings
    {
        Stream stream;

        public ClientSettings(Stream stream)
        {
            this.stream = stream;
        }

        public void Send()
        {
            stream.Write(new byte[1] { 0xCC }, 0, 1);

            string locale = "en_GB";
            stream.Write(new byte[2] { 0, (byte)(locale.Length * 2) }, 0, 2);
            for (int i = 0; i < locale.Length; i++)
            {
                stream.Write(new byte[2] { 0, Convert.ToByte(locale[i]) }, 0, 2);
            }
            stream.Write(new byte[4] { 0, 0, 0, 1 }, 0, 4);
        }
    }
}

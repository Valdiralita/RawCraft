using System.Text;
using System.IO;
using System;

namespace RawCraft.Network
{
    static class Writer
    {
        public static void WriteByte(Stream stream)
        {

        }
        public static void WriteShort(Stream stream)
        {

        }
        public static void WriteInt(Stream stream)
        {

        }
        public static void WriteFloat(Stream stream)
        {

        }
        public static void WriteString(string str, Stream stream)
        {
            stream.Write(new byte[2] { 0, (byte)(str.Length * 2) }, 0, 2);
            for (int i = 0; i < str.Length; i++)
            {
                stream.Write(new byte[2] { 0, Convert.ToByte(str[i]) }, 0, 2);
            }
        }
    }
}

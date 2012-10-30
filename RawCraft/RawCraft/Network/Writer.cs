using System.Text;
using System.IO;
using System;

namespace RawCraft.Network
{
    static class Writer
    {
        public static void WriteByte(byte b, Stream stream)
        {
            stream.WriteByte(b);
        }
        public static void WriteShort(short s, Stream stream)
        {
            byte[] data = BitConverter.GetBytes(s);
            //Array.Reverse(data);
            stream.Write(data, 0, data.Length);
        }
        public static void WriteInt(int i, Stream stream)
        {
            byte[] data = BitConverter.GetBytes(i);
            Array.Reverse(data);
            stream.Write(data, 0, data.Length);
        }
        public static void WriteFloat(float f, Stream stream)
        {
            byte[] data = BitConverter.GetBytes(f);
            //Array.Reverse(data);
            stream.Write(data, 0, data.Length);
        }
        public static void WriteString(string str, Stream stream)
        {
            WriteShort((short)str.Length, stream);
            for (int i = 0; i < str.Length; i++)
            {
                stream.Write(new byte[2] { Convert.ToByte(str[i]), 0 }, 0, 2);
            }
        }
    }
}

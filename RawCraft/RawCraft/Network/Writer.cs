using System.Text;
using System.IO;
using System;

namespace RawCraft.Network
{
    static class Writer
    {
        internal static void WriteByte(byte b, Stream stream)
        {
            stream.WriteByte(b);
        }
        internal static void WriteShort(short s, Stream stream)
        {
            byte[] data = BitConverter.GetBytes(s);
            Array.Reverse(data);
            stream.Write(data, 0, 2);
        }
        internal static void WriteInt(int i, Stream stream)
        {
            byte[] data = BitConverter.GetBytes(i);
            Array.Reverse(data);
            stream.Write(data, 0, 4);
        }
        internal static void WriteFloat(float f, Stream stream)
        {
            byte[] data = BitConverter.GetBytes(f);
            Array.Reverse(data);
            stream.Write(data, 0, data.Length);
        }
        internal static void WriteString(string str, Stream stream)
        {
            WriteShort((short)str.Length, stream);
            for (int i = 0; i < str.Length; i++)
            {
                stream.Write(new byte[2] { 0, Convert.ToByte(str[i]) }, 0, 2);
            }
        }

        internal static void WriteData(byte[] data, Stream stream)
        {
            stream.Write(data, 0, data.Length);
        }

        internal static void WriteDouble(double p, Stream stream)
        {
            byte[] data = BitConverter.GetBytes(p);
            Array.Reverse(data);
            stream.Write(data, 0, data.Length);
        }

        internal static void WriteBool(bool b, Stream stream)
        {
            stream.WriteByte(b ? (byte)1 : (byte)0);
        }
    }
}

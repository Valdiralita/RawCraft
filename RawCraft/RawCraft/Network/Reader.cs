using System;
using System.Text;
using System.IO;

namespace RawCraft.Network
{
    public static class Reader
    {
        // TODO: Just copy Craft.Net's code for this

        internal static short ReadShort(Stream stream)
        {
            short SignedShort;
            SignedShort = (byte)stream.ReadByte();
            SignedShort <<= 8;
            SignedShort += (byte)stream.ReadByte();
            return SignedShort;
        }

        internal static byte ReadByte(Stream stream)
        {
            return (byte)stream.ReadByte();
        }

        internal static int ReadInt(Stream stream)
        {
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

        internal static double ReadDouble(Stream stream)
        {
            byte[] buffer = new byte[8];
            stream.Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        internal static Int64 ReadLong(Stream stream)
        {
            byte[] buffer = new byte[8];
            stream.Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
        internal static string ReadString(Stream stream, int count)
        {
            byte[] String = ReadData(stream, count * 2);
            Encoding enc = new UnicodeEncoding(true, true, true);
            return enc.GetString(String, 0, String.Length);
        }

        internal static byte[] ReadData(Stream stream, int count)
        {
            if (count > 0)
            {
                byte[] buffer = new byte[count];
                stream.Read(buffer, 0, count);
                return buffer;
            }
            return new byte[0];
        }

        internal static float ReadFloat(Stream stream)
        {
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        internal static void ReadMetaData(Stream stream)
        {
            byte MetaDataType = ReadByte(stream);
            while (MetaDataType != 255)
            {
                byte First3Bytes = (byte)(MetaDataType >> 0x05);
                byte Last5Bytes = (byte)(MetaDataType & 0x1F);

                switch (First3Bytes)
                {
                    case 0:
                        ReadByte(stream);
                        break;
                    case 1:
                        ReadShort(stream);
                        break;
                    case 2:
                        ReadInt(stream);
                        break;
                    case 3:
                        ReadFloat(stream);
                        break;
                    case 4:
                        ReadString(stream, ReadShort(stream));
                        break;
                    case 5:
                        ReadShort(stream);
                        ReadByte(stream);
                        ReadShort(stream);
                        break;
                    case 6:
                        ReadInt(stream);
                        ReadInt(stream);
                        ReadInt(stream);
                        break;
                    default:
                        throw new Exception();
                }
                MetaDataType = ReadByte(stream);
            }
        }

        internal static void ReadSlot(Stream stream)
        {
            short Block = ReadShort(stream);
            if (Block != -1)
            {
                ReadByte(stream);
                ReadShort(stream);

                int ByteArrayLength = ReadShort(stream);

                if (ByteArrayLength > -1)
                    ReadData(stream, ByteArrayLength);

            }
        }
    }
}

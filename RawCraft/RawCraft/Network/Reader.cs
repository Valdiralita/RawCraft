using System;
using System.Text;
using System.IO;

namespace RawCraft.Network
{
    public static class Reader
    {
        // TODO: Just copy Craft.Net's code for this

        public static short ReadSignedShort(Stream stream)
        {
            short SignedShort;
            SignedShort = (byte)stream.ReadByte();
            SignedShort <<= 8;
            SignedShort += (byte)stream.ReadByte();
            return SignedShort;
        }

        public static ushort ReadUnsignedShort(Stream stream)
        {
            int UnsignedShort;
            UnsignedShort = stream.ReadByte();
            UnsignedShort <<= 8;
            UnsignedShort += stream.ReadByte();
            return (ushort)UnsignedShort;
        }

        public static byte ReadUnsignedByte(Stream stream)
        {
            return (byte)stream.ReadByte();
        }

        public static SByte ReadSignedByte(Stream stream)
        {
            return (SByte)stream.ReadByte();
        }

        public static int ReadInt(Stream stream)
        {
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

        public static double ReadDouble(Stream stream)
        {
            byte[] buffer = new byte[8];
            stream.Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        public static Int64 ReadLong(Stream stream)
        {
            byte[] buffer = new byte[8];
            stream.Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
        public static string ReadString(Stream stream, int count)
        {
            byte[] String = ReadData(stream, count * 2);
            Encoding enc = new UnicodeEncoding(true, true, true);
            return enc.GetString(String, 0, String.Length);
        }

        public static byte[] ReadData(Stream stream, int count)
        {
            if (count > 0)
            {
                byte[] buffer = new byte[count];
                stream.Read(buffer, 0, count);
                return buffer;
            }
            return new byte[0];
        }

        public static float ReadFloat(Stream stream)
        {
            byte[] buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        public static void ReadMetaData(Stream stream)
        {
            sbyte MetaDataType = ReadSignedByte(stream);
            while (MetaDataType != 127)
            {
                byte First3Bytes = (byte)(MetaDataType >> 0x05);
                byte Last5Bytes = (byte)(MetaDataType & 0x1F);

                switch (First3Bytes)
                {
                    case 0:
                        ReadUnsignedByte(stream);
                        break;
                    case 1:
                        ReadSignedShort(stream);
                        break;
                    case 2:
                        ReadInt(stream);
                        break;
                    case 3:
                        ReadFloat(stream);
                        break;
                    case 4:
                        ReadString(stream, ReadSignedShort(stream));
                        break;
                    case 5:
                        ReadSignedShort(stream);
                        ReadUnsignedByte(stream);
                        ReadSignedShort(stream);
                        break;
                    case 6:
                        ReadInt(stream);
                        ReadInt(stream);
                        ReadInt(stream);
                        break;
                    default:
                        throw new Exception();
                }
                MetaDataType = ReadSignedByte(stream);
            }
        }

        public static void ReadSlot(Stream stream)
        {
            short Block = ReadSignedShort(stream);
            if (Block != -1)
            {
                ReadSignedByte(stream);
                ReadSignedShort(stream);

                int ByteArrayLength = ReadSignedShort(stream);

                if (ByteArrayLength > -1)
                    ReadData(stream, ByteArrayLength);

            }
        }
    }
}

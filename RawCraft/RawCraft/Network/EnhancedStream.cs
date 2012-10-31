using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace RawCraft.Network
{
    public class EnhancedStream : NetworkStream
    {
        Socket socket;

        public EnhancedStream(Socket s) : base(s)
        {
            socket = s;
        }

        public short ReadShort()
        {
            byte[] buffer = new byte[2];
            Read(buffer, 0, 2);
            Array.Reverse(buffer);
            return BitConverter.ToInt16(buffer, 0);
        }

        public override int ReadByte()
        {
            return base.ReadByte();
        }

        public int ReadInt()
        {
            byte[] buffer = new byte[4];
            Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

        public double ReadDouble()
        {
            byte[] buffer = new byte[8];
            Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        public Int64 ReadLong()
        {
            byte[] buffer = new byte[8];
            Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
        public string ReadString(int count)
        {
            byte[] String = ReadData(count * 2);
            Encoding enc = new UnicodeEncoding(true, true, true);
            return enc.GetString(String, 0, String.Length);
        }

        public byte[] ReadData(int count)
        {
            if (count > 0)
            {
                byte[] buffer = new byte[count];
                Read(buffer, 0, count);
                return buffer;
            }
            return new byte[0];
        }

        public float ReadFloat()
        {
            byte[] buffer = new byte[4];
            Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        public void ReadMetaData() //dummy
        {
            byte MetaDataType = (byte)ReadByte();
            while (MetaDataType != 127)
            {
                byte First3Bytes = (byte)(MetaDataType >> 0x05);
                byte Last5Bytes = (byte)(MetaDataType & 0x1F);

                switch (First3Bytes)
                {
                    case 0:
                        ReadByte();
                        break;
                    case 1:
                        ReadShort();
                        break;
                    case 2:
                        ReadInt();
                        break;
                    case 3:
                        ReadFloat();
                        break;
                    case 4:
                        ReadString(ReadShort());
                        break;
                    case 5:
                        ReadShort();
                        ReadByte();
                        ReadShort();
                        break;
                    case 6:
                        ReadInt();
                        ReadInt();
                        ReadInt();
                        break;
                    default:
                        throw new Exception();
                }
                MetaDataType = (byte)ReadByte();
            }
        }

        public void ReadSlot() //dummy
        {
            short Block = ReadShort();
            if (Block != -1)
            {
                ReadByte();
                ReadShort();

                int ByteArrayLength = ReadShort();

                if (ByteArrayLength > -1)
                    ReadData(ByteArrayLength);

            }
        }

        public override void WriteByte(byte b)
        {
            base.WriteByte(b);
        }

        public void WriteShort(short s)
        {
            byte[] data = BitConverter.GetBytes(s);
            Array.Reverse(data);
            Write(data, 0, 2);
        }

        public void WriteInt(int i)
        {
            byte[] data = BitConverter.GetBytes(i);
            Array.Reverse(data);
            Write(data, 0, 4);
        }

        public void WriteFloat(float f)
        {
            byte[] data = BitConverter.GetBytes(f);
            Array.Reverse(data);
            Write(data, 0, 4);
        }

        public void WriteString(string str)
        {
            WriteShort((short)str.Length);
            Write(Encoding.BigEndianUnicode.GetBytes(str), 0, str.Length * 2);
        }

        public void WriteData(byte[] data)
        {
            Write(data, 0, data.Length);
        }

        public void WriteDouble(double p)
        {
            byte[] data = BitConverter.GetBytes(p);
            Array.Reverse(data);
            Write(data, 0, 8);
        }

        public void WriteBool(bool b)
        {
            WriteByte(b ? (byte)1 : (byte)0);
        }
    }
}

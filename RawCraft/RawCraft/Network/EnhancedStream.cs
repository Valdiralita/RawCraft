using System;
using System.Text;
using System.Net.Sockets;

namespace RawCraft.Network
{
    public class EnhancedStream : NetworkStream
    {
        Encoding _enc = new UnicodeEncoding(true, true, true);
        byte[] _buffer, _data;

        public EnhancedStream(Socket s) : base(s)
        {
        }

        internal bool readBool()
        {
            return Convert.ToBoolean(ReadByte());
        }

        public short ReadShort()
        {
            _buffer = new byte[2];
            Read(_buffer, 0, 2);
            Array.Reverse(_buffer);
            return BitConverter.ToInt16(_buffer, 0);
        }

        public int ReadInt()
        {
            _buffer = new byte[4];
            Read(_buffer, 0, 4);
            Array.Reverse(_buffer);
            return BitConverter.ToInt32(_buffer, 0);
        }

        public double ReadDouble()
        {
            _buffer = new byte[8];
            Read(_buffer, 0, 8);
            Array.Reverse(_buffer);
            return BitConverter.ToDouble(_buffer, 0);
        }

        public Int64 ReadLong()
        {
            _buffer = new byte[8];
            Read(_buffer, 0, 8);
            Array.Reverse(_buffer);
            return BitConverter.ToInt64(_buffer, 0);
        }

        public string ReadString()
        {
            int length = ReadShort();
            _buffer = ReadData(length * 2);
            return _enc.GetString(_buffer, 0, _buffer.Length);
        }

        public byte[] ReadData(int count)
        {
            if (count > 0)
            {
                _buffer = new byte[count];
                Read(_buffer, 0, count);
                return _buffer;
            }
            return new byte[0];
        }

        public float ReadFloat()
        {
            _buffer = new byte[4];
            Read(_buffer, 0, 4);
            Array.Reverse(_buffer);
            return BitConverter.ToSingle(_buffer, 0);
        }

        public void ReadMetaData() //dummy
        {
            byte metaDataType = (byte)ReadByte();
            while (metaDataType != 127)
            {
                byte first3Bytes = (byte)(metaDataType >> 5);
                byte last5Bytes = (byte)(metaDataType & 0x1F);

                switch (first3Bytes)
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
                        ReadString();
                        break;
                    case 5:
                        ReadSlot();
                        break;
                    case 6:
                        ReadInt();
                        ReadInt();
                        ReadInt();
                        break;
                    default:
                        throw new Exception();
                }
                metaDataType = (byte)ReadByte();
            }
        }

        public void ReadSlot() //dummy
        {
            short slot = ReadShort();
            if (slot != -1)
            {
                ReadByte();
                ReadShort();

                int byteArrayLength = ReadShort();

                if (byteArrayLength > 0)
                    ReadData(byteArrayLength);
            }
        }

        public void WriteShort(short s)
        {
            _data = BitConverter.GetBytes(s);
            Array.Reverse(_data);
            Write(_data, 0, 2);
        }

        public void WriteInt(int i)
        {
            _data = BitConverter.GetBytes(i);
            Array.Reverse(_data);
            Write(_data, 0, 4);
        }

        public void WriteFloat(float f)
        {
            _data = BitConverter.GetBytes(f);
            Array.Reverse(_data);
            Write(_data, 0, 4);
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
            _data = BitConverter.GetBytes(p);
            Array.Reverse(_data);
            Write(_data, 0, 8);
        }

        public void WriteBool(bool b)
        {
            WriteByte(b ? (byte)1 : (byte)0);
        }
    }
}

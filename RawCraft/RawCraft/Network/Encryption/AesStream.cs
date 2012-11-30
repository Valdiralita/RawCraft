// =============================================================
// Credits and special thanks go to _68x - creator of this file.
// =============================================================

using System;
using System.IO;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace RawCraft.Network.Encryption
{
    public class AesStream : EnhancedStream
    {
        CryptoStream _enc;
        CryptoStream _dec;

        public AesStream(Socket socket, EnhancedStream stream, byte[] key) : base(socket)
        {
            BaseStream = stream;
            _enc = new CryptoStream(stream, GenerateAES(key).CreateEncryptor(), CryptoStreamMode.Write);
            _dec = new CryptoStream(stream, GenerateAES(key).CreateDecryptor(), CryptoStreamMode.Read);
        }
        public Stream BaseStream { get; set; }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            BaseStream.Flush();
        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        private RijndaelManaged GenerateAES(byte[] key)
        {
            RijndaelManaged cipher = new RijndaelManaged();
            cipher.Mode = CipherMode.CFB;
            cipher.Padding = PaddingMode.None;
            cipher.KeySize = 128;
            cipher.FeedbackSize = 8;
            cipher.Key = key;
            cipher.IV = key;

            return cipher;
        }

        public override int ReadByte()
        {
            return _dec.ReadByte();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _dec.Read(buffer, offset, count);
        }
        public override void WriteByte(byte b)
        {
            _enc.WriteByte(b);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _enc.Write(buffer, offset, count);
        }
    }
}
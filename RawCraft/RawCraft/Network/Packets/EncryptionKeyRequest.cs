using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Network.Packet
{
    class EncryptionKeyRequest
    {
        byte[] encryptedToken, encryptedSharedSecret;

        public EncryptionKeyRequest(Stream stream, byte[] SharedSecret,string SessionID, string Username)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Encryption Key Request (0xFD)");

            string ServerID = Reader.ReadString(stream, Reader.ReadSignedShort(stream));
            byte[] PublicKey = Reader.ReadData(stream, Reader.ReadSignedShort(stream));
            byte[] Token = Reader.ReadData(stream, Reader.ReadSignedShort(stream));

            encryptedToken = EncryptSHA1.RSAEnc(Token, PublicKey);
            encryptedSharedSecret = EncryptSHA1.RSAEnc(SharedSecret, PublicKey);
            byte[] data = Encoding.UTF8.GetBytes(ServerID).Concat(SharedSecret).Concat(PublicKey).ToArray();
            string serverSHAHash = EncryptSHA1.JavaHexDigest(data);

            Authentication.HTTPRequest(Username, SessionID, serverSHAHash);
        }

        public byte[] GetEncToken()
        {
            return encryptedToken;
        }

        public byte[] GetEncSharedSecret()
        {
            return encryptedSharedSecret;
        }
    }
}

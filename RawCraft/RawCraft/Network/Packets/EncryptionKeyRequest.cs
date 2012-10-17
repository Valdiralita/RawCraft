using System;
using System.Linq;
using System.Text;
using System.IO;
using RawCraft.Network.Encryption;

namespace RawCraft.Network.Packets
{
    class EncryptionKeyRequest
    {
        byte[] encryptedToken, encryptedSharedSecret;

        public EncryptionKeyRequest(Stream stream, byte[] sharedSecret, string sessionID, string username)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Encryption Key Request (0xFD)");

            string serverID = Reader.ReadString(stream, Reader.ReadSignedShort(stream));
            byte[] publicKey = Reader.ReadData(stream, Reader.ReadSignedShort(stream));
            byte[] token = Reader.ReadData(stream, Reader.ReadSignedShort(stream));

            encryptedToken = EncryptSHA1.RSAEnc(token, publicKey);
            encryptedSharedSecret = EncryptSHA1.RSAEnc(sharedSecret, publicKey);
            byte[] data = Encoding.UTF8.GetBytes(serverID).Concat(sharedSecret).Concat(publicKey).ToArray();
            string serverSHAHash = EncryptSHA1.JavaHexDigest(data);

            Authentication.Authentication.HTTPRequest(username, sessionID, serverSHAHash);
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

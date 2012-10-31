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

        public EncryptionKeyRequest(EnhancedStream stream, byte[] sharedSecret, string sessionID, string username)
        {
            Storage.Misc.Log.Write(DateTime.Now.TimeOfDay + " We got a: Encryption Key Request (0xFD)");

            string serverID = stream.ReadString(stream.ReadShort());
            byte[] publicKey = stream.ReadData(stream.ReadShort());
            byte[] token = stream.ReadData(stream.ReadShort());

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

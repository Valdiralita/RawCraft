using System.Linq;
using System.Text;
using RawCraft.Network.Encryption;

namespace RawCraft.Network.Packets
{
    class EncryptionKeyRequest
    {
        byte[] _encryptedToken, _encryptedSharedSecret;

        public EncryptionKeyRequest(EnhancedStream stream, byte[] sharedSecret, string sessionID, string username)
        {
            string serverID = stream.ReadString();
            byte[] publicKey = stream.ReadData(stream.ReadShort());
            byte[] token = stream.ReadData(stream.ReadShort());

            _encryptedToken = EncryptSHA1.RSAEnc(token, publicKey);
            _encryptedSharedSecret = EncryptSHA1.RSAEnc(sharedSecret, publicKey);
            byte[] data = Encoding.UTF8.GetBytes(serverID).Concat(sharedSecret).Concat(publicKey).ToArray();
            string serverSHAHash = EncryptSHA1.JavaHexDigest(data);

            Authentication.Authentication.HttpRequest(username, sessionID, serverSHAHash);
        }

        public byte[] GetEncToken()
        {
            return _encryptedToken;
        }

        public byte[] GetEncSharedSecret()
        {
            return _encryptedSharedSecret;
        }
    }
}

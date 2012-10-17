using System.Security.Cryptography;

namespace RawCraft.Network.Encryption
{
    class SharedSecretGenerator
    {
        private byte[] secret = new byte[16];

        public SharedSecretGenerator()
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            rng.GetBytes(secret);
        }

        public byte[] Get
        {
            get { return secret; }
        }
    }
}

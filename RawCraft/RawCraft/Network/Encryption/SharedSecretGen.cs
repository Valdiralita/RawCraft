using System.Security.Cryptography;

namespace RawCraft.Network.Encryption
{
    class SharedSecretGenerator
    {
        private byte[] _secret = new byte[16];

        public SharedSecretGenerator()
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            rng.GetBytes(_secret);
        }

        public byte[] Get
        {
            get { return _secret; }
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;
using CSInteropKeys;

namespace Network
{
    class EncryptSHA1
    {
        public static string JavaHexDigest(byte[] data)
        {
            var sha1 = SHA1.Create();

            byte[] hash = sha1.ComputeHash(data);
            bool negative = (hash[0] & 0x80) == 0x80;
            if (negative) // check for negative hashes
                hash = TwosCompliment(hash);
            // Create the string and trim away the zeroes
            string digest = GetHexString(hash).Trim('0');
            if (negative)
                digest = '-'+ digest;
            return digest;
        }

        private static string GetHexString(byte[] p)
        {
            string result = "";
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] < 0x10)
                    result += "0";
                result += p[i].ToString("x"); // Converts to hex string
            }
            return result;
        }

        private static byte[] TwosCompliment(byte[] p) // little endian
        {
            int i;
            for (i = 0; i < p.Length; i++)
                p[i] = (byte)~p[i];
            bool carry = true;
            i = p.Length - 1;
            while (carry)
            {
                carry = p[i] == 0xFF;
                p[i--]++;
            }
            return p;
        }

        public static byte[] RSAEnc(byte[] data, byte[] key) //RSA
        {
            AsnKeyParser keyParser = new AsnKeyParser(key);
            RSAParameters publicKey = keyParser.ParseRSAPublicKey();

            CspParameters csp = new CspParameters();

            csp.ProviderType = 1;

            csp.KeyNumber = 1;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);
            rsa.PersistKeyInCsp = false;
            rsa.ImportParameters(publicKey);
            byte[] enc = rsa.Encrypt(data, false);
            rsa.Clear();
            return enc;
        }
    }
}
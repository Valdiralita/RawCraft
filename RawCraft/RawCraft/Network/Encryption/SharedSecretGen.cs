using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Network
{
    class SharedSecretGen
    {
        private byte[] Secret = new byte[16];
        Random random;

        public SharedSecretGen()
        {
            random = new Random();
            random.NextBytes(Secret);
        }

        public byte[] Get
        {
            get { return Secret; }
        }
    }
}

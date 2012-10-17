using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Network
{
    static class Writer
    {
        public static byte[] StringToByteArray(string str) //unused
        {
            return new System.Text.ASCIIEncoding().GetBytes(str);
        }

        //todo: generic stream writer?
    }
}

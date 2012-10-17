using System.Text;

namespace RawCraft.Network
{
    static class Writer
    {
        public static byte[] StringToByteArray(string str) //unused
        {
            return Encoding.ASCII.GetBytes(str);
        }

        //todo: generic stream writer?
    }
}

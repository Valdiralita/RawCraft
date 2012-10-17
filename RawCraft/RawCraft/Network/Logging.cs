using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network
{
    class Logging
    {
        TextWriter file;
        private const string FileName = "log.txt";

        public Logging()
        {
            file = new StreamWriter(FileName, true);
        }

        public void Write(string line)
        {
            if (Misc.EnableLog)
            {
                file.WriteLine(line);
                file.Flush();
            }
        }
    }
}
using System;
using System.IO;
using Storage;

namespace Network
{
    class Logging
    {
        TextWriter file;
        string FileName = "log.txt";

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
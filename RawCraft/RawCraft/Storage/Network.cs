namespace RawCraft.Storage
{
    class Network
    {
        public static string UserName = "", Password = "", Server = ""; //this will be loaded into the textboxes at startup (implement some reading for last login)
        public static int Port = 25565;

        public static bool isConnected;
    }
}

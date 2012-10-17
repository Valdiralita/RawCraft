using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network.Encryption
{
    class SessionIDRequest
    {
        private const string loginUrl = "https://login.minecraft.net?user={0}&password={1}&version=13";

        string username, password;
        public string SessionID;

        public SessionIDRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void SendRequest()
        {
            var buffer = new byte[128];

            try
            {
                var request = WebRequest.Create(string.Format(loginUrl, username, password));
                var response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();

                var responseParts = new string[4];

                string responseString = Encoding.ASCII.GetString(buffer, 0, stream.Read(buffer, 0, buffer.Length));
                if (!responseString.Contains(':'))
                {
                    Misc.Log.Write("Bad login, bad password");
                    throw new InvalidDataException("Bad Login, implement disconnect behaviour here");
                }
                Misc.Log.Write(responseString); // debug

                SessionID = responseString.Split(':')[3];
            }
            catch
            {
                Storage.Network.UserName = "Player";
                Misc.Log.Write("Could not connect to 'login.minecraft.net'.");
                SessionID = "-";
            }
        }

        public string GetID()
        {
            return SessionID;
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace RawCraft.Network.Encryption
{
    class SessionIDRequest
    {
        private const string LoginUrl = "https://login.minecraft.net?user={0}&password={1}&version=13";

        string _username, _password;
        public string SessionID;

        public SessionIDRequest(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void SendRequest()
        {
            var buffer = new byte[128];

            try
            {
                var request = WebRequest.Create(string.Format(LoginUrl, _username, _password));
                var response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();

                if (stream != null)
                {
                    string responseString = Encoding.ASCII.GetString(buffer, 0, stream.Read(buffer, 0, buffer.Length));
                    if (!responseString.Contains(':'))
                    {
                        throw new InvalidDataException("Bad Login");
                    }

                    SessionID = responseString.Split(':')[3];
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Storage.Network.UserName = "Player";
                SessionID = "-";
            }
        }

        public string GetID()
        {
            return SessionID;
        }
    }
}

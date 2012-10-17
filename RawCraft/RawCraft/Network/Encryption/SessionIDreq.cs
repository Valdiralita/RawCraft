using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Storage;

namespace Network
{
    class SessionIDreq
    {
        string Username, Password;
        public string SessionID;

        public SessionIDreq(string username, string pw)
        {
            Username = username;
            Password = pw;
        }

        public void SendRequest()
        {
            byte[] Buffer = new byte[128];

            try
            {
                WebRequest request = WebRequest.Create("https://login.minecraft.net?user=" + Username + "&password=" + Password + "&version=13");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();

                string[] responseParts = new string[4];

                string responseString = Encoding.ASCII.GetString(Buffer, 0, stream.Read(Buffer, 0, Buffer.Length));
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

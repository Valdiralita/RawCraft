using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Storage;

namespace Network
{
    class Authentication
    {
        public static string HTTPRequest(string PlayerName, string SessionID, string hash)
        {
            byte[] Buffer = new byte[32];
            string HTTPResponse = "";
            try
            {
                WebRequest request = WebRequest.Create("http://session.minecraft.net/game/joinserver.jsp?user=" + PlayerName + "&sessionId=" + SessionID + "&serverId=" + hash);
                HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();
                Stream resStream = response.GetResponseStream();

                int count = resStream.Read(Buffer, 0, Buffer.Length);
                HTTPResponse = Encoding.ASCII.GetString(Buffer, 0, count);

                Misc.Log.Write("HTTP response was: '" + HTTPResponse + "'");
            }
            catch
            {
                Misc.Log.Write("Could not connect to minecraft.net server. Connecting in offline mode.");
            }

            return HTTPResponse;
        }
    }
}

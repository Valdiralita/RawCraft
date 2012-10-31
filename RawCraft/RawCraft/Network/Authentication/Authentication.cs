using System.Text;
using System.Net;
using System.IO;
using RawCraft.Storage;

namespace RawCraft.Network.Authentication
{
    class Authentication
    {
        private const string loginUrl = "http://session.minecraft.net/game/joinserver.jsp?user={0}&sessionId={1}&serverId={2}";

        public static string HTTPRequest(string playerName, string sessionID, string hash)
        {
            var buffer = new byte[32];
            string httpResponse = "";
            try
            {
                var request = WebRequest.Create(string.Format(loginUrl, playerName, sessionID, hash));
                var response = (HttpWebResponse)
                request.GetResponse();
                Stream resStream = response.GetResponseStream();

                int count = resStream.Read(buffer, 0, buffer.Length);
                httpResponse = Encoding.ASCII.GetString(buffer, 0, count);
            }
            catch
            {
            }

            return httpResponse;
        }
    }
}

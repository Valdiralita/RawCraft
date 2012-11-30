using System.Text;
using System.Net;
using System.IO;

namespace RawCraft.Network.Authentication
{
    static class Authentication
    {
        private const string LoginUrl = "http://session.minecraft.net/game/joinserver.jsp?user={0}&sessionId={1}&serverId={2}";

        public static string HttpRequest(string playerName, string sessionID, string hash)
        {
            var buffer = new byte[32];
            string httpResponse = "";
            try
            {
                var request = WebRequest.Create(string.Format(LoginUrl, playerName, sessionID, hash));
                var response = (HttpWebResponse)
                request.GetResponse();
                Stream resStream = response.GetResponseStream();

                if (resStream != null)
                {
                    int count = resStream.Read(buffer, 0, buffer.Length);
                    httpResponse = Encoding.ASCII.GetString(buffer, 0, count);
                }
            }
            catch
            {
            }

            return httpResponse;
        }
    }
}

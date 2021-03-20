using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsVideoDesktopApplicationServiceLibrary
{
    public static class XtreamCodeService
    {
        public static string xc_server_url = "http://hd.qwert.com:80";
        public static string Authenticate(string username, string password)
        {
            var xc_auth_url = $"{xc_server_url}/player_api.php?username={username}&password={password}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xc_auth_url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            try
            {
                using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using(Stream stream = response.GetResponseStream())
                using(StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            } catch (WebException e)
            {
                if(e.Status == WebExceptionStatus.ProtocolError)
                {
                    return "Bad";
                }
                return "Error";
            }
        }
    }
}

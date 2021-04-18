using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StrimoLibrary.Services
{
    public static class TMDBService
    {
        public static string api_key = "675a0678b964dc810918383d58ee83e3";
        public static string tmdb_url = "https://api.themoviedb.org/3/search/";
        public static string GetOrientationImage(string videoTitle)
        {
            return null;
        }

        public static string SearchVodByTitleAsync(string vodtitle)
        {
            var searchMovieURL = $"{tmdb_url}movie?api_key={api_key}&query={vodtitle}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(searchMovieURL);

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return "Bad_Streaming_URL";
                }
                return "Error";
            }

        }
    }
}

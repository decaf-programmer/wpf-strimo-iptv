using Newtonsoft.Json.Linq;
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
    public static class XtreamCodeService
    {
        public static string server_url = "http://hd.qweret.com:80";

        public static string Auth(string username, string password)
        {
            var request_url = $"{server_url}/player_api.php?username={username}&password={password}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(request_url);
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

        public static async Task<List<List<XCCategoryModel>>> DownloadAllCategories(string username, string password, List<string> categoryActionTypes, IProgress<int> progress, int currentProgress)
        {
            List<List<XCCategoryModel>> categoryModels = new List<List<XCCategoryModel>>();

            
            foreach(string categoryActionType in categoryActionTypes)
            {
                var results = await ReadCategoriesByType(username, password, categoryActionType);
                categoryModels.Add(results);

                currentProgress = (categoryModels.Count * 50) / categoryActionTypes.Count;
                progress.Report(currentProgress);
            }
            return categoryModels;
        }

        private static async Task<List<XCCategoryModel>> ReadCategoriesByType(string username, string password, string categoryAction)
        {
            var categoryRequestURL = $"{server_url}/player_api.php?username={username}&password={password}&action={categoryAction}";

            using(HttpClient httpClient = new HttpClient())
            {
                using(HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(categoryRequestURL))
                {
                    using(HttpContent httpContent = httpResponseMessage.Content)
                    {
                        var responseContent = await httpContent.ReadAsStringAsync();

                        var categoryModels = new JavaScriptSerializer().Deserialize<List<XCCategoryModel>>(responseContent);

                        foreach(XCCategoryModel categoryModel in categoryModels)
                        {
                            if (categoryAction.Equals("get_live_categories"))
                            {
                                categoryModel.category_type = XCCategoryType.Live;
                            } else if (categoryAction.Equals("get_series_categories"))
                            {
                                categoryModel.category_type = XCCategoryType.Serie;
                            } else if (categoryAction.Equals("get_vod_categories"))
                            {
                                categoryModel.category_type = XCCategoryType.Movie;
                            }
                        }
                        return categoryModels;
                    }
                }
            }
        }

        public static async Task<List<XCLiveStreamModel>> ReadLiveStreams(string username, string password, IProgress<int> progress, int currentProgress)
        {
            var liveStreamRequestURL = $"{server_url}/player_api.php?username={username}&password={password}&action=get_live_streams";

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(liveStreamRequestURL))
                {
                    using (HttpContent httpContent = httpResponseMessage.Content)
                    {
                        var responseContent = await httpContent.ReadAsStringAsync();

                        currentProgress += 15;
                        progress.Report(currentProgress);

                        var livestreamModels = new JavaScriptSerializer().Deserialize<List<XCLiveStreamModel>>(responseContent);
                        return livestreamModels;
                    }
                }
            }
        }

        public static async Task<List<XCVodStreamModel>> ReadVodStreams(string username, string password, IProgress<int> progress, int currentProgress)
        {
            var vodStreamRequestURL = $"{server_url}/player_api.php?username={username}&password={password}&action=get_vod_streams";

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(vodStreamRequestURL))
                {
                    using (HttpContent httpContent = httpResponseMessage.Content)
                    {
                        var responseContent = await httpContent.ReadAsStringAsync();

                        currentProgress += 10;
                        progress.Report(currentProgress);
                        
                        var vodStreamModels = new JavaScriptSerializer().Deserialize<List<XCVodStreamModel>>(responseContent);
                        return vodStreamModels;
                    }
                }
            }
        }
        public static async Task<List<XCSerieStreamModel>> ReadSerieStreams(string username, string password, IProgress<int> progress, int currentProgress)
        {
            var serieStreamRequestURL = $"{server_url}/player_api.php?username={username}&password={password}&action=get_series";
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(serieStreamRequestURL))
                {
                    using (HttpContent httpContent = httpResponseMessage.Content)
                    {
                        var responseContent = await httpContent.ReadAsStringAsync();

                        currentProgress += 10;
                        progress.Report(currentProgress);

                        var serieStreamModels = new JavaScriptSerializer().Deserialize<List<XCSerieStreamModel>>(responseContent);
                        return serieStreamModels;
                    }
                }
            }
        }

        public static List<XCVodImageModel> ReadVodImages(string username, string password, List<XCVodStreamModel> vodStreamModels, IProgress<int> progress, int currentProgress)
        {
            List<XCVodImageModel> vodImageModels = new List<XCVodImageModel>();


            foreach (XCVodStreamModel vodStream  in vodStreamModels)
            {
                XCVodImageModel temp = ReadVodBackdropImage(username, password, vodStream.stream_id);
                vodImageModels.Add(temp);

                //currentProgress = (vodImageModels.Count * 15) / vodStreamModels.Count;
                //progress.Report(currentProgress);
            }
            return vodImageModels;
        }

        public static XCVodImageModel ReadVodBackdropImage(string username, string password, int stream_id)
        {
            
            var vodStreamByIDRequestURL = $"{server_url}/player_api.php?username={username}&password={password}&action=get_vod_info&vod_id={stream_id}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(vodStreamByIDRequestURL);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    
                    string responseContent = reader.ReadToEnd();
                    JObject responseContentObj = JObject.Parse(responseContent);
                    JObject infoContentObj = JObject.FromObject(responseContentObj["info"]);
                    XCVodImageModel temp = new XCVodImageModel();
                    temp.stream_id = stream_id;
                    if (infoContentObj != null && infoContentObj.ContainsKey("backdrop_path"))
                    {

                        temp.backdrop_path = (string)infoContentObj["backdrop_path"][0];

                    }
                    else
                    {
                        temp.backdrop_path = null;
                    }
                    return temp;
                }
            }
            catch (WebException e)
            {
                return new XCVodImageModel() { stream_id = stream_id, backdrop_path = null };
            }

            
                    
        }

        public static string GetImageWithStreamId(string username, string password, int stream_id, Type stream_type){
            if(stream_type.Equals(typeof(XCVodStreamModel))){
                var request_url = $"{server_url}/player_api.php?username={username}&password={password}&action=get_vod_info&vod_id={stream_id}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(request_url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();
                        JObject contentObj = JObject.Parse(content);
                        if((string)contentObj["info"]["tmdb_id"] == ""){
                            // This should be customized by searching movie name in TMDB API...
                            return null;
                        } else {
                            return (string)contentObj["info"]["backdrop_path"][0];
                        }
                        
                    }
                }
                catch (WebException e)
                {
                    return null;
                }

            } else if (stream_type.Equals(typeof(XCSerieStreamModel))){
                var request_url = $"{server_url}/player_api.php?username={username}&password={password}&action=get_serie_info&serie_id={stream_id}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(request_url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();
                        JObject contentObj = JObject.Parse(content);
                        if((string)contentObj["info"]["tmdb_id"] == ""){
                            // This should be customized by searching movie name in TMDB API...
                            return null;
                        } else {
                            return (string)contentObj["info"]["backdrop_path"][0];
                        }
                    }
                }catch (WebException e)
                {
                    return null;
                }
            } else {
                return null;
            }
        }

    }

}


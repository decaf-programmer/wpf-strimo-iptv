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

        //public static async Task<List<List<CategoryModel>>> DownloadCategories(string username, string password, List<string> categoryActionTypes)
        //{
        //    List<Task<List<CategoryModel>>> categoryDownloadTasks = new List<Task<List<CategoryModel>>>();

        //    foreach(string categoryActionType in categoryActionTypes)
        //    {
        //        categoryDownloadTasks.Add(ReadCategories(username, password, categoryActionType));
        //    }

        //    var categoriesListArray = await Task.WhenAll(categoryDownloadTasks);

        //    //return new List<CategoryModel>(results);

        //    List<List<CategoryModel>> categoriesLists = categoriesListArray.ToList();
        //    return categoriesLists;
        //}

        public static async Task<List<List<CategoryModel>>> DownloadCategories(string username, string password, List<string> categoryActionTypes, IProgress<int> progress)
        {
            List<List<CategoryModel>> categoryModels = new List<List<CategoryModel>>();

            int report = 0;
            foreach(string categoryActionType in categoryActionTypes)
            {
                var results = await ReadCategories(username, password, categoryActionType);
                categoryModels.Add(results);

                report = (categoryModels.Count * 100) / categoryActionTypes.Count;
                progress.Report(report);
            }

            return categoryModels;

        }

        private static async Task<List<CategoryModel>> ReadCategories(string username, string password, string categoryAction)
        {
            var categoryRequestURL = $"{server_url}/player_api.php?username={username}&password={password}&action={categoryAction}";

            using(HttpClient httpClient = new HttpClient())
            {
                using(HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(categoryRequestURL))
                {
                    using(HttpContent httpContent = httpResponseMessage.Content)
                    {
                        var responseContent = await httpContent.ReadAsStringAsync();

                        var categoryModels = new JavaScriptSerializer().Deserialize<List<CategoryModel>>(responseContent);

                        foreach(CategoryModel categoryModel in categoryModels)
                        {
                            if (categoryAction.Equals("get_live_categories"))
                            {
                                categoryModel.category_type = CategoryType.Live;
                            } else if (categoryAction.Equals("get_series_categories"))
                            {
                                categoryModel.category_type = CategoryType.Serie;
                            } else if (categoryAction.Equals("get_vod_categories"))
                            {
                                categoryModel.category_type = CategoryType.Movie;
                            }
                        }
                        return categoryModels;
                    }
                }
            }
        }


        public static string ReadCategory(string username, string password, string action)
        {
            var request_url = $"{server_url}/player_api.php?username={username}&password={password}&action={action}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(request_url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using(StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            } catch(WebException e)
            {
                return "Error";
            }
        }
    }

}


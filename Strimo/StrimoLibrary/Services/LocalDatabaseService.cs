using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Services
{
    public class LocalDatabaseService
    {
        public HttpClient LocalDBClient { get; set; }

        public LocalDatabaseService()
        {

        }

        private void InitializeClient()
        {
            LocalDBClient = new HttpClient();
            LocalDBClient.DefaultRequestHeaders.Accept.Clear();
            LocalDBClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

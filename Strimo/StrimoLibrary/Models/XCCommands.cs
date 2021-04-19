using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Models
{
    public static class XCCommands
    {
        public static string GET_LIVE_CATEGORIES = "get_live_categories";
        public static string GET_SERIE_CATEGORIES = "get_series_categories";
        public static string GET_VOD_CATEGORIES = "get_vod_categories";

        public static List<string> GET_CATEGORIES = new List<string>() 
        { 
            GET_LIVE_CATEGORIES,
            GET_SERIE_CATEGORIES,
            GET_VOD_CATEGORIES
        };
    }
}

using StrimoLibrary.Models;
using StrimoUI.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Globals
{
    public static class GlobalVars
    {
        // Current Logged User...
        public static XCAuthInfoModel currentAuthInfo;

        // Xtream Codes Categories...
        public static List<XCCategoryModel> currentUserLiveCategories;
        public static List<XCCategoryModel> currentUserVodCategories;
        public static List<XCCategoryModel> currentUserSerieCategories;

        // Xtream Codes Stream Infos...
        public static List<XCLiveStreamModel> currentLiveStreams;
        public static List<XCVodStreamModel> currentVodStreams;
        public static List<XCSerieStreamModel> currentSerieStreams;
        public static List<XCLiveStreamModel> currentRadioStreams;

        public static List<XCVodImageModel> currentVodImages;
        
        // Xtream Code Last Added or Favourite Carousel Infos...
        public static List<CarouselModel> latestVodCarouselList;
        public static List<CarouselModel> latestSerieCaoureslList;
        public static List<CarouselModel> latestLiveCarouselList;
        public static List<CarouselModel> latestRadioCarouselList; 
    }
}

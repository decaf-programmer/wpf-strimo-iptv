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
        public static XCUserModel currentUser;

        // Xtream Codes Categories...
        public static List<XCCategoryModel> currentUserLiveCategories;
        public static List<XCCategoryModel> currentUserVodCategories;
        public static List<XCCategoryModel> currentUserSerieCategories;

        // Xtream Codes Stream Infos...
        public static List<XCLiveStreamModel> currentLiveStreams;
        public static List<XCVodStreamModel> currentVodStreams;
        public static List<XCSerieStreamModel> currentSerieStreams;

        // Xtrea Code Last Added or Favourite Carousel Infos...

        public static List<CarouselModel> lastVodCarouselList;
        public static List<CarouselModel> lastSerieCaoureslList;
        public static List<CarouselModel> lastLiveCarouselList;
    }
}

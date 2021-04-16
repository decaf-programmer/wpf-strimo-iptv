using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Globals
{
    public static class GlobalVars
    {
        public static XCUserModel currentUser;

        public static List<XCCategoryModel> currentUserLiveCategories;
        public static List<XCCategoryModel> currentUserVodCategories;
        public static List<XCCategoryModel> currentUserSerieCategories;

        public static int HomeLastMovieCarouselItemListSelectedIndex;
    }
}

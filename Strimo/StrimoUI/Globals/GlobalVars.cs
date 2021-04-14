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
        public static UserModel currentUser;

        public static List<CategoryModel> currentUserLiveCategories;
        public static List<CategoryModel> currentUserVodCategories;
        public static List<CategoryModel> currentUserSerieCategories;

        public static int HomeLastMovieCarouselItemListSelectedIndex;
    }
}

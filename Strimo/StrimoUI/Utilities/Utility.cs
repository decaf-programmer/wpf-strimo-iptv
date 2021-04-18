using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Utilities
{
    public static class Utility
    {

        public static List<CarouselModel> ExtractVodCarouselList(List<XCVodStreamModel> vods)
        {
            List<string> vodTitles = new List<string>();
            foreach(XCVodStreamModel vod in vods)
            {
                vodTitles.Add(vod.name);
            }

            string model = TMDBService.SearchVodByTitleAsync(vodTitles[0]);


            List<CarouselModel> carouselList = new List<CarouselModel>();
            return carouselList;
        }
    }
}

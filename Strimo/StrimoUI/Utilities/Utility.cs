using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Components.Models;
using StrimoUI.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Utilities
{
    public static class Utility
    {

        public static List<CarouselModel> ConvertStreamListToCarouselList<T>(List<T> streamList)
        {
            
            List<CarouselModel> carouselList = new List<CarouselModel>();

            string username = GlobalVars.currentAuthInfo.user_info.username;
            string password = GlobalVars.currentAuthInfo.user_info.password;


            Type streamType = typeof(T);
            foreach(T stream in streamList){
                CarouselModel temp = new CarouselModel();
                if(streamType.Equals(typeof(XCVodStreamModel))){
                    XCVodStreamModel vodStream = stream as XCVodStreamModel;
                    if (XtreamCodeService.GetImageWithStreamId(username, password, vodStream.stream_id, streamType) != null){
                        temp.CarouselItemTitle = vodStream.name;
                        temp.CarouselItemStreamId = vodStream.stream_id;
                        temp.CarouselItemImage = XtreamCodeService.GetImageWithStreamId(username, password, vodStream.stream_id, streamType);
                        temp.CarouselItemImageWidth = 670;
                        temp.CarouselItemImageHeight = 349;
                        temp.CarouselItemImageTop = 19;
                        temp.CarouselItemActive = false;
                        carouselList.Add(temp);
                    }
                } else if(streamType.Equals(typeof(XCSerieStreamModel))){
                    XCSerieStreamModel serieStream = stream as XCSerieStreamModel;
                    if (serieStream.backdrop_path[0] != null){
                        temp.CarouselItemTitle = serieStream.name;
                        temp.CarouselItemStreamId = serieStream.series_id;
                        temp.CarouselItemImage = serieStream.backdrop_path[0];
                        temp.CarouselItemImageWidth = 670;
                        temp.CarouselItemImageHeight = 312;
                        temp.CarouselItemImageTop = 19;
                        temp.CarouselItemActive = false;
                        carouselList.Add(temp);
                    }
                } else if(streamType.Equals(typeof(XCLiveStreamModel))){
                    XCLiveStreamModel liveStream = stream as XCLiveStreamModel;
                    if (liveStream.stream_icon != null){
                        temp.CarouselItemTitle = liveStream.name;
                        temp.CarouselItemStreamId = liveStream.stream_id;
                        temp.CarouselItemImage = liveStream.stream_icon;
                        temp.CarouselItemImageWidth = 274;
                        temp.CarouselItemImageHeight = 162;
                        temp.CarouselItemImageTop = 0;
                        temp.CarouselItemActive = false;
                        carouselList.Add(temp);
                    }
                }
            }
            return carouselList;
        }
    }
}

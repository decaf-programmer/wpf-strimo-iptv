using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StrimoUI.Components.Models
{
    public class CarouselModel
    {
        public string CarouselItemTitle { get; set; }
        public string CarouselItemImage { get; set; }
        private int _CarouselItemImageWidth;
        public int CarouselItemImageWidth { 
            get { return _CarouselItemImageWidth; } 
            set { _CarouselItemImageWidth = value; } 
        }

        private int _CarouselItemImageHeight;
        public int CarouselItemImageHeight
        {
            get { return _CarouselItemImageHeight; }
            set { _CarouselItemImageHeight = value; }
        }

        public int CarouselItemInnerImageWidth
        { 
            get { return _CarouselItemImageWidth - 2; }
            set
            {
                _CarouselItemImageWidth = value;
            }
        }

        public int CarouselItemInnerImageHeight
        {
            get { return _CarouselItemImageHeight-2; }
            set{ _CarouselItemImageHeight = value; }
        }

        public int CarouselItemImageTop { get; set; }

        public bool CarouselItemActive{ get; set; }
        public int CarouselItemStreamId { get; set; }
        
    }
}

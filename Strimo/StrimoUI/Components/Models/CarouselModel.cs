using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Components.Models
{
    public class CarouselModel
    {
        private string _CarouselItemTitle;
        public string CarouselItemTitle {
            get { return _CarouselItemTitle; }
            set { 
                _CarouselItemTitle = value;
            }
        }

        private string _CarouselItemImageName;
        public string CarouselItemImageName { 
            get {
                return $"/StrimoUI;component/Resources/{_CarouselItemImageName}.jpg";
            } 
            set {
                _CarouselItemImageName = value;
            } 
        }

        private CategoryType _CategoryType;
        public CategoryType CategoryType { 
            get { 
                return _CategoryType; 
            } 
            set
            {
                _CategoryType = value;
            }
        }

        private string _CategoryId;
        public string CategoryId { 
            get {
                return _CategoryId;
            } 
            set { 
                _CategoryId = value; 
            } 
        }
        public string ParentId { get; set; }
    }
}

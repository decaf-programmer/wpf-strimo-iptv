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

        private int _CarouselItemImageWidth;
        public int CarouselItemImageWidth
        {
            get { return _CarouselItemImageWidth; }
            set { _CarouselItemImageWidth = value; }
        }

        private int _CarouselItemImageHeight;
        public int CarouselItemImageHeight
        {
            get { return _CarouselItemImageHeight; }
            set { _CarouselItemImageHeight = value; }
        }

        private int _CarouselItemInnerImageWidth;
        public int CarouselItemInnerImageWidth
        {
            get { return _CarouselItemInnerImageWidth; }
            set { _CarouselItemInnerImageWidth = value; }
        }

        private int _CarouselItemInnerImageHeight;
        public int CarouselItemInnerImageHeight
        {
            get { return _CarouselItemInnerImageHeight; }
            set { _CarouselItemInnerImageHeight = value; }
        }

        private int _CarouselItemImageTop;
        public int CarouselItemImageTop
        {
            get
            {
                return _CarouselItemImageTop;
            }
            set
            {
                _CarouselItemImageTop = value;
            }
        }

        private bool _CarouselItemAlphaVisible;
        public bool CarouselItemAlphaVisible
        {
            get { return _CarouselItemAlphaVisible; }
            set
            {
                _CarouselItemAlphaVisible = value;
            }
        }

        private bool _CarouselItemTitleVisible;
        public bool CarouselItemTitleVisible
        {
            get { return _CarouselItemTitleVisible; }
            set
            {
                _CarouselItemTitleVisible = value;
            }
        }


        private CategoryType _CarouselItemCategoryType;
        public CategoryType CarouselItemCategoryType { 
            get { 
                return _CarouselItemCategoryType; 
            } 
            set
            {
                _CarouselItemCategoryType = value;
            }
        }

        private string _CarouselItemCategoryId;
        public string CarouselItemCategoryId
        { 
            get {
                return _CarouselItemCategoryId;
            } 
            set {
                _CarouselItemCategoryId = value; 
            } 
        }
        private string _CarouselItemParentId;
        public string CarouselItemParentId 
        {
            get { return _CarouselItemParentId; }
            set { _CarouselItemParentId = value; }
        }
    }
}

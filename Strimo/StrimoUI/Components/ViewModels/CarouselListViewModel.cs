using Caliburn.Micro;
using StrimoUI.Components.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StrimoUI.Components.ViewModels
{
    public class CarouselListViewModel:Screen
    {
		public int CarouselListWidth { get; set; }
		public int CarouselListHeight { get; set; }

		private ObservableCollection<CarouselModel> _CarouselListCollection;
		public ObservableCollection<CarouselModel> CarouselListCollection
		{
			get
			{
				return _CarouselListCollection;
			}
			set
			{
				_CarouselListCollection = value;
				NotifyOfPropertyChange(() => CarouselListCollection);
			}
		}

		public void CarouselList_PreviewMouseWheel(MouseWheelEventArgs e)
		{
			if (e.Delta > 0)
			{
				// Mouse Wheel Up...
				CarouselListMoveLeft();
			}
			else
			{
				// Mouse Wheel Down...
				CarouselListMoveRight();
			}
		}

		public void LeftButtonClick()
		{
			CarouselListMoveLeft();
		}

		public void RightButtonClick()
		{
			CarouselListMoveRight();
		}

		public void CarouselListMoveLeft()
		{
			CarouselListCollection[0].CarouselItemImageTop = 0;
			CarouselListCollection[0].CarouselItemImageHeight = 349;
			CarouselListCollection[0].CarouselItemInnerImageHeight = 347;
			CarouselListCollection[0].CarouselItemAlphaVisible = false;
			CarouselListCollection[0].CarouselItemTitleVisible = true;
			CarouselListCollection[0].CarouselItemBorderColor = "#EB761C";
			
			CarouselListCollection[1].CarouselItemImageTop = 19;
			CarouselListCollection[1].CarouselItemImageHeight = 312;
			CarouselListCollection[1].CarouselItemInnerImageHeight = 310;
			CarouselListCollection[1].CarouselItemAlphaVisible = true;
			CarouselListCollection[1].CarouselItemTitleVisible = false;
			CarouselListCollection[1].CarouselItemBorderColor = "#20ffffff";

			CarouselModel temp = CarouselListCollection[CarouselListCollection.Count - 1];
			for (int i = CarouselListCollection.Count - 1; i > 0; i--)
			{
				CarouselListCollection[i] = CarouselListCollection[i - 1];
				CarouselListCollection[i].CarouselItemImageTop = 19;
				CarouselListCollection[i].CarouselItemImageHeight = 312;
				CarouselListCollection[i].CarouselItemInnerImageHeight = 310;
				CarouselListCollection[i].CarouselItemAlphaVisible = true;
				CarouselListCollection[i].CarouselItemTitleVisible = false;
				CarouselListCollection[i].CarouselItemBorderColor = "#20ffffff";
			}
			CarouselListCollection[0] = temp;
		}

		public void CarouselListMoveRight()
		{
			CarouselListCollection[2].CarouselItemImageTop = 0;
			CarouselListCollection[2].CarouselItemImageHeight = 349;
			CarouselListCollection[2].CarouselItemInnerImageHeight = 347;
			CarouselListCollection[2].CarouselItemAlphaVisible = false;
			CarouselListCollection[2].CarouselItemTitleVisible = true;
			CarouselListCollection[2].CarouselItemBorderColor = "#EB761C";

			CarouselListCollection[1].CarouselItemImageTop = 19;
			CarouselListCollection[1].CarouselItemImageHeight = 312;
			CarouselListCollection[1].CarouselItemInnerImageHeight = 310;
			CarouselListCollection[1].CarouselItemAlphaVisible = true;
			CarouselListCollection[1].CarouselItemTitleVisible = false;
			CarouselListCollection[1].CarouselItemBorderColor = "#20ffffff";

			CarouselModel temp = CarouselListCollection[0];
			for (int i = 0; i < CarouselListCollection.Count - 1; i++)
			{
				CarouselListCollection[i] = CarouselListCollection[i + 1];
				CarouselListCollection[i].CarouselItemImageTop = 19;
				CarouselListCollection[i].CarouselItemImageHeight = 312;
				CarouselListCollection[i].CarouselItemInnerImageHeight = 310;
				CarouselListCollection[i].CarouselItemAlphaVisible = true;
				CarouselListCollection[i].CarouselItemTitleVisible = false;
				CarouselListCollection[i].CarouselItemBorderColor = "#20ffffff";
			}

			CarouselListCollection[CarouselListCollection.Count - 1] = temp;
		}
	}
}

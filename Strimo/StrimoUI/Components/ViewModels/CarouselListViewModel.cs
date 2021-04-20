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
		public string CarouselListHeader { get; set; }
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
			CarouselListCollection[0].CarouselItemActive = true;
			
			
			CarouselListCollection[1].CarouselItemImageTop = 19;
			CarouselListCollection[1].CarouselItemImageHeight = 312;
			CarouselListCollection[1].CarouselItemActive = false;

			CarouselModel temp = CarouselListCollection[CarouselListCollection.Count - 1];
			for (int i = CarouselListCollection.Count - 1; i > 0; i--)
			{
				CarouselListCollection[i] = CarouselListCollection[i - 1];
				CarouselListCollection[i].CarouselItemImageTop = 19;
				CarouselListCollection[i].CarouselItemImageHeight = 312;
				CarouselListCollection[i].CarouselItemActive = false;
			}
			CarouselListCollection[0] = temp;
		}

		public void CarouselListMoveRight()
		{
			CarouselListCollection[2].CarouselItemImageTop = 0;
			CarouselListCollection[2].CarouselItemImageHeight = 349;
			CarouselListCollection[2].CarouselItemActive = true;

			CarouselListCollection[1].CarouselItemImageTop = 19;
			CarouselListCollection[1].CarouselItemImageHeight = 312;
			CarouselListCollection[1].CarouselItemActive = false;

			CarouselModel temp = CarouselListCollection[0];
			for (int i = 0; i < CarouselListCollection.Count - 1; i++)
			{
				CarouselListCollection[i] = CarouselListCollection[i + 1];
				CarouselListCollection[i].CarouselItemImageTop = 19;
				CarouselListCollection[i].CarouselItemImageHeight = 312;
				CarouselListCollection[i].CarouselItemActive = false;
			}

			CarouselListCollection[CarouselListCollection.Count - 1] = temp;
		}
	}
}

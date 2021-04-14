using Caliburn.Micro;
using StrimoUI.Components.Models;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StrimoUI.Pages.ViewModels.Content
{
    public class DashboardViewModel:Screen
    {

		private ObservableCollection<CarouselModel> _lastMovieCollection;
		public ObservableCollection<CarouselModel> LastMovieCollection
		{
			get
			{
				return _lastMovieCollection;
			}
			set
			{
				_lastMovieCollection = value;
				NotifyOfPropertyChange(() => LastMovieCollection);
			}
		}
		public DashboardViewModel()
		{
			LastMovieCollection = new ObservableCollection<CarouselModel>();
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "Buchanan", 
				CarouselItemImageName="movie_backdrop1", 
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 312, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 309,
				CarouselItemImageTop = 19
			});
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "Callahan", 
				CarouselItemImageName= "movie_backdrop2", 
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 349, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 347,
				CarouselItemImageTop = 0
			});
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "Davolio", 
				CarouselItemImageName= "movie_backdrop3", 
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 312, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 310,
				CarouselItemImageTop = 19
			});
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "Dodsworth", 
				CarouselItemImageName= "movie_backdrop4",
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 312, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 310,
				CarouselItemImageTop = 19
			});
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "Fuller", 
				CarouselItemImageName= "movie_backdrop5", 
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 312, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 310,
				CarouselItemImageTop = 19
			});
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "King", 
				CarouselItemImageName= "movie_backdrop6", 
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 312, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 310,
				CarouselItemImageTop = 19
			});
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "Leverling", 
				CarouselItemImageName = "movie_backdrop7", 
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 312, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 310,
				CarouselItemImageTop = 19
			});
			LastMovieCollection.Add(new CarouselModel() { 
				CarouselItemTitle = "Suyama", 
				CarouselItemImageName = "movie_backdrop8", 
				CarouselItemImageWidth = 670, 
				CarouselItemImageHeight = 312, 
				CarouselItemInnerImageWidth = 668, 
				CarouselItemInnerImageHeight = 310,
				CarouselItemImageTop = 19
			});
		}

		public void CarouselList_PreviewMouseWheel(MouseWheelEventArgs e)
        {
			if(e.Delta > 0)
            {
				// Mouse Wheel Up...
				CarouselModel temp = LastMovieCollection[LastMovieCollection.Count - 1];
				for (int i = LastMovieCollection.Count - 1; i > 0; i--)
				{
					LastMovieCollection[i] = LastMovieCollection[i - 1];
				}
				LastMovieCollection[0] = temp;


			} else
            {
				// Mouse Wheel Down...
				
				CarouselModel temp = LastMovieCollection[0];
				for (int i = 0; i < LastMovieCollection.Count - 1; i++)
				{
					LastMovieCollection[i] = LastMovieCollection[i + 1];
				}

				LastMovieCollection[LastMovieCollection.Count - 1] = temp;
			}

			
        }

	}
}

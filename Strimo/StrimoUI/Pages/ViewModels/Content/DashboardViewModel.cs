using Caliburn.Micro;
using StrimoUI.Components.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Pages.ViewModels.Content
{
    public class DashboardViewModel:Screen
    {
		private ObservableCollection<CarouselModel> collection;
		public ObservableCollection<CarouselModel> HeaderCollection
		{
			get
			{
				return collection;
			}
			set
			{
				collection = value;
			}
		}
		public DashboardViewModel()
		{
			HeaderCollection = new ObservableCollection<CarouselModel>();
			HeaderCollection.Add(new CarouselModel() { Header = "Buchanan" });
			HeaderCollection.Add(new CarouselModel() { Header = "Callahan" });
			HeaderCollection.Add(new CarouselModel() { Header = "Davolio" });
			HeaderCollection.Add(new CarouselModel() { Header = "Dodsworth" });
			HeaderCollection.Add(new CarouselModel() { Header = "Fuller" });
			HeaderCollection.Add(new CarouselModel() { Header = "King" });
			HeaderCollection.Add(new CarouselModel() { Header = "Leverling" });
			HeaderCollection.Add(new CarouselModel() { Header = "Suyama" });
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
	class NavigationViewModel : INotifyPropertyChanged
	{
		
		private object selectedViewModel;
		public object SelectedViewModel
		{
			get { return selectedViewModel; }
			set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
		}

		public void Init()
		{
			SelectedViewModel = new HomePageViewModel();
		}

		private void OpenFares(object obj)
		{
			SelectedViewModel = new FaresPageViewModel();
		}

		private void OpenDuration(object obj)
		{
			SelectedViewModel = new DurationPageViewModel();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propName)
		{

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}

	}
}

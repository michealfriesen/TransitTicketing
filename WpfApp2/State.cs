using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
	class State
	{
		public static MainWindow PageSwitcher;
		public static int StepNumber;
		public static UserControl CurrentPage;

		public static void Init()
		{
			Flow = new UserControl[] { new HomePage(), new DurationPage(), new FaresPage(), new SummaryPage() };
			StepNumber = 0;
			CurrentPage = Flow[StepNumber];
		}

		public static void Switch(UserControl newPage)
		{
			PageSwitcher.Navigate(newPage);
		}

		public static void Next()
		{
			StepNumber++;
			CurrentPage = Flow[StepNumber];
			PageSwitcher.Navigate(CurrentPage);
		}

		public static UserControl[] Flow;
	}
}

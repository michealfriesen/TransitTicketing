using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for HomePage.xaml
	/// </summary>
	public partial class HomePage : UserControl
	{
        public String title
        {
            get { return "Home Page"; }
        }
        public String time
        {
            get { return DateTime.Now.ToString("HH:mm"); }
        }
        public String date
        {
            get { return DateTime.Now.ToString("MM/dd/yyy"); }
        }
        public HomePage()
		{
			InitializeComponent();

            this.Express_expiry.Text = DateTime.Now.AddHours(2.0).ToString("MM/dd/yyy HH:mm");
        }
    }

	class HomePageViewModel : IViewModel { }
}

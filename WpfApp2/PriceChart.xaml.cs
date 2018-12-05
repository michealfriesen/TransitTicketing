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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class PriceChart : UserControl 
    {
        public String title
        {
            get { return "Price Chart"; }
        }
        public String time
        {
            get { return DateTime.Now.ToString("HH:mm"); }
        }
        public String date
        {
            get { return DateTime.Now.ToString("MM/dd/yyy"); }
        }
        public PriceChart()
        {
            InitializeComponent();
        }

        private void Header_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

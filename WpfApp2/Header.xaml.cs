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
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for FooterNavigation.xaml
    /// </summary>
    public partial class Header : UserControl
    {
		public Header()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.clock_label.Content = DateTime.Now.ToString("HH:mm");
                this.date_label.Content = DateTime.Now.ToString("MM/dd/yyyy");
            }, this.Dispatcher);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

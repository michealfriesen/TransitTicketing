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
    /// Interaction logic for FooterNavigation.xaml
    /// </summary>
    public partial class FooterNavigation : UserControl
    {
		public event EventHandler OnPrevious;
		public event EventHandler OnNext;

		public FooterNavigation()
        {
            InitializeComponent();
        }

		private void Next_Click(object sender, RoutedEventArgs e)
		{
			this.OnNext?.Invoke(this, new EventArgs());
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			this.OnPrevious?.Invoke(this, new EventArgs());
		}
	}
}

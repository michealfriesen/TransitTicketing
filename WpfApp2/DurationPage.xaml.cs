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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for DurationWindow.xaml
    /// </summary>
    public partial class DurationPage : UserControl
    {
        public String title
        {
            get { return "Duration"; }
        }
        public String time
        {
            get { return DateTime.Now.ToString("HH:mm"); }
        }
        public String date
        {
            get { return DateTime.Now.ToString("MM/dd/yyy"); }
        }
        public DurationPage()
        {
            InitializeComponent();

            this.TwoHours_expiry.Text = DateTime.Now.AddHours(2.0).ToString("MM/dd/yyy HH:mm");
            this.FullDay_expiry.Text = DateTime.Now.AddDays(1.0).ToString("MM/dd/yyy HH:mm");
            this.ThreeDays_expiry.Text = DateTime.Now.AddDays(3.0).ToString("MM/dd/yyy HH:mm");
            this.Week_expiry.Text = DateTime.Now.AddDays(7.0).ToString("MM/dd/yyy HH:mm");
            this.Month_expiry.Text = DateTime.Now.AddMonths(1).ToString("MM/dd/yyy HH:mm");
        }
    }

	class DurationPageViewModel:IViewModel { }
}

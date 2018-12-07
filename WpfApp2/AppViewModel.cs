using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;

namespace WpfApp2
{
	class AppViewModel : INotifyPropertyChanged
	{
        private PurchaseState purchaseState;
        public PurchaseState PurchaseState
        {
            get { return purchaseState; }
            set { purchaseState = value; OnPropertyChanged("PurchaseState"); }
        }

        //public object SelectedPage_actual { get { return SelectedPage; } set { SelectedPage = value; } }

        #region Initialization
        public void Init()
        {
            purchaseState = new PurchaseState();
            SelectedPage = new HomePage();
        }
        #endregion

        #region Property Changed Handling
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        
        private void TriggerPurchaseStateUIUpdate()
        {
            OnPropertyChanged("PurchaseState");
        }

        public string GetEnumType
        {
            get{
                Type type = PurchaseState.SelectedDuration.GetType();
                var next = type.GetMember(PurchaseState.SelectedDuration.ToString());
                var after = next[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var tmpstring = (DescriptionAttribute)after[0];
                return tmpstring.Description.ToString();
            }
            
        }
        
        public string GetExpiry
        {
            get
            {
                var type = PurchaseState.SelectedDuration;
                switch (type){
                    case TicketDuration.SingleFare:
                        return "Valid Until: " + DateTime.Now.AddHours(2.0).ToString("MM/dd/yyyy HH:mm");
                    case TicketDuration.FullDay:
                        return "Valid Until: " + DateTime.Now.AddDays(1.0).ToString("MM/dd/yyyy HH:mm");
                    case TicketDuration.ThreeDay:
                        return "Valid Until:" + DateTime.Now.AddDays(3.0).ToString("MM/dd/yyyy HH:mm");
                    case TicketDuration.Week:
                        return "Valid Until: " + DateTime.Now.AddDays(7.0).ToString("MM/dd/yyyy HH:mm");
                    case TicketDuration.Month:
                        return "Valid Until:" + DateTime.Now.AddMonths(1).ToString("MM/dd/yyyy HH:mm");
                    default:
                        return "Valid Until: " + DateTime.Now.AddHours(2.0).ToString("MM/dd/yyyy HH:mm");

                }

                
            }
        }

        #endregion

        #region Navigation
        public ICommand OnGoToPriceChartPage
        {
            get
            {
                return new CommandHandler(param => GoToPriceChartPage(), true);
            }
        }
        public void GoToPriceChartPage()
        {
            SelectedPage = new PriceChart();
        }

        public ICommand OnGoToHomePage
        {
            get
            {
                return new CommandHandler(param => GoToHomePage(), true);
            }
        }
        public void GoToHomePage()
        {
            SelectedPage = new HomePage();
            this.Init();
        }

        public ICommand OnGoToFaresPage
        {
            get
            {
                return new CommandHandler(param => GoToFaresPage(), true);
            }
        }
        public void GoToFaresPage()
        {
            SelectedPage = new FaresPage();
        }

        public ICommand OnGoToDurationPage
        {
            get
            {
                return new CommandHandler(param => GoToDurationPage(), true);
            }
        }
        public void GoToDurationPage()
        {
            SelectedPage = new DurationPage();
        }

        public ICommand OnGoToSummaryPage
        {
            get
            {
                return new CommandHandler(param => GoToSummaryPage(), true);
            }
        }
        public void GoToSummaryPage()
        {
            if(PurchaseState.GetTotal > 0.0M)
            {
                SelectedPage = new SummaryPage();
            }
            
        }

        public ICommand OnExpressAdult
        {
            get
            {
                return new CommandHandler(param => ExpressAdult(), true);
            }
        }
        public void ExpressAdult()
        {
            //set the state for one adult regular ticket.
            PurchaseState.SelectDuration(TicketDuration.SingleFare);
            PurchaseState.IncreaseTicketQuantity(TicketAge.Adult);
            GoToSummaryPage();
        }

        public ICommand OnExpressYouth
        {
            get
            {
                return new CommandHandler(param => ExpressYouth(), true);
            }
        }
        public void ExpressYouth()
        {
            //set the state for one youth regular ticket.
            PurchaseState.SelectDuration(TicketDuration.SingleFare);
            PurchaseState.IncreaseTicketQuantity(TicketAge.Youth);
            GoToSummaryPage();
        }

        public ICommand OnExpressSenior
        {
            get
            {
                return new CommandHandler(param => ExpressSenior(), true);
            }
        }
        public void ExpressSenior()
        {
            //set the state for one senior regular ticket.
            PurchaseState.SelectDuration(TicketDuration.SingleFare);
            PurchaseState.IncreaseTicketQuantity(TicketAge.Senior);
            GoToSummaryPage();
        }

        public ICommand OnGoToPrintingPage
        {
            get
            {
                return new CommandHandler(param => GoToPrintingPage(), true);
            }
        }
        public void GoToPrintingPage()
        {
            SelectedPage = new PrintingPage();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                this.Init();
            };
        }

        public ICommand OnExitSession
        {
            get
            {
                return new CommandHandler(param => ExitSession(), true);
            }
        }
        public void ExitSession()
        {
             this.Init();
        }

        private object selectedPage;
		public object SelectedPage
		{
			get { return selectedPage; }
			set { selectedPage = value; OnPropertyChanged("SelectedPage"); }
		}

        public ICommand OnAcceptPayment
        {
            get
            {
                return new CommandHandler(param => AcceptPayment(), true);
            }
        }
        public void AcceptPayment()
        { 
                GoToPrintingPage();
        }
        #endregion

        #region State Handing

        public ICommand OnSelectDuration { get { return new CommandHandler(param => SelectDuration((TicketDuration)param)); } }
        public void SelectDuration(TicketDuration duration)
        {
			PurchaseState.SelectDuration(duration);
            this.GoToFaresPage();
        }

        public ICommand OnIncreaseTicketQuantity { get { return new CommandHandler(param => IncreaseTicketQuantity((TicketAge)param)); } }
        public void IncreaseTicketQuantity(TicketAge age)
        {
            PurchaseState.IncreaseTicketQuantity(age);
            TriggerPurchaseStateUIUpdate();
        }

        public ICommand OnDecreaseTicketQuantity { get { return new CommandHandler(param => DecreaseTicketQuantity((TicketAge)param)); } }
        public void DecreaseTicketQuantity(TicketAge age)
        {
            PurchaseState.DecreaseTicketQuantity(age);
            TriggerPurchaseStateUIUpdate();
        }
        #endregion

    }

    public class CommandHandler : ICommand
	{
        private readonly Action<object> _action;
        private bool _canExecute = true;
		public CommandHandler(Action<object> action, bool canExec=true)
		{
			_action = action;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			_action(parameter);
		}
	}
}

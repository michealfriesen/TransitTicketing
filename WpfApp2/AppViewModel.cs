using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        #endregion

        #region Navigation

        public void GoToPriceChart()
        {
            throw new NotImplementedException();
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
            SelectedPage = new SummaryPage();
        }

        private object selectedPage;
		public object SelectedPage
		{
			get { return selectedPage; }
			set { selectedPage = value; OnPropertyChanged("SelectedPage"); }
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

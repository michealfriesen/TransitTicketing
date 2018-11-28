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
            var adultTicketType = new TicketType {  Name = "Adult" };
            var youthTicketType = new TicketType {  Name = "Youth" };
            var seniorTicketType = new TicketType {  Name = "Senior" };
            purchaseState = new PurchaseState();
            purchaseState.TicketTypes = new TicketType[] { adultTicketType, youthTicketType, seniorTicketType };
            SelectedViewModel = flow[stepNumber];
        }
        #endregion

        #region Property Changed Handling
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        #region Navigation 

        public IViewModel[] flow = new IViewModel[] { new HomePageViewModel(), new DurationPageViewModel(), new FaresPageViewModel(), new SummaryPageViewModel() };
		private int stepNumber = 0;

		public ICommand OnNext
		{
			get
			{
				return new CommandHandler(param => GoToNext(), true);
			}
		}
		public void GoToNext()
		{
			if (stepNumber < flow.Length)
			{
				stepNumber++;
				SelectedViewModel = flow[stepNumber];
			}
		}
		
		public ICommand OnPrevious
		{
			get
			{
				return new CommandHandler(param => GoToPrevious(), true);
			}
		}
		public void GoToPrevious()
		{
			if (stepNumber > 0)
			{
				stepNumber--;
				SelectedViewModel = flow[stepNumber];
			}
		}

		private object selectedViewModel;
		public object SelectedViewModel
		{
			get { return selectedViewModel; }
			set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
		}
        #endregion

        #region State Handing
   
        public ICommand OnSelectDuration { get { return new CommandHandler(param => SelectDuration((TicketDurationType)param)); } }
        public void SelectDuration(TicketDurationType type)
        {
            PurchaseState.Duration = type;
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

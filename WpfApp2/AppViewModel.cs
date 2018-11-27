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
		#region Navigation 
		
		public IViewModel[] flow = new IViewModel[] { new HomePageViewModel(), new DurationPageViewModel(), new FaresPageViewModel(), new SummaryPageViewModel() };
		private int stepNumber = 0;

		public ICommand OnNext
		{
			get
			{
				return new CommandHandler(() => GoToNext(), true);
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
				return new CommandHandler(() => GoToPrevious(), true);
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

		public void Init()
		{
			SelectedViewModel = flow[stepNumber];
		}

		
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propName)
		{

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}

	}

	public class CommandHandler : ICommand
	{
		private Action _action;
		private bool _canExecute = true;
		public CommandHandler(Action action, bool canExec=true)
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
			_action();
		}
	}
}

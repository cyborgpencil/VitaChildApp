using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace VitaChildApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private DelegateCommand _exitAppCommand;
        public DelegateCommand ExitAppCommand
        {
            get { return _exitAppCommand; }
            set { SetProperty(ref _exitAppCommand, value); }
        }

        public MainWindowViewModel()
        {
            ExitAppCommand = new DelegateCommand(ExitApp);
        }

        // Commands
        private void ExitApp()
        {
            Application.Current.Shutdown();
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.IO;
using System.Diagnostics;
using VitaChildApp.Utilities;

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
        private readonly IRegionManager _regionManager;
        private DelegateCommand _mainWindowLoadedCommand;
        public DelegateCommand MainWindowLoadedCommand
        {
            get { return _mainWindowLoadedCommand; }
            set { SetProperty(ref _mainWindowLoadedCommand, value); }
        }
        private DelegateCommand _openAppFolderCommand;
        public DelegateCommand OpenAppFolderCommand
        {
            get { return _openAppFolderCommand; }
            set { SetProperty(ref _openAppFolderCommand, value); }
        }

        public MainWindowViewModel()
        {
            ExitAppCommand = new DelegateCommand(ExitApp);
            MainWindowLoadedCommand = new DelegateCommand(MainWindowLoaded);
            OpenAppFolderCommand = new DelegateCommand(()=> Process.Start(FileManager.Instance.WorkingFolder));
        }

        public MainWindowViewModel( IRegionManager regionManager) :this()
        {
            _regionManager = regionManager;
        }

        // Commands
        private void ExitApp()
        {
            Application.Current.Shutdown();
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("NavigationRegion", uri);
        }

        private void MainWindowLoaded()
        {
            Navigate("MealPlannerView");

        }
    }
}

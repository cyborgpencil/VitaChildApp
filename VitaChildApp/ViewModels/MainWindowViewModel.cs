using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.IO;
using System.Diagnostics;
using VitaChildApp.Utilities;
using System;
using System.Windows.Controls;
using VitaChildApp.Views;
using System.Windows.Documents;

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
        private DelegateCommand _printMealCommand;
        public DelegateCommand PrintMealCommand
        {
            get { return _printMealCommand; }
            set { SetProperty(ref _printMealCommand, value); }
        }

        public MainWindowViewModel()
        {
            ExitAppCommand = new DelegateCommand(ExitApp);
            MainWindowLoadedCommand = new DelegateCommand(MainWindowLoaded);
            OpenAppFolderCommand = new DelegateCommand(()=> Process.Start(FileManager.Instance.WorkingFolder));
            PrintMealCommand = new DelegateCommand(PrintMeal);
        }

        private void PrintMeal()
        {
            // Print Dialog
            PrintDialog printDlg = new PrintDialog();
            FlowDocument MealPrint = new FlowDocument();
            MealPrint.DataContext = App.Current.MainWindow.DataContext;
            IDocumentPaginatorSource dpage = MealPrint;
            printDlg.PrintDocument(dpage.DocumentPaginator, "Test");
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
            Navigate("MealPlannerBaseView");

        }
    }
}

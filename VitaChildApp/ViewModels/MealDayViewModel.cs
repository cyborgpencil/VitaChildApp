using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using VitaChildApp.Models;
using VitaChildApp.Utilities;

namespace VitaChildApp.ViewModels
{
    public class MealDayViewModel : BindableBase
    {

        #region PRISM PROPS
        private ICollectionView _currentFoodList;
        public ICollectionView CurrentFoodList
        {
            get { return _currentFoodList; }
            set { SetProperty(ref _currentFoodList, value); }
        }
        #endregion

        #region PROPS
        #endregion

        #region COMMANDS
        private DelegateCommand _loadedCommand;
        public DelegateCommand LoadedCommand
        {
            get { return _loadedCommand; }
            set { SetProperty(ref _loadedCommand, value); }
        }
        private DelegateCommand _lostFocusCommand;
        public DelegateCommand LostFocusCommand
        {
            get { return _lostFocusCommand; }
            set { SetProperty(ref _lostFocusCommand, value); }
        }
        #endregion

        #region CTOR
        public MealDayViewModel()
        {
            LoadedCommand = new DelegateCommand(Loaded);
            LostFocusCommand = new DelegateCommand(LostFocus);

            IList<FoodItem> FoodItems = FoodItemsFileManager.Instance.GetFoodItemList();
            CurrentFoodList = CollectionViewSource.GetDefaultView(FoodItems);
        }

        #endregion

        #region EVENTS
        private void Loaded()
        {
            // Load Current Food Item List
            IList<FoodItem> FoodItems = FoodItemsFileManager.Instance.GetFoodItemList();
            CurrentFoodList = CollectionViewSource.GetDefaultView(FoodItems);

            // Refresh CollectionViewSource
            CurrentFoodList.Refresh();
        }
        private void LostFocus()
        {
            // Load Current Food Item List
        }
        #endregion
    }
}

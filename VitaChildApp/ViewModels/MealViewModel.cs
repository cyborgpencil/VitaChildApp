using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using VitaChildApp.Models;
using VitaChildApp.Utilities;

namespace VitaChildApp.ViewModels
{
    public class MealViewModel : BindableBase
    {
        private ObservableCollection<FoodItem> _currentFoodItems;
        public ObservableCollection<FoodItem> CurrentFoodItems
        {
            get { return _currentFoodItems; }
            set { SetProperty(ref _currentFoodItems, value); }
        }
        
        private FoodItem _selectedFoodItem;
        public FoodItem SelectedFoodItem
        {
            get { return _selectedFoodItem; }
            set { SetProperty(ref _selectedFoodItem, value); }
        }
        private Meal _currentMeal;
        public Meal CurrentMeal
        {
            get { return _currentMeal; }
            set { SetProperty(ref _currentMeal, value); }
        }

        private DelegateCommand _addFoodItemCommand;
        public DelegateCommand AddFoodItemCommand
        {
            get { return _addFoodItemCommand; }
            set { SetProperty(ref _addFoodItemCommand, value); }
        }

        public MealViewModel()
        {
            // Load foodItems
            //FoodItemsFileManager FiM = new FoodItemsFileManager();
            //CurrentFoodItems = FiM.LoadFoodItems();

            CurrentMeal = new Meal();
            CurrentMeal.FoodItemList = new ObservableCollection<FoodItem>();
            AddFoodItemCommand = new DelegateCommand(CanAddFoodItem);
        }

        private void CanAddFoodItem()
        {
            if(SelectedFoodItem != null)
            {
                CurrentMeal.FoodItemList.Add(SelectedFoodItem);
            }

            SelectedFoodItem = null;
        }
    }
}

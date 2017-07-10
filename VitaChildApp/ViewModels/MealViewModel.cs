using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MealViewModel()
        {
            // Load foodItems
            FoodItemsFileManager FiM = new FoodItemsFileManager();
            CurrentFoodItems = FiM.LoadFoodItems();
        }
    }
}

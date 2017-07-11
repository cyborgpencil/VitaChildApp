
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
/// <summary>
/// Meals that is used to make a meal plan
/// </summary>
namespace VitaChildApp.Models
{
    public class Meal : BindableBase
    {
        private ObservableCollection<FoodItem> _foodItemList;
        public ObservableCollection<FoodItem> FoodItemList
        {
            get { return _foodItemList; }
            set { SetProperty(ref _foodItemList, value); }
        }

        private MealTimes _mealTimes;
        public MealTimes MealTimes
        {
            get { return _mealTimes; }
            set { SetProperty(ref _mealTimes, value); }
        }
    }
}

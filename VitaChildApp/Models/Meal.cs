
using Prism.Mvvm;
using System;
using System.Collections.Generic;
/// <summary>
/// Meals that is used to make a meal plan
/// </summary>
namespace VitaChildApp.Models
{
    public class Meal : BindableBase
    {
        private List<FoodItem> _foodItemList;
        public List<FoodItem> FoodItemList
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

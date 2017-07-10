﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace VitaChildApp.ViewModels
{
    public class MealPlannerBaseViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private DelegateCommand _navigateHomeCommand;
        public DelegateCommand NavigateHomeCommand
        {
            get { return _navigateHomeCommand; }
            set { SetProperty(ref _navigateHomeCommand, value); }
        }
        private DelegateCommand _mealPlannerBaseLoaded;
        public DelegateCommand MealPlannerBaseLoaded
        {
            get { return _mealPlannerBaseLoaded; }
            set { SetProperty(ref _mealPlannerBaseLoaded, value); }
        }
        private DelegateCommand _createMealCommand;
        public DelegateCommand EditFoodItemCommand
        {
            get { return _createMealCommand; }
            set { SetProperty(ref _createMealCommand, value); }
        }
        private DelegateCommand _editMealCommand;
        public DelegateCommand EditMealCommand
        {
            get { return _editMealCommand; }
            set { SetProperty(ref _editMealCommand, value); }
        }

        public MealPlannerBaseViewModel()
        {
            //NavigateHomeCommand = new DelegateCommand(NavigateToHome);
            MealPlannerBaseLoaded = new DelegateCommand(NavigateToHome);
            EditFoodItemCommand = new DelegateCommand(NavigateToEditFoodItem);
            EditMealCommand = new DelegateCommand(NavigateToEditMeal);
        }

        public MealPlannerBaseViewModel( IRegionManager regionManager) : this()
        {
            _regionManager = regionManager;
        }

        private void NavigateToEditFoodItem()
        {
            // navigate to MealPlanner on load
            Navigate("EditFoodItemView");
        }

        private void NavigateToEditMeal()
        {
            Navigate("MealView");
        }

        private void NavigateToHome()
        {
            Navigate("MealPlannerView");
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("MealMenuContent", uri);
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace VitaChildApp.ViewModels
{
    public class MealPlannerViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private DelegateCommand _navigateHomeCommand;
        public DelegateCommand NavigateHomeCommand
        {
            get { return _navigateHomeCommand; }
            set { SetProperty(ref _navigateHomeCommand, value); }
        }
        private DelegateCommand _mealPlannerLoaded;
        public DelegateCommand MealPlannerLoaded
        {
            get { return _mealPlannerLoaded; }
            set { SetProperty(ref _mealPlannerLoaded, value); }
        }
        private DelegateCommand _createMealCommand;
        public DelegateCommand CreateMealCommand
        {
            get { return _createMealCommand; }
            set { SetProperty(ref _createMealCommand, value); }
        }

        public MealPlannerViewModel()
        {
            NavigateHomeCommand = new DelegateCommand(NavigateToHome);
            MealPlannerLoaded = new DelegateCommand(NavigateToHome);
            CreateMealCommand = new DelegateCommand(NavigateToCreateMeal);
        }

        public MealPlannerViewModel( IRegionManager regionManager) : this()
        {
            _regionManager = regionManager;
        }

        private void NavigateToCreateMeal()
        {
            // navigate to MealPlanner on load
            Navigate("CreateMenuView");
        }

        private void NavigateToHome()
        {
           
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("MealMenuContent", uri);
        }
    }
}

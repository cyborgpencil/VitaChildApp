using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;
using VitaChildApp.Views;

namespace VitaChildApp
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<MealPlannerBaseView>();
            Container.RegisterTypeForNavigation<EditFoodItemView>();
            Container.RegisterTypeForNavigation<MealView>();
            Container.RegisterTypeForNavigation<MealPlannerView>();
            Container.RegisterTypeForNavigation<MealDayView>();
            Container.RegisterTypeForNavigation<MealPlannerCalendarView>();
        }
    }
}

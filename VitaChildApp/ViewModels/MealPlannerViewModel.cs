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
    public class MealPlannerViewModel : BindableBase
    {

        private MealPlan _currentMealPlan;
        public MealPlan CurrentMealPlan
        {
            get { return _currentMealPlan; }
            set { SetProperty(ref _currentMealPlan, value); }
        }



        public MealPlannerViewModel()
        {
            CurrentMealPlan = new MealPlan();
            CurrentMealPlan.MealName = "Meal test";
            CurrentMealPlan.FromDate = new DateTime(2017, 01, 01);
            CurrentMealPlan.ToDate = CurrentMealPlan.FromDate.AddDays(6);

            CurrentMealPlan.MealDay = new ObservableCollection<MealDay>(new List<MealDay>());

            
        }

    }
}

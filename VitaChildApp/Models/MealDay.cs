// Meal Plan for a full day
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaChildApp.Models
{
    public class MealDay : BindableBase
    {
        private DateTime _MealDate;
        public DateTime MealDate
        {
            get { return _MealDate; }
            set { SetProperty(ref _MealDate, value); }
        }

        private Meal _breakfastMeal;
        public Meal BreakfastMeal
        {
            get { return _breakfastMeal; }
            set { SetProperty(ref _breakfastMeal, value); }
        }
        private Meal _am_Snack;
        public Meal AM_Snack
        {
            get { return _am_Snack; }
            set { SetProperty(ref _am_Snack, value); }
        }
        private Meal _lunch;
        public Meal Lunch
        {
            get { return _lunch; }
            set { SetProperty(ref _lunch, value); }
        }
        private Meal _pm_Snack;
        public Meal PM_Snack
        {
            get { return _pm_Snack; }
            set { SetProperty(ref _pm_Snack, value); }
        }
        private Meal _supper;
        public Meal Supper
        {
            get { return _supper; }
            set { SetProperty(ref _supper, value); }
        }
        private Meal _ev_snack;
        public Meal EV_Snack
        {
            get { return _ev_snack; }
            set { SetProperty(ref _ev_snack, value); }
        }

        public MealDay()
        {
            BreakfastMeal = new Meal();
            BreakfastMeal.MealTimes = MealTimes.BREAKFAST;
            AM_Snack = new Meal();
            AM_Snack.MealTimes = MealTimes.AM_SNACK;
            Lunch = new Meal();
            Lunch.MealTimes = MealTimes.LUNCH;
            PM_Snack = new Meal();
            PM_Snack.MealTimes = MealTimes.PM_SNACK;
            Supper = new Meal();
            Supper.MealTimes = MealTimes.SUPPER;
            EV_Snack = new Meal();
            EV_Snack.MealTimes = MealTimes.EV_SNACK;
        }
    }
}

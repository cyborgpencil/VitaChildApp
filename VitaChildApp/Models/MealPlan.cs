
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
/// <summary>
/// Meals Plan that can be printed out
/// </summary>
namespace VitaChildApp.Models
{
    public class MealPlan : BindableBase
    {
        private string _mealName;
        public string MealName
        {
            get { return _mealName; }
            set { SetProperty(ref _mealName, value); }
        }

        private DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set { SetProperty(ref _fromDate, value); }
        }

        private DateTime _toDate;
        public DateTime ToDate
        {
            get { return _toDate; }
            set { SetProperty(ref _toDate, value); }
        }

        private ObservableCollection<MealDay> _mealday;
        public ObservableCollection<MealDay> MealDay
        {
            get { return _mealday; }
            set { SetProperty(ref _mealday, value); }
        }

        public MealPlan()
        {
            MealDay = new ObservableCollection<MealDay>();
            MealDay.Add(new MealDay());
            MealDay.Add(new MealDay());
            MealDay.Add(new MealDay());
            MealDay.Add(new MealDay());
            MealDay.Add(new MealDay());
            MealDay.Add(new MealDay());
            MealDay.Add(new MealDay());
            UpdateMealDates();
        }

        public void UpdateMealDates()
        {
            MealDay[0].MealDate = FromDate;

            for (int i = 1; i < MealDay.Count; i++)
            {
                MealDay[i].MealDate = MealDay[i].MealDate.AddDays(1);
            }
        }
    }
}

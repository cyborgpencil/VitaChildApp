using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitaChildApp.Models;

namespace VitaChildApp.ViewModels
{
    public class MealDayViewModel : BindableBase
    {

        #region PRISM PROPS
        private ObservableCollection<FoodItem> _currentFoodList;
        public ObservableCollection<FoodItem> CurrentFoodList
        {
            get { return _currentFoodList; }
            set { SetProperty(ref _currentFoodList, value); }
        }
        #endregion

        #region PROPS
        #endregion

        #region CTOR
        public MealDayViewModel()
        {
            
        }
        #endregion
    }
}

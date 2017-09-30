using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using VitaChildApp.Models;
using VitaChildApp.Utilities;

namespace VitaChildApp.ViewModels
{
    public class MealDayViewModel : BindableBase
    {

        #region PRISM PROPS
        private ICollectionView _currentFoodList;
        public ICollectionView CurrentFoodList
        {
            get { return _currentFoodList; }
            set { SetProperty(ref _currentFoodList, value); }
        }
        private bool _fluidChecked;
        public bool FluidChecked
        {
            get { return _fluidChecked; }
            set {
                SetProperty(ref _fluidChecked, value);
                FluidCheck();
                CurrentFoodList.Refresh();
            }
        }
        private bool _meatAltChecked;
        public bool MeatAltChecked
        {
            get { return _meatAltChecked; }
            set {
                SetProperty(ref _meatAltChecked, value);
                MeatAltChecks();
                CurrentFoodList.Refresh();
            }
        }
        private bool _veggieChecked;
        public bool VeggieChecked
        {
            get { return _veggieChecked; }
            set {
                SetProperty(ref _veggieChecked, value);
                VeggieCheck();
                CurrentFoodList.Refresh();
            }
        }
        private bool _breadGrainsChecked;
        public bool BreadGrainsChecked
        {
            get { return _breadGrainsChecked; }
            set {
                SetProperty(ref _breadGrainsChecked, value);
                BreadCheck();
                CurrentFoodList.Refresh();
            }
        }
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set {
                SetProperty(ref _searchText, value);
                SearchFilter();
                CurrentFoodList.Refresh();
            }
        }
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set {
                SetProperty(ref _selectedDate, value);
                    SetActiveMealdDay();
            }
        }

        private ObservableCollection<FoodItem> _breakfastList;
        public ObservableCollection<FoodItem> BreakfastList
        {
            get { return _breakfastList; }
            set { SetProperty(ref _breakfastList, value); }
        }
        private ObservableCollection<FoodItem> _am_Snack;
        public ObservableCollection<FoodItem> AM_SnackList
        {
            get { return _am_Snack; }
            set { SetProperty(ref _am_Snack, value); }
        }
        private ObservableCollection<FoodItem> _lunchList;
        public ObservableCollection<FoodItem> LunchList
        {
            get { return _lunchList; }
            set { SetProperty(ref _lunchList, value); }
        }
        private ObservableCollection<FoodItem> _pm_Snack;
        public ObservableCollection<FoodItem> PM_SnackList
        {
            get { return _pm_Snack; }
            set { SetProperty(ref _pm_Snack, value); }
        }
        private ObservableCollection<FoodItem> _supper;
        public ObservableCollection<FoodItem> SupperList
        {
            get { return _supper; }
            set { SetProperty(ref _supper, value); }
        }
        private ObservableCollection<FoodItem> _ev_Snack;
        public ObservableCollection<FoodItem> EV_SnackList
        {
            get { return _ev_Snack; }
            set { SetProperty(ref _ev_Snack, value); }
        }



        private FoodItem _selectedBreakfastItem;
        public FoodItem SelectedBreakfastItem
        {
            get { return _selectedBreakfastItem; }
            set { SetProperty(ref _selectedBreakfastItem, value); }
        }
        private FoodItem _selectedAMSnack;
        public FoodItem SelectedAMSnack
        {
            get { return _selectedAMSnack; }
            set { SetProperty(ref _selectedAMSnack, value); }
        }
        private FoodItem _selectedFoodItem;
        public FoodItem SelectedFoodItem
        {
            get { return _selectedFoodItem; }
            set { SetProperty(ref _selectedFoodItem, value); }
        }
        private FoodItem _selectedLunchItem;
        public FoodItem SelectedLunchItem
        {
            get { return _selectedLunchItem; }
            set { SetProperty(ref _selectedLunchItem, value); }
        }
        private FoodItem _selectedPM_SnackITem;
        public FoodItem SelectedPM_SnackItem
        {
            get { return _selectedPM_SnackITem; }
            set { SetProperty(ref _selectedPM_SnackITem, value); }
        }
        private FoodItem _selectedSupperItem;
        public FoodItem SelectedSupperItem
        {
            get { return _selectedSupperItem; }
            set { SetProperty(ref _selectedSupperItem, value); }
        }
        private FoodItem _selectedEV_SnackItem;
        public FoodItem SelectedEV_SnackItem
        {
            get { return _selectedEV_SnackItem; }
            set { SetProperty(ref _selectedEV_SnackItem, value); }
        }

        private int _breakfastSelIndex;
        public int BreakfastSelIndex
        {
            get { return _breakfastSelIndex; }
            set { SetProperty(ref _breakfastSelIndex, value); }
        }
        private int _selectedAMSnackIndex;
        public int SelectedAMSnackIndex
        {
            get { return _selectedAMSnackIndex; }
            set { SetProperty(ref _selectedAMSnackIndex, value); }
        }
        private int _selectedLunchIndex;
        public int SelectedLunchIndex
        {
            get { return _selectedLunchIndex; }
            set { SetProperty(ref _selectedLunchIndex, value); }
        }
        private int _selectedPM_SnackIndex;
        public int SelectedPM_SnackIndex
        {
            get { return _selectedPM_SnackIndex; }
            set { SetProperty(ref _selectedPM_SnackIndex, value); }
        }
        private int _selectedSupperIndex;
        public int SelectedSupperIndex
        {
            get { return _selectedSupperIndex; }
            set { SetProperty(ref _selectedSupperIndex, value); }
        }
        private int _selectedEV_SnackIndex;
        public int SelectedEV_SnackIndex
        {
            get { return _selectedEV_SnackIndex; }
            set { SetProperty(ref _selectedEV_SnackIndex, value); }
        }

        private ObservableCollection<MealDay> _workingMealDayList;
        public ObservableCollection<MealDay> WorkingMealDayList
        {
            get { return _workingMealDayList; }
            set { SetProperty(ref _workingMealDayList, value); }
        }

        private int _activeMealDayIndex;
        public int ActiveMealDayIndex
        {
            get { return _activeMealDayIndex; }
            set {
                if (value == -1)
                    value = 0;  
                SetProperty(   
                    ref _activeMealDayIndex, value);
            }
        }

        private ObservableCollection<MealDay> _mealDayList;
        public ObservableCollection<MealDay> MealDayList
        {
            get { return _mealDayList; }
            set { SetProperty(ref _mealDayList, value); }
        }
        #endregion

        #region PROPS
        private MealDay _workingMealDay;
        #endregion

        #region COMMANDS
        private DelegateCommand _loadedCommand;
        public DelegateCommand LoadedCommand
        {
            get { return _loadedCommand; }
            set { SetProperty(ref _loadedCommand, value); }
        }
        private DelegateCommand _lostFocusCommand;
        public DelegateCommand LostFocusCommand
        {
            get { return _lostFocusCommand; }
            set { SetProperty(ref _lostFocusCommand, value); }
        }
        private DelegateCommand _addBreakfastCommand;
        public DelegateCommand AddBreakfastCommand
        {
            get { return _addBreakfastCommand; }
            set { SetProperty(ref _addBreakfastCommand, value); }
        }
        private DelegateCommand _removeBreakfastListCommand;
        public DelegateCommand RemoveBreakfastListCommand
        {
            get { return _removeBreakfastListCommand; }
            set { SetProperty(ref _removeBreakfastListCommand, value); }
        }
        private DelegateCommand _addAMSnackCommand;
        public DelegateCommand AddAMSnackCommand
        {
            get { return _addAMSnackCommand; }
            set { SetProperty(ref _addAMSnackCommand, value); }
        }
        private DelegateCommand _removeAMSnackCommand;
        public DelegateCommand RemoveAMSnackCommand
        {
            get { return _removeAMSnackCommand; }
            set { SetProperty(ref _removeAMSnackCommand, value); }
        }
        private DelegateCommand _addLunchItemCommand;
        public DelegateCommand AddLunchItemCommand
        {
            get { return _addLunchItemCommand; }
            set { SetProperty(ref _addLunchItemCommand, value); }
        }
        private DelegateCommand _removeLunchItemCommand;
        public DelegateCommand RemoveLunchItemCommand
        {
            get { return _removeLunchItemCommand; }
            set { SetProperty(ref _removeLunchItemCommand, value); }
        }
        private DelegateCommand _addPM_SnackItemCommand;
        public DelegateCommand AddPM_SnackItemCommand
        {
            get { return _addPM_SnackItemCommand; }
            set { SetProperty(ref _addPM_SnackItemCommand, value); }
        }
        private DelegateCommand _removePM_SnackItemCommand;
        public DelegateCommand RemovePM_SnackItemCommand
        {
            get { return _removePM_SnackItemCommand; }
            set { SetProperty(ref _removePM_SnackItemCommand, value); }
        }
        private DelegateCommand _addSupperItemCommand;
        public DelegateCommand AddSupperItemCommand
        {
            get { return _addSupperItemCommand; }
            set { SetProperty(ref _addSupperItemCommand, value); }
        }
        private DelegateCommand _removeSupperItemCommand;
        public DelegateCommand RemoveSupperItemCommand
        {
            get { return _removeSupperItemCommand; }
            set { SetProperty(ref _removeSupperItemCommand, value); }
        }
        private DelegateCommand _addEV_SnackItemCommand;
        public DelegateCommand AddEV_SnackItemCommand
        {
            get { return _addEV_SnackItemCommand; }
            set { SetProperty(ref _addEV_SnackItemCommand, value); }
        }
        private DelegateCommand _removeEV_SnackItemCommand;
        public DelegateCommand RemoveEV_SnackItemCommand
        {
            get { return _removeEV_SnackItemCommand; }
            set { SetProperty(ref _removeEV_SnackItemCommand, value); }
        }

        private DelegateCommand _addMealDayCommand;
        public DelegateCommand AddMealDayCommand
        {
            get { return _addMealDayCommand; }
            set { SetProperty(ref _addMealDayCommand, value); }
        }
        #endregion

        #region CTOR
        public MealDayViewModel()
        {
            //DEBUG

            LoadedCommand = new DelegateCommand(Loaded);

            IList<FoodItem> FoodItems = FoodItemsFileManager.Instance.GetFoodItemList();
            CurrentFoodList = CollectionViewSource.GetDefaultView(FoodItems);
            CurrentFoodList.SortDescriptions.Add(new SortDescription("ItemName", ListSortDirection.Ascending));

            SelectedDate = DateTime.Now;

            BreakfastList = new ObservableCollection<FoodItem>();
            AM_SnackList = new ObservableCollection<FoodItem>();
            LunchList = new ObservableCollection<FoodItem>();
            PM_SnackList = new ObservableCollection<FoodItem>();
            SupperList = new ObservableCollection<FoodItem>();
            EV_SnackList = new ObservableCollection<FoodItem>();

            AddBreakfastCommand = new DelegateCommand(AddBreakfast);
            RemoveBreakfastListCommand = new DelegateCommand(RemoveBreakfastItems);
            AddAMSnackCommand = new DelegateCommand(AddAMSnack);
            RemoveAMSnackCommand = new DelegateCommand(RemoveAMSnack);
            AddLunchItemCommand = new DelegateCommand(AddLunchItem);
            RemoveLunchItemCommand = new DelegateCommand(RemoveLunchItem);
            AddPM_SnackItemCommand = new DelegateCommand(AddPM_SnackItem);
            RemovePM_SnackItemCommand = new DelegateCommand(RemovePM_SnackItem);
            AddSupperItemCommand = new DelegateCommand(AddSupperItem);
            RemoveSupperItemCommand = new DelegateCommand(RemoveSupperItem);
            //AddEV_SnackItemCommand = new DelegateCommand(AddEV_SnackItem);
            //RemoveEV_SnackItemCommand = new DelegateCommand(RemoveEV_SnackItem);

            ActiveMealDayIndex = 0;

            //Check loaded MealDay List
            WorkingMealDayList = new ObservableCollection<MealDay>();
        }

        #endregion

        #region EVENTS
        private void Loaded()
        {
            // Load Current Food Item List
            IList<FoodItem> FoodItems = FoodItemsFileManager.Instance.GetFoodItemList();
            CurrentFoodList = CollectionViewSource.GetDefaultView(FoodItems);
            CurrentFoodList.SortDescriptions.Add(new SortDescription("ItemName", ListSortDirection.Ascending));

            // Refresh CollectionViewSource
            CurrentFoodList.Refresh();

            // Load MealDay based on date 

            //DEBUG
            MealDay m1 = new MealDay();
            m1.MealDate = DateTime.Now;
            m1.BreakfastMeal.FoodItemList = new ObservableCollection<FoodItem>();
            m1.BreakfastMeal.FoodItemList.Add(new FoodItem { ItemName = "Current Test Name", FoodType = FoodType.VEGETABLE });
            WorkingMealDayList.Add(m1);

            //compar date to any in loaded list
            MealDay m2 = new MealDay();
            m2.MealDate = DateTime.Now.AddDays(-1);
            m2.BreakfastMeal.FoodItemList = new ObservableCollection<FoodItem>();
            m2.BreakfastMeal.FoodItemList.Add(new FoodItem { ItemName = "YesterDay Test Name", FoodType = FoodType.VEGETABLE });
            WorkingMealDayList.Add(m2);

            SetActiveMealdDay();
        }
        private void AddBreakfast()
        {
            if (SelectedFoodItem != null)
            {
                BreakfastList.Add(SelectedFoodItem);
            }
            SelectedBreakfastItem = null;
        }
        private void RemoveBreakfastItems()
        {
            if (SelectedBreakfastItem != null)
            {
                BreakfastList.RemoveAt(BreakfastSelIndex);
            }
            SelectedBreakfastItem = null;
        }
        #endregion

        #region METHODS
        private MealDay MealDateMatch()
        {
            if (WorkingMealDayList != null)
            {
                for (int i = 0; i < WorkingMealDayList.Count; i++)
                {
                    if (WorkingMealDayList[i].MealDate.Date.Equals(SelectedDate))
                        return WorkingMealDayList[i];
                }
            }

            // No dates matched
            return null;
        }
        private void SetMealDate()
        {
            // Set BreakfastList
            BreakfastList = _workingMealDay.BreakfastMeal.FoodItemList;
            // Set AM_Snack

            // Set Lunch

            // Set PM_Snack

            // Set Supper

            // Set EV_Snack
        }

        private void ClearMealDate()
        {
            WorkingMealDayList = new ObservableCollection<MealDay>();
            BreakfastList = new ObservableCollection<FoodItem>();
        }

        private void FluidCheck()
        {
            if (FluidChecked)
            {
                CurrentFoodList.Filter = FluidFilter;
            }
            else
                CurrentFoodList.Filter = null;
        }
        private bool FluidFilter(object item)
        {
            FoodItem fi = (FoodItem)item;
            return fi.FoodType == FoodType.FLUID;
        }

        private void MeatAltChecks()
        {
            if (MeatAltChecked)
            {
                CurrentFoodList.Filter = MeatAltFilter;
            }
            else
                CurrentFoodList.Filter = null;
        }

        private bool MeatAltFilter(object item)
        {
            FoodItem fi = (FoodItem)item;
            return fi.FoodType == FoodType.MEAT_ALTERNATE;
        }

        private void VeggieCheck()
        {
            if (VeggieChecked)
            {
                CurrentFoodList.Filter = VeggieFilter;
            }
            else
                CurrentFoodList.Filter = null;
        }

        private bool VeggieFilter(object item)
        {
            FoodItem fi = (FoodItem)item;
            return fi.FoodType == FoodType.VEGETABLE;
        }

        private void BreadCheck()
        {
            if (BreadGrainsChecked)
            {
                CurrentFoodList.Filter = BreadFilter;
            }
            else
                CurrentFoodList.Filter = null;
        }

        private bool BreadFilter(object item)
        {
            FoodItem fi = (FoodItem)item;
            return fi.FoodType == FoodType.GRAINS;
        }
        private void SearchFilter()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                CurrentFoodList.Filter = null;
            }
            else
                CurrentFoodList.Filter = FilterList;
        }

        private bool FilterList(object obj)
        {
            FoodItem fi = (FoodItem)obj;
            return fi.ItemName.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase);
        }

        private void RemoveAMSnack()
        {
            if (SelectedAMSnackIndex != -1)
            {
                AM_SnackList.RemoveAt(SelectedAMSnackIndex);
            }
            SelectedAMSnackIndex = -1;
            SelectedFoodItem = null;
        }

        private void AddAMSnack()
        {
            if (SelectedFoodItem != null)
            {
                AM_SnackList.Add(SelectedFoodItem);
            }
            SelectedFoodItem = null;
        }

        private void AddLunchItem()
        {
            if (SelectedFoodItem != null)
                LunchList.Add(SelectedFoodItem);
        }
        private void RemoveLunchItem()
        {
            if (SelectedLunchItem != null)
                LunchList.RemoveAt(SelectedLunchIndex);

            SelectedLunchItem = null;
        }
        private void AddPM_SnackItem()
        {
            if (SelectedFoodItem != null)
                PM_SnackList.Add(SelectedFoodItem);
        }
        private void RemovePM_SnackItem()
        {
            if (SelectedPM_SnackItem != null)
                PM_SnackList.RemoveAt(_selectedPM_SnackIndex);
            SelectedPM_SnackIndex = -1;
        }
        private void AddSupperItem()
        {
            if (SelectedFoodItem != null)
                SupperList.Add(SelectedFoodItem);
        }
        private void RemoveSupperItem()
        {
            if (SelectedSupperItem != null)
                SupperList.RemoveAt(SelectedSupperIndex);
            SelectedSupperIndex = -1;
        }
        

        private void SetActiveMealdDay()
        {
            _workingMealDay = MealDateMatch();
            if (_workingMealDay != null)
                SetMealDate();
            else
                ClearMealDate();
        }
        #endregion
    }

}

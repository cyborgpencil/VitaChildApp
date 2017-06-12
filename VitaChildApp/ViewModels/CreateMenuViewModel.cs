using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitaChildApp.Models;
using VitaChildApp.Utilities;

namespace VitaChildApp.ViewModels
{
    public class CreateMenuViewModel : BindableBase
    {
        private bool _breakfastBindable;
        public bool BreakfastBindable
        {
            get { return _breakfastBindable; }
            set { SetProperty(ref _breakfastBindable, value);
                Debug.Write("Test");
            }
        }
        private DelegateCommand _createMenuLoadedCommand;
        public DelegateCommand CreateMenuLoadedCommand
        {
            get { return _createMenuLoadedCommand; }
            set { SetProperty(ref _createMenuLoadedCommand, value); }
        }
        
        private DelegateCommand _addFoodItemCommand;
        public DelegateCommand AddFoodItemCommand
        {
            get { return _addFoodItemCommand; }
            set { SetProperty(ref _addFoodItemCommand, value); }
        }

        //Bindings
        private ObservableCollection<FoodItem> _currentFoodList;
        public ObservableCollection<FoodItem> CurrentFoodList
        {
            get { return _currentFoodList; }
            set { SetProperty(ref _currentFoodList, value); }
        }
        private FoodItem _workingFoodItem;
        public FoodItem WorkingFoodItem
        {
            get { return _workingFoodItem; }
            set {
                SetProperty(ref _workingFoodItem, value);
            }
        }
        private int _currentListIndex;
        public int CurrentListIndex
        {
            get { return _currentListIndex; }
            set { SetProperty(ref _currentListIndex, value); }
        }
        private string _currentIngredientBind;
        public string CurrentIngredientBind
        {
            get { return _currentIngredientBind; }
            set { SetProperty(ref _currentIngredientBind, value); }
        }
        private int _indexCount;
        public int IndexCount
        {
            get { return _indexCount; }
            set { SetProperty(ref _indexCount, value); }
        }
        private ObservableCollection<string> _fullFoodItemsList;
        public ObservableCollection<string> FullFoodItemsNamesList
        {
            get { return _fullFoodItemsList; }
            set { SetProperty(ref _fullFoodItemsList, value); }
        }
        private int _currentSelectedIngredient;
        public int CurrentSelectedIngredient
        {
            get { return _currentSelectedIngredient; }
            set { SetProperty(ref _currentSelectedIngredient, value); }
        }

        // Commands
        private DelegateCommand _clearFormCommand;
        public DelegateCommand ClearFormCommand
        {
            get { return _clearFormCommand; }
            set { SetProperty(ref _clearFormCommand, value); }
        }
        private DelegateCommand _addIngredientsCommand;
        public DelegateCommand AddIngredientsCommand
        {
            get { return _addIngredientsCommand; }
            set { SetProperty(ref _addIngredientsCommand, value); }
        }
        private DelegateCommand _deleteSelIngredientCommand;
        public DelegateCommand DeleteSelIngredientCommand
        {
            get { return _deleteSelIngredientCommand; }
            set { SetProperty(ref _deleteSelIngredientCommand, value); }
        }
        

        // Binding items
        private string _selFoodItemBind;
        public string SelFoodItemBind
        {
            get { return _selFoodItemBind; }
            set {
                SetProperty(ref _selFoodItemBind, value);
            }
        }
        private bool _deleteActive;
        public bool DeleteActive
        {
            get { return _deleteActive; }
            set { SetProperty(ref _deleteActive, value); }
        }
        private DelegateCommand _deleteFoodItemCommand;
        public DelegateCommand DeleteFoodItemCommand
        {
            get { return _deleteFoodItemCommand; }
            set { SetProperty(ref _deleteFoodItemCommand, value); }
        }
        private DelegateCommand _saveFoodItemCommand;
        public DelegateCommand SaveFoodItemCommand
        {
            get { return _saveFoodItemCommand; }
            set { SetProperty(ref _saveFoodItemCommand, value); }
        }
        private string _currentFoodListBind;
        public string CurrentFoodListBind
        {
            get { return _currentFoodListBind; }
            set { SetProperty(ref _currentFoodListBind, value); }
        }
        private FoodType _foodType;
        public FoodType FoodType
        {
            get { return _foodType; }
            set { SetProperty(ref _foodType, value); }
        }
        private ObservableCollection<string> _foodTypesToString;
        public ObservableCollection<string> FoodTypesToString
        {
            get { return _foodTypesToString; }
            set { SetProperty(ref _foodTypesToString, value); }
        }
        private int _foodtypeIndexBind;
        public int FoodtypeIndexBind
        {
            get { return _foodtypeIndexBind; }
            set { SetProperty(ref _foodtypeIndexBind, value); }
        }
        private string _selectedTypeBind;
        public string SelectedTypeBind
        {
            get { return _selectedTypeBind; }
            set { SetProperty(ref _selectedTypeBind, value); }
        }

        public CreateMenuViewModel()
        {
            BreakfastBindable = true;
            AddFoodItemCommand = new DelegateCommand(AddFoodItem).ObservesProperty(()=> FullFoodItemsNamesList.Count);
            WorkingFoodItem = new FoodItem();
            CurrentFoodList = new ObservableCollection<FoodItem>();
            CurrentSelectedIngredient = -1;
            for (int i = 0; i < CurrentFoodList.Count; i++)
            {
                CurrentFoodList[i].IngredientsList = new ObservableCollection<string>(new List<string>());
            }

            CurrentFoodListBind = "Current Food List:";

            WorkingFoodItem.IngredientsList = new ObservableCollection<string>(new List<string>());
            AddIngredientsCommand = new DelegateCommand(AddIngredients).ObservesProperty(()=>WorkingFoodItem);

            FullFoodItemsNamesList = new ObservableCollection<string>();
            DeleteFoodItemCommand = new DelegateCommand(DeleteFoodItem, CanDeleteFoodItem).ObservesProperty(() => WorkingFoodItem);
            SaveFoodItemCommand = new DelegateCommand(SaveFoodItem, CanSaveFoodItems).ObservesProperty(() => FullFoodItemsNamesList).ObservesProperty(()=> FullFoodItemsNamesList.Count);
            ClearFormCommand = new DelegateCommand(ClearForm);
            DeleteSelIngredientCommand = new DelegateCommand(DeleteSelIngredient, CanDeleteSelIngredient).ObservesProperty(() => WorkingFoodItem.IngredientsList.Count);
            // Load Current Food list from File
            CurrentFoodList = new FoodItemsFileManager().LoadFoodItems();
            if (CurrentFoodList != null)
            {
                for (int i = 0; i < CurrentFoodList.Count; i++)
                {
                    FullFoodItemsNamesList.Add(CurrentFoodList[i].ItemName);
                }
            }

            FoodType = new FoodType();
            FoodTypesToString = new ObservableCollection<string>(new List<string>(Enum.GetNames(typeof(FoodType))));
            FoodtypeIndexBind = 0;
            CurrentListIndex = -1;
        }

        private bool CanDeleteSelIngredient()
        {
            if (WorkingFoodItem.IngredientsList.Count <= 0)
                return false;

            return true;
        }

        private void DeleteSelIngredient()
        {
            CurrentFoodList.RemoveAt(CurrentSelectedIngredient);
        }

        private void ClearForm()
        {
            WorkingFoodItem = null;
            WorkingFoodItem = new FoodItem();
            WorkingFoodItem.IngredientsList = new ObservableCollection<string>(new List<string>());
        }

        private bool CanSaveFoodItems()
        {
            if (FullFoodItemsNamesList.Count > 0)
                return true;
            else
                return false;
        }

        private void SaveFoodItem()
        {
            FoodItemsFileManager fiFM = new FoodItemsFileManager();

            fiFM.SaveFoodItemList(CurrentFoodList);

            CurrentFoodListBind = "Current Food List:";
        }

        private bool CanDeleteFoodItem()
        {
            if (WorkingFoodItem != null)
                return true;
            else
                return false;
        }

        private void DeleteFoodItem()
        {
            // Remove from Current Food item
            //CurrentFoodList.RemoveAt(WorkingFoodItemIndex);

            // Clear form
            ClearForm();

            // Remove list of food item names
            //FullFoodItemsNamesList.RemoveAt(WorkingFoodItemIndex);

            CurrentFoodListBind = "Current Food List:*";
            
            CurrentFoodList.RemoveAt(CurrentListIndex);
            WorkingFoodItem = null;
            WorkingFoodItem = new FoodItem();
            WorkingFoodItem.IngredientsList = new ObservableCollection<string>(new List<string>());
            CurrentListIndex = -1;
        }

        private void AddIngredients()
        {
            if(!string.IsNullOrWhiteSpace(CurrentIngredientBind))
            {
                WorkingFoodItem.IngredientsList.Add(CurrentIngredientBind);
            }


            // Clear ingrdients text box when done
            CurrentIngredientBind = "";
        }
        
        private void AddFoodItem()
        {
            // Check for an updte
            if(CurrentListIndex != -1)
            {
                // Update current List
                CurrentFoodList[CurrentListIndex] = WorkingFoodItem;
            }
            else
                // Add New item
                CurrentFoodList.Add(WorkingFoodItem);

            ClearForm();
        }

        private void AddNewFoodItemToList(FoodItem foodItem)
        {
            // Get the current Fooditem based on the index
            var newFoodItem = new FoodItem();
            newFoodItem.IngredientsList = new ObservableCollection<string>();
            newFoodItem.ItemName = foodItem.ItemName;
            foreach (var ing in foodItem.IngredientsList)
            {
                newFoodItem.IngredientsList.Add(ing);
            }

            CurrentFoodList.Add(newFoodItem);
        }

        private bool CheckCurrentFoodList()
        {
            foreach (var fi in CurrentFoodList)
            {
                if (fi.ItemName == WorkingFoodItem.ItemName)
                    return true;
            }

            return false;
        }
    }
}

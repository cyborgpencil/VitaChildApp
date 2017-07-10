using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VitaChildApp.Models;
using VitaChildApp.Utilities;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace VitaChildApp.ViewModels
{
    public class EditFoodItemViewModel : BindableBase
    {
        private bool _breakfastBindable;
        public bool BreakfastBindable
        {
            get { return _breakfastBindable; }
            set { SetProperty(ref _breakfastBindable, value);
            }
        }
        private DelegateCommand _editFoodItemLoadedCommand;
        public DelegateCommand EditFoodItemLoadedCommand
        {
            get { return _editFoodItemLoadedCommand; }
            set { SetProperty(ref _editFoodItemLoadedCommand, value); }
        }
        
        private DelegateCommand _addFoodItemCommand;
        public DelegateCommand AddFoodItemCommand
        {
            get { return _addFoodItemCommand; }
            set {
                SetProperty(ref _addFoodItemCommand, value);
            }
        }
        public bool CanAddToList { get; set; }

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
            get {
                return _workingFoodItem;
            }
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
        public int SelectedIngredientIndex
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
        private DelegateCommand _deleteAllIngredientsCommand;
        public DelegateCommand DeleteAllIngredientsCommand
        {
            get { return _deleteAllIngredientsCommand; }
            set { SetProperty(ref _deleteAllIngredientsCommand, value); }
        }
        private string _selectedIngredient;
        public string SelectedIngredient
        {
            get { return _selectedIngredient; }
            set { SetProperty(ref _selectedIngredient, value); }
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

        public EditFoodItemViewModel()
        {
            BreakfastBindable = true;
            WorkingFoodItem = new FoodItem();
            AddFoodItemCommand = new DelegateCommand(AddFoodItem);
            WorkingFoodItem.IngredientsList.CollectionChanged += IngredientsPropertyChanged;
            CurrentFoodList = new ObservableCollection<FoodItem>();
            CurrentFoodList.CollectionChanged += FoodListPropertyChanged;
            SelectedIngredientIndex = -1;
            for (int i = 0; i < CurrentFoodList.Count; i++)
            {
                CurrentFoodList[i].IngredientsList = new ObservableCollection<string>(new List<string>());
            }

            CurrentFoodListBind = "Current Food List:";
            AddIngredientsCommand = new DelegateCommand(AddIngredients).ObservesProperty(()=>WorkingFoodItem);

            FullFoodItemsNamesList = new ObservableCollection<string>();
            DeleteFoodItemCommand = new DelegateCommand(DeleteFoodItem, CanDeleteFoodItem).ObservesProperty(() => CurrentListIndex);
            SaveFoodItemCommand = new DelegateCommand(SaveFoodItem);
            ClearFormCommand = new DelegateCommand(ClearForm);
            DeleteSelIngredientCommand = new DelegateCommand(DeleteSelIngredient, CanDeleteSelIngredient).ObservesProperty(() => SelectedIngredientIndex);
            DeleteAllIngredientsCommand = new DelegateCommand(DeleteAllIngredients, CanDeleteAllIngredients);
            
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

        private void FoodListPropertyChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CanSaveFoodItems();
        }

        private void WorkingFoodItemChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WorkingFoodItem.ItemName))
                CanAddToList = true;
            else
                CanAddToList = false;

            CanAddFoodItem();
        }

        // Can add a Food Item if There is a Food Item Name
        private bool CanAddFoodItem()
        {
            return CanAddToList;
        }

        private void IngredientsPropertyChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Simple Call to check if DeleteAllIngredients can Run
           CanDeleteAllIngredients();
        }

        // If there are at least 1 ingredient, user can delete all
        private bool CanDeleteAllIngredients()
        {
            if (WorkingFoodItem.IngredientsList.Count > 0)
                return true;
            else
                return false;
        }

        // Clear all ingredients
        private void DeleteAllIngredients()
        {
            WorkingFoodItem.IngredientsList.Clear();
        }

        // Can delete the selected ingredient
        private bool CanDeleteSelIngredient()
        {
            if (SelectedIngredientIndex <= -1)
                return false;

            return true;
        }

        private void DeleteSelIngredient()
        {
            WorkingFoodItem.IngredientsList.RemoveAt(SelectedIngredientIndex);
        }

        private void ClearForm()
        {
            WorkingFoodItem = null;
            WorkingFoodItem = new FoodItem();
            WorkingFoodItem.IngredientsList.Clear();
        }

        private bool CanSaveFoodItems()
        {
            if (CurrentFoodList.Count > 0)
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
            if (CurrentListIndex != -1)
                return true;
            else
                return false;
        }

        private void DeleteFoodItem()
        {
            if (CurrentListIndex != -1)
            {
                // Remove from Current Food item
                CurrentFoodList.RemoveAt(CurrentListIndex);

                // Clear Selected Item
                CurrentListIndex = -1;

                // Clear form
                ClearForm();
            }
        }

        private void AddIngredients()
        {
            if(!string.IsNullOrWhiteSpace(CurrentIngredientBind))
            {
                WorkingFoodItem.IngredientsList.Add(CurrentIngredientBind);
            }

            // Check if you can Delete all Items
            CanDeleteAllIngredients();

            // Clear ingrdients text box when done
            CurrentIngredientBind = "";
        }
        
        private void AddFoodItem()
        {
            // verify Food Item has a Name
            if (!string.IsNullOrWhiteSpace(WorkingFoodItem.ItemName))
            {
                //Check For Update
                if(CurrentListIndex != -1)
                {
                    CurrentFoodList[CurrentListIndex] = WorkingFoodItem;
                }
                else
                {
                    // New Item
                    CurrentFoodList.Add(WorkingFoodItem);
                }
            }

            // clear Working Food Item
            ClearForm();
        }

        //private void AddNewFoodItemToList(FoodItem foodItem)
        //{
        //    // Get the current Fooditem based on the index
        //    var newFoodItem = new FoodItem();
        //    newFoodItem.IngredientsList = new ObservableCollection<string>();
        //    newFoodItem.ItemName = foodItem.ItemName;
        //    foreach (var ing in foodItem.IngredientsList)
        //    {
        //        newFoodItem.IngredientsList.Add(ing);
        //    }

        //    CurrentFoodList.Add(newFoodItem);
        //}
    }
}

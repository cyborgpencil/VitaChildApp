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
        private FoodItem _workingFoodItem;
        public FoodItem WorkingFoodItem
        {
            get { return _workingFoodItem; }
            set { SetProperty(ref _workingFoodItem, value); }
        }
        private DelegateCommand _addFoodItemCommand;
        public DelegateCommand AddFoodItemCommand
        {
            get { return _addFoodItemCommand; }
            set { SetProperty(ref _addFoodItemCommand, value); }
        }
        private ObservableCollection<FoodItem> _currentFoodList;
        public ObservableCollection<FoodItem> CurrentFoodList
        {
            get { return _currentFoodList; }
            set { SetProperty(ref _currentFoodList, value); }
        }
        private string _currentIngredientBind;
        public string CurrentIngredientBind
        {
            get { return _currentIngredientBind; }
            set { SetProperty(ref _currentIngredientBind, value); }
        }
        private DelegateCommand _addIngredientsCommand;
        public DelegateCommand AddIngredientsCommand
        {
            get { return _addIngredientsCommand; }
            set { SetProperty(ref _addIngredientsCommand, value); }
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
        private string _selFoodItemBind;
        public string SelFoodItemBind
        {
            get { return _selFoodItemBind; }
            set {
                SetProperty(ref _selFoodItemBind, value);
                GetCurrentFoodItem();
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

        // Keeps a working index to match list of string to FoodItems Name
        private int _workingFoodItemIndex;
        public int WorkingFoodItemIndex
        {
            get { return _workingFoodItemIndex; }
            set { SetProperty(ref _workingFoodItemIndex, value); }
        }

        public CreateMenuViewModel()
        {
            BreakfastBindable = true;
            CreateMenuLoadedCommand = new DelegateCommand(CreateMenuLoaded);
            AddFoodItemCommand = new DelegateCommand(AddFoodItem).ObservesProperty(()=> FullFoodItemsNamesList.Count);
            WorkingFoodItem = new FoodItem();
            CurrentFoodList = new ObservableCollection<FoodItem>();
            for (int i = 0; i < CurrentFoodList.Count; i++)
            {
                CurrentFoodList[i].IngredientsList = new ObservableCollection<string>(new List<string>());
            }

            CurrentFoodListBind = "Current Food List:";

            WorkingFoodItem.IngredientsList = new ObservableCollection<string>(new List<string>());
            AddIngredientsCommand = new DelegateCommand(AddIngredients).ObservesProperty(()=>WorkingFoodItem);

            FullFoodItemsNamesList = new ObservableCollection<string>();
            DeleteFoodItemCommand = new DelegateCommand(DeleteFoodItem, CanDeleteFoodItem).ObservesProperty(() => WorkingFoodItemIndex);
            SaveFoodItemCommand = new DelegateCommand(SaveFoodItem, CanSaveFoodItems).ObservesProperty(() => FullFoodItemsNamesList.Count);
            WorkingFoodItemIndex = -1;

            // Load Current Food list from File
            CurrentFoodList = new FoodItemsFileManager().LoadFoodItems();
            if (CurrentFoodList != null)
            {
                for (int i = 0; i < CurrentFoodList.Count; i++)
                {
                    FullFoodItemsNamesList.Add(CurrentFoodList[i].ItemName);
                }
            }
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
            //Save Food itms using FoodItemsFileManager
            FoodItemsFileManager fiFM = new FoodItemsFileManager();
            //foreach (var fi in CurrentFoodList)
            //{
            //    fiFM.SaveFoodItem(fi);
            //}
            fiFM.SaveFoodItemList(CurrentFoodList);

            CurrentFoodListBind = "Current Food List:";
        }

        private bool CanDeleteFoodItem()
        {
            if (WorkingFoodItemIndex > -1)
                return true;
            else
                return false;
        }

        private void DeleteFoodItem()
        {      
            // Remove from Current Food item
            CurrentFoodList.RemoveAt(WorkingFoodItemIndex);

            // Clear form
            ClearWorkingFoodItem();

            // Remove list of food item names
            FullFoodItemsNamesList.RemoveAt(WorkingFoodItemIndex);

            CurrentFoodListBind = "Current Food List:*";
        }

        private void AddIngredients()
        {
            if(!string.IsNullOrWhiteSpace(CurrentIngredientBind))
            {
                WorkingFoodItem.IngredientsList.Add(CurrentIngredientBind);
            }

            IndexCount = WorkingFoodItem.IngredientsList.Count-1;

            // Clear ingrdients text box when done
            CurrentIngredientBind = "";
        }

        private void CreateMenuLoaded()
        {           
        }
        
        private void AddFoodItem()
        {
            // Update Full List of Food Object
            AddNewFoodItemToList(WorkingFoodItem);

            //Update Food object to display
            FullFoodItemsNamesList.Add(CurrentFoodList[CurrentFoodList.Count-1].ItemName);

            //Cleare Food form
            ClearWorkingFoodItem();

            // Visually show That is a Change neding to be saved
            CurrentFoodListBind = "Current Food List:";
        }

        private void GetCurrentFoodItem()
        {
            //check for null Selected Item
            if (!string.IsNullOrWhiteSpace(SelFoodItemBind))
            {
                WorkingFoodItem.ItemName = CurrentFoodList[WorkingFoodItemIndex].ItemName;
                WorkingFoodItem.IngredientsList = new ObservableCollection<string>();
                for (int i = 0; i < CurrentFoodList[WorkingFoodItemIndex].IngredientsList.Count; i++)
                {
                    WorkingFoodItem.IngredientsList.Add(CurrentFoodList[WorkingFoodItemIndex].IngredientsList[i]);
                }
                IndexCount = 0;
            }
        }

        private void AddNewFoodItemToList(FoodItem foodItem)
        {
            var newFoodItem = new FoodItem();
            newFoodItem.IngredientsList = new ObservableCollection<string>();
            newFoodItem.ItemName = foodItem.ItemName;
            foreach (var ing in foodItem.IngredientsList)
            {
                newFoodItem.IngredientsList.Add(ing);
            }

            CurrentFoodList.Add(newFoodItem);
            WorkingFoodItemIndex = -1;
        }

        private void ClearWorkingFoodItem()
        {
            WorkingFoodItem.ItemName = "";
            WorkingFoodItem.IngredientsList.Clear();
            CurrentIngredientBind = "";
        }
    }
}

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

        public CreateMenuViewModel()
        {
            BreakfastBindable = true;
            CreateMenuLoadedCommand = new DelegateCommand(CreateMenuLoaded);
            AddFoodItemCommand = new DelegateCommand(AddFoodItem);
            WorkingFoodItem = new FoodItem();
            CurrentFoodList = new ObservableCollection<FoodItem>();
            for (int i = 0; i < CurrentFoodList.Count; i++)
            {
                CurrentFoodList[i].IngredientsList = new ObservableCollection<string>(new List<string>());
            }
            WorkingFoodItem.IngredientsList = new ObservableCollection<string>(new List<string>());
            AddIngredientsCommand = new DelegateCommand(AddIngredients).ObservesProperty(()=>WorkingFoodItem);

            FullFoodItemsNamesList = new ObservableCollection<string>();

            CurrentFoodList.Add(WorkingFoodItem);
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
            CurrentFoodList.Add(WorkingFoodItem);

            //Update Food object to display
            FullFoodItemsNamesList.Add(WorkingFoodItem.ItemName);

            //Cleare Food form
            WorkingFoodItem.ItemName = "";
            WorkingFoodItem.IngredientsList.Clear();
            CurrentIngredientBind = "";
        }

        private void GetCurrentFoodItem()
        {
            // validate item selected string
            if(!string.IsNullOrWhiteSpace(SelFoodItemBind))
            {
                // Get Item that matches the name of the Food Item.
                for (int i = 0; i < FullFoodItemsNamesList.Count; i++)
                {
                    // Find Matching Name
                    if (FullFoodItemsNamesList[i].Equals(SelFoodItemBind, StringComparison.CurrentCulture))
                    {
                        // Set Working Form to edit the found Food Item
                        WorkingFoodItem.ItemName = CurrentFoodList[i].ItemName;
                        WorkingFoodItem.IngredientsList = CurrentFoodList[i].IngredientsList;
                        return;
                    }
                }
            }
        }
    }
}

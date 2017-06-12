using System.Collections.ObjectModel;
using Prism.Mvvm;
using System.ComponentModel;

namespace VitaChildApp.Models
{
    public enum FoodType
    {
        [Description("Milk")]
        MILK,
        [Description("Fluid")]
        FLUID,
        [Description("Meat")]
        MEAT,
        [Description("Meat Alternate")]
        MEAT_ALTERNATE,
        [Description("Juice")]
        JUICE,
        [Description("Fruit")]
        FRUIT,
        [Description("Vegetable")]
        VEGETABLE,
        [Description("Grains")]
        GRAINS,
        [Description("Breads")]
        BREADS
    }
    public class FoodItem : BindableBase
    {
        private string _itemName;
        public string ItemName
        {
            get { return _itemName; }
            set { SetProperty(ref _itemName, value); }
        }
        private ObservableCollection<string> _ingredientsList;
        public ObservableCollection<string> IngredientsList
        {
            get { return _ingredientsList; }
            set { SetProperty(ref _ingredientsList, value); }
        }
        private FoodType _foodType;
        public FoodType FoodType
        {
            get { return _foodType; }
            set { SetProperty(ref _foodType, value); }
        }
    }
}

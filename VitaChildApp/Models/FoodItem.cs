using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace VitaChildApp.Models
{
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
    }
}

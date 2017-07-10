using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using VitaChildApp.Models;

namespace VitaChildApp.Utilities
{
    public class FoodItemsFileManager
    {
        private FoodItem _foodItem { get; set; }
        
        public void SaveFoodItem(FoodItem foodItem)
        {
            XmlSerializer xml = new XmlSerializer(typeof(FoodItem));
            TextWriter tWriter = new StreamWriter($"{FileManager.Instance.WorkingFolder}/Food Items.xml");
            xml.Serialize(tWriter, foodItem);
            tWriter.Close();
        }

        public void SaveFoodItemList(ObservableCollection<FoodItem> foodItemList)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<FoodItem>));
            FileStream sWriter = new FileStream($"{FileManager.Instance.WorkingFolder}/Food Items.xml", FileMode.Create);
            xml.Serialize(sWriter, foodItemList);
            sWriter.Close();
        }

        public ObservableCollection<FoodItem> LoadFoodItems()
        {
            XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<FoodItem>));
            var FoodItemLists = new ObservableCollection<FoodItem>();
            if (File.Exists($"{FileManager.Instance.WorkingFolder}/Food Items.xml"))
            {
                FileStream sWriter = new FileStream($"{FileManager.Instance.WorkingFolder}/Food Items.xml", FileMode.Open);
                XmlReader reader = XmlReader.Create(sWriter);

                
                foreach (var ing in FoodItemLists)
                {
                    ing.IngredientsList = new ObservableCollection<string>();
                }

                FoodItemLists = (ObservableCollection<FoodItem>)xml.Deserialize(reader);
                sWriter.Close();
            }

            return FoodItemLists;
        }
    }
}

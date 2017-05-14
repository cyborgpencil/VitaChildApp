using System.IO;
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
            TextWriter tWriter = new StreamWriter($"{FileManager.Instance._workingFolder}/Food Items.xml");
            xml.Serialize(tWriter, foodItem);
            tWriter.Close();
        }

        public void LoadFoodItems()
        {

        }
    }
}

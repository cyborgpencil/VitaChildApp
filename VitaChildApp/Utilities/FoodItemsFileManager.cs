using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using VitaChildApp.Models;

namespace VitaChildApp.Utilities
{
    public class FoodItemsFileManager
    {
        private static FoodItemsFileManager _instance;
        private static readonly object padlock = new object();

        // filename for all food items
        private string _foodItemListFileName;

        // this is the global Food Item List
        private List<FoodItem> LoadedFoodtemList { get; set; }

        private FoodItemsFileManager()
        {
            _foodItemListFileName = "Food Items.xml";

            VerifyFile();
        }

        public static FoodItemsFileManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(padlock)
                    {
                        _instance = new FoodItemsFileManager();
                    }
                }
                return _instance;
            }
        }

        private void LoadFoodItemsFromFile()
        {
            XmlSerializer xmlSerial = new XmlSerializer(typeof(List<FoodItem>));

            using (FileStream fileStream = new FileStream($"{FileManager.Instance.FoodItemsDir}\\{_foodItemListFileName}", FileMode.Open))
            {
                LoadedFoodtemList = new List<FoodItem>();
                LoadedFoodtemList = (List<FoodItem>)xmlSerial.Deserialize(fileStream);
            }
        }

        public List<FoodItem> GetFoodItemList()
        {
            // Load list from File
            LoadFoodItemsFromFile();

            // return current List
            return LoadedFoodtemList;
        }

        public void SaveCurrentFoodItemList(List<FoodItem> foodItemList)
        {
            // Screate xml Serializer type of FoodItem
            XmlSerializer xmlSaveSerial = new XmlSerializer(typeof(List<FoodItem>));

            using (FileStream fileStream = new FileStream($"{FileManager.Instance.FoodItemsDir}\\{_foodItemListFileName}", FileMode.Create))
            {
                // add food item to list
                LoadedFoodtemList = foodItemList;

                // save list
                xmlSaveSerial.Serialize(fileStream, LoadedFoodtemList);
            }
        }

        private void VerifyFile()
        {
            if(!File.Exists($"{FileManager.Instance.FoodItemsDir}\\{_foodItemListFileName}"))
            {
                File.Create($"{FileManager.Instance.FoodItemsDir}\\{_foodItemListFileName}");
            }
        }
    }
}

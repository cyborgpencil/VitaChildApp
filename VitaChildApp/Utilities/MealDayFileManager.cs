using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VitaChildApp.Models;

namespace VitaChildApp.Utilities
{
    public class MealDayFileManager
    {
        private static MealDayFileManager _instance;
        private static readonly object padlock = new object();
        public List<MealDay> LoadedMealDayList;


        private string _mealDayFileName;

        private MealDayFileManager()
        {
            LoadedMealDayList = new List<MealDay>();
            _mealDayFileName = "Meal Day.xml";
            VerifyFile();
        }

        public static MealDayFileManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        _instance = new MealDayFileManager();
                    }
                }
                return _instance;
            }
        }

        private void VerifyFile()
        {
            if (!File.Exists($"{FileManager.Instance.MealDayDir}\\{_mealDayFileName}"))
            {
                File.Create($"{FileManager.Instance.MealDayDir}\\{_mealDayFileName}");
            }
        }

        public void SaveMealDay(MealDay saveMealDay)
        {
            if (saveMealDay != null)
            {
                // Screate xml Serializer type of FoodItem
                XmlSerializer xmlSaveMeal = new XmlSerializer(typeof(List<MealDay>));

                using (FileStream fileStream = new FileStream($"{FileManager.Instance.MealDayDir}\\{_mealDayFileName}", FileMode.Create))
                {
                    LoadedMealDayList.Add(saveMealDay);

                    // save list
                    xmlSaveMeal.Serialize(fileStream, LoadedMealDayList);
                }
            }
        }
    }
}

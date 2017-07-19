using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitaChildApp.Models;

namespace VitaChildApp.Utilities
{
    public class MealFileManager
    {
        private static MealFileManager _instance;
        public string MealFileName;
        public string MealFileNameFull;

        // list of meal objects used while app is running
        public ObservableCollection<Meal> LoadedMealList { get; set; }

        private MealFileManager()
        {
            MealFileName = @"Meals.xml";
            MealFileNameFull = $"{FileManager.Instance.WorkingFolder}\\{MealFileName}";

            if (!File.Exists(MealFileNameFull))
            {
                File.Create(MealFileNameFull);
            }
        }

        public static MealFileManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MealFileManager();
                }
                return _instance;
            }
        }

        public void LoadMealList()
        {

        }

    }
}

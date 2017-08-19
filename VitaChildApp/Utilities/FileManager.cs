using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using VitaChildApp.Models;

namespace VitaChildApp.Utilities
{
    public class FileManager
    {

        private static FileManager instance;
        private static readonly object padlock = new object();

        public IList<MealDay> LoadedMealDayList;

        // FOLDERS
        private string AppMealDirName { get; }
        private string FoodItemsDirName { get; }
        private string MealDayDirName { get; }
        private string MealPlanDirName { get; }

        // Directories
        public string MealPlanDir { get;}
        public string MealDayDir { get; }
        public string FoodItemsDir { get; }

        private FileManager()
        {
             // set object Directory names names
            MealPlanDirName = "Meal Plan";
            MealDayDirName = "Meal Day";
            AppMealDirName = "Child App";
            FoodItemsDirName = "Food Items";

            // set directories
            MealPlanDir = $"{AppMealDirName}\\{MealPlanDirName}";
            MealDayDir = $"{AppMealDirName}\\{MealDayDirName}";
            FoodItemsDir = $"{AppMealDirName}\\{FoodItemsDirName}";

            LoadedMealDayList = new List<MealDay>();
        }

        public static FileManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new FileManager();
                        }
                    }
                }
                return instance;
            }
        }

        public void SetupAndVerifyFolders()
        {
            // check and create Folders 
            if (!Directory.Exists(AppMealDirName))
            {
                Directory.CreateDirectory(AppMealDirName);
            }
            if (!Directory.Exists(MealPlanDir))
            {
                Directory.CreateDirectory(MealPlanDir);
            }
            if (!Directory.Exists(MealDayDir))
            {
                Directory.CreateDirectory(MealDayDir);
            }
            if (!Directory.Exists(FoodItemsDir))
            {
                Directory.CreateDirectory(FoodItemsDir);
            }

        }
    }
}

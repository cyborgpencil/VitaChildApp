using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaChildApp.Utilities
{
    public class MealDayFileManager
    {
        private static MealDayFileManager _instance;
        private static readonly object padlock = new object();

        private string _mealDayFileName;

        private MealDayFileManager()
        {
            _mealDayFileName = "Meal Day.xml";
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
    }
}

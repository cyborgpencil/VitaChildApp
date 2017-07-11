using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitaChildApp.Utilities
{
    public class MealFileManager
    {
        private static MealFileManager _instance;

        private MealFileManager()
        {

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

    }
}

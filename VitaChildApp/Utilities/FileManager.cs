using System;
using System.IO;

namespace VitaChildApp.Utilities
{
    public class FileManager
    {
        private static FileManager instance;
        public string WorkingFolder;
        

        private FileManager()
        {
            WorkingFolder = "Food Items";
        }

        public static FileManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new FileManager();
                }
                return instance;
            }
        }

        public void CreateWorkingFolders()
        {
            if (!Directory.Exists(WorkingFolder))
            {
                Directory.CreateDirectory(WorkingFolder);
            }
        }
    }
}

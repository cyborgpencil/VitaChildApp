using System;
using System.IO;

namespace VitaChildApp.Utilities
{
    public class FileManager
    {
        private static FileManager instance;
        public string _workingFolder;

        private FileManager()
        {
            _workingFolder = "Food Items";
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
            if (!Directory.Exists(_workingFolder))
            {
                Directory.CreateDirectory(_workingFolder);
            }
        }
    }
}

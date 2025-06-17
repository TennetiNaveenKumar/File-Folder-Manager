using System;
using System.IO;

namespace FileManagerLib
{
    public class FileManager
    {
        public string DirectoryPath { get; }

        public FileManager(string directoryPath)
        {
            DirectoryPath = directoryPath;
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public bool CreateFile(string fileName)
        {
            string fullPath = Path.Combine(DirectoryPath, fileName);
            if (File.Exists(fullPath))
                return false;

            File.WriteAllText(fullPath, "This is a sample file created on " + DateTime.Now);
            return true;
        }

        public bool DeleteFile(string fileName)
        {
            string fullPath = Path.Combine(DirectoryPath, fileName);
            if (!File.Exists(fullPath))
                return false;

            File.Delete(fullPath);
            return true;
        }

        public string[] ListFiles()
        {
            return Directory.GetFiles(DirectoryPath);
        }
    }
}

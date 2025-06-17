using System;
using FileManagerLib;

namespace FileManagerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "MyFiles";
            FileManager fileManager = new FileManager(folderPath);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== File Manager ===");
                Console.WriteLine("1. Create File");
                Console.WriteLine("2. Delete File");
                Console.WriteLine("3. List Files");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter file name to create: ");
                        string createName = Console.ReadLine();
                        if (fileManager.CreateFile(createName))
                            Console.WriteLine("File created successfully.");
                        else
                            Console.WriteLine("File already exists.");
                        break;

                    case "2":
                        Console.Write("Enter file name to delete: ");
                        string deleteName = Console.ReadLine();
                        if (fileManager.DeleteFile(deleteName))
                            Console.WriteLine("File deleted successfully.");
                        else
                            Console.WriteLine("File does not exist.");
                        break;

                    case "3":
                        Console.WriteLine("\nFiles:");
                        var files = fileManager.ListFiles();
                        if (files.Length == 0)
                            Console.WriteLine("No files found.");
                        else
                            foreach (var file in files)
                                Console.WriteLine("- " + System.IO.Path.GetFileName(file));
                        break;

                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting.");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}

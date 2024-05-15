using System;
using System.Windows.Input;
namespace AutoPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
          
            ICommand iCI = null;
            while (true)
            {
                Console.WriteLine("Select any option from below");
                Console.WriteLine("1. Type 1 to File Copy");
                Console.WriteLine("2. Type 2 to File Delete");
                Console.WriteLine("3. Type 3 to Query Folder Files");
                Console.WriteLine("4. Type 4 to Create Folder");
                Console.WriteLine("5. Type 5 to Download File");
                Console.WriteLine("6. Type 6 to Wait");
                Console.WriteLine("7. Type 7 to Conditional Count Rows File");
                Console.Write("Enter the number of the command you want to execute:  ");
                string command = Console.ReadLine();
                ExecuteSelectedCommand(command, iCI);
            
            }
        }


        static void ExecuteSelectedCommand(string command, ICommand iCI)
        {

            switch (command)
            {
                case "1":
                    Console.Write("Enter source file path with name eg:- (F:\\TestingData\\1.txt) :-  ");
                    string sourceFilePath = Console.ReadLine();
                    Console.Write("Enter destination file path with name eg:- (F:\\TestingData\\new.txt) :-  ");
                    string destinationFilePath = Console.ReadLine();
                    iCI = new FileCopyCommand(sourceFilePath, destinationFilePath);
                    iCI.ExecuteCommand();
                    break;
                case "2":
                    Console.Write("Enter  file path to delete eg:- (F:\\TestingData\\1.txt) :-  ");
                    string filepath = Console.ReadLine();
                    //iCE.deleteFile(filepath);
                    iCI = new DeleteFileCommand(filepath);
                    iCI.ExecuteCommand();
                    break;
                case "3":
                    Console.Write("Enter folpder path to get all files list :-  ");
                    string folderPath = Console.ReadLine();
                    iCI = new GetAllFilesCommand(folderPath);
                    iCI.ExecuteCommand();
                    break;
                case "4":
                    Console.Write("Enter folpder path  :-  ");
                    string folderpath = Console.ReadLine();
                    Console.Write("Enter folpder Name :-  ");
                    string foldername = Console.ReadLine();
                    iCI = new CreateFolderCommand(folderpath, foldername);
                    iCI.ExecuteCommand();
                    break;
                case "5":
                    Console.Write("Enter file path to download eg:- (F:\\TestingData\\1.txt) :-  ");
                    string downloadfilepath = Console.ReadLine();
                    iCI = new DownloadFileCommand(downloadfilepath);
                    iCI.ExecuteCommand();
                    break;
                case "6":
                    Console.Write("Enter time in seconds to wait: ");
                    string timeInSeconds = Console.ReadLine();
                    iCI = new WaitCommand(timeInSeconds);
                    iCI.ExecuteCommand();
                    break;
                case "7":
                    Console.Write("Enter file path to read eg:- (F:\\TestingData\\1.txt) :-  ");
                    string filePath = Console.ReadLine();
                    Console.Write("Enter text to seacrh in file :- ");
                    string searchText = Console.ReadLine();
                    iCI = new searchTextInFileCommand(filePath, searchText);
                    iCI.ExecuteCommand();
                    break;
                default:
                    Console.WriteLine("Exiting...");
                    break;
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine(); // for empty line
        }


        //static void ExecuteSelectedCommand(string command, ICommandInterface iCI)
        //{

        //    switch (command)
        //    {
        //        case "1":
        //            Console.Write("Enter source file path with name eg:- (F:\\TestingData\\1.txt) :-  ");
        //            string sourceFilePath = Console.ReadLine();
        //            Console.Write("Enter destination file path with name eg:- (F:\\TestingData\\new.txt) :-  ");
        //            string destinationFilePath = Console.ReadLine();
        //            //iCE.copyFile(sourceFilePath, destinationFilePath);
        //            iCI = new FileCopyCommand(sourceFilePath, destinationFilePath);
        //            iCI.ExecuteCommand();
        //            break;
        //        case "2":
        //            Console.Write("Enter  file path to delete :-  ");
        //            string filepath = Console.ReadLine();
        //            //iCE.deleteFile(filepath);
        //            iCI = new DeleteFileCommand(filepath);
        //            iCI.ExecuteCommand();
        //            break;
        //        case "3":
        //            Console.Write("Enter folpder path to get all files list :-  ");
        //            string folderPath = Console.ReadLine();
        //            iCE.getAllFiles(folderPath);
        //            break;
        //        case "4":
        //            Console.Write("Enter folpder path :-  ");
        //            string folderpath = Console.ReadLine();
        //            Console.Write("Enter folpder Name :-  ");
        //            string foldername = Console.ReadLine();
        //            iCE.createFolder(folderpath, foldername);
        //            break;
        //        case "5":
        //            Console.Write("Enter file path to download eg:- (F:\\TestingData\\1.txt) :-  ");
        //            string downloadfilepath = Console.ReadLine();
        //            iCE.downloadFile(downloadfilepath);
        //            break;
        //        case "6":
        //            Console.Write("Enter time in seconds to wait: ");
        //            string timeInSeconds = Console.ReadLine();
        //            iCE.waitExecution(timeInSeconds);
        //            break;
        //        case "7":
        //            Console.Write("Enter file path to read eg:- (F:\\TestingData\\1.txt) :-  ");
        //            string filePath = Console.ReadLine();
        //            Console.Write("Enter text to seacrh in file :- ");
        //            string searchText = Console.ReadLine();
        //            iCE.searchTextInFile(filePath, searchText);
        //            break;
        //        default:
        //            Console.WriteLine("Exiting...");
        //            break;
        //    }

        //    Console.WriteLine("----------------------------------");
        //    Console.WriteLine(); // for empty line
        //}
    }

}
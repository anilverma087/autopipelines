using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace AutoPipeline
{
    public class FileCopyCommand : ICommand
    {
        private readonly string _sourceFilePath;
        private readonly string _destinationFilePath;
        public FileCopyCommand(string sourceFilePath, string destinationFilePath)
        {
            _sourceFilePath = sourceFilePath;
            _destinationFilePath = destinationFilePath;
        }
        public void ExecuteCommand()
        {
            try
            {
                // Check if source file exists
                if (!File.Exists(_sourceFilePath))
                {
                    Console.WriteLine($"Source file : '{_sourceFilePath}' does not exist.");
                    return;
                }

                // Check if destination directory exists, create it if not
                string destinationDirectory = Path.GetDirectoryName(_destinationFilePath);
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Copy the file
                File.Copy(_sourceFilePath, _destinationFilePath, true); // Overwrite if the file exists
                Console.WriteLine($"File copied from '{_sourceFilePath}' to '{_destinationFilePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }
        }
    }
    public class DeleteFileCommand : ICommand
    {
        private readonly string _filePath;
        public DeleteFileCommand(string filePath)
        {
            _filePath = filePath;
        }
        public void ExecuteCommand()
        {
            try
            {
                // Check if the file exists
                if (File.Exists(_filePath))
                {
                    // Delete the file
                    File.Delete(_filePath);
                    Console.WriteLine($"File : '{_filePath}' deleted successfully!");
                }
                else
                {
                    Console.WriteLine($"File : '{_filePath}' not found.");
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting file: {ex.Message}");
            }
        }
    }
    public class CreateFolderCommand : ICommand
    {
        private readonly string _folderPath;
        private readonly string _folderName;

        public CreateFolderCommand(string folderPath, string folderName)
        {
            _folderPath = folderPath;
            _folderName = folderName;
        }
        public void ExecuteCommand()
        {
            try
            {
                string fullFolderPath = Path.Combine(_folderPath, _folderName);
                if (Directory.Exists(fullFolderPath))
                {
                    Console.WriteLine($"Folder '{fullFolderPath}' already exists.");
                }
                else
                {
                    // Create new folder
                    Directory.CreateDirectory(fullFolderPath);
                    Console.WriteLine($"Folder '{fullFolderPath}' created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating folder: {ex.Message}");
            }
        }
    }
    public class GetAllFilesCommand : ICommand
    {
        private readonly string _folderPath;

        public GetAllFilesCommand(string folderPath)
        {
            _folderPath = folderPath;
        }
        public void ExecuteCommand()
        {
            try
            {
                if (!Directory.Exists(_folderPath))
                {
                    Console.WriteLine($"Folder '{_folderPath}' does not exists");
                }
                string[] files = Directory.GetFiles(_folderPath);
                Console.WriteLine($"Files in the folder : '{_folderPath}': Total No. of files : {files.Length} ");
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating folder: {ex.Message}");
            }
        }
    }
    public class DownloadFileCommand : ICommand
    {
        private readonly string _filePath;

        public DownloadFileCommand(string filePath)
        {
            _filePath = filePath;
        }
        public void ExecuteCommand()
        {
            try
            {
                string downloadFolderPath = "C:\\Downloads";  // created download folder if not exists
                if (!Directory.Exists(downloadFolderPath))
                {
                    Directory.CreateDirectory(downloadFolderPath); // created download folder if not exists
                }
                string fileName = Path.GetFileName(_filePath);
                string destinationFilePath = Path.Combine(downloadFolderPath, fileName);
                File.Copy(_filePath, destinationFilePath, true); // set true to Overwrite if the file exists.
                Console.WriteLine($"File '{fileName}' downloaded to '{downloadFolderPath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while downloading the file: {ex.Message}");
            }
        }

    }
    public class WaitCommand : ICommand
    {
        private readonly string _timeInSeconds;
        public WaitCommand(string timeInSeconds)
        {
            _timeInSeconds = timeInSeconds;
        }
        public void ExecuteCommand()
        {
            try
            {
                int seconds = Convert.ToInt32(_timeInSeconds);
                Console.WriteLine($"Please wait for {seconds} seconds...");
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.AddSeconds(seconds);
                int lastPrintedSecond = 0;
                while (DateTime.Now < endTime)
                {
                    int currentSecond = DateTime.Now.Second;
                    if (currentSecond != lastPrintedSecond) 
                    {
                        int remainingTime = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
                        Console.WriteLine($"Remaining time: {remainingTime} seconds");  // print only when the second changes.
                        lastPrintedSecond = currentSecond;
                    }
                }

                Console.WriteLine("Wait completed...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while waiting: {ex.Message}");
            }
        }

    }
    public class searchTextInFileCommand : ICommand
    {
        private readonly string _filePath;
        private readonly string _searchString;

        public searchTextInFileCommand(string filePath, string searchString)
        {
            _filePath = filePath;
            _searchString = searchString;
        }
        public void ExecuteCommand()
        {
            try
            {
                string[] lines = File.ReadAllLines(_filePath);
                int count = 0;
                foreach (string line in lines)
                {
                    if (line.Contains(_searchString))
                    {
                        Console.WriteLine(line);
                        count++;
                    }
                }
                Console.WriteLine($"Number of rows containing '{_searchString}' in file '{_filePath}'  is, Total : {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while counting rows in the file: {ex.Message}");
            }
        }

    }
}

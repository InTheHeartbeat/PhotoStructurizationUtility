using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ExifLib;
using PhotoStructurizationUtility.Kernel.FileSystem;
using PhotoStructurizationUtility.Kernel.Logging;
using PhotoStructurizationUtility.Kernel.Logging.Enums;

namespace PhotoStructurizationUtility.Kernel.Processing
{
    public class Processor
    {
        private FileSystemWalker _fileSystemWalker;
        private string _destinationRootPath;

        public Processor()
        {
            LoggerSingleton.GetLogger().Log("Started initializing...", LogNoteType.Info, "Processor");

            _fileSystemWalker = new FileSystemWalker();
            LoggerSingleton.GetLogger().Log("Initialized.", LogNoteType.Success, "Processor");
        }

        public async Task OrganizeForRoot(string rootPath, string destRoot)
        {
            _destinationRootPath = destRoot;
            await Task.Run(() => _fileSystemWalker.WalkDirectoryTree(new DirectoryInfo(rootPath), ProcessFile));
        }

        private void ProcessFile(FileInfo file)
        {
            LoggerSingleton.GetLogger().Log($"File {file.Name} at {file.DirectoryName} was found", LogNoteType.Info, "Processor");
            
            try
            {
                LoggerSingleton.GetLogger().Log($"Loading photo {file.Name}...", LogNoteType.Secondary, "Processor");                                

                using (ExifReader reader = new ExifReader(@"C:\temp\testImage.jpg"))
                {
                    LoggerSingleton.GetLogger().Log($"{file.Name} Loaded!", LogNoteType.Success, "Processor");

                    int width = 0;
                    int height = 0;
                    DateTime taken = new DateTime();

                    reader.GetTagValue(ExifTags.ImageWidth, out width);
                    reader.GetTagValue(ExifTags.ImageLength, out height);
                    reader.GetTagValue(ExifTags.DateTimeDigitized, out taken);

                    LoggerSingleton.GetLogger().Log($"Width: {width}", LogNoteType.Secondary, $"Processor ({file.Name})");
                    LoggerSingleton.GetLogger().Log($"Height: {height}", LogNoteType.Secondary, $"Processor ({file.Name})");
                    LoggerSingleton.GetLogger().Log($"Taken: {taken}", LogNoteType.Secondary, $"Processor ({file.Name})");
                    LoggerSingleton.GetLogger().Log($"Checking hierarchy..", LogNoteType.Info, $"Processor ({file.Name})");

                    string destinationPath = DirectoryUtility.CreateFolderHierarchy(taken, _destinationRootPath, false);
                    if (!String.IsNullOrWhiteSpace(destinationPath) && Directory.Exists(destinationPath))
                    {
                        LoggerSingleton.GetLogger().Log($"Successfully hierarchy validated.", LogNoteType.Success, $"Processor ({file.Name})");


                    }
                    else
                    {
                        LoggerSingleton.GetLogger().Log($"Unknown error while hierarchy validation!", LogNoteType.Error, $"Processor ({file.Name})");
                        LoggerSingleton.GetLogger().Log($"File {file.Name} miss out.", LogNoteType.Info,
                            $"Processor ({file.Name})");
                    }
                }                
            }
            catch (Exception e)
            {
                LoggerSingleton.GetLogger().Log($"An error occured while processing photo {file.Name}: {e.Message}",
                    LogNoteType.Error, "Processor");
            }            
        }
    }
}

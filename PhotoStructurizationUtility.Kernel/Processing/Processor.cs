using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ExifLib;
using PhotoStructurizationUtility.Kernel.BackCompatibility;
using PhotoStructurizationUtility.Kernel.FileSystem;
using PhotoStructurizationUtility.Kernel.Logging;
using PhotoStructurizationUtility.Kernel.Logging.Enums;

namespace PhotoStructurizationUtility.Kernel.Processing
{
    public class Processor
    {
        private readonly FileSystemWalker _fileSystemWalker;
        private readonly BackCompatibilityUtility _backCompatibility;
        private string _destinationRootPath;
        private bool _move;
        public Processor()
        {
            LoggerSingleton.GetLogger().Log("Started initializing...", LogNoteType.Info, "Processor");

            _fileSystemWalker = new FileSystemWalker();
            _backCompatibility = new BackCompatibilityUtility();

            LoggerSingleton.GetLogger().Log("Initialized.", LogNoteType.Success, "Processor");
        }

        public async Task OrganizeForRoot(string rootPath, string destRoot, bool move)
        {
            _destinationRootPath = destRoot;
            _move = move;
            await Task.Run(() => _fileSystemWalker.WalkDirectoryTree(new DirectoryInfo(rootPath), ProcessFile));
            _backCompatibility.SaveSnapshot(destRoot);
        }

        private void ProcessFile(FileInfo file)
        {
            LoggerSingleton.GetLogger().Log($"File {file.Name} at {file.DirectoryName} was found", LogNoteType.Info, "Processor");

            try
            {
                LoggerSingleton.GetLogger().Log($"Loading photo {file.Name}...", LogNoteType.Secondary, "Processor");
                Image img = Image.FromFile(file.FullName);
                DateTime taken = new DateTime();

                using (ExifReader reader = new ExifReader(file.FullName))
                {
                    LoggerSingleton.GetLogger().Log($"{file.Name} Loaded!", LogNoteType.Success, "Processor");
                    reader.GetTagValue(ExifTags.DateTimeDigitized, out taken);
                }

                LoggerSingleton.GetLogger().Log($"Width: {img.Width}", LogNoteType.Secondary,
                        $"Processor ({file.Name})");
                LoggerSingleton.GetLogger().Log($"Height: {img.Height}", LogNoteType.Secondary,
                    $"Processor ({file.Name})");
                LoggerSingleton.GetLogger()
                    .Log($"Taken: {taken}", LogNoteType.Secondary, $"Processor ({file.Name})");
                LoggerSingleton.GetLogger()
                    .Log($"Checking hierarchy..", LogNoteType.Info, $"Processor ({file.Name})");

                string destinationPath = DirectoryUtility.CreateFolderHierarchy(taken, _destinationRootPath, false, !(img.Width >= 1024 && img.Height >= 768));
                img.Dispose();
                if (!String.IsNullOrWhiteSpace(destinationPath) && Directory.Exists(destinationPath))
                {
                    LoggerSingleton.GetLogger().Log($"Successfully hierarchy validated.", LogNoteType.Success,
                        $"Processor ({file.Name})");

                    _backCompatibility.AddSnapshotEnty(file.Name, file.FullName, destinationPath);

                    LoggerSingleton.GetLogger().Log((_move ? "Moving" : "Copying") + $" to {destinationPath}",
                        LogNoteType.Info, $"Processor ({file.Name})");
                    if (_move)
                    {
                        file.MoveTo(destinationPath + "/" + file.Name);
                    }
                    else
                    {
                        file.CopyTo(destinationPath + "/" + file.Name);
                    }

                    LoggerSingleton.GetLogger()
                        .Log("Successful" + (_move ? "moved!" : "copyed!") + $" to {destinationPath}",
                            LogNoteType.Success, $"Processor ({file.Name})");
                }
                else
                {
                    LoggerSingleton.GetLogger().Log($"Unknown error while hierarchy validation!", LogNoteType.Error,
                        $"Processor ({file.Name})");
                    LoggerSingleton.GetLogger().Log($"File {file.Name} miss out.", LogNoteType.Info,
                        $"Processor ({file.Name})");
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

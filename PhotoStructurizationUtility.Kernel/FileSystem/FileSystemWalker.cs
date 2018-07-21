using System;
using System.IO;
using System.Linq;
using PhotoStructurizationUtility.Kernel.Extentions;
using PhotoStructurizationUtility.Kernel.Logging;
using PhotoStructurizationUtility.Kernel.Logging.Enums;

namespace PhotoStructurizationUtility.Kernel.FileSystem
{
    public class FileSystemWalker
    {
        public FileSystemWalker()
        {
            LoggerSingleton.GetLogger().Log("Initialized.", LogNoteType.Info, "FileSystemWalker");
        }
        public void WalkDirectoryTree(DirectoryInfo root, Action<FileInfo> searched)
        {
            System.IO.FileInfo[] files = null;
            try
            {
                files = root.GetFilesByExtensions(".jpg", ".jpeg", ".png").ToArray();
            }
            catch (UnauthorizedAccessException e)
            {
                LoggerSingleton.GetLogger().Log(e.Message, LogNoteType.Error, "WalkDirectoryTree");
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                LoggerSingleton.GetLogger().Log(e.Message, LogNoteType.Error, "WalkDirectoryTree");
            }
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    searched(file);
                }

                var subDirs = root.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo, searched);
                }
            }
        }
    }
}

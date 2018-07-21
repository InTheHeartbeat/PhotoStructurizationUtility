using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStructurizationUtility
{
    public class FileSystemWalker
    {
        
        public void WalkDirectoryTree(DirectoryInfo root, Action<FileInfo> searched)
        {
            System.IO.FileInfo[] files = null;
            try
            {
                files = root.GetFilesByExtensions(".jpg", ".jpeg", ".png").ToArray();
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
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

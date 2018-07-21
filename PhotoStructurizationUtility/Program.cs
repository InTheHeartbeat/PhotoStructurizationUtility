using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStructurizationUtility
{
    class Program
    {
        private static int processBySizeCounter = 0;
        private static int photosCounter = 0;
        static void Main(string[] args)
        {
             SearchBySize();
            Console.ReadLine();
        }

        public static void SearchBySize()
        {
            FileSystemWalker fileSystemWalker = new FileSystemWalker();

             fileSystemWalker.WalkDirectoryTree(new DirectoryInfo(@"E://Photos/"), ProcessBySize);
        }

        private static void ProcessBySize(FileInfo file)
        {
            try
            {
                photosCounter++;
                Console.WriteLine($"Searched photo #{photosCounter}: ");
                Console.WriteLine(file.FullName);

                Bitmap photo = new Bitmap(file.FullName);
                Console.WriteLine($"Width: {photo.Width}");
                Console.WriteLine($"Height: {photo.Height}");

                if (photo.Width >= 3000 && photo.Height >= 2000)
                {
                    processBySizeCounter++;
                    file.CopyTo($@"C:/TestSystem/Photos/{file.Name}");
                    Console.WriteLine("Moved!");
                }

                Console.WriteLine("");
            }
            catch { }
        }
    }
}

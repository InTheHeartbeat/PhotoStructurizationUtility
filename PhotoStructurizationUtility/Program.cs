using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoStructurizationUtility.Kernel.Logging;
using PhotoStructurizationUtility.Kernel.Logging.Enums;
using PhotoStructurizationUtility.Kernel.Processing;

namespace PhotoStructurizationUtility
{
    class Program
    {        
        [STAThread]
        static void Main(string[] args)
        {
            string root = null;
            string destRoot = null;

            BackgroundWorker worker = new BackgroundWorker {WorkerReportsProgress = true};
            worker.DoWork += async (sender, eventArgs) =>
            {
                LoggerSingleton.GetLogger().Logged = note =>
                {
                    switch (note.NoteType)
                    {
                        case LogNoteType.Info:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(note.Message);
                            break;
                        case LogNoteType.Warning:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(note.Message);
                            break;
                        case LogNoteType.Error:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(note.Message);
                            break;
                        case LogNoteType.Message:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(note.Message);
                            break;
                        case LogNoteType.Secondary:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(note.Message);
                            break;
                        case LogNoteType.Success:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(note.Message);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                };

                Processor processor = new Processor();                

                LoggerSingleton.GetLogger().Log("Ready to processing! Please choose folders.", LogNoteType.Info);

                
                       await processor.OrganizeForRoot(root, destRoot,
                            true);
                    
            };
            FolderBrowserDialog rootBrowserDialog = new FolderBrowserDialog();
            rootBrowserDialog.ShowNewFolderButton = true;
            FolderBrowserDialog destRootBrowserDialog = new FolderBrowserDialog();
            destRootBrowserDialog.ShowNewFolderButton = true;
            

            if (rootBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (destRootBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    root = rootBrowserDialog.SelectedPath;
                    destRoot = destRootBrowserDialog.SelectedPath;
                    worker.RunWorkerAsync();
                }
            }            
            Console.ReadLine();
        }        
    }
}

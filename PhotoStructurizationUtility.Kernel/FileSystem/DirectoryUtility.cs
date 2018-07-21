using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStructurizationUtility.Kernel.Logging;
using PhotoStructurizationUtility.Kernel.Logging.Enums;

namespace PhotoStructurizationUtility.Kernel.FileSystem
{
    public static class DirectoryUtility
    {
        public static string CreateFolderHierarchy(DateTime dateTime, string root, bool isDayLayer)
        {
            string yearFolder = Path.Combine(root, dateTime.Year.ToString());
            string monthFolder = Path.Combine(yearFolder, $"{dateTime.Month.ToString()}. {dateTime.Month.ToString("MMMM", CultureInfo.InvariantCulture)}");
            string dayFolder = Path.Combine(root, dateTime.Year.ToString());

            if (!Directory.Exists(yearFolder))
            {
                LoggerSingleton.GetLogger().Log($"Folder for year ({yearFolder}) is not exist!", LogNoteType.Warning, "DirectoryUtility");
                LoggerSingleton.GetLogger().Log($"Creating folder \"{yearFolder}\"...", LogNoteType.Secondary, "DirectoryUtility");
                try
                {
                    Directory.CreateDirectory(yearFolder);
                    LoggerSingleton.GetLogger().Log($"Folder \"{yearFolder}\" successfully created!", LogNoteType.Success, "DirectoryUtility");
                }
                catch (Exception e)
                {
                    LoggerSingleton.GetLogger().Log($"An error occurred while creating folder \"{yearFolder}\": {e.Message}", LogNoteType.Error, "DirectoryUtility");
                    return String.Empty;
                }                
            }

            if (!Directory.Exists(monthFolder))
            {
                LoggerSingleton.GetLogger().Log($"Folder for month ({monthFolder}) is not exist!", LogNoteType.Warning, "DirectoryUtility");
                LoggerSingleton.GetLogger().Log($"Creating folder \"{monthFolder}\"...", LogNoteType.Secondary, "DirectoryUtility");
                try
                {
                    Directory.CreateDirectory(yearFolder);
                    LoggerSingleton.GetLogger().Log($"Folder \"{monthFolder}\" successfully created!", LogNoteType.Success, "DirectoryUtility");
                }
                catch (Exception e)
                {
                    LoggerSingleton.GetLogger().Log($"An error occurred while creating folder \"{monthFolder}\": {e.Message}", LogNoteType.Error, "DirectoryUtility");
                    return String.Empty;
                }
            }

            if (!Directory.Exists(dayFolder) && isDayLayer)
            {
                LoggerSingleton.GetLogger().Log($"Folder for day ({dayFolder}) is not exist!", LogNoteType.Warning, "DirectoryUtility");
                LoggerSingleton.GetLogger().Log($"Creating folder \"{dayFolder}\"...", LogNoteType.Secondary, "DirectoryUtility");
                try
                {
                    Directory.CreateDirectory(yearFolder);
                    LoggerSingleton.GetLogger().Log($"Folder \"{dayFolder}\" successfully created!", LogNoteType.Success, "DirectoryUtility");
                }
                catch (Exception e)
                {
                    LoggerSingleton.GetLogger().Log($"An error occurred while creating folder \"{dayFolder}\": {e.Message}", LogNoteType.Error, "DirectoryUtility");
                    return String.Empty;
                }
            }

            return isDayLayer ? dayFolder : monthFolder;
        }
    }
}

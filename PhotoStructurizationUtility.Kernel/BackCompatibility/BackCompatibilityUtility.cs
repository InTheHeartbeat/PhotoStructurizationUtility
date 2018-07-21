using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PhotoStructurizationUtility.Kernel.FileSystem;
using PhotoStructurizationUtility.Kernel.Logging;
using PhotoStructurizationUtility.Kernel.Logging.Enums;

namespace PhotoStructurizationUtility.Kernel.BackCompatibility
{
    public class BackCompatibilityUtility
    {
        private readonly List<SnapshotEntry> _snapshots;

        public BackCompatibilityUtility()
        {
            LoggerSingleton.GetLogger().Log("Started initializing...", LogNoteType.Info, "BackCompatibility");

            _snapshots = new List<SnapshotEntry>();
            LoggerSingleton.GetLogger().Log("Initialized.", LogNoteType.Success, "BackCompatibility");            
        }

        public void AddSnapshotEnty(string filename, string oldPath, string newPath)
        {
            _snapshots.Add(new SnapshotEntry
            {
                Created = DateTime.Now,
                FileName = filename,
                OldPath = oldPath,
                NewPath = newPath
            });
            LoggerSingleton.GetLogger().Log("Snapshot entry added.", LogNoteType.Secondary, "BackCompatibility");
        }

        public string SaveSnapshot(string path)
        {
            if (!Directory.Exists(path))
            {
                LoggerSingleton.GetLogger().Log("Path for save snapshot is not exist.", LogNoteType.Warning, "BackCompatibility");
                LoggerSingleton.GetLogger().Log("Creating folder for snapshot", LogNoteType.Secondary, "BackCompatibility");
                try
                {
                    Directory.CreateDirectory(path);
                    LoggerSingleton.GetLogger().Log($"Folder \"{path}\" successfully created!", LogNoteType.Success, "BackCompatibility");
                }
                catch (Exception e)
                {
                    LoggerSingleton.GetLogger().Log($"An error occurred while creating folder \"{path}\": {e.Message}", LogNoteType.Error, "BackCompatibility");
                    return String.Empty;
                }                
            }
            try
            {
                LoggerSingleton.GetLogger().Log($"Snapshot serializing...", LogNoteType.Info, "BackCompatibility");
                XmlSerializer formatter = new XmlSerializer(typeof(List<SnapshotEntry>));

                string xmlPath = path + $"bc_snapshot_{DateTime.Now.ToShortDateString().Replace('.', '-')}.xml";

                using (FileStream fs = new FileStream(xmlPath, FileMode.CreateNew))
                {
                    formatter.Serialize(fs, _snapshots);
                }

                LoggerSingleton.GetLogger().Log($"Snapshot serialized!", LogNoteType.Success, "BackCompatibility");
                return xmlPath;
            }
            catch (Exception e)
            {
                LoggerSingleton.GetLogger().Log($"An error occurred while snapshot serializing: {e.Message}", LogNoteType.Error, "BackCompatibility");
                return String.Empty;
            }
        }
    }
}

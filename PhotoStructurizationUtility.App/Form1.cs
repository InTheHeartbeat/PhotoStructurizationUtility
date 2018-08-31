using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoStructurizationUtility.App.Models;
using PhotoStructurizationUtility.App.Models.Enums;
using PhotoStructurizationUtility.Kernel.Logging;
using PhotoStructurizationUtility.Kernel.Logging.Enums;
using PhotoStructurizationUtility.Kernel.Processing;

namespace PhotoStructurizationUtility.App
{
    public partial class Form1 : Form
    {
        private ObservableCollection<DirectoryInfo> _sourceFolders;
        private ObservableCollection<DirectoryInfo> _targetFolders;

        private ObservableCollection<KeyValuePair<DirectoryInfo, DirectoryInfo>> _assignedFolders;

        private BackgroundWorker _organizeWorker;

        public Form1()
        {
            Initialize();
        }

        private void Initialize()
        {
            _sourceFolders = new ObservableCollection<DirectoryInfo>();
            _targetFolders = new ObservableCollection<DirectoryInfo>();
            _assignedFolders = new ObservableCollection<KeyValuePair<DirectoryInfo, DirectoryInfo>>();
            _sourceFolders.CollectionChanged += SourceFoldersCollectionChanged;
            _targetFolders.CollectionChanged += TargetFoldersCollectionChanged;
            _assignedFolders.CollectionChanged += AssignedFolders_CollectionChanged;

            _organizeWorker = new BackgroundWorker { WorkerReportsProgress = true };
            _organizeWorker.DoWork += _organizeWorker_DoWork;            
            InitializeComponent();

            LoggerSingleton.GetLogger().Logged = note =>
            {
                switch (note.NoteType)
                {
                    case LogNoteType.Info:
                        AddHistoryItem(new HistoryItemViewModel(note.Message, Color.DarkCyan));
                        break;
                    case LogNoteType.Warning:
                        AddHistoryItem(new HistoryItemViewModel(note.Message, Color.DarkGoldenrod));
                        break;
                    case LogNoteType.Error:
                        AddHistoryItem(new HistoryItemViewModel(note.Message, Color.DarkRed));
                        break;
                    case LogNoteType.Message:
                        AddHistoryItem(new HistoryItemViewModel(note.Message, Color.Black));
                        break;
                    case LogNoteType.Secondary:
                        AddHistoryItem(new HistoryItemViewModel(note.Message, Color.CadetBlue));
                        break;
                    case LogNoteType.Success:
                        AddHistoryItem(new HistoryItemViewModel(note.Message, Color.ForestGreen));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };            
        }        
        

        private void _organizeWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            Processor processor = new Processor();
            
            LoggerSingleton.GetLogger().Log("Ready to processing! Please choose folders.", LogNoteType.Info);

            Parallel.ForEach(_assignedFolders, async (currentAssign) =>
            {
                await processor.OrganizeForRoot(currentAssign.Key.FullName, currentAssign.Value.FullName, false);
            });            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnAddSourceButtonClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "Select folder for analize",
                ShowNewFolderButton = true               
            })
            {                
                if (folderBrowserDialog.ShowDialog(this) != DialogResult.OK) return;

                if (!string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath) &&
                    Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    AddFolder(new DirectoryInfo(folderBrowserDialog.SelectedPath), FolderType.Source);
                }
            }

            SourceFoldersListBox.ClearSelected();
        }

        private void OnRemoveSourceFolderButtonClick(object sender, EventArgs e)
        {
            if (SourceFoldersListBox.SelectedIndex == -1 || String.IsNullOrWhiteSpace(SourceFoldersListBox.SelectedItem as string))
            {
                return;
            }

            RemoveFolder(new DirectoryInfo((string)SourceFoldersListBox.SelectedItem), FolderType.Source);

            SourceFoldersListBox.ClearSelected();
        }

        private void OnClearSourceButtonClick(object sender, EventArgs e)
        {
            ClearFolders(FolderType.Source);
            SourceFoldersListBox.ClearSelected();
        }

        private void OnAddTargetFolderButtonClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "Select target folder",
                ShowNewFolderButton = true
            })
            {
                if (folderBrowserDialog.ShowDialog(this) != DialogResult.OK) return;

                if (!string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath) &&
                    Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    AddFolder(new DirectoryInfo(folderBrowserDialog.SelectedPath), FolderType.Target);
                }
            }

            TargetFoldersListBox.ClearSelected();
        }

        private void OnRemoveTargetFolderButtonClick(object sender, EventArgs e)
        {
            if (TargetFoldersListBox.SelectedIndex == -1 || String.IsNullOrWhiteSpace(TargetFoldersListBox.SelectedItem as string))
            {
                return;
            }

            RemoveFolder(new DirectoryInfo((string)TargetFoldersListBox.SelectedItem), FolderType.Target);

            TargetFoldersListBox.ClearSelected();
        }

        private void OnClearTargetFoldersButtonClick(object sender, EventArgs e)
        {
            ClearFolders(FolderType.Target);
            TargetFoldersListBox.ClearSelected();
        }

        private void OnAssignFoldersButtonClick(object sender, EventArgs e)
        {
            if (SourceFoldersListBox.SelectedItems.Count > 0 && TargetFoldersListBox.SelectedItems.Count > 0)
            {
                if (_assignedFolders == null)
                {
                    return;
                }

                object[] sources = new object[SourceFoldersListBox.SelectedItems.Count];
                object[] targets = new object[TargetFoldersListBox.SelectedItems.Count];

                SourceFoldersListBox.SelectedItems.CopyTo(sources,0);
                TargetFoldersListBox.SelectedItems.CopyTo(targets, 0);

                sources.ToList().ForEach(source =>
                {
                    targets.ToList().ForEach(target =>
                    {
                        if (source == null || target == null)
                        {
                            return;
                        }

                        string sourcePath = source as string;
                        string targetPath = target as string;

                        if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(targetPath))
                        {
                            return;
                        }

                        DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
                        DirectoryInfo targetDirectory = new DirectoryInfo(targetPath);

                        if (!sourceDirectory.Exists || !targetDirectory.Exists)
                        {
                            return;
                        }

                        var data = new KeyValuePair<DirectoryInfo, DirectoryInfo>(sourceDirectory, targetDirectory);
                        if (!_assignedFolders.Contains(data))
                        {
                            _assignedFolders.Add(data);
                        }
                    });                    
                });

                TargetFoldersListBox.ClearSelected();
                SourceFoldersListBox.ClearSelected();
            }
            else
            {
                MessageBox.Show("You need to choose source and target folders before", "Achtung", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void OnRemoveAssignButtonClick(object sender, EventArgs e)
        {
            if (AssignsListBox.SelectedItems.Count <= 0) return;

            foreach (int selectedIndex in AssignsListBox.SelectedIndices)
            {            
                RemoveAssigns(selectedIndex);
            }

            AssignsListBox.ClearSelected();
        }

        private void OnClearAssignsButtonClick(object sender, EventArgs e)
        {
            ClearAssigns();
            AssignsListBox.ClearSelected();
        }

        private void OnHistoryListBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index > 0)
            if (HistoryListBox.Items[e.Index] is HistoryItemViewModel item)
            {
                e.DrawBackground();
                Brush myBrush = new SolidBrush(item.Color);
                
                e.Graphics.DrawString(item.Message,
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                
                e.DrawFocusRectangle();;
            }
        }

        private void SourceFoldersCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TotalFoldersToScanLabel.Text = _sourceFolders.Count.ToString();

            SourceFoldersListBox.Items.Clear();
            SourceFoldersListBox.Items.AddRange(_sourceFolders.Select(folder => folder.FullName).ToArray());
        }

        private void TargetFoldersCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TotalTargetRoots.Text = _targetFolders.Count.ToString();

            TargetFoldersListBox.Items.Clear();
            TargetFoldersListBox.Items.AddRange(_targetFolders.Select(folder => folder.FullName).ToArray());
        }

        private void AssignedFolders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            AssignsListBox.Items.Clear();
            AssignsListBox.Items.AddRange(_assignedFolders.Select(assigns => $"{assigns.Key.FullName} => {assigns.Value.FullName}").ToArray());
        }

        private void AddFolder(DirectoryInfo folder, FolderType type)
        {
            ICollection<DirectoryInfo> folders = type == FolderType.Source ? _sourceFolders : _targetFolders;

            if (folders == null)
            {
                throw new InvalidOperationException("Initialize required");
            }

            if (folder == null || !folder.Exists)
            {
                throw new ArgumentException("Invalid folder");
            }

            if (folders.Contains(folder))
            {
                return;
            }

            folders.Add(folder);
        }

        private void RemoveFolder(DirectoryInfo folder, FolderType type)
        {
            ICollection<DirectoryInfo> folders = type == FolderType.Source ? _sourceFolders : _targetFolders;

            if (folders == null)
            {
                throw new InvalidOperationException("Initialize required");
            }

            if (folder == null)
            {
                throw new ArgumentException("Invalid folder");
            }

            if (!folders.Any(f => f.FullName.Contains(folder.FullName)))
            {
                return;
            }

            folders.Remove(folder);
        }

        private void RemoveAssigns(int index)
        {
            _assignedFolders.RemoveAt(index);
        }

        private void ClearFolders(FolderType type)
        {
            ICollection<DirectoryInfo> folders = type == FolderType.Source ? _sourceFolders : _targetFolders;
            if (folders == null)
            {
                throw new InvalidOperationException("Initialize required");
            }

            if (folders.Any())
            {
                folders.Clear();
            }
        }

        private void ClearAssigns()
        {
            if (_assignedFolders != null && _assignedFolders.Any())
            {
                _assignedFolders.Clear();
            }
        }

        private void AddHistoryItem(HistoryItemViewModel model)
        {
            MethodInvoker methodInvokerDelegate = delegate
            {
                HistoryListBox.Items.Add(model);
            };

            if (InvokeRequired)
            {
                Invoke(methodInvokerDelegate);
            }
            else
            {
                methodInvokerDelegate();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _organizeWorker.RunWorkerAsync();
        }
    }
}

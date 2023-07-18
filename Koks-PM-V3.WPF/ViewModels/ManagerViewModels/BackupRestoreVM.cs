using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Koks_PM_V3.WPF.ViewModels.ManagerViewModels
{
    public class BackupRestoreVM : BindableBase
    {
        private readonly DataStore _dataStore;

        public BackupRestoreVM(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public ICommand BackupCommand => new RelayCommand(parameter =>
        {
            string backupFileName = "backup" + (DateTime.Now).ToString("dd/mm/yyyy") + ".json";

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                string selectedFolder = folderBrowserDialog.SelectedPath;
                string fullPath = Path.Combine(selectedFolder, backupFileName);

                BackupRestoreService backupRestoreService = new(_dataStore);
                backupRestoreService.CreateBackup(fullPath);
            }

        });

        public ICommand RestoreCommand => new RelayCommand(parameter =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup data |*.json";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;
                BackupRestoreService backupRestoreService = new(_dataStore);
                backupRestoreService.RestoreBackup(fullPath);
            }

        });
    }
}

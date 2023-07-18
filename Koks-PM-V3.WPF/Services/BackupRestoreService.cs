using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Koks_PM_V3.WPF.Services
{
    public class BackupRestoreService 
    {
        private readonly DataStore _dataStore;

        public BackupRestoreService(DataStore dataStore) {
            _dataStore = dataStore;
        }

        public void CreateBackup(string filePath)
        {
            List<IRecord> records = _dataStore.Notes.Cast<IRecord>()
                                                    .Concat(_dataStore.BankCards
                                                    .Cast<IRecord>())
                                                    .ToList();

            string json = JsonConvert.SerializeObject(records, Formatting.Indented);
            File.WriteAllText(filePath, json);

            MessageBox.Show("Резервная копия успешно создана");
        }

        public void RestoreBackup(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Note> restoredNotes = JsonConvert.DeserializeObject<List<Note>>(json);
            List<BankCard> restoredBankCards = JsonConvert.DeserializeObject<List<BankCard>>(json);

            List<IRecord> restoredRecords = restoredNotes.Cast<IRecord>()
                                                         .Concat(restoredBankCards
                                                         .Cast<IRecord>())
                                                         .ToList();

            List<IRecord> records = _dataStore.Notes.Cast<IRecord>()
                                                    .Concat(_dataStore.BankCards
                                                    .Cast<IRecord>())
                                                    .ToList();

            List<IRecord> newRecords = restoredRecords.Where(record => !records.Any(currentRecord => currentRecord.ID == record.ID)).ToList();

            newRecords.ForEach(record =>
            {
                if (record is Note) {
                    Note note = record as Note;
                    note.userID = _dataStore.UserAccount.userID;
                    note.noteID = Guid.NewGuid();
                    note.categoryID = new Guid("22222222-2222-2222-2222-222222222222");
                    _dataStore?.AddNote(note);
                }
                else if (record is BankCard) {
                    BankCard bankCard = record as BankCard;
                    bankCard.userID = _dataStore.UserAccount.userID;
                    bankCard.cardID = Guid.NewGuid();
                    bankCard.categoryID = new Guid("22222222-2222-2222-2222-222222222222");
                    _dataStore?.AddBankCard(bankCard);
                }
            });

            MessageBox.Show("Данные успешно восстановлены из резервной копии");
        }
    }
}

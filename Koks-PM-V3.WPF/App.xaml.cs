using Koks_PM_V3.Domain.Commands.CreateCommands;
using Koks_PM_V3.Domain.Commands.DeleteCommands;
using Koks_PM_V3.Domain.Commands.UpdateCommands;
using Koks_PM_V3.Domain.Querires;
using Koks_PM_V3.EntityFramework;
using Koks_PM_V3.EntityFramework.Commands.CreateCommands;
using Koks_PM_V3.EntityFramework.Commands.DeleteCommands;
using Koks_PM_V3.EntityFramework.Commands.UpdateCommands;
using Koks_PM_V3.EntityFramework.Queries;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.MainViewModels;
using Koks_PM_V3.WPF.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Koks_PM_V3.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MainPageNavigator _pageNavigator;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public App()
        {
            _pageNavigator = new MainPageNavigator();
            _storageDbContextFactory = new StorageDbContextFactory(DbOptionsBuilder.getDbOptions());
            ICreateNote createNote = new CreateNote(_storageDbContextFactory);
            ICreateBankCard createBankCard = new CreateBankCard(_storageDbContextFactory);
            ICreateCategory createCategory = new CreateCategory(_storageDbContextFactory);
            ICreateUser createUser = new CreateUser(_storageDbContextFactory);
            IDeleteNote deleteNote = new DeleteNote(_storageDbContextFactory);
            IDeleteBankCard deleteBankCard = new DeleteBankCard(_storageDbContextFactory);
            IDeleteCategory deleteCategory = new DeleteCategory(_storageDbContextFactory);
            IDeleteUser deleteUser = new DeleteUser(_storageDbContextFactory);
            IUpdateNote updateNote = new UpdateNote(_storageDbContextFactory);
            IUpdateBankCard updateBankCard = new UpdateBankCard(_storageDbContextFactory);
            IUpdateCategory updateCategory = new UpdateCategory(_storageDbContextFactory);
            IUpdateUser updateUser = new UpdateUser(_storageDbContextFactory);
            IGetAllNotes getAllNotes = new GetAllNotesQuery(_storageDbContextFactory);
            IGetAllBankCards getAllBankCards = new GetAllBankCardQuery(_storageDbContextFactory);
            IGetAllCategories getAllCategories = new GetAllCategoriesQuery(_storageDbContextFactory);

            _dataStoreFactory = new DataStoreFactory(createNote, deleteNote,
                updateNote, createBankCard, deleteBankCard,
                updateBankCard, createCategory, deleteCategory,
                updateCategory, createUser, deleteUser,
                updateUser, getAllNotes, getAllBankCards, getAllCategories);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                using (StorageDbContext context = _storageDbContextFactory.Create())
                {
                    context.Users.Load();
                    context.Notes.Load();
                    context.BankCards.Load();
                    context.CategoryDtos.Load();
                }

                MainVM _mainVM = new MainVM(_pageNavigator, _dataStoreFactory, _storageDbContextFactory);
                MainWindow _MainWindow = new MainWindow() { DataContext = _mainVM };
                _MainWindow.Show();

                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

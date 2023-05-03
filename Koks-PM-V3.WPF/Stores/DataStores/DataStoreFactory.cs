using Koks_PM_V3.Domain.Commands.CreateCommands;
using Koks_PM_V3.Domain.Commands.DeleteCommands;
using Koks_PM_V3.Domain.Commands.UpdateCommands;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.Domain.Querires;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Stores.DataStores
{
    public class DataStoreFactory
    {
        private readonly ICreateNote _createNoteCommand;
        private readonly IDeleteNote _deleteNoteCommand;
        private readonly IUpdateNote _updateNoteCommand;
        private readonly ICreateBankCard _createBankCardCommand;
        private readonly IDeleteBankCard _deleteBankCardCommand;
        private readonly IUpdateBankCard _updateBankCardCommand;
        private readonly ICreateCategory _createCategoryCommand;
        private readonly IDeleteCategory _deleteCategoryCommand;
        private readonly IUpdateCategory _updateCategoryCommand;
        private readonly ICreateUser _createUserCommand;
        private readonly IDeleteUser _deleteUserCommand;
        private readonly IUpdateUser _updateUserCommand;
        private readonly IGetAllNotes _getAllNotesQuerry;
        private readonly IGetAllBankCards _getAllBankCardsQuerry;
        private readonly IGetAllCategories _getAllCategoriesQuerry;

        public DataStoreFactory(ICreateNote createNoteCommand, IDeleteNote deleteNoteCommand, 
            IUpdateNote updateNoteCommand, ICreateBankCard createBankCardCommand, 
            IDeleteBankCard deleteBankCardCommand, IUpdateBankCard updateBankCardCommand, 
            ICreateCategory createCategoryCommand, IDeleteCategory deleteCategoryCommand, 
            IUpdateCategory updateCategoryCommand, ICreateUser createUserCommand, 
            IDeleteUser deleteUserCommand, IUpdateUser updateUserCommand, 
            IGetAllNotes getAllNotesQuerry, IGetAllBankCards getAllBankCardsQuerry, 
            IGetAllCategories getAllCategoriesQuerry)
        {
            _createNoteCommand = createNoteCommand;
            _deleteNoteCommand = deleteNoteCommand;
            _updateNoteCommand = updateNoteCommand;
            _createBankCardCommand = createBankCardCommand;
            _deleteBankCardCommand = deleteBankCardCommand;
            _updateBankCardCommand = updateBankCardCommand;
            _createCategoryCommand = createCategoryCommand;
            _deleteCategoryCommand = deleteCategoryCommand;
            _updateCategoryCommand = updateCategoryCommand;
            _createUserCommand = createUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _updateUserCommand = updateUserCommand;
            _getAllNotesQuerry = getAllNotesQuerry;
            _getAllBankCardsQuerry = getAllBankCardsQuerry;
            _getAllCategoriesQuerry = getAllCategoriesQuerry;
        }

        public DataStore Create(UserDto userDto)
        {
            DataStore dataStore = new DataStore(_createNoteCommand, _deleteNoteCommand,
                _updateNoteCommand, _createBankCardCommand, _deleteBankCardCommand,
                _updateBankCardCommand, _createCategoryCommand, _deleteCategoryCommand,
                _updateCategoryCommand, _createUserCommand, _deleteUserCommand,
                _updateUserCommand, _getAllNotesQuerry, _getAllBankCardsQuerry,
                _getAllCategoriesQuerry, userDto);

            return dataStore;
        }
    }
}

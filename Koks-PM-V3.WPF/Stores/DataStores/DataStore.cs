using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koks_PM_V3.Domain.Commands.CreateCommands;
using Koks_PM_V3.Domain.Commands.DeleteCommands;
using Koks_PM_V3.Domain.Commands.UpdateCommands;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.Domain.Querires;
using Koks_PM_V3.EntityFramework.Commands.UpdateCommands;
using Koks_PM_V3.EntityFramework.DTOs;
using Koks_PM_V3.EntityFramework.Queries;

namespace Koks_PM_V3.WPF.Stores.DataStores
{
    public class DataStore
    {
        #region Commands/Queries Interfaces
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

        #endregion

        #region Account & Lists
        private User _userAccount { get; set; }
        public User UserAccount => _userAccount;
        private List<Note> _notes { get; set; }
        public List<Note> Notes => _notes;
        private List<BankCard> _bankCards { get; set; }
        public List<BankCard> BankCards => _bankCards;
        private List<Category> _categories { get; set; }
        public List<Category> Categories => _categories;
        #endregion

        #region Events
        public delegate void updateNote(int noteID);
        public delegate void updateBankCard(int bankCardID);
        public event updateNote? noteUpdateAdd;
        public event updateBankCard? bankCardUpdateAdd;
        public event Action categoryUpdateAddDelete;
        public event Action noteDelete;
        public event Action bbnkCardDelete;
        public event Action userUpdate;
        #endregion
        public DataStore(ICreateNote createNoteCommand, IDeleteNote deleteNoteCommand, IUpdateNote updateNoteCommand, 
            ICreateBankCard createBankCardCommand, IDeleteBankCard deleteBankCardCommand, IUpdateBankCard updateBankCardCommand, 
            ICreateCategory createCategoryCommand, IDeleteCategory deleteCategoryCommand, IUpdateCategory updateCategoryCommand, 
            ICreateUser createUserCommand, IDeleteUser deleteUserCommand, IUpdateUser updateUserCommand, 
            IGetAllNotes getAllNotesQuerry, IGetAllBankCards getAllBankCardsQuerry, IGetAllCategories getAllCategoriesQuerry, 
            UserDto userDto)
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

            LoadAll(userDto);
        }

        private async void LoadAll(UserDto userDto)
        {
            List<Note> notes = await _getAllNotesQuerry.Execute(userDto.UserDtoID);
            _notes = notes;
            List<BankCard> bankcards = await _getAllBankCardsQuerry.Execute(userDto.UserDtoID);
            _bankCards = bankcards;
            List<Category> categories = await _getAllCategoriesQuerry.Execute(userDto.UserDtoID);
            _categories = categories;

            User user = new User(userDto.UserDtoID, userDto.userName, userDto.userLogin, userDto.userPassword, userDto.userTotpKey, userDto.userTelegramBotApi, userDto.userTelegramChatID, userDto.userAvatar,
                userDto.modifyDate, userDto.createDate, notes, bankcards, categories);

            _userAccount = user;
        }

        #region Add commands
        public async Task AddNote(Note note)
        {

        }

        public async Task AddBankCard(BankCard bankCard)
        {

        }

        public async Task AddCategory(Category category)
        {

        }
        #endregion

        #region Update commands
        public async Task UpdateNote(Note note)
        {

        }

        public async Task UpdateBankCard(BankCard bankCard)
        {

        }

        public async Task UpdateCategory(Category category)
        {

        }

        public async Task UpdateUser(User user)
        {

        }
        #endregion

        #region Delete commands
        public async Task DeleteNote(Guid noteID)
        {

        }

        public async Task DeleteBankCard(Guid bankCardID)
        {

        }

        public async Task DeleteCategory(Guid categoryID)
        {

        }

        public async Task DeleteUser(Guid userID)
        {
            
        }
        #endregion

        //ReEncrypt
    }
}

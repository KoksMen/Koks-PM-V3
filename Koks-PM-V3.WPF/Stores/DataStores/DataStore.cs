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
using static Koks_PM_V3.WPF.Services.SymmetricEncryptorModule;

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
        public delegate void updateNote(Guid noteID);
        public delegate void updateBankCard(Guid bankCardID);
        public event updateNote? noteUpdateAdd;
        public event updateBankCard? bankCardUpdateAdd;
        public event Action categoryUpdateAddDelete;
        public event Action noteDelete;
        public event Action bankCardDelete;
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
            notes.ForEach(note => DecryptNote(note, userDto.userPassword));
            _notes = notes;

            List<BankCard> bankcards = await _getAllBankCardsQuerry.Execute(userDto.UserDtoID);
            bankcards.ForEach(bankcard => DecryptBankCard(bankcard, userDto.userPassword));
            _bankCards = bankcards;

            List<Category> categories = await _getAllCategoriesQuerry.Execute(userDto.UserDtoID);
            categories.ForEach(category => DecryptCategory(category, userDto.userPassword));
            _categories = categories;

            User user = new User(userDto.UserDtoID, userDto.userName, userDto.userLogin, userDto.userPassword, userDto.userTotpKey, userDto.userTelegramBotApi, userDto.userTelegramChatID, userDto.userAvatar,
                userDto.modifyDate, userDto.createDate, notes, bankcards, categories);

            _userAccount = user;
        }

        #region Add commands
        public async Task AddNote(Note note)
        {
            await _createNoteCommand.Execute(EncryptNote(note, _userAccount.userPassword));

            _notes.Add(note);

            noteUpdateAdd?.Invoke(note.noteID);
        }

        public async Task AddBankCard(BankCard bankCard)
        {
            await _createBankCardCommand.Execute(EncryptBankCard(bankCard, _userAccount.userPassword));

            _bankCards.Add(bankCard);

            bankCardUpdateAdd?.Invoke(bankCard.cardID);
        }

        public async Task AddCategory(Category category)
        {
            await _createCategoryCommand.Execute(EncryptCategory(category, _userAccount.userPassword));

            _categories.Add(category);

            categoryUpdateAddDelete?.Invoke();
        }
        #endregion

        #region Update commands
        public async Task UpdateNote(Note note)
        {
            await _updateNoteCommand.Execute(EncryptNote(note, _userAccount.userPassword));

            int currentIndex = _notes.FindIndex(n => n.noteID == note.noteID);

            if (currentIndex != -1)
            {
                _notes[currentIndex] = note;
            }
            else
            {
                _notes.Add(note);
            }

            noteUpdateAdd?.Invoke(note.noteID);
        }

        public async Task UpdateBankCard(BankCard bankCard)
        {
            await _updateBankCardCommand.Execute(EncryptBankCard(bankCard, _userAccount.userPassword));

            int currentIndex = _bankCards.FindIndex(c => c.cardID == bankCard.cardID);

            if (currentIndex != -1)
            {
                _bankCards[currentIndex] = bankCard;
            }
            else
            {
                _bankCards.Add(bankCard);
            }

            bankCardUpdateAdd?.Invoke(bankCard.cardID);
        }

        public async Task UpdateCategory(Category category)
        {
            await _updateCategoryCommand.Execute(EncryptCategory(category, _userAccount.userPassword));

            int currentIndex = _categories.FindIndex(c => c.categoryID == category.categoryID);

            if (currentIndex != -1)
            {
                _categories[currentIndex] = category;
            }
            else
            {
                _categories.Add(category);
            }

            categoryUpdateAddDelete?.Invoke();
        }

        public async Task UpdateUser(User user)
        {

        }
        #endregion

        #region Delete commands
        public async Task DeleteNote(Guid noteID)
        {
            await _deleteNoteCommand.Execute(noteID);

            _notes.RemoveAll(n => n.noteID == noteID);

            noteDelete?.Invoke();
        }

        public async Task DeleteBankCard(Guid bankCardID)
        {
            await _deleteBankCardCommand.Execute(bankCardID);

            _bankCards.RemoveAll(c => c.cardID == bankCardID);

            bankCardDelete?.Invoke();
        }

        public async Task DeleteCategory(Guid categoryID)
        {
            await _deleteCategoryCommand.Execute(categoryID);

            _categories.RemoveAll(c => c.categoryID == categoryID);

            categoryUpdateAddDelete.Invoke();
        }

        public async Task DeleteUser(Guid userID)
        {
            
        }
        #endregion


        private async Task ReEncryptAll(string newPassword)
        {
            _userAccount.userPassword = newPassword;

            _notes.ForEach(async note => await UpdateNote(note));
            _bankCards.ForEach(async bankcard => await UpdateBankCard(bankcard));
            _categories.ForEach(async category => await UpdateCategory(category));
        }
        
        //UpdateUser
        //Deleteuser
    }
}

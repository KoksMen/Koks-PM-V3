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
using Koks_PM_V3.EntityFramework.DTOs;

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


    }
}

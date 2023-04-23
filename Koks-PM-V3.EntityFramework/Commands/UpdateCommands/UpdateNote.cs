using Koks_PM_V3.Domain.Commands.UpdateCommands;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.UpdateCommands
{
    public class UpdateNote : IUpdateNote
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public UpdateNote(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(Note note)
        {
            using (StorageDbContext context =  _storageDbContextFactory.Create())
            {
                NoteDto noteDto = new NoteDto()
                {
                    NoteDtoID = note.noteID,
                    noteName = note.noteName,
                    noteLogin = note.noteLogin,
                    notePassword = note.notePassword,
                    noteUrl = note.noteUrl,
                    noteTotp = note.noteTotp,
                    categoryID = note.categoryID,
                    userID = note.userID,
                    modifyDate = note.modifyDate,
                    createDate = note.createDate,
                };

                context.Notes.Update(noteDto);
                await context.SaveChangesAsync();
            }
        }
    }
}

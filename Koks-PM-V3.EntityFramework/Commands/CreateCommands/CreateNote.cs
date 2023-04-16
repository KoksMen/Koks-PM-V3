using Koks_PM_V3.Domain.Commands.CreateCommands;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.CreateCommands
{
    public class CreateNote : ICreateNote
    {
        private readonly StorageDbContextFactory _storageContextFactory;

        public CreateNote(StorageDbContextFactory storageContextFactory)
        {
            _storageContextFactory = storageContextFactory;
        }

        public async Task Execute(Note note)
        {
            using (StorageDbContext context = _storageContextFactory.Create())
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
                    modifyDate = note.modifyDate,
                    createDate = note.createDate,
                    userID = note.userID,
                };

                context.Notes.Add(noteDto);
                await context.SaveChangesAsync();
            }
        }
    }
}

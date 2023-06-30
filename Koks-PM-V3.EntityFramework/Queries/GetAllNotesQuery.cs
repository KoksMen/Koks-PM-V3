using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.Domain.Querires;
using Koks_PM_V3.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Queries
{
    public class GetAllNotesQuery : IGetAllNotes
    {
        private readonly StorageDbContextFactory _storageContextFactory;

        public GetAllNotesQuery(StorageDbContextFactory storageContextFactory)
        {
            _storageContextFactory = storageContextFactory;
        }

        public async Task<List<Note>> Execute(Guid userID)
        {
            using (StorageDbContext context = _storageContextFactory.Create())
            {
                List<NoteDto> notesDtos = await context.Notes.Where(c => c.userID == userID).ToListAsync();

                List<Note> notes = notesDtos.Select(x => new Note(
                    x.NoteDtoID,
                    x.noteName,
                    x.noteLogin,
                    x.notePassword,
                    x.noteUrl,
                    x.noteTotp,
                    x.categoryID,
                    x.userID,
                    x.modifyDate,
                    x.createDate
                    )).ToList();

                return notes;
            }
        }
    }
}

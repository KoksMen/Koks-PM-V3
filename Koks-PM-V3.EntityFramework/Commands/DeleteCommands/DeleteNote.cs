using Koks_PM_V3.Domain.Commands.DeleteCommands;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.DeleteCommands
{
    public class DeleteNote : IDeleteNote
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public DeleteNote(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(Guid noteID)
        {
            using (StorageDbContext context = _storageDbContextFactory.Create())
            {
                NoteDto noteDto = new NoteDto()
                {
                    NoteDtoID = noteID,
                };

                context.Notes.Remove(noteDto);
                context.SaveChangesAsync();
            }
        }
    }
}

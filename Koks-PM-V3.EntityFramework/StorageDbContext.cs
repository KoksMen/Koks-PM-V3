using Koks_PM_V3.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework
{
    public class StorageDbContext : DbContext
    {
        public StorageDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserDto> Users { get; set; }
        public DbSet<NoteDto> Notes { get; set; }
        public DbSet<BankCardDto> BankCards { get; set; }
        public DbSet<CategoryDto> CategoryDtos { get; set; }
    }
}

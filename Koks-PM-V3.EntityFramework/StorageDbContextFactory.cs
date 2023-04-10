using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework
{
    public class StorageDbContextFactory
    {
        private readonly DbContextOptions _options;

        public StorageDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public StorageDbContext Create() => new StorageDbContext(_options);
    }
}

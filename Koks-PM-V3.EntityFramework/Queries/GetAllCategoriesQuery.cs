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
    public class GetAllCategoriesQuery : IGetAllCategories
    {
        private readonly StorageDbContextFactory _storageContextFactory;

        public GetAllCategoriesQuery(StorageDbContextFactory storageContextFactory)
        {
            _storageContextFactory = storageContextFactory;
        }

        public async Task<List<Category>> Execute(Guid userID)
        {
            using (StorageDbContext context = _storageContextFactory.Create())
            {
                List<CategoryDto> categoryDtos = await context.CategoryDtos.ToListAsync();

                List<Category> categories = categoryDtos.Select(x => new Category(
                    x.CategoryDtoID,
                    x.categoryName,
                    x.userID,
                    x.modifyDate,
                    x.createDate
                    )).ToList();

                return categories;
            }
        }
    }
}

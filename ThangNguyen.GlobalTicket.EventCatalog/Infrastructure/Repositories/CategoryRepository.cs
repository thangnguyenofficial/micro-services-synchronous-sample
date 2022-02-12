using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;

namespace ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public CategoryRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _eventCatalogDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(Guid categoryId)
        {
            return await _eventCatalogDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThangNguyen.GlobalTicket.EventCatalog.Entities;

namespace ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetCategory(Guid categoryId);
    }
}

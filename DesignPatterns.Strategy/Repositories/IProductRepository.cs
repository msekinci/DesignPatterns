using DesignPatterns.Strategy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(string id);
        Task<List<Product>> GetAllByUserIdAsync(string userId);
        Task<Product> SaveAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}

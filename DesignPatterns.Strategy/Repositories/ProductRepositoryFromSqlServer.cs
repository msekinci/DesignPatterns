using DesignPatterns.Strategy.Models;
using DesignPatterns.Strategy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy.Repositories
{
    public class ProductRepositoryFromSqlServer : IProductRepository
    {
        private readonly AppIdentityDbContext _context;

        public ProductRepositoryFromSqlServer(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllByUserIdAsync(string userId)
        {
            return await _context.Product.Where(x => x.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<Product> SaveAsync(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

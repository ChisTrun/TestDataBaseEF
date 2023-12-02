using GroceryStore.Domain.Models;
using GroceryStore.EntityFramework.EntityFramework;
using GroceryStoreManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.EntityFramework.Services
{
    public class CustomerDataService: IDataService<Customer>
    {
        private string _connectionString = string.Empty;

        public CustomerDataService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public async Task<Customer> Create(Customer entity)
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString))
            {
                var result = await context.Set<Customer>().AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString))
            {
                Customer? removeEntity = context.Set<Customer>().FirstOrDefault((e) => e.Id == id);
                context.Set<Customer>().Remove(removeEntity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(int id1, int id2)
        {
            throw new NotImplementedException("!");
        }
                
        public async Task<Customer> Get(int id)
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString))
            {
                Customer? result = context.Set<Customer>().Include(c => c.Coupons).FirstOrDefault(e => e.Id == id);
                return result;
            }
        }

        public async Task<Customer> Get(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString))
            {
                IEnumerable<Customer> entities = await context.Set<Customer>().ToListAsync();
                return entities;
            }
        }

        public async Task<Customer> Update(int id, Customer entity)
        {
            entity.Id = id;
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString))
            {
                context.Set<Customer>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<Customer> Update(int id1, int id2, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

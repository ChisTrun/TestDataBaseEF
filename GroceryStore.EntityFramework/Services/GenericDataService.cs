using GroceryStore.Domain;
using GroceryStore.EntityFramework.EntityFramework;
using GroceryStoreManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
            
        private string _connectionString = string.Empty;

        public GenericDataService(string connectionString)
        {
            this._connectionString = connectionString;
        }   

        public async Task<T> Create(T entity)
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString)) { 
                var result = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString)) {
                T? removeEntity = context.Set<T>().FirstOrDefault((e) => e.Id == id);
                context.Set<T>().Remove(removeEntity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString)) { 
                T? result =  context.Set<T>().FirstOrDefault(e => e.Id == id);
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString)) {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString)) { 
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<T>> TestQueryAsync()
        {
            using (GroceryStoreManagerDBContext context = new GroceryStoreManagerDBContext(_connectionString))
            {
                var result = await context.Set<T>().FromSqlRaw($"SELECT * FROM [{typeof(T).Name}]").ToListAsync();
                return result;
            }
        }
    }
}

using GroceryStore.Domain;
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
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly DBContextFactory? _dbContexFactory;

        public GenericDataService(DBContextFactory? dbContexFactory)
        {
            _dbContexFactory = dbContexFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (GroceryStoreManagerDBContext context = _dbContexFactory.CreateDbContext()) { 
                var result = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (GroceryStoreManagerDBContext context = _dbContexFactory.CreateDbContext()) {
                T removeEntity = context.Set<T>().FirstOrDefault((e) => e.Id == id);
                context.Set<T>().Remove(removeEntity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (GroceryStoreManagerDBContext context = _dbContexFactory.CreateDbContext()) { 
                T result =  context.Set<T>().FirstOrDefault(e => e.Id == id);
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (GroceryStoreManagerDBContext context = _dbContexFactory.CreateDbContext()) {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;
            using (GroceryStoreManagerDBContext context = _dbContexFactory.CreateDbContext()) { 
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}

using GroceryStore.EntityFramework.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.EntityFramework
{
    public class DBContextFactory : IDesignTimeDbContextFactory<GroceryStoreManagerDBContext>
    {
        public GroceryStoreManagerDBContext CreateDbContext(string[] args = null)
        {
            var option = new  DbContextOptionsBuilder<GroceryStoreManagerDBContext>();
            option.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=store;Trusted_Connection=True;");
            return new GroceryStoreManagerDBContext(option.Options);
        }

    }
}

using GroceryStore.Domain.Models;
using GroceryStore.EntityFramework.Services;

namespace Test_DataContext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericDataService<ProductType> dataService = new GenericDataService<ProductType>("Server=(localdb)\\mssqllocaldb;Database=store;Trusted_Connection=True;");
            //GenericDataService<ProductType> dataService = new GenericDataService<ProductType>(new GroceryStore.EntityFramework.DBContextFactory() );
            //ProductType productType = new ProductType()
            //{
            //    Name = "Con cac",
            //    Image = "image link"
            //};
            //dataService.Create(productType).Wait();
            //"Server=(localdb)\\mssqllocaldb;Database=store;Trusted_Connection=True;"
            //int productTypes = dataService.GetAll().Result.Count();
            //Console.WriteLine(productTypes);
            //IEnumerable<ProductType> result = dataService.TestQueryAsync().Result;
            //foreach (ProductType item in result)
            //{
            //    Console.WriteLine(item.Name);
            //}
        }
    }
}
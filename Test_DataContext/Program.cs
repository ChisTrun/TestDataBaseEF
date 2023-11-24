using GroceryStore.Domain.Models;
using GroceryStore.EntityFramework.Services;

namespace Test_DataContext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericDataService<ProductType> dataService = new GenericDataService<ProductType>(new GroceryStore.EntityFramework.DBContextFactory() );
            ProductType productType = new ProductType()
            {
                Name = "Gia dung",
                Image = "image link"
            };
            //dataService.Create(productType).Wait();
            //int productTypes = dataService.GetAll().Result.Count();
            //Console.WriteLine(productTypes);
            dataService.Delete(1).Wait();

        }
    }
}
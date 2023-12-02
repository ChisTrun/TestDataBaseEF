using GroceryStore.Domain.Models;
using GroceryStore.EntityFramework.Services;
using GroceryStoreManager.Domain.Services;
using Microsoft.Data.SqlClient;

namespace Test_DataContext
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost\\SQLEXPRESS";
            builder.InitialCatalog = "testDataWindow";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;
            string connectionString = builder.ConnectionString;
            IDataService<Customer> dataService = new CustomerDataService(connectionString);

            var person = dataService.Get(1).Result;
            Console.WriteLine(person.Coupons[0].perCoupon);


            //GenericDataService<ProductType> dataService = new GenericDataService<ProductType>("Server=(localdb)\\mssqllocaldb;Database=store;Trusted_Connection=True;");
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
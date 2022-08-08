using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
//using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data Transformatiton Object
            ProductTest();
            //IoC
            //CategoryTest();
            
        }

        private static void NewMethod()
        {

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            ProductManager productManager = new ProductManager(new EfProductDal());


            var x = productManager.GetProductDetails();


            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();
            if(result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.ProductName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            } 

            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName+ "/"+ product.ProductName);
            }
        }
    }
}

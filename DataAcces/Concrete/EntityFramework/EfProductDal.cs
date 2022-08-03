using Core.DataAccess.EntityFramework;
//using DataAcces.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    //Nuget
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        //        public void Add(Product entity)
        //    {
        //        //IDispossable pattern implementation of c#
        //        using (NorthwindContext context = new NorthwindContext()) //  using içinde yazılan nesneler  using bitinve bellekten at diyor 
        //        {
        //            // eklenen varlık
        //            var addedEntity = context.Entry(entity); //git benim gönderdiğim producta veri kaynağından nesneyle eşleştir
        //            addedEntity.State = EntityState.Added;
        //            context.SaveChanges();
        //        }

        //    }





        //    public void Delete(Product entity)
        //    {
        //        using (NorthwindContext context = new NorthwindContext()) //  using içinde yazılan nesneler  using bitinve bellekten at diyor 
        //        {
        //            // eklenen varlık
        //            var deletedEntity = context.Entry(entity); //git benim gönderdiğim producta veri kaynağından nesneyle eşleştir
        //            deletedEntity.State = EntityState.Deleted;
        //            context.SaveChanges();
        //        }


        //    }

        //    public Product Get(Expression<Func<Product, bool>> filter)
        //    {
        //        using (NorthwindContext context = new NorthwindContext())
        //        {
        //            return context.Set<Product>().SingleOrDefault(filter);


        //        }


        //    }

        //    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        //    {
        //        using (NorthwindContext context = new NorthwindContext())
        //        {
        //            return filter == null
        //                ? context.Set<Product>().ToList()
        //                : context.Set<Product>().Where(filter).ToList();
        //        }
        //    }

        //    public void Test()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Update(Product entity)
        //    {
        //        using (NorthwindContext context = new NorthwindContext()) //  using içinde yazılan nesneler  using bitinve bellekten at diyor 
        //        {
        //            // eklenen varlık
        //            var updatedEntity = context.Entry(entity); //git benim gönderdiğim producta veri kaynağından nesneyle eşleştir
        //            updatedEntity.State = EntityState.Modified;
        //            context.SaveChanges();
        //        }

        //    }
        //}
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //var result = context.Products.Select(p => new ProductDetailDto()
                //{
                //    ProductId = p.ProductID,
                //    ProductName = p.ProductName,
                //    CategoryName = p.Category.CategoryName,
                //    UnitsInStock = p.UnitsInStock
                //});


                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();

            }
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   
    public class InMemoryProductDal:IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductID=1,CategoryID=1,ProductName="Bardak",UnitPrice=15, UnitsInStock=15},
                new Product{ProductID=2,CategoryID=1,ProductName="Kamera",UnitPrice=1000, UnitsInStock=10},
                new Product{ProductID=3,CategoryID=2,ProductName="Klavye",UnitPrice=150, UnitsInStock=14},
                new Product{ProductID=4,CategoryID=1,ProductName="Fare",UnitPrice=100, UnitsInStock=12},
                new Product{ProductID=5,CategoryID=2,ProductName="Telefon",UnitPrice=15000, UnitsInStock=3}

            };
        }
       

        public void Add(Product product)
        {
            _products.Add(product);
        }


        public void Delete(Product product)
        {
            
            //LINQ İLE YAZIM
            //Lambda
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID==product.ProductID);


            _products.Remove(productToDelete);

             /*foreach (var p in _products)
            {
                if(product.ProductID== p.ProductID)
                {
                    producToDelete = p;
                }

            }
            */
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine shaip olan ürün id sini bul demek
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;


        }

        public List<Product> GetAllByCategory(int CategoryID)
        {
            return _products.Where(p => p.CategoryID == CategoryID).ToList();

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
  
    }


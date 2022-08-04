using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
//using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
       
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //iş kodları

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult("Ürün ismi min 2 karakter olmalıdır");

            }

            _productDal.Add(product);

            return new SuccessResult("ürün eklendi"); //neden new yaptık?
        }

        public List<Product> GetAll()
        {
            //iş kodları
            return _productDal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id, int v)
        {
            return _productDal.GetAll(p=>p.CategoryID==id);
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();

        }
    }
}

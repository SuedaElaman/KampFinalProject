using Business.Abstract;
using Business.Constants;
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
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);

            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded); 
        }

        public IDataResult <List<Product>> GetAll()
        {
            //iş kodları

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID==id));
        }

        //public List<Product> GetAllByCategoryId(int id)
        //{
        //    return _productDal.GetAll()
        //}

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());

        }

        //IDataResult<List<Product>> IProductService.GetAllByCategoryId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //IDataResult<Product> IProductService.GetById(int productId)
        //{
        //    throw new NotImplementedException();
        //}

        //IDataResult<List<Product>> IProductService.GetByUnitPrice(decimal min, decimal max)
        //{
        //    throw new NotImplementedException();
        //}

        //IDataResult<List<ProductDetailDto>> IProductService.GetProductDetails()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

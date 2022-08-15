using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
//using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   
    public class ProductManager : IProductService   
       //ProductManager IProductDal a bağımlı - interfaceler referans tutucudur.
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes
            //validation


            


            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded); 
        }

        public IDataResult <List<Product>> GetAll()
        {
            //iş kodları

            if (DateTime.Now.Hour == 1)
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

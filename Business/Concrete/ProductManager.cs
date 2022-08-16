﻿using Business.Abstract;
using Business.CCS;
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
         //ILogger _logger;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
           
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result = _productDal.GetAll(p =>p.CategoryID == product.CategoryID).Count;
            if(result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            //business codes
            if(CheckIfProductCountOfCategoryCorrect(product.CategoryID).Success);
            {

                _productDal.Add(product);

                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();

  
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p =>p.CategoryID == product.CategoryID).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();

        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p=>p.CategoryID == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
            

        }

    }
}

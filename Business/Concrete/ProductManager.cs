using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Serilog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [LogAspect]
        [ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("product.add,admin")]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        public IResult AddWithImage(Product product, List<ProductImageModel> images)
        {
            _productDal.AddWithImage(product, images);
            return new SuccessResult(Messages.ProductAdded);
        }
        [LogAspect]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new SuccessResult(Messages.ProductDeleted);
        }
        [LogAspect]
        public IResult Update(Product product)
        {
            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();

            return new SuccessDataResult<List<Product>>
                (result, Messages.AllProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);

            return new SuccessDataResult<List<Product>>
                (result,Messages.AllProductsListedWithCategory);
        }

        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(p => p.Id == id);

            return new SuccessDataResult<Product>
                (result,Messages.ProductListedWithProductId);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var result = _productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max);

            return new SuccessDataResult<List<Product>>
                (result, Messages.ProductsListedWithUnitPrice);
        }

        public IDataResult<ProductDetailDto> GetProductDetail(int productId)
        {
            var result = _productDal.GetProductDetail(productId);

            return new SuccessDataResult<ProductDetailDto>
                (result,Messages.ProductDetailCameWithId);
               
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetails()
        {
            var result = _productDal.ProductsList();
            return new SuccessDataResult<List<ProductDetailDto>>
                (result,Messages.AllProductsListedWithDetails);
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetailsforShowCase()
        {
            var result = _productDal.GetProductsForShowCase();
            return new SuccessDataResult<List<ProductDetailDto>>
                 (result, Messages.AllProductsListedWithDetails);
        }

       
    }
}

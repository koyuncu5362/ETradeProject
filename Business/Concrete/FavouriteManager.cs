﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FavouriteManager : IFavouriteService
    {
        IFavouriteDal _favouriteDal;
        public FavouriteManager(IFavouriteDal favrouriteDal)
        {
            _favouriteDal = favrouriteDal;
        }

        [ValidationAspect(typeof(FavouriteValidator))]
        public IResult Add(Favourite favourite)
        {
            _favouriteDal.Add(favourite);
            return new SuccessResult();
        }

        public IResult Delete(Favourite favourite)
        {
            _favouriteDal.Delete(favourite);
            return new SuccessResult(Messages.FavouriteProductDeleted);
        }

        public IResult DeleteByCustomerIdAndProductId(int productId, string customerId)
        {
            _favouriteDal.DeleteByCustomerIdAndProductId(productId, customerId);
            return new SuccessResult();
        }

        public IDataResult<List<FavouritesDetailDto>> GetAllFavourite(string customerId)
        {
            var result =  _favouriteDal.GetFavourites(customerId);
            Console.WriteLine(customerId);
            return new SuccessDataResult<List<FavouritesDetailDto>>(result);
        }

        public IDataResult<Favourite> GetById(int productId, string customerId)
        {
            var result = _favouriteDal.GetByProductIdAndCustomerId(productId, customerId);
            return new SuccessDataResult<Favourite>(result);
        }
    }
}

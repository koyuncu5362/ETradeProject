using Business.Abstract;
using Business.Constants;
using Core.Aspects.Serilog.Logger;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal=categoryDal;
        }
        [LogAspect]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }
        [LogAspect]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result  = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>
                (result, Messages.CategoriesListed
                );
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(c => c.Id == id);
            return new SuccessDataResult<Category>
                (result, Messages.CategoryListedWithCategoryId
                );
        }

        public IDataResult<List<CategoryDetailDto>> GetDetails()
        {
            var result =_categoryDal.GetCategoryDetails();
            return new SuccessDataResult<List<CategoryDetailDto>>(result,Messages.AllCategoriesListedWithAllDetails);
        }

        [LogAspect]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}

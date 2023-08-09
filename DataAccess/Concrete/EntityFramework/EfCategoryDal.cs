using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ETradeDbContext>, ICategoryDal
    {
        public List<CategoryDetailDto> GetCategoryDetails()
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var result = from category in context.Categories
                            join  supportCategory in context.SupportCategories
                            on category.Id equals supportCategory.CategoryId
                            join subCategory in context.SubCategories
                            on supportCategory.Id equals subCategory.SupportCategoryId
                            select new CategoryDetailDto
                             {
                               CatId = category.Id,
                               CatTitle = supportCategory.Name,
                              SubCats = subCategory.Name,
                               Cats = category.CategoryName
                            };

                return result.ToList();

            }
        }
    }
}

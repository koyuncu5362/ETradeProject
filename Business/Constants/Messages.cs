using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string ProductAdded = "Product Added";
        public static string ProductDeleted = "Product Deleted";
        public static string AllProductsListed = "Products Listed";
        public static string AllProductsListedWithCategory = "AllProductsListedWithCategory";
        public static string ProductListedWithProductId = "ProductListedWithProductId";
        public static string ProductsListedWithUnitPrice = "ProductsListedWithUnitPrice";
        public static string AllProductsListedWithDetails = "AllProductsListedWithDetails";
        public static string ProductUpdated = "ProductUpdated";
        public static string ProductDetailCameWithId = "ProductDetailCameWithId";
        public static string CategoryAdded = "CategoryAdded";
        public static string CategoryDeleted = "CategoryDeleted";
        public static string CategoriesListed = "CategoriesListed";
        public static string CategoryListedWithCategoryId = "CategoryListedWithCategoryId";
        public static string CategoryUpdated = "CategoryUpdated";
        public static string UserRegistered = "UserRegistered";
        public static string UserNotFound = "UserNotFound";
        public static string PasswordError = "PasswordError";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string AccessTokenCreated = "AccessTokenCreated";
        public static string AuthorizationDenied = "AuthorizationDenied";
        public static string ProductNameCantEmpty = "ProductNameCantEmpty";
        public static string ProductNameHaveToMin2Character = "ProductNameHaveToMin2Character";
        public static string UnitPriceCantEmpty = "UnitPriceCantEmpty";
        public static string UnitPriceHaveToGreaterThanZero = "UnitPriceHaveToGreaterThanZero";
        public static string CategoryCantEmpty = "CategoryCantEmpty";
        public static string AllCategoriesListedWithAllDetails = "AllCategoriesListedWithAllDetails";
        public static string AllImageListed = "AllImageListed";
        public static string AllProductsListedWithImages = "AllProductsListedWithImages";
        public static string FavouriteProductDeleted = "FavouriteProductDeleted";
        public static string CustomerIdCantEmpty = "CustomerIdCantEmpty";
        public static string ProductIdCantEmpty = "ProductIdCantEmpty";
        public static string HaveToChooseSize = "HaveToChooseSize";
    }
}

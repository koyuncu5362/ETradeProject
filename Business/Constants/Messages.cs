using Core.Entities.Concrete;
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
        public static string AllProductsListedWithCategory = "Product Added";
        public static string ProductListedWithProductId { get; internal set; }
        public static string ProductsListedWithUnitPrice { get; internal set; }
        public static string AllProductsListedWithDetails { get; internal set; }
        public static string ProductUpdated { get; internal set; }
        public static string ProductDetailCameWithId { get; internal set; }
        public static string CategoryAdded { get; internal set; }
        public static string CategoryDeleted { get; internal set; }
        public static string CategoriesListed { get; internal set; }
        public static string CategoryListedWithCategoryId { get; internal set; }
        public static string CategoryUpdated { get; internal set; }
        public static string UserRegistered { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }

        public static string AuthorizationDenied = "YourRoleCantDoIt";

        public static string ProductNameCantEmpty = "ProductNameCantEmpty";
        public static string ProductNameHaveToMin2Character = "ProductNameHaveToMin2Character";
        public static string UnitPriceCantEmpty = "UnitPriceCantEmpty";
        public static string UnitPriceHaveToGreaterThanZero = "UnitPriceHaveToGreaterThanZero";
        public static string CategoryCantEmpty = "CategoryCantEmpty";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhuocCon.Model.Models;
using PhuocCon.Web.Models;

namespace PhuocCon.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
       // mapping data from entity to DB
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;
            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;
            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;
            postCategory.UpdateDate = postCategoryViewModel.UpdateDate;
            postCategory.UpdateBy = postCategoryViewModel.UpdateBy;
            postCategory.Metakeyword = postCategoryViewModel.Metakeyword;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.Status = postCategoryViewModel.Status;
        }
        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;
            post.CategoryID = postViewModel.CategoryID;
            post.Image = postViewModel.Image;
            post.Description = postViewModel.Description;
            post.Content = postViewModel.Content;
            post.HomeFlag = postViewModel.HomeFlag;
            post.ViewCount = postViewModel.ViewCount;
            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdateDate = postViewModel.UpdateDate;
            post.UpdateBy = postViewModel.UpdateBy;
            post.Metakeyword = postViewModel.Metakeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }
        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategory.ID = productCategoryViewModel.ID;
            productCategory.Name = productCategoryViewModel.Name;
            productCategory.Alias = productCategoryViewModel.Alias;
            productCategory.Image = productCategoryViewModel.Image;
            productCategory.Description = productCategoryViewModel.Description;
            productCategory.ParentID = productCategoryViewModel.ParentID;
            productCategory.HomeFlag = productCategoryViewModel.HomeFlag;
            productCategory.CreatedDate = productCategoryViewModel.CreatedDate;
            productCategory.CreatedBy = productCategoryViewModel.CreatedBy;
            productCategory.UpdateDate = productCategoryViewModel.UpdateDate;
            productCategory.UpdateBy = productCategoryViewModel.UpdateBy;
            productCategory.Metakeyword = productCategoryViewModel.Metakeyword;
            productCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategory.Status = productCategoryViewModel.Status;
        }
        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.ID = productViewModel.ID;
            product.Name = productViewModel.Name;
            product.Alias = productViewModel.Alias;
            product.Image = productViewModel.Image;
            product.ProviderID = productViewModel.ProviderID;
            product.CategoryID = productViewModel.CategoryID;
            product.MoreImages = productViewModel.MoreImages;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.Description = productViewModel.Description;
            product.Content = productViewModel.Content;
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.ViewCount = productViewModel.ViewCount;
            product.Tags = productViewModel.Tags;
            product.Quantity = productViewModel.Quantity;
            product.OriginalPrice = productViewModel.OriginalPrice;
            product.CreatedDate = productViewModel.CreatedDate;
            product.CreatedBy = productViewModel.CreatedBy;
            product.UpdateDate = productViewModel.UpdateDate;
            product.UpdateBy = productViewModel.UpdateBy;
            product.Metakeyword = productViewModel.Metakeyword;
            product.MetaDescription = productViewModel.MetaDescription;
            product.Status = productViewModel.Status;
        }
        public static void UpdatePage(this Page page, PageViewModel pageViewModel)
        {
            page.ID = pageViewModel.ID;
            page.Name = pageViewModel.Name;
            page.Alias = pageViewModel.Alias;
            page.Content = pageViewModel.Content;
            page.CreatedDate = pageViewModel.CreatedDate;
            page.CreatedBy = pageViewModel.CreatedBy;
            page.UpdateDate = pageViewModel.UpdateDate;
            page.UpdateBy = pageViewModel.UpdateBy;
            page.Metakeyword = pageViewModel.Metakeyword;
            page.MetaDescription = pageViewModel.MetaDescription;
            page.Status = pageViewModel.Status;
        }
        public static void UpdateContactDetail(this ContactDetail contactDetail, ContactDetailViewModel contactDetailViewModel)
        {
            //contactDetail.ID = contactDetailViewModel.ID;
            contactDetail.Name = contactDetailViewModel.Name;
            contactDetail.Phone = contactDetailViewModel.Phone;
            contactDetail.Address = contactDetailViewModel.Address;
            contactDetail.Website = contactDetailViewModel.Website;
            contactDetail.Email = contactDetailViewModel.Email;
            contactDetail.Other = contactDetailViewModel.Other;
            contactDetail.Lat = contactDetailViewModel.Lat;
            contactDetail.Lng = contactDetailViewModel.Lng;
            contactDetail.Status = contactDetailViewModel.Status;

        }
        public static void UpdateFeedback(this Feedback feedback, FeedbackViewModel feedbackViewModel)
        {
            //feedback.ID = feedbackViewModel.ID;
            feedback.Name = feedbackViewModel.Name;
            feedback.Email = feedbackViewModel.Email;
            feedback.Message = feedbackViewModel.Message;
            feedback.Status = feedbackViewModel.Status;
            feedback.CreatedDate = feedbackViewModel.CreatedDate;
        }
        public static void UpdateOrder(this Order order, OrderViewModel orderViewModel)
        {
            order.ID = orderViewModel.ID;
            order.CustomerName = orderViewModel.CustomerName;
            order.CustomerMobile = orderViewModel.CustomerMobile;
            order.CustomerMessage = orderViewModel.CustomerMessage;
            order.CustomerID = orderViewModel.CustomerID;
            order.CustomerEmail = orderViewModel.CustomerEmail;
            order.CustomerAdress = orderViewModel.CustomerAdress;
            order.CreatedDate = DateTime.Now;
            order.CreatedBy = orderViewModel.CreatedBy;
            order.PaymentMethod = orderViewModel.PaymentMethod;
            order.Status = orderViewModel.Status;
        }
        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }
        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
            {
                appRole.Id = appRoleViewModel.Id;
            }
            else
            {
                appRole.Id = Guid.NewGuid().ToString();
            }
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {
            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDate;
            appUser.Adress = appUserViewModel.Adress;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        }
        public static void UpdateCountry(this Country country,CountryViewModel countryViewModel)
        {
            country.ID = countryViewModel.ID;
            country.Name = countryViewModel.Name;
            country.Slug = countryViewModel.Slug;
            country.Capital = countryViewModel.Capital;
            country.Sovereignty = countryViewModel.Sovereignty;
            country.CurrencyName = countryViewModel.CurrencyName;
            country.FormalName = countryViewModel.FormalName;
            country.CountryType = countryViewModel.CountryType;
            country.CountrySubType = countryViewModel.CountrySubType;
            country.CountryNumber = countryViewModel.CountryNumber;
            country.TelephoneCode = countryViewModel.TelephoneCode;
            country.InternetCountryCode = countryViewModel.InternetCountryCode;
            country.SortOrder = countryViewModel.SortOrder;
            country.Status = countryViewModel.Status;
            country.Flags = countryViewModel.Flags;
            country.IsDelete = countryViewModel.IsDelete;
        }
        public static void UpdateProvince(this Province province, ProvinceViewModel provinceViewModel)
        {
            province.ID = provinceViewModel.ID;
            province.Name = provinceViewModel.Name;
            province.TelePhoneCode = provinceViewModel.TelePhoneCode;
            province.CountryID = provinceViewModel.CountryID;
            province.CountryCode = provinceViewModel.CountryCode;
            province.SortOrder = provinceViewModel.SortOrder;
            province.Status = provinceViewModel.Status;
            province.IsDelete = provinceViewModel.IsDelete;
        }
        public static void UpdateDistrict(this District district, DistrictViewModel districtViewModel)
        {
            district.ID = districtViewModel.ID;
            district.Name = districtViewModel.Name;
            district.Type = districtViewModel.Type;
            district.ProvinceID = districtViewModel.ProvinceID;
            district.SortOrder = districtViewModel.SortOrder;
            district.Status = districtViewModel.Status;
            district.IsDelete = districtViewModel.IsDelete;
        }
        public static void UpdateWard(this Ward ward, WardViewModel wardViewModel)
        {
            ward.ID = wardViewModel.ID;
            ward.Name = wardViewModel.Name;
            ward.Type = wardViewModel.Type;
            ward.DistrictID = wardViewModel.DistrictID;
            ward.SortOrder = wardViewModel.SortOrder;
            ward.Status = wardViewModel.Status;
            ward.IsDelete = wardViewModel.IsDelete;
        }
        public static void UpdateProvider(this Provider provider, ProviderViewModel providerViewModel)
        {
            provider.ID = providerViewModel.ID;
            provider.Image = providerViewModel.Image;
            provider.Name = providerViewModel.Name;
            provider.Status = providerViewModel.Status;
        }
        public static void UpdateFooter(this Footer footer, FooterViewModel footerViewModel)
        {
            footer.ID = footerViewModel.ID;
            footer.Content = footer.Content;
        }
    }
}
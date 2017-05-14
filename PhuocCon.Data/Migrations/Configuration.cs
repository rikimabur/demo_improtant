namespace PhuocCon.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PhuocCon.Common;
    internal sealed class Configuration : DbMigrationsConfiguration<PhuocCon.Data.PhuocConDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PhuocCon.Data.PhuocConDbContext context)
        {
            //CreateUser(context);
            //CreateProductCategorySample(context);
            //CreateSlide(context);
            //CreatePage(context);
            //CreateContactDetail(context);
            //CreateTitle(context);
            //CreateCountry(context);
            //CreateCountryDetail(context);
            //CreateCountry(context);
            //CreateProvince(context);
            CreateDistrict(context);
        }
        private void CreateTitle(PhuocConDbContext context)
        {
            if (!context.SystemConfigs.Any(x => x.Code == "HomeTitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang chủ PhuocConShop",

                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang chủ PhuocConShop",

                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang chủ PhuocConShop",

                });
            }
        }
        private void CreateUser(PhuocConDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new PhuocConDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new PhuocConDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "phuoccon",
                Email = "phuoccon@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Phuoc"

            };

            manager.Create(user, "khongbiet");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("phuoccon@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(PhuocConDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="LapTop",Alias="lap-top",Status=true},
                    new ProductCategory() { Name="Điện Thoại",Alias="dien-thoai",Status=true},
                    new ProductCategory() { Name="Phụ Kiện",Alias="phu-kien",Status=true},
                    new ProductCategory() { Name="Máy Tính Bảng",Alias="may-tinh-bang",Status=true},
                    new ProductCategory() { Name="Tin Tức",Alias="tin-tuc",Status=true},
                    new ProductCategory() { Name="Khuyến Mãi",Alias="khuyen-mai",Status=true},
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
        private void CreateFooter(PhuocConDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "";
            }
        }
        private void CreateSlide(PhuocConDbContext context)
        {
            if (context.Slides.Count() == 0)
            { 
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide()
                    {
                        Name ="Slide 1",
                        DisplayOrder = 1,
                        Status = true,
                        URL ="#",
                        Image = "/Assets/Client/images/bag.jpg",
                        Content =@"<h2>FLAT 50% 0FF</h2>
                                    <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                    <p>Lorem ipsum dolor sit amet, consectetur
                                    adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                                    < span class=""on-get"">GET NOW</span>"
                    },
                    new Slide()
                    {
                        Name ="Slide 2",
                        DisplayOrder = 2,
                        Status = true,
                        URL ="#",
                        Image = "/Assets/Client/images/bag1.jpg",
                        Content =@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                                <span class=""on-get"">GET NOW</span>"
                    },
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
        private void CreatePage(PhuocConDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                var page = new Page()
                {
                    Name = "Gioi Thieu",
                    Alias = "gioi-thieu",
                    Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                                Duis tincidunt, libero quis rhoncus aliquam, velit enim viverra leo, 
                                vitae tristique nibh tellus sed metus. Vestibulum in ullamcorper risus,
                                in pharetra risus. Quisque pulvinar vulputate posuere.
                                Nullam vulputate hendrerit sapien a mollis. Sed urna lorem, faucibus id diam id, volutpat pretium risus.
                                Praesent nisi ante, ultrices vitae erat a, consequat hendrerit lorem.",
                    Status = true
                };
                context.Pages.Add(page);
                context.SaveChanges();
            }
        }
        private void CreateContactDetail(PhuocConDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                var contactDetail = new PhuocCon.Model.Models.ContactDetail()
                {
                    Name = "Shop Thoi Trang Phuoc Con",
                    Address = "Ho Chi Minh ",
                    Email = "PhuocCon@gamil.com",
                    Lat = 21.0633645,
                    Lng = 105.8053274,
                    Phone = "0927384672",
                    Website = "PhuocCon.com.vn",
                    Other = "",
                    Status = true
                };
                context.ContactDetails.Add(contactDetail);
                context.SaveChanges();
            }
        }
        public void CreateCountry(PhuocConDbContext context)
        {
            if(context.Countrys.Count() == 0)
            {
                Country country = new Country()
                {
                    Name = "Việt Name"
                };
                context.Countrys.Add(country);
                context.SaveChanges();
            }
        }
        private void CreateProvince(PhuocConDbContext context)
        {
            List<Province> listProvince = new List<Province>()
                {
                    new Province() { Name = "Hồ Chí Minh", CountryID = 1 },
                    new Province() { Name = "Hà Nội", CountryID = 1 },
                    new Province() { Name = "Đà Nẳng" , CountryID = 1 },
                };

                context.Provinces.AddRange(listProvince);
                context.SaveChanges();
        }
        private void CreateDistrict(PhuocConDbContext context)
        {
                List<District> listDistrictHCM = new List<District>()
                {
                   new District() { ProvinceID=1,Name ="Quận 1",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 2",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 3",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 4",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 5",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 6",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 7",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 8",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 9",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 10",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 11",Status = true},
                   new District() { ProvinceID=1,Name ="Quận 12",Status = true},
                   new District() { ProvinceID=1,Name ="Quận Bình Tân",Status = true},
                   new District() { ProvinceID=1,Name ="Quận Thủ Đức",Status = true},
                   new District() { ProvinceID=1,Name ="Quận Gò Vấp",Status = true},
                   new District() { ProvinceID=1,Name ="Quận Bình Thạnh",Status = true},
                   new District() { ProvinceID=1,Name ="Quận Tân Phú",Status = true},
                   new District() { ProvinceID=1,Name ="Quận Phú Nhuận",Status = true},
                   new District() { ProvinceID=1,Name ="Huyện Củ Chi",Status = true},
                   new District() { ProvinceID=1,Name ="Huyện Hóc Môn",Status = true},
                   new District() { ProvinceID=1,Name ="Huyện Bình Chánh",Status = true},
                   new District() { ProvinceID=1,Name ="Huyện Nhà Bè",Status = true},
                   new District() { ProvinceID=1,Name ="Huyện Cần Giờ",Status = true},
                };
                context.Districts.AddRange(listDistrictHCM);
                List<District> listDistrictHN = new List<District>()
                {
                   new District() { ProvinceID=2,Name ="Quận 1",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 2",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 3",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 4",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 5",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 6",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 7",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 8",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 9",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 10",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 11",Status = true},
                   new District() { ProvinceID=2,Name ="Quận 12",Status = true},
                };
            context.Districts.AddRange(listDistrictHN);
            context.SaveChanges();
        }
        public void CreateStoreSlide(PhuocConDbContext context)
        {
            //CreateStoredProcedure("AddSlide",
            //    {


            //})
        }

    }
}

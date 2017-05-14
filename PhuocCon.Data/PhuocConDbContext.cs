using System.Data.Entity;
using PhuocCon.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PhuocCon.Data
{
    public class PhuocConDbContext : IdentityDbContext<ApplicationUser>
    {
        public PhuocConDbContext() : base ("PhuocConShopConnection")
        {
            //Load bảng cha không load thêm bảng con
            this.Configuration.LazyLoadingEnabled = false;
        }
        // khai báo all bảng có trong data
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<VisistorStatistic> VisistorStatistics { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<ContactDetail> ContactDetails { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }

        public DbSet<Country> Countrys { set; get; }
        public DbSet<Province> Provinces { set; get; }
        public DbSet<District> Districts { set; get; }
        public DbSet<Ward> Wards { set; get; }
        public DbSet<Provider> Providers { set; get; }
        //return tables
        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }
        //public DbSet<ApplicationUser> ApplicationUser{ set; get; }
        public static PhuocConDbContext Create()
        {
            return new PhuocConDbContext();
        }
        //Ghi đè phương thức DBcontext chay khi khoi tao enityframeword
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationClaims");
        }
    }
}

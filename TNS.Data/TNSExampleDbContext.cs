using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Model.Models;

namespace TNS.Data
{
    public class TNSExampleDbContext : IdentityDbContext<ApplicationUser>
    {
        public TNSExampleDbContext() : base ("TNSExampleConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
      
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TrackOrder> TrackOrders { get; set; }

        public static TNSExampleDbContext Create()
        {
            return new TNSExampleDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(i => i.UserId).ToTable("ApplicationUserLogins");

            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .HasKey(i => i.UserId).ToTable("ApplicationUserClaims");

        }
    }
}

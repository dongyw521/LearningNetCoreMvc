using Learning.NetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learning.NetCore.EntityFrameworkCore
{
    public class kuchenDbContext : DbContext
    {
        public kuchenDbContext(DbContextOptions<kuchenDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<RoleMenu>().HasKey(rm => new { rm.MenuId, rm.RoleId });
            builder.Entity<RoleMenu>()
            .HasOne(rm => rm.Role).WithMany(r => r.Menus)
            .HasForeignKey(rm => rm.RoleId).IsRequired();

            builder.Entity<RoleMenu>()
            .HasOne(rm => rm.Menu).WithMany(r=>r.Roles)
            .HasForeignKey(rm => rm.MenuId).IsRequired();
            //.HasForeignKey(rm => rm.MenuId);

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            base.OnModelCreating(builder);

        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Learning.NetCore.Domain.Entities;

namespace Learning.NetCore.EntityFrameworkCore
{
    public class kuchenDbContext : DbContext
    {
        public kuchenDbContext(DbContextOptions<kuchenDbContext> options) : base(options)
        {

        }

        DbSet<User> Users { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Menu> Menus { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<RoleMenu> RoleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RoleMenu>().HasKey(rm => new { rm.MenuId, rm.RoleId });
            builder.Entity<RoleMenu>()
            .HasOne(rm => rm.Role).WithMany(r => r.Menus)
            .HasForeignKey(rm => rm.RoleId)
            .HasForeignKey(rm => rm.MenuId);

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            base.OnModelCreating(builder);

        }
    }
}
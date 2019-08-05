using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Learning.NetCore.Domain.Entities;
using System.Linq;

namespace Learning.NetCore.EntityFrameworkCore
{
    public static class SeedData
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                //var context = new kuchenDbContext(serviceProvider.GetRequiredService<DbContextOptions<kuchenDbContext>>());
                var context = scope.ServiceProvider.GetService<kuchenDbContext>();
                if (context.Users.Any())
                {
                    return;
                }
                int _departmentId = 1;
                context.Departments.Add(new Department()
                {
                    Id = _departmentId,
                    Name = "酷晨总部",
                    Code = "000",
                    Manager = "admin",
                    ContactNumber = "12345678901",
                    Remarks = "总部",
                    ParentId = 0,
                    CreateUserId = 1,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                });

                context.Users.Add(new User
                {
                    UserName = "admin",
                    Name = "超级管理员",
                    Password = "123456",
                    DepartmentId = _departmentId,
                    IsDeleted = 0
                });

                context.Menus.AddRange(new Menu
                {
                    ParentId = 0,
                    SerialNumber = 0,
                    Name = "组织机构管理",
                    Code = "department",
                    Icon = "fa fa-link",
                    Type = 0
                }, new Menu
                {
                    ParentId = 0,
                    SerialNumber = 1,
                    Name = "角色管理",
                    Code = "role",
                    Icon = "fa fa-link",
                    Type = 0
                }, new Menu
                {
                    ParentId = 0,
                    SerialNumber = 2,
                    Name = "用户管理",
                    Code = "user",
                    Icon = "fa fa-link",
                    Type = 0
                }, new Menu
                {
                    ParentId = 0,
                    SerialNumber = 3,
                    Name = "功能管理",
                    Code = "menu",
                    Icon = "fa fa-link",
                    Type = 0
                });

                context.SaveChanges();
            }
        }
    }
}
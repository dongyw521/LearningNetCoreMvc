using System;
using Learning.NetCore.Domain.Entities;
using Learning.NetCore.Domain.IRepositories;

namespace Learning.NetCore.EntityFrameworkCore.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(kuchenDbContext dbContext) : base(dbContext)
        {

        }

        public User CheckUser(string uname, string pwd)
        {
            return FirstOrDefault(usr => usr.UserName == uname && usr.Password == pwd);
        }
    }
}
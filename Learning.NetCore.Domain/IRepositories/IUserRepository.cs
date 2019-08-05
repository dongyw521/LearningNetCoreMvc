using System;
using Learning.NetCore.Domain.Entities;

namespace Learning.NetCore.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User CheckUser(string uname, string pwd);
    }
}
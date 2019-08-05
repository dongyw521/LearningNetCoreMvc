using System;
using Learning.NetCore.Domain.Entities;

namespace Learning.NetCore.Application.ApplicationServices
{
    public interface IUserApplicationService
    {
        User CheckUser(string uname,string pwd);
    }
}
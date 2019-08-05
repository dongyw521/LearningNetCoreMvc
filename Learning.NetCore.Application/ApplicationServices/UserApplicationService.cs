using System;
using Learning.NetCore.Domain.Entities;
using Learning.NetCore.Domain.IRepositories;

namespace Learning.NetCore.Application.ApplicationServices
{
    public class UserApplicationService : IUserApplicationService
    {
        IUserRepository _userRepository;

        public UserApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CheckUser(string uname, string pwd)
        {
            return _userRepository.CheckUser(uname, pwd);
        }
    }
}
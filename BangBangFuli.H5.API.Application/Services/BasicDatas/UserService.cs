using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserInfo UserLogin(string username, string password)
        {
            return _userRepository.UserLogin(username,password);
        }
    }
}

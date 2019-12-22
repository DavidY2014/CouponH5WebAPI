using System;
using System.Collections.Generic;
using System.Text;
using BangBangFuli.H5.API.Core.Entities;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IUserService:IAppService
    {
        UserInfo UserLogin(string username, string password);
    }
}

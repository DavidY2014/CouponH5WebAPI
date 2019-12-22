using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BangBangFuli.Common;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class UserRepository: BaseRepository<CouponSystemDBContext, UserInfo>,IUserRepository
    {
        public UserRepository(CouponSystemDBContext dbContext) : base(dbContext)
        {

        }
        public UserInfo UserLogin(string username, string password)
        {
            try
            {
                password = ConvertPassword(password);
                UserInfo user = null;
                var list = Master.UserAccounts.Where(x => x.UserName == username && x.Password == password).ToList();
                if (list != null && list.Count > 0)
                {
                    int userid = list.FirstOrDefault().UserID;
                    user = GetByID(userid);
                }
                return user;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        string ConvertPassword(string password)
        {
            return password.MD5();
        }

        public UserInfo GetByID(int id)
        {
            try
            {
                var userinfo =  Master.UserInfos.Find(id);
                return userinfo;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}

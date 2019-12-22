using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class UserRoleJurisdictionRepository : BaseRepository<CouponSystemDBContext, UserRoleJurisdiction> , IUserRoleJurisdictionRepository
    {
        public UserRoleJurisdictionRepository(CouponSystemDBContext dbContext) : base(dbContext)
        {

        }

        public List<UserRoleJurisdiction> GetListAsync(int UserRoleID)
        {
            try
            {
                List<UserRoleJurisdiction> list = null;
                list = Master.UserRoleJurisdictions.Where(x => x.UserRoleID == UserRoleID).ToList();
                return list;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

    }
}

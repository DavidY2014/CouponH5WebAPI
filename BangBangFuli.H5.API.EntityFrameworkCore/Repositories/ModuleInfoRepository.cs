using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class ModuleInfoRepository: BaseRepository<CouponSystemDBContext, ModuleInfo>, IModuleInfoRepository
    {
        public ModuleInfoRepository(CouponSystemDBContext dbContext) : base(dbContext)
        {

        }

        public List<ModuleInfo> GetList()
        {
            try
            {
                List<ModuleInfo> list = null;
                list = Master.ModuleInfos.ToList();
                return list;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

    }
}

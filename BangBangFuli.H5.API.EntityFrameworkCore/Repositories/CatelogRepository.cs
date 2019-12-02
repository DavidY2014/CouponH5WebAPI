using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class CatelogRepository: BaseRepository<CouponSystemDBContext, Catelog>, ICatelogRepository
    {
        public CatelogRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }


        public Catelog GetCatelogInfoByClassId(int classId)
        {
            return Master.Catelogs.FirstOrDefault(item => item.ClassId == classId);
        }


        public List<Catelog> GetAll()
        {
            return Master.Catelogs.ToList();
        }

    }
}
